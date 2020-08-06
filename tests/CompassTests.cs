using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;

namespace Cyotek.ChemotaxisSimulation.Tests
{
  [TestFixture]
  public class CompassTests
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> GetAngleTestCaseSource
    {
      get
      {
        yield return new TestCaseData(Compass.North, 0).SetName(nameof(GetAngleTestCases) + "North");
        yield return new TestCaseData(Compass.NorthEast, 45).SetName(nameof(GetAngleTestCases) + "NorthEast");
        yield return new TestCaseData(Compass.East, 90).SetName(nameof(GetAngleTestCases) + "East");
        yield return new TestCaseData(Compass.SouthEast, 135).SetName(nameof(GetAngleTestCases) + "SouthEast");
        yield return new TestCaseData(Compass.South, 180).SetName(nameof(GetAngleTestCases) + "South");
        yield return new TestCaseData(Compass.SouthWest, 225).SetName(nameof(GetAngleTestCases) + "SouthWest");
        yield return new TestCaseData(Compass.West, 270).SetName(nameof(GetAngleTestCases) + "West");
        yield return new TestCaseData(Compass.NorthWest, 315).SetName(nameof(GetAngleTestCases) + "NorthWest");
        yield return new TestCaseData(new Point(20, 21), 0).SetName(nameof(GetAngleTestCases) + "Invalid");
      }
    }

    public static IEnumerable<TestCaseData> GetNextQuarterTestCaseSource
    {
      get
      {
        yield return new TestCaseData(Compass.North, Compass.East).SetName(nameof(GetNextQuarterTestCases) + "North");
        yield return new TestCaseData(Compass.NorthEast, Compass.SouthEast).SetName(nameof(GetNextQuarterTestCases) + "NorthEast");
        yield return new TestCaseData(Compass.East, Compass.South).SetName(nameof(GetNextQuarterTestCases) + "East");
        yield return new TestCaseData(Compass.SouthEast, Compass.SouthWest).SetName(nameof(GetNextQuarterTestCases) + "SouthEast");
        yield return new TestCaseData(Compass.South, Compass.West).SetName(nameof(GetNextQuarterTestCases) + "South");
        yield return new TestCaseData(Compass.SouthWest, Compass.NorthWest).SetName(nameof(GetNextQuarterTestCases) + "SouthWest");
        yield return new TestCaseData(Compass.West, Compass.North).SetName(nameof(GetNextQuarterTestCases) + "West");
        yield return new TestCaseData(Compass.NorthWest, Compass.NorthEast).SetName(nameof(GetNextQuarterTestCases) + "NorthWest");
        yield return new TestCaseData(new Point(20, 21), Point.Empty).SetName(nameof(GetNextQuarterTestCases) + "Invalid");
      }
    }

    public static IEnumerable<TestCaseData> GetNextTestCaseSource
    {
      get
      {
        yield return new TestCaseData(Compass.North, Compass.NorthEast).SetName(nameof(GetNextTestCases) + "North");
        yield return new TestCaseData(Compass.NorthEast, Compass.East).SetName(nameof(GetNextTestCases) + "NorthEast");
        yield return new TestCaseData(Compass.East, Compass.SouthEast).SetName(nameof(GetNextTestCases) + "East");
        yield return new TestCaseData(Compass.SouthEast, Compass.South).SetName(nameof(GetNextTestCases) + "SouthEast");
        yield return new TestCaseData(Compass.South, Compass.SouthWest).SetName(nameof(GetNextTestCases) + "South");
        yield return new TestCaseData(Compass.SouthWest, Compass.West).SetName(nameof(GetNextTestCases) + "SouthWest");
        yield return new TestCaseData(Compass.West, Compass.NorthWest).SetName(nameof(GetNextTestCases) + "West");
        yield return new TestCaseData(Compass.NorthWest, Compass.North).SetName(nameof(GetNextTestCases) + "NorthWest");
        yield return new TestCaseData(new Point(20, 21), Point.Empty).SetName(nameof(GetNextTestCases) + "Invalid");
      }
    }

    public static IEnumerable<TestCaseData> GetOppositeTestCaseSource
    {
      get
      {
        yield return new TestCaseData(Compass.North, Compass.South).SetName(nameof(GetOppositeTestCases) + "North");
        yield return new TestCaseData(Compass.NorthEast, Compass.SouthWest).SetName(nameof(GetOppositeTestCases) + "NorthEast");
        yield return new TestCaseData(Compass.East, Compass.West).SetName(nameof(GetOppositeTestCases) + "East");
        yield return new TestCaseData(Compass.SouthEast, Compass.NorthWest).SetName(nameof(GetOppositeTestCases) + "SouthEast");
        yield return new TestCaseData(Compass.South, Compass.North).SetName(nameof(GetOppositeTestCases) + "South");
        yield return new TestCaseData(Compass.SouthWest, Compass.NorthEast).SetName(nameof(GetOppositeTestCases) + "SouthWest");
        yield return new TestCaseData(Compass.West, Compass.East).SetName(nameof(GetOppositeTestCases) + "West");
        yield return new TestCaseData(Compass.NorthWest, Compass.SouthEast).SetName(nameof(GetOppositeTestCases) + "NorthWest");
        yield return new TestCaseData(new Point(20, 21), Point.Empty).SetName(nameof(GetOppositeTestCases) + "Invalid");
      }
    }

