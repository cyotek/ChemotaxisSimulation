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
        Size = new Size(256, 256),
        Strand = new Strand
        {
          Position = new Point(128, 128)
        },
        Scale = 2
      };

      this.UpdateSimulationControls();

      base.OnShown(e);

      renderPanel.Invalidate();
    }

    private void RenderPanel_Paint(object sender, PaintEventArgs e)
    {
      _environment.Draw(e.Graphics);
    }

    private void NextMoveToolStripButton_Click(object sender, EventArgs e)
    {
      _environment.NextMove();

      renderPanel.Invalidate();
    }

    private void ScaleToolStripTrackBar_ValueChanged(object sender, EventArgs e)
    {
      _environment.Scale = scaleToolStripTrackBar.Value / 10F;

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

    private long _ticks;

    private void Timer_Tick(object sender, EventArgs e)
    {
      long ticks;

      ticks = DateTime.Now.Ticks;

      if (_ticks != 0)
      {
        Console.WriteLine((ticks - _ticks).ToString());
      }

      _ticks = ticks;

      _environment.NextMove();

      renderPanel.Invalidate();
    }

    private void SpeedToolStripTrackBar_ValueChanged(object sender, EventArgs e)
    {
      timer.Interval = speedToolStripTrackBar.Value;
    }
  }
}
