using System.Drawing;
using System.Drawing.Drawing2D;

namespace Cyotek.ChemotaxisSimulation.Renderer
{
  public class GdiSimulationRenderer
  {
    #region Private Fields

    private static readonly Point[] _attractorShape = new[]
    {
      new Point(-2, -1),
      new Point(-2, 1),
      new Point(-1, 2),
      new Point(1, 2),
      new Point(2, 1),
      new Point(2, -1),
      new Point(1, -2),
      new Point(-1, -2),
    };

    private static readonly Point[] _repellentShape = new[]
    {
      new Point(0, -2),
      new Point(-2, 0),
      new Point(0, 2),
      new Point(2, 0),
    };

    private static readonly Point[] _strandShape = new[]
            {
      new Point(0, 0),
      new Point(-1, 1),
      new Point(-1, 2),
      new Point(0, 3),
      new Point(1, 2),
      new Point(1, 1)
    };

    private readonly Pen _attractorPen;

    private readonly Pen _repellentPen;

    private readonly Pen _strandPen;

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

    public GdiSimulationRenderer()
    {
      _scale = 1;
      _showFoodDetectionZone = true;
      _showTails = true;
      _showStrands = true;
      _showFoodSources = true;
      _showNoxiousSources = true;
      _showNoxiousDetectionZone = true;
      _drawShapes = true;

      _strandPen = new Pen(Color.DarkGoldenrod)
      {
        EndCap = LineCap.Round,
        LineJoin = LineJoin.Round,
        StartCap = LineCap.Round
      };

      _attractorPen = new Pen(Color.SeaGreen)
      {
        EndCap = LineCap.Round,
        LineJoin = LineJoin.Round,
        StartCap = LineCap.Round
      };

      _repellentPen = new Pen(Color.Firebrick);
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

    public void Draw(Simulation simulation, Graphics graphics)
    {
      graphics.Clear(SystemColors.Control);

      graphics.ScaleTransform(_scale, _scale);

      graphics.FillRectangle(Brushes.White, new Rectangle(Point.Empty, simulation.Size));

      if (_showFoodSources)
      {
        for (int i = 0; i < simulation.FoodSources.Count; i++)
        {
          this.DrawFood(graphics, simulation.FoodSources[i]);
        }
      }

      if (_showNoxiousSources)
      {
        for (int i = 0; i < simulation.NoxiousSources.Count; i++)
        {
          this.DrawNoxious(graphics, simulation.NoxiousSources[i]);
        }
      }

      if (_showStrands)
      {
        for (int i = 0; i < simulation.Strands.Count; i++)
        {
          this.DrawStrand(graphics, simulation.Strands[i]);
        }
      }
    }

    #endregion Public Methods

    #region Private Methods

    private void DrawChemoeffector(Graphics graphics, Chemoeffector chemoeffector, Pen pen, Point[] shape, bool showDetectionZone)
    {
      if (showDetectionZone)
      {
        Rectangle bounds;

        bounds = new Rectangle(chemoeffector.Position.X - (chemoeffector.Strength / 2), chemoeffector.Position.Y - (chemoeffector.Strength / 2), chemoeffector.Strength, chemoeffector.Strength);

        if (_outlinesOnly)
        {
          graphics.DrawEllipse(pen, bounds);
        }
        else
        {
          using (GraphicsPath ellipsePath = new GraphicsPath())
          {
            ellipsePath.AddEllipse(bounds);

            using (PathGradientBrush brush = new PathGradientBrush(ellipsePath))
            {
              brush.CenterPoint = chemoeffector.Position;
              brush.CenterColor = Color.FromArgb(128, pen.Color);
              brush.SurroundColors = new[] { Color.Transparent };

              graphics.FillEllipse(brush, bounds);
            }
          }
        }
      }

      if (_drawShapes)
      {
        int x;
        int y;
        GraphicsState state;

        x = chemoeffector.Position.X;
        y = chemoeffector.Position.Y;
        state = graphics.Save();

        graphics.TranslateTransform(x, y);
        graphics.RotateTransform(Compass.GetAngle(chemoeffector.Heading));
        graphics.DrawPolygon(pen, shape);

        graphics.Restore(state);
      }
      else
      {
        graphics.DrawLine(pen, new Point(chemoeffector.Position.X - 1, chemoeffector.Position.Y), new Point(chemoeffector.Position.X + 1, chemoeffector.Position.Y));
        graphics.DrawLine(pen, new Point(chemoeffector.Position.X, chemoeffector.Position.Y - 1), new Point(chemoeffector.Position.X, chemoeffector.Position.Y + 1));
      }
    }

    private void DrawFood(Graphics graphics, Chemoeffector food)
    {
      this.DrawChemoeffector(graphics, food, _attractorPen, _attractorShape, _showFoodDetectionZone);
    }

    private void DrawNoxious(Graphics graphics, Chemoeffector noxious)
    {
      this.DrawChemoeffector(graphics, noxious, _repellentPen, _repellentShape, _showNoxiousDetectionZone);
    }

    private void DrawStrand(Graphics graphics, Strand strand)
    {
      if (_drawShapes)
      {
        int x;
        int y;
        GraphicsState state;

        x = strand.Position.X;
        y = strand.Position.Y;
        state = graphics.Save();

        graphics.TranslateTransform(x, y);
        graphics.RotateTransform(Compass.GetAngle(strand.Heading));
        graphics.DrawPolygon(_strandPen, _strandShape);

        graphics.Restore(state);
      }
      else
      {
        graphics.DrawLine(_strandPen, new Point(strand.Position.X - 1, strand.Position.Y - 1), new Point(strand.Position.X + 1, strand.Position.Y + 1));
        graphics.DrawLine(_strandPen, new Point(strand.Position.X - 1, strand.Position.Y + 1), new Point(strand.Position.X + 1, strand.Position.Y - 1));
      }
    }

    #endregion Private Methods
  }
}