    public static IEnumerable<TestCaseData> GetPreviousQuarterTestCaseSource
    {
      get
      {
        yield return new TestCaseData(Compass.North, Compass.West).SetName(nameof(GetPreviousQuarterTestCases) + "North");
        yield return new TestCaseData(Compass.NorthWest, Compass.SouthWest).SetName(nameof(GetPreviousQuarterTestCases) + "NorthWest");
        yield return new TestCaseData(Compass.West, Compass.South).SetName(nameof(GetPreviousQuarterTestCases) + "West");
        yield return new TestCaseData(Compass.SouthWest, Compass.SouthEast).SetName(nameof(GetPreviousQuarterTestCases) + "SouthWest");
        yield return new TestCaseData(Compass.South, Compass.East).SetName(nameof(GetPreviousQuarterTestCases) + "South");
        yield return new TestCaseData(Compass.SouthEast, Compass.NorthEast).SetName(nameof(GetPreviousQuarterTestCases) + "SouthEast");
        yield return new TestCaseData(Compass.East, Compass.North).SetName(nameof(GetPreviousQuarterTestCases) + "East");
        yield return new TestCaseData(Compass.NorthEast, Compass.NorthWest).SetName(nameof(GetPreviousQuarterTestCases) + "NorthEast");
        yield return new TestCaseData(new Point(20, 21), Point.Empty).SetName(nameof(GetPreviousQuarterTestCases) + "Invalid");
      }
    }

    public static IEnumerable<TestCaseData> GetPreviousTestCaseSource
    {
      get
      {
        yield return new TestCaseData(Compass.North, Compass.NorthWest).SetName(nameof(GetPreviousTestCases) + "North");
        yield return new TestCaseData(Compass.NorthWest, Compass.West).SetName(nameof(GetPreviousTestCases) + "NorthWest");
        yield return new TestCaseData(Compass.West, Compass.SouthWest).SetName(nameof(GetPreviousTestCases) + "West");
        yield return new TestCaseData(Compass.SouthWest, Compass.South).SetName(nameof(GetPreviousTestCases) + "SouthWest");
        yield return new TestCaseData(Compass.South, Compass.SouthEast).SetName(nameof(GetPreviousTestCases) + "South");
        yield return new TestCaseData(Compass.SouthEast, Compass.East).SetName(nameof(GetPreviousTestCases) + "SouthEast");
        yield return new TestCaseData(Compass.East, Compass.NorthEast).SetName(nameof(GetPreviousTestCases) + "East");
        yield return new TestCaseData(Compass.NorthEast, Compass.North).SetName(nameof(GetPreviousTestCases) + "NorthEast");
        yield return new TestCaseData(new Point(20, 21), Point.Empty).SetName(nameof(GetPreviousTestCases) + "Invalid");
      }
    }

    #endregion Public Properties

    #region Public Methods

    [Test]
    [TestCaseSource(nameof(GetAngleTestCaseSource))]
    public void GetAngleTestCases(Point current, int expected)
    {
      // arrange
      int actual;

      // act
      actual = Compass.GetAngle(current);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(GetNextQuarterTestCaseSource))]
    public void GetNextQuarterTestCases(Point current, Point expected)
    {
      // arrange
      Point actual;

      // act
      actual = Compass.GetNextQuarter(current);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(GetNextTestCaseSource))]
    public void GetNextTestCases(Point current, Point expected)
    {
      // arrange
      Point actual;

      // act
      actual = Compass.GetNext(current);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(GetOppositeTestCaseSource))]
    public void GetOppositeTestCases(Point current, Point expected)
    {
      // arrange
      Point actual;

      // act
      actual = Compass.GetOpposite(current);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(GetPreviousQuarterTestCaseSource))]
    public void GetPreviousQuarterTestCases(Point current, Point expected)
    {
      // arrange
      Point actual;

      // act
      actual = Compass.GetPreviousQuarter(current);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(GetPreviousTestCaseSource))]
    public void GetPreviousTestCases(Point current, Point expected)
    {
      // arrange
      Point actual;

      // act
      actual = Compass.GetPrevious(current);

      // assert
      Assert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}