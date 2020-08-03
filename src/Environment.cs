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

    private ChemoeffectorCollection _noxiousSources;

    public ChemoeffectorCollection NoxiousSources
    {
      get { return _noxiousSources; }
      set { _noxiousSources = value; }
    }


    public Environment()
    {
      _environmentSeed = 20200803;
      _movementSeed = 1622;
      _size = new Size(256, 256);
      _strands = new StrandCollection(this);
      _foodSources = new ChemoeffectorCollection(this);
      _noxiousSources = new ChemoeffectorCollection(this);
      _minimumAttractorStrength = 1;
      _maximumAttractorStrength = 128;
      _minimumRepellentStrength = 1;
      _maximumRepellentStrength = 128;
      _attractorCollisionAction = CollisionAction.ReduceSelf;
      _repellentCollisionAction = CollisionAction.ReduceOther;
      _respawnAttractor = true;
      _wrap = true;

      this.Reset();
    }

    private bool _binaryFission;

    public bool BinaryFission
    {
      get { return _binaryFission; }
      set { _binaryFission = value; }
    }


    private int _movementSeed;

    public int MovementSeed
    {
      get { return _movementSeed; }
      set { _movementSeed = value; }
    }

    private int _maximumAttractorStrength;

    public int MaximumAttractorStrength
    {
      get { return _maximumAttractorStrength; }
      set { _maximumAttractorStrength = value; }
    }

    private int _minimumAttractorStrength;

    public int MinimumAttractorStrength
    {
      get { return _minimumAttractorStrength; }
      set { _minimumAttractorStrength = value; }
    }

    private int _minimumRepellentStrength;

    public int MinimumRepellentStrength
    {
      get { return _minimumRepellentStrength; }
      set { _minimumRepellentStrength = value; }
    }
    private int _maximumRepellentStrength;

    public int MaximumRepellentStrength
    {
      get { return _maximumRepellentStrength; }
      set { _maximumRepellentStrength = value; }
    }



    private int _environmentSeed;

    public int EnvironmentSeed
    {
      get { return _environmentSeed; }
      set { _environmentSeed = value; }
    }

    public void Reset()
    {
      _environmentRandom = new Random(_environmentSeed);
      _movementRandom = new Random(_movementSeed);

      _strands.Clear();
      _foodSources.Clear();
      _noxiousSources.Clear();
    }

    public void AddStrand()
    {
      _strands.Add(new Strand
      {
        Position = this.GetRandomPoint(),
        Heading = this.GetRandomHeading()
      });
    }

    private Point GetRandomHeading()
    {
      int x;
      int y;

      do
      {
        x = _environmentRandom.Next(-1, 2);
        y = _environmentRandom.Next(-1, 2);
      } while (x + y == 0);

      return new Point(x, y);
    }

    private Point GetRandomPoint()
    {
      return new Point(_environmentRandom.Next(1, _size.Width), _environmentRandom.Next(1, _size.Height));
    }

    public void NextMove()
    {
      for (int i = 0; i < _strands.Count; i++)
      {
        Strand strand;

        strand = _strands[i];

        this.CheckFission(strand);
        this.MoveStrand(strand);

        if (_attrition && _environmentRandom.NextDouble() < 0.001)
        {
          strand.Strength--;

          if (strand.Strength <= 0)
          {
            _strands.Remove(strand);
          }
        }
      }
    }

    private bool _wrap;

    public bool Wrap
    {
      get { return _wrap; }
      set { _wrap = value; }
    }


    private void CheckFission(Strand strand)
    {
      if (_binaryFission && _environmentRandom.NextDouble() < 0.001 && strand.Strength % 2 == 0)
      {
        strand.Strength /= 2;
        _strands.Add(strand.Copy());
      }
    }

    private Chemoeffector GetStrongestAttractor(Strand strand)
    {
      return this.GetStrongestChemoeffector(strand, _foodSources);
    }

    private Chemoeffector GetStrongestChemoeffector(Strand strand, ChemoeffectorCollection container)
    {
      Chemoeffector result;
      int strength;

      result = null;
      strength = 0;

      for (int i = 0; i < container.Count; i++)
      {
        Chemoeffector chemoeffector;

        chemoeffector = container[i];

        if (Geometry.DoesPointIntersectCircle(strand.Position, chemoeffector.Position, (chemoeffector.Strength / 2) + 4) // add a bit of a buffer so even the smallest have a gradient
          && chemoeffector.Strength > strength)
        {
          strength = chemoeffector.Strength;
          result = chemoeffector;
        }
      }

      return result;
    }

    private Chemoeffector GetStrongestRepellor(Strand strand)
    {
      return this.GetStrongestChemoeffector(strand, _noxiousSources);
    }

    private Chemoeffector GetClosestAttractor(Strand strand)
    {
      return this.GetClosestChemoeffector(strand, _foodSources);
    }

    private Chemoeffector GetClosestChemoeffector(Strand strand, ChemoeffectorCollection container)
    {
      Chemoeffector result;
      int strength;

      result = null;
      strength = 0;

      for (int i = 0; i < container.Count; i++)
      {
        Chemoeffector chemoeffector;

        chemoeffector = container[i];

        if (Geometry.DoesPointIntersectCircle(strand.Position, chemoeffector.Position, (chemoeffector.Strength / 2) + 4) // add a bit of a buffer so even the smallest have a gradient
          && (strength == 0 || chemoeffector.Strength < strength))
        {
          strength = chemoeffector.Strength;
          result = chemoeffector;
        }
      }

      return result;
    }

    private bool _solidStrands;

    public bool SolidStrands
    {
      get { return _solidStrands; }
      set { _solidStrands = value; }
    }


    private Chemoeffector GetClosestRepellor(Strand strand)
    {
      return this.GetClosestChemoeffector(strand, _noxiousSources);
    }
    private void MoveStrand(Strand strand)
    {
      Chemoeffector noxious;

      strand.Move();

      noxious = this.GetClosestRepellor(strand);

      if (noxious != null)
      {
        this.Flee(strand, noxious);
      }
      else
      {
        Chemoeffector food;

        food = this.GetClosestAttractor(strand);

        if (food != null)
        {
          this.Approach(strand, food);
        }
        else if (strand.PreviousSensor != 0)
        {
          strand.Heading = Compass.GetOpposite(strand.Heading);
          this.Tumble(strand);
          strand.PreviousSensor = 0;
          this.CheckCollisions(strand);
        }
        else
        {
          this.Tumble(strand);
          strand.PreviousSensor = 0;
          this.CheckCollisions(strand);
        }
      }
    }

    private bool _respawnAttractor;

    public bool RespawnAttractor
    {
      get { return _respawnAttractor; }
      set { _respawnAttractor = value; }
    }


    private void Approach(Strand strand, Chemoeffector food)
    {
      double distance;

      distance = Geometry.GetDistance(strand.Position, food.Position);

      if (distance <= 1)
      {
        this.ProcessCollision(strand, food, _foodSources, _attractorCollisionAction, this.CheckRespawn);

        strand.PreviousSensor = 0;
      }
      else
      {
        if (distance > strand.PreviousSensor)
        {
          this.Tumble(strand);
          this.CheckCollisions(strand);
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

    private void CheckRespawn()
    {
      if (_respawnAttractor)
      {
        this.AddFoodSource();
      }
    }

    private void ProcessCollision(Strand strand, Chemoeffector chemoeffector, ChemoeffectorCollection container, CollisionAction action, Action createNew)
    {
      if (action == CollisionAction.ReduceSelf)
      {
        chemoeffector.Strength--;
        strand.Strength++;
      }
      else if (action == CollisionAction.ReduceOther)
      {
        strand.Strength--;
      }

      if (chemoeffector.Strength <= 0 || action == CollisionAction.DestroySelf)
      {
        container.Remove(chemoeffector);

        createNew();
      }

      if (strand.Strength <= 0 || action == CollisionAction.DestroyOther)
      {
        _strands.Remove(strand);
      }
    }

    private void Flee(Strand strand, Chemoeffector noxious)
    {
      double distance;

      distance = Geometry.GetDistance(strand.Position, noxious.Position);

      if (distance <= 1)
      {
        this.ProcessCollision(strand, noxious, _noxiousSources, _repellentCollisionAction, () => this.AddNoxiousSource());
      }
      else
      {
        if (distance < strand.PreviousSensor)
        {
          this.Tumble(strand);
          this.CheckCollisions(strand);
        }
        else
        {
          double newDistance;
          Point heading;
          heading = strand.Heading;
          this.Tumble(strand);
          strand.Move();
          newDistance = Geometry.GetDistance(strand.Position, noxious.Position);
          if (newDistance < distance)
          {
            strand.Heading = heading;
          }
          strand.UndoMove();
        }

        strand.PreviousSensor = distance;
      }
    }

    private void CheckCollisions(Strand strand)
    {
      for (int i = 0; i < _noxiousSources.Count; i++)
      {
        if (Geometry.GetDistance(strand.Position, _noxiousSources[i].Position) <= 1)
        {
          this.ProcessCollision(strand, _noxiousSources[i], _noxiousSources, _repellentCollisionAction, () => this.AddNoxiousSource());
        }
      }

      for (int i = 0; i < _foodSources.Count; i++)
      {
        if (Geometry.GetDistance(strand.Position, _foodSources[i].Position) <= 1)
        {
          this.ProcessCollision(strand, _foodSources[i], _foodSources, _attractorCollisionAction, this.CheckRespawn);
          break;
        }
      }

      if (_solidStrands)
      {
        for (int i = 0; i < _strands.Count; i++)
        {
          Strand other;

          other = _strands[i];

          if (!object.ReferenceEquals(strand, other) && strand.Position == other.Position)
          {
            strand.UndoMove();
            strand.Heading = _movementRandom.NextDouble() >= 0.5 ? Compass.GetNextQuarter(strand.Heading) : Compass.GetPreviousQuarter(strand.Heading);
            break;
          }
        }
      }
    }

    public void AddFoodSource()
    {
      _foodSources.Add(new Chemoeffector
      {
        Position = this.GetRandomPoint(),
        Strength = this.GetRandomSize(_minimumAttractorStrength, _maximumAttractorStrength)
      });
    }

    public void AddNoxiousSource()
    {
      _noxiousSources.Add(new Chemoeffector
      {
        Position = this.GetRandomPoint(),
        Strength = this.GetRandomSize(_minimumRepellentStrength, _maximumRepellentStrength)
      });
    }

    private int GetRandomSize(int min, int max)
    {
      return _environmentRandom.Next(min, max);
    }

    private void Tumble(Strand strand)
    {
      double dir;
      //int x;
      //int y;

      dir = _movementRandom.NextDouble();
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


    private Random _environmentRandom;
    private Random _movementRandom;

    private CollisionAction _attractorCollisionAction;

    public CollisionAction AttractorCollisionAction
    {
      get { return _attractorCollisionAction; }
      set { _attractorCollisionAction = value; }
    }

    private CollisionAction _repellentCollisionAction;

    public CollisionAction RepelleCollisionAction
    {
      get { return _repellentCollisionAction; }
      set { _repellentCollisionAction = value; }
    }

    private bool _attrition;

    public bool Attrition
    {
      get { return _attrition; }
      set { _attrition = value; }
    }

  }
}
