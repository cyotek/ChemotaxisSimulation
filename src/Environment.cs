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
    private Strand _strand;

    public Strand Strand
    {
      get { return _strand; }
      set
      {
        _strand = value;

        _strand.Environment = this;
      }
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

    private Chemoeffector _food;

    public Chemoeffector Food
    {
      get { return _food; }
      set { _food = value; }
    }


    public Environment()
    {
      _scale = 1;
      _seed = 10;
      _size = new Size(256, 256);

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

      _strand = new Strand
      {
        Position = new Point(_random.Next(1, _size.Width), _random.Next(1, _size.Height))
      };
    }

    private void DumpBuffer(int start, int count)
    {
      Point[] buffer;

      buffer = (Point[])typeof(CircularBuffer<Point>).GetField("_buffer", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_strand.PreviousPositions);

      this.WriteBuffer(@"t:\internal.txt", buffer, _strand.PreviousPositions.Head, _strand.PreviousPositions.Tail);
      this.WriteBuffer(@"t:\array.txt", _strand.PreviousPositions.ToArray(), _strand.PreviousPositions.Head, _strand.PreviousPositions.Tail);

      buffer = ArrayPool<Point>.Shared.Allocate(count - start);

      _strand.PreviousPositions.CopyTo(start, buffer, 0, count - start);

      this.WriteBuffer(@"t:\range.txt", buffer.ToArray(), start, count);
    }

    private void WriteBuffer(string fileName, Point[] points, int head, int tail)
    {
      using (TextWriter writer = new StreamWriter(fileName))
      {
        writer.WriteLine(head);
        writer.WriteLine(tail);
        for (int i = 0; i < points.Length; i++)
        {
          writer.Write(points[i].X);
          writer.Write(',');
          writer.Write(points[i].Y);
          writer.WriteLine();
        }
      }
    }

    public void Draw(Graphics graphics)
    {
      graphics.Clear(SystemColors.Control);
      graphics.SmoothingMode = SmoothingMode.AntiAlias;

      graphics.ScaleTransform(_scale, _scale);

      graphics.FillRectangle(Brushes.White, new Rectangle(Point.Empty, _size));

      this.DrawFood(graphics, _food);

      if (_strand.PreviousPositions.Size > 1)
      {
        //int start;
        //start = 0;
        //for (int i = 1; i < _strand.PreviousPositions.Size; i++)
        //{
        //  Point previous;
        //  Point current;

        //  previous = _strand.PreviousPositions.PeekAt(i - 1);
        //  current = _strand.PreviousPositions.PeekAt(i);

        //  if (!new Rectangle(current.X - 1, current.Y - 1, 3, 3).Contains(previous) && i - start > 1)
        //  {
        //    Point[] buffer;

        //    buffer = ArrayPool<Point>.Shared.Allocate(i - start);


        //    _strand.PreviousPositions.CopyTo(start, buffer, 0, i - start);
        //    graphics.DrawLines(Pens.CornflowerBlue, buffer);

        //    start = i;
        //  }
        //}

        //if (start < _strand.PreviousPositions.Size && _strand.PreviousPositions.Size - start > 1)
        //{
        //  Point[] buffer;

        //  buffer = ArrayPool<Point>.Shared.Allocate(_strand.PreviousPositions.Size - start);

        //  _strand.PreviousPositions.CopyTo(start, buffer, 0, _strand.PreviousPositions.Size - start);
        //  graphics.DrawLines(Pens.CornflowerBlue, buffer);
        //}
        //Point[] buffer;

        //buffer = ArrayPool<Point>.Shared.Allocate(_strand.PreviousPositions.Size + 1);

        //_strand.PreviousPositions.CopyTo(buffer);
        //buffer[buffer.Length - 1] = _strand.Position;

        //graphics.DrawLines(Pens.CornflowerBlue, buffer);

        //ArrayPool<Point>.Shared.Free(buffer);
        this.DrawTail(graphics, _strand.PreviousPositions, Color.CornflowerBlue);
      }

      graphics.DrawEllipse(Pens.Black, _strand.Position.X - 1, _strand.Position.Y - 1, 2, 2);
    }

    private void DrawFood(Graphics graphics, Chemoeffector food)
    {
      Rectangle bounds;

      bounds = new Rectangle(food.Position.X - (food.Size / 2), food.Position.Y - (food.Size / 2), food.Size, food.Size);

      using (GraphicsPath ellipsePath = new GraphicsPath())
      {
        ellipsePath.AddEllipse(bounds);

        using (PathGradientBrush brush = new PathGradientBrush(ellipsePath))
        {
          brush.CenterPoint = food.Position;
          brush.CenterColor = Color.FromArgb(128, Color.SeaGreen);
          brush.SurroundColors = new[] { Color.Transparent };

          graphics.FillEllipse(brush, bounds);
        }
      }


      graphics.DrawEllipse(Pens.SeaGreen, food.Position.X - 1, food.Position.Y - 1, 2, 2);
    }


    private void DrawTail(Graphics graphics, CircularBuffer<Point> positions, Color color)
    {
      GraphicsPath path;
      int start;

      path = new GraphicsPath();
      start = 0;

      for (int i = 0; i < positions.Size; i++)
      {
        Point current;
        Point next;
        bool draw;

        current = _strand.PreviousPositions.PeekAt(i);

        if (i == positions.Size - 1)
        {
          this.DrawTail(graphics, positions, color, start, positions.Size - start);
        }
        else
        {
          next = _strand.PreviousPositions.PeekAt(i + 1);
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
      _strand.Move();

      if (Geometry.DoesPointIntersectCircle(_strand.Position, _food.Position, _food.Size / 2))
      {
        double distance;

        distance = Geometry.GetDistance(_strand.Position, _food.Position);

        if (distance <= 1)
        {
          _food = new Chemoeffector
          {
            Position = new Point(_random.Next(1, _size.Width - 32), _random.Next(1, _size.Height - 32)),
            Size = _random.Next(32, 128)
          };

          _strand.PreviousSensor = 0;
        }
        else
        {
          if (distance > _strand.PreviousSensor)
          {
            this.Tumble();
          }
          else
          {
            double newDistance;
            Point heading;
            heading = _strand.Heading;
            this.Tumble();
            _strand.Move();
            newDistance = Geometry.GetDistance(_strand.Position, _food.Position);
            if (newDistance >= distance)
            {
              _strand.Heading = heading;
            }
            _strand.UndoMove();
          }

          _strand.PreviousSensor = distance;
        }
      }
      else if (_strand.PreviousSensor != 0)
      {
        _strand.Heading = Compass.GetOpposite(_strand.Heading);
        this.Tumble();
        _strand.PreviousSensor = 0;
      }
      else
      {
        this.Tumble();
        _strand.PreviousSensor = 0;
      }

    }

    private void Tumble()
    {
      double dir;
      //int x;
      //int y;

      dir = _random.NextDouble();
      //x = _strand.Heading.X;
      //y = _strand.Heading.Y;

      if (dir < 0.25)
      {
        // counter-clockwise
        _strand.Heading = Compass.GetPrevious(_strand.Heading);
      }
      else if (dir > 0.75)
      {
        // clockwise
        _strand.Heading = Compass.GetNext(_strand.Heading);
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

      //_strand.Heading = new Point(x, y);
    }

    private bool IsOutOfBounds(Strand strand)
    {
      return _strand.Position.X <= 0 || _strand.Position.Y <= 0 || _strand.Position.X >= _size.Width - 1 || _strand.Position.Y >= _size.Height;
    }

    private Random _random;
  }
}
