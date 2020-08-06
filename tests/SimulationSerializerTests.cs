using Cyotek.Demo.ChemotaxisSimulation;
using NUnit.Framework;
using System;
using System.Drawing;
using System.IO;

namespace Cyotek.ChemotaxisSimulation.Tests
{
  [TestFixture]
  public class SimulationSerializerTests
  {
    #region Private Properties

    private string DataPath
    {
      get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data"); }
    }

    #endregion Private Properties

    #region Public Methods

    [Test]
    public void LoadAdvancedTest()
    {
      // arrange
      SimulationSerializer target;
      Simulation expected;
      Simulation actual;

      expected = this.CreateDemonstrationSimulation();

      target = new SimulationSerializer();

      // act
      actual = target.Load(this.GetDataFileName("advanced.sim"));

      // assert
      SimulationAssert.AreEqual(expected, actual);
    }

    [Test]
    public void LoadTest()
    {
      // arrange
      SimulationSerializer target;
      Simulation expected;
      Simulation actual;

      expected = new Simulation();

      target = new SimulationSerializer();

      // act
      actual = target.Load(this.GetDataFileName("default.sim"));

      // assert
      SimulationAssert.AreEqual(expected, actual);
    }

    [Test]
    public void SaveAdvancedTest()
    {
      // arrange
      SimulationSerializer target;
      Simulation simulation;
      string expected;
      string actual;
      StringWriter writer;

      simulation = this.CreateDemonstrationSimulation();

      expected = File.ReadAllText(this.GetDataFileName("advanced.sim"));

      target = new SimulationSerializer();

      writer = new StringWriter();

      // act
      target.Save(writer, simulation);

      // assert
      actual = writer.ToString();
      //File.WriteAllText(@"D:\Checkout\trunk\cyotek\source\demo\ChemotaxisSimulation\tests\data\advanced.sim", actual);
      Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SaveTest()
    {
      // arrange
      SimulationSerializer target;
      Simulation simulation;
      string expected;
      string actual;
      StringWriter writer;

      simulation = new Simulation();

      expected = File.ReadAllText(this.GetDataFileName("default.sim"));

      target = new SimulationSerializer();

      writer = new StringWriter();

      // act
      target.Save(writer, simulation);

      // assert
      actual = writer.ToString();
      // File.WriteAllText(@"D:\Checkout\trunk\cyotek\source\demo\ChemotaxisSimulation\tests\data\default.sim", actual);
      Assert.AreEqual(expected, actual);
    }

    #endregion Public Methods

    #region Private Methods

    private Simulation CreateDemonstrationSimulation()
    {
      Simulation simulation;

      simulation = new Simulation
      {
        EnvironmentSeed = 20200806,
        MovementSeed = 0736,
        Size = new Size(100, 100),
        RespawnAttractor = false
      };

      simulation.FoodSources.Add(new Chemoeffector
      {
        Position = new Point(25, 25),
        Strength = 25
      });

      simulation.FoodSources.Add(new Chemoeffector
      {
        Position = new Point(75, 25),
        Strength = 25
      });

      simulation.FoodSources.Add(new Chemoeffector
      {
        Position = new Point(25, 75),
        Strength = 25
      });

      simulation.FoodSources.Add(new Chemoeffector
      {
        Position = new Point(75, 75),
        Strength = 25
      });

      simulation.NoxiousSources.Add(new Chemoeffector
      {
        Position = new Point(50, 50),
        Strength = 50
      });

      simulation.Strands.Add(new Strand
      {
        Position = new Point(25, 5),
        Heading = Compass.South
      });

      simulation.Strands.Add(new Strand
      {
        Position = new Point(95, 25),
        Heading = Compass.West
      });

      simulation.Strands.Add(new Strand
      {
        Position = new Point(75, 95),
        Heading = Compass.North
      });

      simulation.Strands.Add(new Strand
      {
        Position = new Point(5, 75),
        Heading = Compass.East
      });

      simulation.Run(500);

      return simulation;
    }

    private string GetDataFileName(string baseName)
    {
      return Path.Combine(this.DataPath, baseName);
    }

    #endregion Private Methods
  }
}