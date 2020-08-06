using Cyotek.Demo.Windows.Forms;
using System;
using System.ComponentModel;
using System.Media;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  internal partial class NumericInputDialog : BaseForm
  {
    #region Constructors

    public NumericInputDialog()
    {
      this.InitializeComponent();
    }

    #endregion

    #region Static Methods

    public static decimal ShowInputDialog(string promptText)
    {
      return ShowInputDialog(promptText, string.Empty, 0);
    }

    public static decimal ShowInputDialog(IWin32Window owner, string promptText)
    {
      return ShowInputDialog(owner, promptText, string.Empty);
    }

    public static decimal ShowInputDialog(string promptText, string caption, decimal defaultValue)
    {
      return ShowInputDialog(null, promptText, caption, defaultValue);
    }

    public static decimal ShowInputDialog(string promptText, string caption)
    {
      return ShowInputDialog(promptText, caption, 0);
    }

    public static decimal ShowInputDialog(string promptText, string caption, Func<decimal, bool> validationCallback)
    {
      return ShowInputDialog(null, promptText, caption, 0, validationCallback);
    }

    public static decimal ShowInputDialog(IWin32Window owner, string promptText, string caption)
    {
      return ShowInputDialog(owner, promptText, caption, 0);
    }

    public static decimal ShowInputDialog(IWin32Window owner, string promptText, string caption, decimal defaultValue)
    {
      return ShowInputDialog(owner, promptText, caption, defaultValue, null);
    }

    public static decimal ShowInputDialog(IWin32Window owner, string promptText, string caption, decimal defaultValue, Func<decimal, bool> validationCallback)
    {
      return ShowInputDialog(owner, promptText, caption, defaultValue, 0, 100, validationCallback);
    }
    public static decimal ShowInputDialog(IWin32Window owner, string promptText, string caption, decimal defaultValue, decimal minimum, decimal maximum, Func<decimal, bool> validationCallback)
    {
      using (NumericInputDialog dialog = new NumericInputDialog
      {
        Text = caption,
        PromptText = promptText,
        Value = defaultValue,
        Minimum = minimum,
        Maximum = maximum,
        ValidationCallback = validationCallback
      })
      {
        return dialog.ShowDialog(owner) == DialogResult.OK ? dialog.Value : defaultValue;
      }
    }

    #endregion

    #region Properties


    private string _promptText;

    [DefaultValue(null)]
    public string PromptText
    {
      get { return _promptText; }
      set { _promptText = value; }
    }

    private string _footerText;

    [DefaultValue(null)]
    public string FooterText
    {
      get { return _footerText; }
      set { _footerText = value; }
    }


    public Func<decimal, bool> ValidationCallback { get; set; }

    private decimal _value;

    [DefaultValue(0)]
    public decimal Value
    {
      get { return _value; }
      set { _value = value; }
    }

    private decimal _minimum;

    [DefaultValue(0)]
    public decimal Minimum
    {
      get { return _minimum; }
      set { _minimum = value; }
    }

    private decimal _maximum;

    [DefaultValue(100)]
    public decimal Maximum
    {
      get { return _maximum; }
      set { _maximum = value; }
    }


    #endregion

    #region Methods

    protected override void OnLoad(EventArgs e)
    {
      //int height;

      base.OnLoad(e);

      inputTextBox.Minimum = _minimum;
      inputTextBox.Maximum = _maximum;
      inputTextBox.Value = _value;

      promptLabel.Text = _promptText;

      if (!string.IsNullOrEmpty(_footerText))
      {
        footerLabel.Text = _footerText;
        footerLabel.Visible = true;
      }

      //if (!this.IsDesignTime() && TranslationProvider.LanguageFoldersPresent)
      //{
      //  okButton.TranslateText("Dialog.OkButton");
      //  cancelButton.TranslateText("Dialog.CancelButton");
      //}

      inputTextBox.Top = promptLabel.Bottom + (promptLabel.Margin.Bottom + inputTextBox.Margin.Top);
      footerLabel.Top = inputTextBox.Bottom + (inputTextBox.Margin.Bottom + footerLabel.Margin.Top);
      //height = footerLabel.Bottom + (promptLabel.Left * 2);

      //this.SetClientHeight(height);
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
      if (this.ValidationCallback != null && !this.ValidationCallback(inputTextBox.Value))
      {
        SystemSounds.Beep.Play();
        this.DialogResult = DialogResult.None;
      }
      else
      {
        _value = inputTextBox.Value;
        this.DialogResult = DialogResult.OK;
      }
    }

    #endregion
  }
}
