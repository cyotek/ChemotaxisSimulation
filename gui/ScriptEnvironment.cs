using Cyotek.ChemotaxisSimulation;
using Jint;
using Jint.Native;
using Jint.Parser;
using Jint.Parser.Ast;
using Jint.Runtime;
using Jint.Runtime.Interop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsProgram = Jint.Parser.Ast.Program;

namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal class ScriptEnvironment
  {

    #region Public Fields

    public const string MainFunctionName = "main";

    #endregion Public Fields

    #region Private Fields

    private Engine _engine;

    private StringBuilder _log;

    #endregion Private Fields

    #region Public Constructors

    public ScriptEnvironment()
    {
      _log = new StringBuilder();
    }

    #endregion Public Constructors

    #region Protected Properties

    [CLSCompliant(false)]
    protected Engine Engine
    {
      get
      {
        if (_engine == null)
        {
          _engine = new Engine(cfg => cfg.AllowClr(AppDomain.CurrentDomain.GetAssemblies()));

          this.InitializeEnvironment();
        }

        return _engine;
      }
      set { _engine = value; }
    }

    #endregion Protected Properties

    #region Public Methods

    public void AddVariable(string name, object value)
    {
      this.SetValue(name, value);
    }

    public void Execute(string input)
    {
      JsProgram program;
      bool hasMainFunction;
      bool hasMainCaller;

      program = new JavaScriptParser().Parse(input);

      hasMainFunction = program.FunctionDeclarations.Any(f => string.Equals(MainFunctionName, f.Id.Name, StringComparison.OrdinalIgnoreCase));
      hasMainCaller = program.Body.OfType<ExpressionStatement>().Any(e => e.Expression is CallExpression && ((CallExpression)e.Expression).Callee is Identifier && string.Equals(((Identifier)((CallExpression)e.Expression).Callee).Name, MainFunctionName, StringComparison.OrdinalIgnoreCase));

      this.Engine.Execute(program);

      if (hasMainFunction && !hasMainCaller)
      {
        this.Invoke(MainFunctionName);
      }
    }

    public string GetOutput()
    {
      return _log.ToString();
    }

    public void Invoke(string name)
    {
      this.Engine.Invoke(name);
    }

    public void Load(string script)
    {
      this.Engine.Execute(new JavaScriptParser().Parse(script));
    }
    public void WrappedExecute(string script)
    {
      try
      {
        JsValue completionValue;
        JsValue result;
        string output;

        _log.Clear();

        this.Execute(script);

        completionValue = this.Engine.GetCompletionValue();
        result = this.Engine.GetValue(completionValue);

        switch (result.Type)
        {
          case Types.String:
            output = result.AsString();
            break;

          case Types.Undefined:
            output = "undefined";
            break;

          case Types.Null:
            output = "null";
            break;

          case Types.Boolean:
            output = result.AsBoolean().ToString();
            break;

          case Types.Number:
            output = result.AsNumber().ToString();
            break;

          case Types.Object:
            output = result.ToObject().ToString();
            break;

          case Types.None:
          default:
            output = string.Empty;
            break;
        }

        this.WriteLine(output);
      }
      catch (Exception ex)
      {
        this.WriteLine(string.Format("{0}: {1}", ex.GetType().Name, ex.GetBaseException().Message));
      }
    }

    #endregion Public Methods

    #region Protected Methods

    protected void ClearScreen()
    {
      _log.Clear();
      //  IImmediateWindow host;

      //  host = this.GetImmediateWindow();

      //  if (host != null)
      //  {
      //    host.Clear();
      //  }
    }

    protected string GetValueString(object obj)
    {
      return (obj ?? "NULL").ToString();
    }

    protected virtual void InitializeEnvironment()
    {
      this.SetValue("print", new Action<object>(this.WriteLine));
      this.SetValue("log", new Action<object>(this.WriteLine));
      this.SetValue("alert", new Action<object>(this.ShowAlert));
      this.SetValue("confirm", new Func<object, bool>(this.ShowConfirm));
      this.SetValue("cls", new Action(this.ClearScreen));
      this.SetValue("size", TypeReference.CreateTypeReference(this.Engine, typeof(Size)));
      this.SetValue("point", TypeReference.CreateTypeReference(this.Engine, typeof(Point)));
      this.SetValue("rectangle", TypeReference.CreateTypeReference(this.Engine, typeof(Rectangle)));
      this.SetValue("strand", TypeReference.CreateTypeReference(this.Engine, typeof(Strand)));
      this.SetValue("chemoeffector", TypeReference.CreateTypeReference(this.Engine, typeof(Chemoeffector)));
    }
    protected void SetValue(string name, object value)
    {
      this.Engine.SetValue(name, value);
    }

    protected void SetValue(string name, Delegate value)
    {
      this.Engine.SetValue(name, value);
    }

    protected void ShowAlert(object obj)
    {
      string message;

      message = this.GetValueString(obj);

      MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.None);
    }

    protected bool ShowConfirm(object obj)
    {
      string message;

      message = this.GetValueString(obj);

      return MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    protected void WriteLine(object obj)
    {
      _log.AppendLine(this.GetValueString(obj));
      //IImmediateWindow host;
      //string message;

      //message = this.GetValueString(obj);
      //host = this.GetImmediateWindow();

      //if (host != null)
      //{
      //  host.WriteLine(message);
      //}
      //else
      //{
      //  MessageWindow.Show(message, "Script Messagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //}
    }

    #endregion Protected Methods

  }
}
