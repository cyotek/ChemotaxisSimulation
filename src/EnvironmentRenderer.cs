using Cyotek.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Cyotek.Demo.EColiSimulation
{
  internal class EnvironmentRenderer
  {
    #region Private Fields

    private float _scale;

    private bool _showFoodDetectionZone;

    private bool _showFoodSources;

    private bool _showNoxiousDetectionZone;

    private bool _showNoxiousSources;

    private bool _showStrands;

    private bool _showTails;

    #endregion Private Fields

    #region Public Constructors

    public EnvironmentRenderer()
    {
      _scale = 1;
      _showFoodDetectionZone = true;
      _showTails = true;
      _showStrands = true;
      _showFoodSources = true;
      _showNoxiousSources = true;
      _showNoxiousDetectionZone = true;
    }

    #endregion Public Constructors

    #region Public Properties

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

    public void Draw(Environment environment, Graphics graphics)
    {
      graphics.Clear(SystemColors.Control);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;

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

      using (Pen pen = new Pen(color))
      {
        graphics.DrawEllipse(pen, chemoeffector.Position.X - 1, chemoeffector.Position.Y - 1, 2, 2);
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
      if (strand.PreviousPositions.Size > 1 && _showTails)
      {
        //int start;
        //start = 0;
        //for (int i = 1; i < strand.PreviousPositions.Size; i++)
        //{
        //  Point previous;
        //  Point current;

        //  previous = strand.PreviousPositions.PeekAt(i - 1);
        //  current = strand.PreviousPositions.PeekAt(i);

        //  if (!new Rectangle(current.X - 1, current.Y - 1, 3, 3).Contains(previous) && i - start > 1)
        //  {
        //    Point[] buffer;

        //    buffer = ArrayPool<Point>.Shared.Allocate(i - start);

        //    strand.PreviousPositions.CopyTo(start, buffer, 0, i - start);
        //    graphics.DrawLines(Pens.CornflowerBlue, buffer);

        //    start = i;
        //  }
        //}

        //if (start < strand.PreviousPositions.Size && strand.PreviousPositions.Size - start > 1)
        //{
        //  Point[] buffer;

        //  buffer = ArrayPool<Point>.Shared.Allocate(strand.PreviousPositions.Size - start);

        //  strand.PreviousPositions.CopyTo(start, buffer, 0, strand.PreviousPositions.Size - start);
        //  graphics.DrawLines(Pens.CornflowerBlue, buffer);
        //}
        //Point[] buffer;

        //buffer = ArrayPool<Point>.Shared.Allocate(strand.PreviousPositions.Size + 1);

        //strand.PreviousPositions.CopyTo(buffer);
        //buffer[buffer.Length - 1] = strand.Position;

        //graphics.DrawLines(Pens.CornflowerBlue, buffer);

        //ArrayPool<Point>.Shared.Free(buffer);
        //this.DrawTail(graphics, strand, Color.CornflowerBlue);
      }

      graphics.DrawEllipse(Pens.Black, strand.Position.X - 1, strand.Position.Y - 1, 2, 2);
    }

    private void DrawTail(Graphics graphics, Strand strand, Color color)
    {
      CircularBuffer<Point> positions;
      GraphicsPath path;
      int start;

      positions = strand.PreviousPositions;
      path = new GraphicsPath();
      start = 0;

      for (int i = 0; i < positions.Size; i++)
      {
        Point current;
        Point next;

        current = strand.PreviousPositions.PeekAt(i);

        if (i == positions.Size - 1)
        {
          this.DrawTail(graphics, positions, color, start, positions.Size - start);
        }
        else
        {
          next = positions.PeekAt(i + 1);
          if (Geometry.GetDistance(next, current) > 1)
          {
            this.DrawTail(graphics, positions, color, start, i - start);
            start = i;
          }
        }

        //if (draw)
        //{
        //  int length;

        //  length = i - start;

        //  if (length > 1)
        //  {
        //    Point[] buffer;

        //    buffer = ArrayPool<Point>.Shared.Allocate(length);

        //    positions.CopyTo(start,buffer,0,length);

        //    graphics.DrawLines(Pens.CornflowerBlue, buffer);

        //    ArrayPool<Point>.Shared.Free(buffer);
        //  start = i;
        //  }
        //}
      }
    }

    private void DrawTail(Graphics graphics, CircularBuffer<Point> positions, Color color, int start, int length)
    {
      if (length > 1)
      {
        Point[] buffer;

        buffer = ArrayPool<Point>.Shared.Allocate(length);

        positions.CopyTo(start, buffer, 0, length);

        graphics.DrawLines(Pens.CornflowerBlue, buffer);

        ArrayPool<Point>.Shared.Free(buffer);
      }
    }

    #endregion Private Methods
  }
}