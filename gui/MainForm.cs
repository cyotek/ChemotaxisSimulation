using Cyotek.ChemotaxisSimulation;
using Cyotek.ChemotaxisSimulation.Renderer;
using Cyotek.ChemotaxisSimulation.Serialization;
using Cyotek.Demo.ChemotaxisSimulation;
using Cyotek.Demo.Windows.Forms;
using Cyotek.Windows.Forms;
using Jint;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace Cyotek.Demo
{
  internal partial class MainForm : BaseForm
  {
    #region Private Fields

    private bool _antiAlias;

    private GdiSimulationRenderer _environmentRenderer;

    private string _fileName;

    private Random _random;

    private Simulation _simulation;

    private int _updateIterations;

    #endregion Private Fields

    #region Public Constructors

    public MainForm()
    {
      this.InitializeComponent();
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override void OnShown(EventArgs e)
    {
      string[] args;

      _random = new Random();
      _antiAlias = true;

      _simulation = new Simulation
      {
        Size = new Size(256, 256)
      };

      _environmentRenderer = new GdiSimulationRenderer
      {
        Scale = 2
      };

      attractorCollisionModeComboBox.SelectedIndex = (int)(CollisionAction.ReduceSelf - 1);
      repellentCollisionModeComboBox.SelectedIndex = (int)(CollisionAction.DestroyOther - 1);

      this.SetUpdateSpeed(2);
      this.NewFile();

      base.OnShown(e);

      args = Environment.GetCommandLineArgs();

      if (args.Length == 2)
      {
        this.OpenFile(args[1]);
      }

      scriptTextBox.Text = File.ReadAllText(@"D:\Checkout\trunk\cyotek\source\demo\ChemotaxisSimulation\samples\allgoodthings.js");
    }

    #endregion Protected Methods

    #region Private Methods

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
    }

    private void ActualSizeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      scaleToolStripTrackBar.Value = 10;
    }

    private void AdvanceToolStripMenuItem_Click(object sender, EventArgs e)
    {
      decimal count;

      count = NumericInputDialog.ShowInputDialog(this, "Enter &iterations to advance:", "Advance", 1, 1, int.MaxValue, _ => true);

      if (count > 0)
      {
        _simulation.Run((int)count);

        this.UpdateStatusBar();

        renderPanel.Invalidate();
      }
    }

    private void AllowBinaryFissionCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _simulation.BinaryFission = allowBinaryFissionCheckBox.Checked;
    }

    private void AntiAliasToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _antiAlias = !_antiAlias;

      antiAliasToolStripMenuItem.Checked = _antiAlias;

      renderPanel.Invalidate();
    }

    private void AttritionCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _simulation.Attrition = attritionCheckBox.Checked;
    }

    private void BacteriaStrandsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowStrands = !_environmentRenderer.ShowStrands;

      bacteriaStrandsToolStripMenuItem.Checked = _environmentRenderer.ShowStrands;

      renderPanel.Invalidate();
    }

    private void BacteriaStrandTailsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowTails = !_environmentRenderer.ShowTails;

      bacteriaStrandTailsToolStripMenuItem.Checked = _environmentRenderer.ShowTails;

      renderPanel.Invalidate();
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void FillShapesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.OutlinesOnly = !_environmentRenderer.OutlinesOnly;

      fillShapesToolStripMenuItem.Checked = !_environmentRenderer.OutlinesOnly;

      renderPanel.Invalidate();
    }

    private void FoodSourceDetectionZonesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowFoodDetectionZone = !_environmentRenderer.ShowFoodDetectionZone;

      foodSourceDetectionZonesToolStripMenuItem.Checked = _environmentRenderer.ShowFoodDetectionZone;

      renderPanel.Invalidate();
    }

    private void FoodSourcesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowFoodSources = !_environmentRenderer.ShowFoodSources;

      foodSourcesToolStripMenuItem.Checked = _environmentRenderer.ShowFoodSources;

      renderPanel.Invalidate();
    }

    private void GoToToolStripMenuItem_Click(object sender, EventArgs e)
    {
      decimal count;

      count = NumericInputDialog.ShowInputDialog(this, "Enter &iteration:", "Go To", 1, 1, int.MaxValue, v => v > _simulation.Iteration);

      if (count > 0)
      {
        long iterations;

        iterations = (long)count - _simulation.Iteration;

        _simulation.Run(iterations);

        this.UpdateStatusBar();

        renderPanel.Invalidate();
      }
    }

    private void HighToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (sender is ToolStripMenuItem menuItem && menuItem.Tag is string value && int.TryParse(value, out int count))
      {
        this.SetUpdateSpeed(count);
      }
    }

    private void InitializeButton_Click(object sender, EventArgs e)
    {
      this.InitializeScenario();
    }

    private void InitializeScenario()
    {
      pauseToolStripButton.PerformClick();

      _simulation.EnvironmentSeed = (int)environmentSeedNumericUpDown.Value;
      _simulation.MovementSeed = (int)movementSeedNumericUpDown.Value;
      _simulation.MinimumAttractorStrength = (int)minimumAttractorSizeNumericUpDown.Value;
      _simulation.MaximumAttractorStrength = (int)maximumAttractorSizeNumericUpDown.Value;
      _simulation.MinimumRepellentStrength = (int)minimumRepellentSizeNumericUpDown.Value;
      _simulation.MaximumRepellentStrength = (int)maximumRepellentSizeNumericUpDown.Value;
      _simulation.AttractorCollisionAction = (CollisionAction)(attractorCollisionModeComboBox.SelectedIndex + 1);
      _simulation.RepellentCollisionAction = (CollisionAction)(repellentCollisionModeComboBox.SelectedIndex + 1);
      _simulation.RespawnAttractor = respawnAttractorsCheckBox.Checked;
      _simulation.BinaryFission = allowBinaryFissionCheckBox.Checked;
      _simulation.Size = new Size((int)widthNumericUpDown.Value, (int)heightNumericUpDown.Value);
      _simulation.Wrap = wrapCheckBox.Checked;
      _simulation.SolidStrands = solidStrandsCheckBox.Checked;
      _simulation.Attrition = attritionCheckBox.Checked;
      _simulation.MobileRepellents = mobileRepellentsCheckBox.Checked;
      _simulation.Reset();

      for (int i = 0; i < (int)strandsNumericUpDown.Value; i++)
      {
        _simulation.AddStrand();
      }

      for (int i = 0; i < (int)attractorsNumericUpDown.Value; i++)
      {
        _simulation.AddFoodSource();
      }

      for (int i = 0; i < (int)repellentsNumericUpDown.Value; i++)
      {
        _simulation.AddNoxiousSource();
      }

      this.UpdateSimulationControls();
      this.UpdateStatusBar();

      renderPanel.Invalidate();
    }

    private void LoadFields()
    {
      environmentSeedNumericUpDown.Value = _simulation.EnvironmentSeed;
      movementSeedNumericUpDown.Value = _simulation.MovementSeed;
      minimumAttractorSizeNumericUpDown.Value = _simulation.MinimumAttractorStrength;
      maximumAttractorSizeNumericUpDown.Value = _simulation.MaximumAttractorStrength;
      minimumRepellentSizeNumericUpDown.Value = _simulation.MinimumRepellentStrength;
      maximumRepellentSizeNumericUpDown.Value = _simulation.MaximumRepellentStrength;
      attractorCollisionModeComboBox.SelectedIndex = (int)_simulation.AttractorCollisionAction - 1;
      repellentCollisionModeComboBox.SelectedIndex = (int)_simulation.RepellentCollisionAction - 1;
      respawnAttractorsCheckBox.Checked = _simulation.RespawnAttractor;
      allowBinaryFissionCheckBox.Checked = _simulation.BinaryFission;
      widthNumericUpDown.Value = _simulation.Size.Width;
      heightNumericUpDown.Value = _simulation.Size.Height;
      wrapCheckBox.Checked = _simulation.Wrap;
      solidStrandsCheckBox.Checked = _simulation.SolidStrands;
      attritionCheckBox.Checked = _simulation.Attrition;
      mobileRepellentsCheckBox.Checked = _simulation.MobileRepellents;
    }

    private void MobileRepellentsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _simulation.MobileRepellents = mobileRepellentsCheckBox.Checked;
    }

    private void NewFile()
    {
      _simulation = new Simulation();

      _fileName = null;
      this.UpdateUi();
      this.InitializeScenario();
    }

    private void NewToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.NewFile();
    }

    private void NextMove(bool single)
    {
      int sum;

      sum = _simulation.FoodSources.Count + _simulation.NoxiousSources.Count + _simulation.Strands.Count;

      if (single)
      {
        _simulation.NextMove();
      }
      else
      {
        _simulation.Run(_updateIterations);
      }

      if ((_simulation.FoodSources.Count + _simulation.NoxiousSources.Count + _simulation.Strands.Count) != sum)
      {
        this.UpdateStatusBar();
      }
      else
      {
        this.UpdateIteration();
      }

      renderPanel.Invalidate();
    }

    private void NextMoveToolStripButton_Click(object sender, EventArgs e)
    {
      this.NextMove(true);
    }

    private void NoxiousSourceDetectionZonesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowNoxiousDetectionZone = !_environmentRenderer.ShowNoxiousDetectionZone;

      noxiousSourceDetectionZonesToolStripMenuItem.Checked = _environmentRenderer.ShowNoxiousDetectionZone;

      renderPanel.Invalidate();
    }

    private void NoxiousSourcesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowNoxiousSources = !_environmentRenderer.ShowNoxiousSources;

      noxiousSourcesToolStripMenuItem.Checked = _environmentRenderer.ShowNoxiousSources;

      renderPanel.Invalidate();
    }

    private void OpenFile()
    {
      string fileName;

      fileName = FileDialogHelper.GetOpenFileName("Open Simulation", Filters.Simulation, "sim");

      if (!string.IsNullOrEmpty(fileName))
      {
        this.OpenFile(fileName);
      }
    }

    private void OpenFile(string fileName)
    {
      try
      {
        _simulation = SimulationSerializer.LoadFrom(fileName);
        _fileName = fileName;

        this.UpdateUi();
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to open file. {0}", ex.GetBaseException().Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.OpenFile();
    }

    private void PauseToolStripButton_Click(object sender, EventArgs e)
    {
      timer.Stop();

      this.UpdateSimulationControls();
    }

    private void PlayToolStripButton_Click(object sender, EventArgs e)
    {
      timer.Start();

      this.UpdateSimulationControls();
    }

    private void RandomButton_Click(object sender, EventArgs e)
    {
      string name;
      NumericUpDown control;

      name = (string)((Control)sender).Tag;
      control = (NumericUpDown)setupTabPage.Controls[name];

      control.Value = _random.Next((int)control.Minimum, (int)control.Maximum + 1);

      this.InitializeScenario();
    }

    private void RenderPanel_Paint(object sender, PaintEventArgs e)
    {
      if (_antiAlias)
      {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      }

      _environmentRenderer.Draw(_simulation, e.Graphics);
    }

    private void RespawnAttractorsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _simulation.RespawnAttractor = respawnAttractorsCheckBox.Checked;
    }

    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SaveFileAs();
    }

    private void SaveFile()
    {
      if (string.IsNullOrEmpty(_fileName))
      {
        this.SaveFileAs();
      }
      else
      {
        this.SaveFile(_fileName);
      }
    }

    private void SaveFile(string fileName)
    {
      try
      {
        _simulation.Save(_fileName);
        _fileName = fileName;

        this.UpdateUi();
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("Failed to save file. {0}", ex.GetBaseException().Message), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void SaveFileAs()
    {
      string fileName;

      fileName = FileDialogHelper.GetSaveFileName("Save Simulation As", Filters.Simulation, "sim", _fileName);

      if (!string.IsNullOrEmpty(fileName))
      {
        this.SaveFile(fileName);
      }
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SaveFile();
    }

    private void ScaleToolStripTrackBar_ValueChanged(object sender, EventArgs e)
    {
      _environmentRenderer.Scale = scaleToolStripTrackBar.Value / 10F;

      renderPanel.Invalidate();
    }

    private void SetUpdateSpeed(int iterations)
    {
      _updateIterations = iterations;

      foreach (ToolStripItem item in refreshIntervalToolStripMenuItem.DropDownItems)
      {
        if (item is ToolStripMenuItem menuItem && item.Tag is string value && int.TryParse(value, out int count))
        {
          menuItem.Checked = iterations == count;
        }
      }
    }

    private void ShapesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.DrawShapes = !_environmentRenderer.DrawShapes;

      shapesToolStripMenuItem.Checked = _environmentRenderer.DrawShapes;

      renderPanel.Invalidate();
    }

    private void SolidStrandsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _simulation.SolidStrands = solidStrandsCheckBox.Checked;
    }

    private void SpeedToolStripTrackBar_ValueChanged(object sender, EventArgs e)
    {
      timer.Interval = speedToolStripTrackBar.Value;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      this.NextMove(false);
    }

    private void UpdateIteration()
    {
      iterationToolStripStatusLabel.Text = _simulation.Iteration.ToString();
    }

    private void UpdateSimulationControls()
    {
      bool isRunning;

      isRunning = timer.Enabled;

      playToolStripButton.Enabled = !isRunning;
      runToolStripMenuItem.Enabled = !isRunning;
      pauseToolStripButton.Enabled = isRunning;
      pauseToolStripMenuItem.Enabled = isRunning;
      nextMoveToolStripButton.Enabled = !isRunning;
      nextMoveToolStripMenuItem.Enabled = !isRunning;
    }

    private void UpdateStatusBar()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(this.UpdateStatusBar));
      }
      else
      {
        this.UpdateIteration();
        standsToolStripStatusLabel.Text = _simulation.Strands.Count.ToString();
        attractorsToolStripStatusLabel.Text = _simulation.FoodSources.Count.ToString();
        repellentsToolStripStatusLabel.Text = _simulation.NoxiousSources.Count.ToString();
      }
    }

    private void UpdateUi()
    {
      this.LoadFields();
      this.UpdateSimulationControls();
      this.UpdateStatusBar();
      this.UpdateWindowTitle();

      renderPanel.Invalidate();
    }

    private void UpdateWindowTitle()
    {
      this.Text = string.Format("{1} - {0}", Application.ProductName, string.IsNullOrEmpty(_fileName) ? "Untitled" : Path.GetFileName(_fileName));
    }

    private void WrapCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _simulation.Wrap = wrapCheckBox.Checked;
    }

    private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
    {
      scaleToolStripTrackBar.Value = Math.Min(scaleToolStripTrackBar.Maximum, scaleToolStripTrackBar.Value + 1);
    }

    private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      scaleToolStripTrackBar.Value = Math.Max(scaleToolStripTrackBar.Minimum, scaleToolStripTrackBar.Value - 1);
    }

    #endregion Private Methods

    private void RunButton_Click(object sender, EventArgs e)
    {
      string script;

      script = scriptTextBox.Text;

      if (!string.IsNullOrWhiteSpace(script))
      {
        ScriptEnvironment engine;

        engine = new ScriptEnvironment();
        engine.AddVariable("simulation", _simulation);

        engine.WrappedExecute(script);

        logTextBox.Text = engine.GetOutput();

        this.LoadFields();
        renderPanel.Invalidate();
      }
      else
      {
        SystemSounds.Beep.Play();
      }
    }

    private void CutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.PerformClipboardAction(tb => tb.Cut());
    }

    private Control GetActiveControl(Control control)
    {
      Control activeControl;
      ContainerControl containerControl;
      TabControl tabControl;

      containerControl = control as ContainerControl;
      tabControl = control as TabControl;

      if (containerControl != null)
      {
        activeControl = this.GetActiveControl(containerControl.ActiveControl);
      }
      else if (tabControl?.SelectedTab?.Controls.Count == 1)
      {
        activeControl = tabControl.SelectedTab.Controls[0];
      }
      else
      {
        activeControl = control;
      }

      return activeControl;
    }

    private void PerformClipboardAction(Action<TextBoxBase> action)
    {
      Control control;

      control = this.GetActiveControl(this);

      if(control is TextBoxBase textBox)
      {
        action(textBox);
      }
      else
      {
        SystemSounds.Beep.Play();
      }
    }

    private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.PerformClipboardAction(tb => tb.Copy());
    }

    private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.PerformClipboardAction(tb => tb.Paste());
    }

    private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.PerformClipboardAction(tb => tb.SelectAll());
    }
  }
}