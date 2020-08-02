using Cyotek.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cyotek.Demo.EColiSimulation
{
  internal class Environment
  {
    private StrandCollection _strands;

    public StrandCollection Strands
    {
      get { return _strands; }
      set { _strands = value; }
    }

    private Size _size;

    public Size Size
    {
      get { return _size; }
      set { _size = value; }
    }

    private float _scale;

    public float Scale
    {
      get { return _scale; }
      set { _scale = value; }
    }
    private ChemoeffectorCollection _foodSources;

    public ChemoeffectorCollection FoodSources
    {
      get { return _foodSources; }
      set { _foodSources = value; }
    }


    public Environment()
    {
      _scale = 1;
      _seed = 10;
      _size = new Size(256, 256);
      _strands = new StrandCollection(this);
      _foodSources = new ChemoeffectorCollection(this);

      this.Reset();
    }

    private int _seed;

    public int Seed
    {
      get { return _seed; }
      set { _seed = value; }
    }

    public void Reset()
    {
      _random = new Random(_seed);

      _strands.Clear();
      _foodSources.Clear();

      //_strand = new Strand
      //{
      //  Position = new Point(_random.Next(1, _size.Width), _random.Next(1, _size.Height))
      //};
    }

    public void AddStrand()
    {
      _strands.Add(new Strand
      {
        Position = new Point(_random.Next(1, _size.Width), _random.Next(1, _size.Height))
      });
    }

    public void Draw(Graphics graphics)
    {
      graphics.Clear(SystemColors.Control);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;

      graphics.ScaleTransform(_scale, _scale);

      graphics.FillRectangle(Brushes.White, new Rectangle(Point.Empty, _size));

      for (int i = 0; i < _foodSources.Count; i++)
      {
        this.DrawFood(graphics, _foodSources[i]);
      }

      for (int i = 0; i < _strands.Count; i++)
      {
        this.DrawStrand(graphics, _strands[i]);
      }
    }

    private void DrawStrand(Graphics graphics, Strand strand)
    {
      if (strand.PreviousPositions.Size > 1)
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
        this.DrawTail(graphics, strand, Color.CornflowerBlue);
      }

      graphics.DrawEllipse(Pens.Black, strand.Position.X - 1, strand.Position.Y - 1, 2, 2);
    }

    private void DrawFood(Graphics graphics, Chemoeffector food)
    {
      this.DrawChemoeffector(graphics, food, Color.SeaGreen);
    }

    private void DrawChemoeffector(Graphics graphics, Chemoeffector chemoeffector, Color color)
    {
      Rectangle bounds;

      bounds = new Rectangle(chemoeffector.Position.X - (chemoeffector.Size / 2), chemoeffector.Position.Y - (chemoeffector.Size / 2), chemoeffector.Size, chemoeffector.Size);

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

      using (Pen pen = new Pen(color))
      {
        graphics.DrawEllipse(pen, chemoeffector.Position.X - 1, chemoeffector.Position.Y - 1, 2, 2);
      }
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

    public void NextMove()
    {
      for (int i = 0; i < _strands.Count; i++)
      {
        this.MoveStrand(_strands[i]);
      }
    }

    private void MoveStrand(Strand strand)
    {
      Chemoeffector food;

      strand.Move();


      food = null;

      for (int i = 0; i < _foodSources.Count; i++)
      {
        Chemoeffector foodSource;

        foodSource = _foodSources[i];

        if (Geometry.DoesPointIntersectCircle(strand.Position, foodSource.Position, foodSource.Size / 2))
        {
          food = foodSource;
          break;
        }
      }

      if (food != null)
      {
        double distance;

        distance = Geometry.GetDistance(strand.Position, food.Position);

        if (distance <= 1)
        {
          _foodSources.Remove(food);

          this.AddFoodSource();

          strand.PreviousSensor = 0;
        }
        else
        {
          if (distance > strand.PreviousSensor)
          {
            this.Tumble(strand);
          }
          else
          {
            double newDistance;
            Point heading;
            heading = strand.Heading;
            this.Tumble(strand);
            strand.Move();
            newDistance = Geometry.GetDistance(strand.Position, food.Position);
            if (newDistance >= distance)
            {
              strand.Heading = heading;
            }
            strand.UndoMove();
          }

          strand.PreviousSensor = distance;
        }
      }
      else if (strand.PreviousSensor != 0)
      {
        strand.Heading = Compass.GetOpposite(strand.Heading);
        this.Tumble(strand);
        strand.PreviousSensor = 0;
      }
      else
      {
        this.Tumble(strand);
        strand.PreviousSensor = 0;
      }

    }

    public void AddFoodSource()
    {
      _foodSources.Add(new Chemoeffector
      {
        Position = new Point(_random.Next(1, _size.Width - 32), _random.Next(1, _size.Height - 32)),
        Size = _random.Next(32, 128)
      });
    }

    private void Tumble(Strand strand)
    {
      double dir;
      //int x;
      //int y;

      dir = _random.NextDouble();
      //x = strand.Heading.X;
      //y = strand.Heading.Y;

      if (dir < 0.25)
      {
        // counter-clockwise
        strand.Heading = Compass.GetPrevious(strand.Heading);
      }
      else if (dir > 0.75)
      {
        // clockwise
        strand.Heading = Compass.GetNext(strand.Heading);
      }

      //if (dir < 0.125)
      //{
      //  x = -1;
      //}
      //else if (dir > 0.125 && dir < 0.250)
      //{
      //  x = 1;
      //}
      //else if (dir > 0.250 && dir < 0.375 && y != 0)
      //{
      //  x = 0;
      //}
      //else if (dir > 0.375 && dir < 0.5)
      //{
      //  y = -1;
      //}
      //else if (dir > 0.5 && dir < 0.625)
      //{
      //  y = 1;
      //}
      //else if (dir > 0.625 && dir < 0.75 && x != 0)
      //{
      //  y = 0;
      //}

      //strand.Heading = new Point(x, y);
    }


    private Random _random;
  }
}
