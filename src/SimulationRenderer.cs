using System.Drawing;
using System.Drawing.Drawing2D;

namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal class SimulationRenderer
  {
    #region Private Fields

    private static readonly Point[] _strandShape = new[]
    {
      new Point(0, 0),
      new Point(-1, 1),
      new Point(-1, 3),
      new Point(1, 3),
      new Point(1, 1),
      new Point(0, 0)
    };

    private bool _drawShapes;

    private bool _outlinesOnly;

    private float _scale;

    private bool _showFoodDetectionZone;

    private bool _showFoodSources;

    private bool _showNoxiousDetectionZone;

    private bool _showNoxiousSources;

    private bool _showStrands;

    private bool _showTails;

    #endregion Private Fields

    #region Public Constructors

    public SimulationRenderer()
    {
      _scale = 1;
      _showFoodDetectionZone = true;
      _showTails = true;
      _showStrands = true;
      _showFoodSources = true;
      _showNoxiousSources = true;
      _showNoxiousDetectionZone = true;
      _drawShapes = true;
    }

    #endregion Public Constructors

    #region Public Properties

    public bool DrawShapes
    {
      get { return _drawShapes; }
      set { _drawShapes = value; }
    }

    public bool OutlinesOnly
    {
      get { return _outlinesOnly; }
      set { _outlinesOnly = value; }
    }

    public float Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }

    public bool ShowFoodDetectionZone
    {
      get { return _showFoodDetectionZone; }
      set { _showFoodDetectionZone = value; }
    }

    public bool ShowFoodSources
    {
      get { return _showFoodSources; }
      set { _showFoodSources = value; }
    }

    public bool ShowNoxiousDetectionZone
    {
      get { return _showNoxiousDetectionZone; }
      set { _showNoxiousDetectionZone = value; }
    }

    public bool ShowNoxiousSources
    {
      get { return _showNoxiousSources; }
      set { _showNoxiousSources = value; }
    }

    public bool ShowStrands
    {
      get { return _showStrands; }
      set { _showStrands = value; }
    }

    public bool ShowTails
    {
      get { return _showTails; }
      set { _showTails = value; }
    }

    #endregion Public Properties

    #region Public Methods

    public void Draw(Simulation environment, Graphics graphics)
    {
      graphics.Clear(SystemColors.Control);

      graphics.ScaleTransform(_scale, _scale);

      graphics.FillRectangle(Brushes.White, new Rectangle(Point.Empty, environment.Size));

      if (_showFoodSources)
      {
        for (int i = 0; i < environment.FoodSources.Count; i++)
        {
          this.DrawFood(graphics, environment.FoodSources[i]);
        }
      }

      if (_showNoxiousSources)
      {
        for (int i = 0; i < environment.NoxiousSources.Count; i++)
        {
          this.DrawNoxious(graphics, environment.NoxiousSources[i]);
        }
      }

      if (_showStrands)
      {
        if (_drawShapes)
        {
          graphics.ResetTransform();
        }

        for (int i = 0; i < environment.Strands.Count; i++)
        {
          this.DrawStrand(graphics, environment.Strands[i]);
        }
      }
    }

    #endregion Public Methods

    #region Private Methods

    private void DrawChemoeffector(Graphics graphics, Chemoeffector chemoeffector, Color color, bool showDetectionZone)
    {
      if (showDetectionZone)
      {
        Rectangle bounds;

        bounds = new Rectangle(chemoeffector.Position.X - (chemoeffector.Strength / 2), chemoeffector.Position.Y - (chemoeffector.Strength / 2), chemoeffector.Strength, chemoeffector.Strength);

        if (_outlinesOnly)
        {
          using (Pen pen = new Pen(color))
          {
            graphics.DrawEllipse(pen, bounds);
          }
        }
        else
        {
          using (GraphicsPath ellipsePath = new GraphicsPath())
          {
            ellipsePath.AddEllipse(bounds);

            using (PathGradientBrush brush = new PathGradientBrush(ellipsePath))
            {
              brush.CenterPoint = chemoeffector.Position;
              brush.CenterColor = Color.FromArgb(128, color);
              brush.SurroundColors = new[] { Color.Transparent };

              graphics.FillEllipse(brush, bounds);
            }
          }
        }
      }

      using (Pen pen = new Pen(color))
      {
        graphics.DrawLine(pen, new Point(chemoeffector.Position.X - 1, chemoeffector.Position.Y), new Point(chemoeffector.Position.X + 1, chemoeffector.Position.Y));
        graphics.DrawLine(pen, new Point(chemoeffector.Position.X, chemoeffector.Position.Y - 1), new Point(chemoeffector.Position.X, chemoeffector.Position.Y + 1));
      }
    }

    private void DrawFood(Graphics graphics, Chemoeffector food)
    {
      this.DrawChemoeffector(graphics, food, Color.SeaGreen, _showFoodDetectionZone);
    }

    private void DrawNoxious(Graphics graphics, Chemoeffector noxious)
    {
      this.DrawChemoeffector(graphics, noxious, Color.Firebrick, _showNoxiousDetectionZone);
    }

    private void DrawStrand(Graphics graphics, Strand strand)
    {
      Pen pen;

      pen = Pens.SaddleBrown;

      if (_drawShapes)
      {
        int x;
        int y;

        x = strand.Position.X;
        y = strand.Position.Y;

        graphics.ScaleTransform(_scale, _scale);
        graphics.TranslateTransform(x, y);
        graphics.RotateTransform(Compass.GetAngle(strand.Heading));
        graphics.DrawLines(pen, _strandShape);
        graphics.ResetTransform();
      }
      else
      {
        graphics.DrawLine(pen, new Point(strand.Position.X - 1, strand.Position.Y - 1), new Point(strand.Position.X + 1, strand.Position.Y + 1));
        graphics.DrawLine(pen, new Point(strand.Position.X - 1, strand.Position.Y + 1), new Point(strand.Position.X + 1, strand.Position.Y - 1));
      }
    }

    #endregion Private Methods
  }
}