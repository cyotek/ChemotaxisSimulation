using Cyotek.Demo.EColiSimulation;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;

namespace Cyotek.EColiSimulation.Tests
{
  [TestFixture]
  public class CompassTests
  {
    #region Public Properties

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