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

    private ChemoeffectorCollection _foodSources;

    public ChemoeffectorCollection FoodSources
    {
      get { return _foodSources; }
      set { _foodSources = value; }
    }


    public Environment()
    {
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
