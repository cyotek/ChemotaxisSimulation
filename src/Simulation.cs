﻿using Cyotek.ChemotaxisSimulation.Serialization;
using System;
using System.Drawing;
using System.IO;

// Simulating Bacterial Chemotaxis
// https://www.cyotek.com/blog/simulating-bacterial-chemotaxis

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.ChemotaxisSimulation
{
  public class Simulation
  {
    #region Private Fields

    private CollisionAction _attractorCollisionAction;

    private ChemoeffectorCollection _attractors;

    private bool _attrition;

    private bool _binaryFission;

    private Random _environmentRandom;

    private int _environmentSeed;

    private long _iteration;

    private int _maximumAttractorStrength;

    private int _maximumRepellentStrength;

    private int _minimumAttractorStrength;

    private int _minimumRepellentStrength;

    private bool _mobileRepellents;

    private Random _movementRandom;

    private int _movementSeed;

    private CollisionAction _repellentCollisionAction;

    private ChemoeffectorCollection _repellents;

    private bool _respawnAttractor;

    private Size _size;

    private bool _solidStrands;

    private StrandCollection _strands;

    private bool _wrap;

    #endregion Private Fields

    #region Public Constructors

    public Simulation()
    {
      _environmentSeed = 20200803;
      _movementSeed = 1622;
      _size = new Size(256, 256);
      _strands = new StrandCollection
      {
        Owner = this
      };
      _attractors = new ChemoeffectorCollection
      {
        Owner = this
      };
      _repellents = new ChemoeffectorCollection
      {
        Owner = this
      };
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

    #endregion Public Constructors

    #region Public Properties

    public CollisionAction AttractorCollisionAction
    {
      get { return _attractorCollisionAction; }
      set { _attractorCollisionAction = value; }
    }

    public ChemoeffectorCollection Attractors
    {
      get { return _attractors; }
      set
      {
        _attractors = value;
        if (value != null)
        {
          value.Owner = this;
        }
      }
    }

    public bool Attrition
    {
      get { return _attrition; }
      set { _attrition = value; }
    }

    public bool BinaryFission
    {
      get { return _binaryFission; }
      set { _binaryFission = value; }
    }

    public int EnvironmentSeed
    {
      get { return _environmentSeed; }
      set { _environmentSeed = value; }
    }

    public long Iteration
    {
      get { return _iteration; }
      set { _iteration = value; }
    }

    public int MaximumAttractorStrength
    {
      get { return _maximumAttractorStrength; }
      set { _maximumAttractorStrength = value; }
    }

    public int MaximumRepellentStrength
    {
      get { return _maximumRepellentStrength; }
      set { _maximumRepellentStrength = value; }
    }

    public int MinimumAttractorStrength
    {
      get { return _minimumAttractorStrength; }
      set { _minimumAttractorStrength = value; }
    }

    public int MinimumRepellentStrength
    {
      get { return _minimumRepellentStrength; }
      set { _minimumRepellentStrength = value; }
    }

    public bool MobileRepellents
    {
      get { return _mobileRepellents; }
      set { _mobileRepellents = value; }
    }

    public int MovementSeed
    {
      get { return _movementSeed; }
      set { _movementSeed = value; }
    }

    public CollisionAction RepellentCollisionAction
    {
      get { return _repellentCollisionAction; }
      set { _repellentCollisionAction = value; }
    }

    public ChemoeffectorCollection Repellents
    {
      get { return _repellents; }
      set
      {
        _repellents = value;
        if (value != null)
        {
          value.Owner = this;
        }
      }
    }

    public bool RespawnAttractor
    {
      get { return _respawnAttractor; }
      set { _respawnAttractor = value; }
    }

    public Size Size
    {
      get { return _size; }
      set { _size = value; }
    }

    public bool SolidStrands
    {
      get { return _solidStrands; }
      set { _solidStrands = value; }
    }

    public StrandCollection Strands
    {
      get { return _strands; }
      set
      {
        _strands = value;
        if (value != null)
        {
          value.Owner = this;
        }
      }
    }

    public bool Wrap
    {
      get { return _wrap; }
      set { _wrap = value; }
    }

    #endregion Public Properties

    #region Public Methods

    public void AddAttractor()
    {
      _attractors.Add(new Chemoeffector
      {
        Position = this.GetRandomPoint(),
        Strength = this.GetRandomSize(_minimumAttractorStrength, _maximumAttractorStrength)
      });
    }

    public void AddRepellent()
    {
      _repellents.Add(new Chemoeffector
      {
        Position = this.GetRandomPoint(),
        Strength = this.GetRandomSize(_minimumRepellentStrength, _maximumRepellentStrength),
        Heading = this.GetRandomHeading()
      });
    }

    public void AddStrand()
    {
      _strands.Add(new Strand
      {
        Position = this.GetRandomPoint(),
        Heading = this.GetRandomHeading()
      });
    }

    public void NextMove()
    {
      _iteration++;

      if (_mobileRepellents)
      {
        for (int i = 0; i < _repellents.Count; i++)
        {
          _repellents[i].Move();

          for (int j = 0; j < _strands.Count; j++)
          {
            this.CheckCollisions(_strands[j]);
          }
        }
      }

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

    public void Reset()
    {
      _environmentRandom = new Random(_environmentSeed);
      _movementRandom = new Random(_movementSeed);

      _iteration = 0;

      _strands.Clear();
      _attractors.Clear();
      _repellents.Clear();
    }

    public void Run(long iterations)
    {
      for (int i = 0; i < iterations; i++)
      {
        this.NextMove();
      }
    }

    public void Save(string fileName)
    {
      using (Stream stream = File.Create(fileName))
      {
        SimulationSerializer.Save(stream, this);
      }
    }

    #endregion Public Methods

    #region Private Methods

    private void Approach(Strand strand, Chemoeffector food)
    {
      double distance;

      distance = Geometry.GetDistance(strand.Position, food.Position);

      if (distance <= 1)
      {
        this.ProcessCollision(strand, food, _attractors, _attractorCollisionAction, this.CheckRespawn);

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

    private void CheckCollisions(Strand strand)
    {
      for (int i = 0; i < _repellents.Count; i++)
      {
        if (Geometry.GetDistance(strand.Position, _repellents[i].Position) <= 1)
        {
          this.ProcessCollision(strand, _repellents[i], _repellents, _repellentCollisionAction, () => this.AddRepellent());
        }
      }

      for (int i = 0; i < _attractors.Count; i++)
      {
        if (Geometry.GetDistance(strand.Position, _attractors[i].Position) <= 1)
        {
          this.ProcessCollision(strand, _attractors[i], _attractors, _attractorCollisionAction, this.CheckRespawn);
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

    private void CheckFission(Strand strand)
    {
      if (_binaryFission && _environmentRandom.NextDouble() < 0.001 && strand.Strength % 2 == 0)
      {
        strand.Strength /= 2;
        _strands.Add(strand.Copy());
      }
    }

    private void CheckRespawn()
    {
      if (_respawnAttractor)
      {
        this.AddAttractor();
      }
    }

    private void Flee(Strand strand, Chemoeffector noxious)
    {
      double distance;

      distance = Geometry.GetDistance(strand.Position, noxious.Position);

      if (distance <= 1)
      {
        this.ProcessCollision(strand, noxious, _repellents, _repellentCollisionAction, () => this.AddRepellent());
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

    private Chemoeffector GetClosestAttractor(Strand strand)
    {
      return this.GetClosestChemoeffector(strand, _attractors);
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

    private Chemoeffector GetClosestRepellor(Strand strand)
    {
      return this.GetClosestChemoeffector(strand, _repellents);
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

    private int GetRandomSize(int min, int max)
    {
      return _environmentRandom.Next(min, max);
    }

    private Chemoeffector GetStrongestAttractor(Strand strand)
    {
      return this.GetStrongestChemoeffector(strand, _attractors);
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
      return this.GetStrongestChemoeffector(strand, _repellents);
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

    private void Tumble(Strand strand)
    {
      double dir;
      //int x;
      //int y;

      dir = _movementRandom.NextDouble();
      //x = strand.Heading.X;
      //y = strand.Heading.Y;

      if (dir < 0.33)
      {
        // counter-clockwise
        strand.Heading = Compass.GetPrevious(strand.Heading);
      }
      else if (dir > 0.66)
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

    #endregion Private Methods
  }
}