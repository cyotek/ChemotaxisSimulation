using System;
using System.Collections.Generic;
using System.Drawing;
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
      set { _strand = value; }
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

    public void Draw(Graphics graphics)
    {
      graphics.Clear(SystemColors.Control);

      graphics.ScaleTransform(_scale, _scale);

      graphics.FillRectangle(Brushes.White, new Rectangle(Point.Empty, _size));

      if (!_strand.PreviousPositions.IsEmpty)
      {
        Point[] buffer;

        buffer = ArrayPool<Point>.Shared.Allocate(_strand.PreviousPositions.Size + 1);

        _strand.PreviousPositions.CopyTo(buffer);
        buffer[buffer.Length - 1] = _strand.Position;

        graphics.DrawLines(Pens.CornflowerBlue, buffer);

        ArrayPool<Point>.Shared.Free(buffer);
      }

      graphics.DrawEllipse(Pens.Black, _strand.Position.X - 1, _strand.Position.Y - 1, 2, 2);
    }

    public void NextMove()
    {
      _strand.Move();

      if (this.IsOutOfBounds(_strand))
      {
        _strand.UndoMove();
      }

      // if (_random.NextDouble() > 0.25)
      {
        double dir;
        int x;
        int y;

        dir = _random.NextDouble();
        x = _strand.Heading.X;
        y = _strand.Heading.Y;

        if (dir < 0.125)
        {
          x = -1;
        }
        else if (dir > 0.125 && dir < 0.250)
        {
          x = 1;
        }
        else if (dir > 0.250 && dir < 0.375 && y != 0)
        {
          x = 0;
        }
        else if (dir > 0.375 && dir < 0.5)
        {
          y = -1;
        }
        else if (dir > 0.5 && dir < 0.625)
        {
          y = 1;
        }
        else if (dir > 0.625 && dir < 0.75 && x != 0)
        {
          y = 0;
        }

        _strand.Heading = new Point(x, y);
      }
    }

    private bool IsOutOfBounds(Strand strand)
    {
      return _strand.Position.X <= 0 || _strand.Position.Y <= 0 || _strand.Position.X >= _size.Width - 1 || _strand.Position.Y >= _size.Height;
    }

    private Random _random;
  }
}
