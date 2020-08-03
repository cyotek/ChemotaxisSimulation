using Cyotek.Demo.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Environment = Cyotek.Demo.EColiSimulation.Environment;
using Cyotek.Demo.EColiSimulation;

namespace Cyotek.Demo
{
  internal partial class MainForm : BaseForm
  {
    public MainForm()
    {
      this.InitializeComponent();
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutDialog.ShowAboutDialog();
    }

    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private Environment _environment;

    protected override void OnShown(EventArgs e)
    {
      _environment = new Environment
      {
        Size = new Size(256, 256)
      };

      _environmentRenderer = new EnvironmentRenderer
      {
        Scale = 2
      };

      attractorCollisionModeComboBox.SelectedIndex = (int)(CollisionAction.ReduceSelf - 1);
      repellentCollisionModeComboBox.SelectedIndex = (int)(CollisionAction.ReduceOther - 1);

      this.InitializeScenario();

      base.OnShown(e);
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
      _environment.RepelleCollisionAction = (CollisionAction)(repellentCollisionModeComboBox.SelectedIndex + 1);
      _environment.RespawnAttractor = respawnAttractorsCheckBox.Checked;
      _environment.BinaryFission = allowBinaryFissionCheckBox.Checked;
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

    private void UpdateStatusBar()
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new Action(this.UpdateStatusBar));
      }
      else
      {
        standsToolStripStatusLabel.Text = _environment.Strands.Count.ToString();
        attractorsToolStripStatusLabel.Text = _environment.FoodSources.Count.ToString();
        repellentsToolStripStatusLabel.Text = _environment.NoxiousSources.Count.ToString();
      }
    }

    private void RenderPanel_Paint(object sender, PaintEventArgs e)
    {
      _environmentRenderer.Draw(_environment, e.Graphics);
    }

    private EnvironmentRenderer _environmentRenderer;

    private void NextMoveToolStripButton_Click(object sender, EventArgs e)
    {
      this.NextMove();
    }

    private void ScaleToolStripTrackBar_ValueChanged(object sender, EventArgs e)
    {
      _environmentRenderer.Scale = scaleToolStripTrackBar.Value / 10F;

      renderPanel.Invalidate();
    }

    private void PlayToolStripButton_Click(object sender, EventArgs e)
    {
      timer.Start();

      this.UpdateSimulationControls();
    }

    private void PauseToolStripButton_Click(object sender, EventArgs e)
    {
      timer.Stop();

      this.UpdateSimulationControls();
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

    private void Timer_Tick(object sender, EventArgs e)
    {
      this.NextMove();
    }

    private void NextMove()
    {
      int sum;

      sum = _environment.FoodSources.Count + _environment.NoxiousSources.Count + _environment.Strands.Count;

      _environment.NextMove();

      if ((_environment.FoodSources.Count + _environment.NoxiousSources.Count + _environment.Strands.Count) != sum)
      {
        this.UpdateStatusBar();
      }

      renderPanel.Invalidate();
    }

    private void SpeedToolStripTrackBar_ValueChanged(object sender, EventArgs e)
    {
      timer.Interval = speedToolStripTrackBar.Value;
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

    private void FoodSourcesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowFoodSources = !_environmentRenderer.ShowFoodSources;

      foodSourcesToolStripMenuItem.Checked = _environmentRenderer.ShowFoodSources;

      renderPanel.Invalidate();

    }

    private void FoodSourceDetectionZonesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowFoodDetectionZone = !_environmentRenderer.ShowFoodDetectionZone;

      foodSourceDetectionZonesToolStripMenuItem.Checked = _environmentRenderer.ShowFoodDetectionZone;

      renderPanel.Invalidate();

    }

    private void NoxiousSourcesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowNoxiousSources = !_environmentRenderer.ShowNoxiousSources;

      noxiousSourcesToolStripMenuItem.Checked = _environmentRenderer.ShowNoxiousSources;

      renderPanel.Invalidate();

    }

    private void NoxiousSourceDetectionZonesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _environmentRenderer.ShowNoxiousDetectionZone = !_environmentRenderer.ShowNoxiousDetectionZone;

      noxiousSourceDetectionZonesToolStripMenuItem.Checked = _environmentRenderer.ShowNoxiousDetectionZone;

      renderPanel.Invalidate();

    }

    private void InitializeButton_Click(object sender, EventArgs e)
    {
      this.InitializeScenario();
    }
  }
}
