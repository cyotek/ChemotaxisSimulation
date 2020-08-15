using System;
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

    private Pen _tailPen;

    #endregion Private Fields

    #region Public Constructors

    public GdiSimulationRenderer()
    {
      _scale = 1;
      _showFoodDetectionZone = true;
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

      _tailPen = new Pen(Color.CornflowerBlue)
      {
        EndCap = LineCap.Round,
        StartCap = LineCap.Round,
        LineJoin = LineJoin.Round
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

    public void Draw(Simulation simulation, Graphics graphics, Rectangle clip)
    {
      graphics.Clear(SystemColors.Control);

      graphics.ScaleTransform(_scale, _scale);

      graphics.FillRectangle(Brushes.White, new Rectangle(Point.Empty, simulation.Size));

      if (_showFoodSources)
      {
        for (int i = 0; i < simulation.Attractors.Count; i++)
        {
          this.DrawFood(graphics, clip, simulation.Attractors[i]);
        }
      }

      if (_showNoxiousSources)
      {
        for (int i = 0; i < simulation.Repellents.Count; i++)
        {
          this.DrawNoxious(graphics, clip, simulation.Repellents[i]);
        }
      }

      if (_showStrands)
      {
        if (_showTails)
        {
          for (int i = 0; i < simulation.Strands.Count; i++)
          {
            this.DrawStrandTail(graphics, simulation.Strands[i].PreviousPositions);
          }
        }

        for (int i = 0; i < simulation.Strands.Count; i++)
        {
          this.DrawStrand(graphics, clip, simulation.Strands[i]);
        }
      }
    }

    #endregion Public Methods

    #region Private Methods

    private void DrawChemoeffector(Graphics graphics, Rectangle clip, Chemoeffector chemoeffector, Pen pen, Point[] shape, bool showDetectionZone)
    {
      Rectangle bounds;

      bounds = new Rectangle(chemoeffector.Position.X - (chemoeffector.Strength / 2), chemoeffector.Position.Y - (chemoeffector.Strength / 2), chemoeffector.Strength, chemoeffector.Strength);

      if (this.ShouldRender(clip, bounds))
      {
        if (showDetectionZone)
        {
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
    }

    private void DrawFood(Graphics graphics, Rectangle clip, Chemoeffector food)
    {
      this.DrawChemoeffector(graphics, clip, food, _attractorPen, _attractorShape, _showFoodDetectionZone);
    }

    private void DrawNoxious(Graphics graphics, Rectangle clip, Chemoeffector noxious)
    {
      this.DrawChemoeffector(graphics, clip, noxious, _repellentPen, _repellentShape, _showNoxiousDetectionZone);
    }

    private void DrawSection(Graphics g, PointBuffer points, int start, int length)
    {
      if (length > 1) // DrawLines crashes if there isn't at least two points
      {
        Point[] _buffer;

        _buffer = ArrayPool<Point>.Shared.Allocate(length);

        points.CopyTo(start, _buffer, 0, length);

        g.DrawLines(_tailPen, _buffer);

        ArrayPool<Point>.Shared.Free(_buffer);
      }
    }

    private void DrawStrand(Graphics graphics, Rectangle clip, Strand strand)
    {
      int x;
      int y;

      x = strand.Position.X;
      y = strand.Position.Y;

      if (this.ShouldRender(clip, x, y))
      {
        if (_drawShapes)
        {
          GraphicsState state;

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
    }

    private void DrawStrandTail(Graphics g, PointBuffer points)
    {
      if (points.Size > 1)
      {
        // don't do this!
        //g.DrawLines(_bodyPen, points.ToArray());

        if (!this.HasSplitResults(points))
        {
          Point[] _buffer;

          // this isn't great, but as Graphics.DrawLines
          // isn't enlightened enough to take a start and length,
          // we copy the buffer out of the CircularBuffer into an
          // existing byte array so in theory we aren't allocating
          // an array over and over again

          _buffer = ArrayPool<Point>.Shared.Allocate(points.Size);

          points.CopyTo(_buffer);

          g.DrawLines(_tailPen, _buffer);

          ArrayPool<Point>.Shared.Free(_buffer);
        }
        else
        {
          int start;
          Point previous;
          Point current;

          // if we've wrapped the playing field, I can't just
          // call DrawLines with the entire buffer as we'll get
          // lines drawn across the entire playing field, so
          // instead I need to break it down into smaller buffers

          start = 0;
          previous = points.PeekAt(0);

          for (int i = 1; i < points.Size; i++)
          {
            current = points.PeekAt(i);

            if (Geometry.GetDistance(previous, current) > 1)
            {
              // here we have a split, so let us grab a subset of
              // the buffer and draw our lines
              this.DrawSection(g, points, start, i - start);
              start = i;
            }

            previous = current;
          }

          if (start < points.Size)
          {
            this.DrawSection(g, points, start, points.Size - start);
          }
        }
      }
    }

    private bool HasSplitResults(PointBuffer _snakeBody)
    {
      bool result;

      result = false;

      for (int i = 1; i < _snakeBody.Size; i++)
      {
        if (Geometry.GetDistance(_snakeBody.PeekAt(i - 1), _snakeBody.PeekAt(i)) > 1)
        {
          result = true;
          break;
        }
      }

      return result;
    }

    private bool ShouldRender(Rectangle clip, Rectangle bounds)
    {
      int x;
      int y;
      int w;
      int h;
      Rectangle newBounds;

      x = Convert.ToInt32(bounds.X * _scale);
      y = Convert.ToInt32(bounds.Y * _scale);
      w = Convert.ToInt32(bounds.Width * _scale);
      h = Convert.ToInt32(bounds.Height * _scale);
      newBounds = new Rectangle(x, y, w, h);

      return clip.IntersectsWith(newBounds);
    }

    private bool ShouldRender(Rectangle clip, int x, int y)
    {
      x = Convert.ToInt32(x * _scale);
      y = Convert.ToInt32(y * _scale);

      return clip.Contains(x, y);
    }

    #endregion Private Methods
  }
}