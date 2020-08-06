using Cyotek.Demo.ChemotaxisSimulation;
using Cyotek.Demo.Windows.Forms;
using Cyotek.Windows.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Cyotek.Demo
{
  internal partial class MainForm : BaseForm
  {
    #region Private Fields

    private bool _antiAlias;

    private Simulation _environment;

    private SimulationRenderer _environmentRenderer;

    private Random _random;

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
      _random = new Random();
      _antiAlias = true;

      _environment = new Simulation
      {
        Size = new Size(256, 256)
      };

      _environmentRenderer = new SimulationRenderer
      {
        Scale = 2
      };

      attractorCollisionModeComboBox.SelectedIndex = (int)(CollisionAction.ReduceSelf - 1);
      repellentCollisionModeComboBox.SelectedIndex = (int)(CollisionAction.DestroyOther - 1);

      this.SetUpdateSpeed(2);
      this.InitializeScenario();

      base.OnShown(e);
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
        _environment.Run((int)count);

        this.UpdateStatusBar();

        renderPanel.Invalidate();
      }
    }

    private void AllowBinaryFissionCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _environment.BinaryFission = allowBinaryFissionCheckBox.Checked;
    }

    private void AntiAliasToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _antiAlias = !_antiAlias;

      antiAliasToolStripMenuItem.Checked = _antiAlias;

      renderPanel.Invalidate();
    }

    private void AttritionCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _environment.Attrition = attritionCheckBox.Checked;
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

      count = NumericInputDialog.ShowInputDialog(this, "Enter &iteration:", "Go To", 1, 1, int.MaxValue, v => v > _environment.Iteration);

      if (count > 0)
      {
        ulong iterations;

        iterations = (ulong)count - _environment.Iteration;

        _environment.Run(iterations);

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

      _environment.EnvironmentSeed = (int)environmentSeedNumericUpDown.Value;
      _environment.MovementSeed = (int)movementSeedNumericUpDown.Value;
      _environment.MinimumAttractorStrength = (int)minimumAttractorSizeNumericUpDown.Value;
      _environment.MaximumAttractorStrength = (int)maximumAttractorSizeNumericUpDown.Value;
      _environment.MinimumRepellentStrength = (int)minimumRepellentSizeNumericUpDown.Value;
      _environment.MaximumRepellentStrength = (int)maximumRepellentSizeNumericUpDown.Value;
      _environment.AttractorCollisionAction = (CollisionAction)(attractorCollisionModeComboBox.SelectedIndex + 1);
      _environment.RepellentCollisionAction = (CollisionAction)(repellentCollisionModeComboBox.SelectedIndex + 1);
      _environment.RespawnAttractor = respawnAttractorsCheckBox.Checked;
      _environment.BinaryFission = allowBinaryFissionCheckBox.Checked;
      _environment.Size = new Size((int)widthNumericUpDown.Value, (int)heightNumericUpDown.Value);
      _environment.Wrap = wrapCheckBox.Checked;
      _environment.SolidStrands = solidStrandsCheckBox.Checked;
      _environment.Attrition = attritionCheckBox.Checked;
      _environment.MobileRepellents = mobileRepellentsCheckBox.Checked;
      _environment.Reset();

      for (int i = 0; i < (int)strandsNumericUpDown.Value; i++)
      {
        _environment.AddStrand();
      }

      for (int i = 0; i < (int)attractorsNumericUpDown.Value; i++)
      {
        _environment.AddFoodSource();
      }

      for (int i = 0; i < (int)repellentsNumericUpDown.Value; i++)
      {
        _environment.AddNoxiousSource();
      }

      this.UpdateSimulationControls();
      this.UpdateStatusBar();

      renderPanel.Invalidate();
    }

    private void MobileRepellentsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _environment.MobileRepellents = !_environment.MobileRepellents;

      mobileRepellentsCheckBox.Checked = _environment.MobileRepellents;
    }

    private void NextMove(bool single)
    {
      int sum;

      sum = _environment.FoodSources.Count + _environment.NoxiousSources.Count + _environment.Strands.Count;

      if (single)
      {
        _environment.NextMove();
      }
      else
      {
        _environment.Run(_updateIterations);
      }

      if ((_environment.FoodSources.Count + _environment.NoxiousSources.Count + _environment.Strands.Count) != sum)
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
      control = (NumericUpDown)setupGroupBox.Controls[name];

      control.Value = _random.Next((int)control.Minimum, (int)control.Maximum + 1);

      this.InitializeScenario();
    }

    private void RenderPanel_Paint(object sender, PaintEventArgs e)
    {
      if (_antiAlias)
      {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      }

      _environmentRenderer.Draw(_environment, e.Graphics);
    }

    private void RespawnAttractorsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _environment.RespawnAttractor = respawnAttractorsCheckBox.Checked;
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
      _environment.SolidStrands = solidStrandsCheckBox.Checked;
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
      iterationToolStripStatusLabel.Text = _environment.Iteration.ToString();
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
        standsToolStripStatusLabel.Text = _environment.Strands.Count.ToString();
        attractorsToolStripStatusLabel.Text = _environment.FoodSources.Count.ToString();
        repellentsToolStripStatusLabel.Text = _environment.NoxiousSources.Count.ToString();
      }
    }

    private void WrapCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      _environment.Wrap = wrapCheckBox.Checked;
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
  }
}