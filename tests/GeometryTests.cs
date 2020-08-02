using Cyotek.Demo.EColiSimulation;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;

namespace Cyotek.EColiSimulation.Tests
{
  [TestFixture]
  public class GeometryTests
  {
    #region Public Properties

    public static IEnumerable<TestCaseData> DoesPointIntersectCircleStructTestCaseData
    {
      get
      {
        yield return new TestCaseData(new object[] { new Point(5, 5), new Point(0, 0), 10, true }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Inside");
        yield return new TestCaseData(new object[] { new Point(0, 0), new Point(0, 0), 10, true }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Centred");
        yield return new TestCaseData(new object[] { new Point(0, 0), new Point(10, 10), 10, false }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Outside1");
        yield return new TestCaseData(new object[] { new Point(0, 20), new Point(10, 10), 10, false }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Outside3");
        yield return new TestCaseData(new object[] { new Point(20, 0), new Point(10, 10), 10, false }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Outside4");
        yield return new TestCaseData(new object[] { new Point(20, 20), new Point(10, 10), 10, false }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Outside2");
      }
    }

    public static IEnumerable<TestCaseData> DoesPointIntersectCircleTestCaseData
    {
      get
      {
        yield return new TestCaseData(new object[] { 5, 5, 0, 0, 10, true }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Inside");
        yield return new TestCaseData(new object[] { 0, 0, 0, 0, 10, true }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Centred");
        yield return new TestCaseData(new object[] { 0, 0, 10, 10, 10, false }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Outside1");
        yield return new TestCaseData(new object[] { 0, 20, 10, 10, 10, false }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Outside3");
        yield return new TestCaseData(new object[] { 20, 0, 10, 10, 10, false }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Outside4");
        yield return new TestCaseData(new object[] { 20, 20, 10, 10, 10, false }).SetName(nameof(DoesPointIntersectCircleTestCases) + "Outside2");
      }
    }

    public static IEnumerable<TestCaseData> GetDistanceTestCaseData
    {
      get
      {
        yield return new TestCaseData(new object[] { 0, 0, 0, 0, 0 }).SetName(nameof(GetDistanceTestCases) + "Zero");
        yield return new TestCaseData(new object[] { 12, 24, 12, 24, 0 }).SetName(nameof(GetDistanceTestCases) + "Same");
        yield return new TestCaseData(new object[] { 12, 26, 12, 24, 2 }).SetName(nameof(GetDistanceTestCases) + "North");
        yield return new TestCaseData(new object[] { 12, 26, 12, 28, 2 }).SetName(nameof(GetDistanceTestCases) + "South");
        yield return new TestCaseData(new object[] { 6, 26, 12, 26, 6 }).SetName(nameof(GetDistanceTestCases) + "West");
        yield return new TestCaseData(new object[] { 18, 26, 12, 26, 6 }).SetName(nameof(GetDistanceTestCases) + "East");
        yield return new TestCaseData(new object[] { 12, 24, 12, 26, 2 }).SetName(nameof(GetDistanceTestCases) + "NorthReversed");
        yield return new TestCaseData(new object[] { 12, 28, 12, 26, 2 }).SetName(nameof(GetDistanceTestCases) + "SouthReversed");
        yield return new TestCaseData(new object[] { 12, 26, 6, 26, 6 }).SetName(nameof(GetDistanceTestCases) + "WestReversed");
        yield return new TestCaseData(new object[] { 12, 26, 18, 26, 6 }).SetName(nameof(GetDistanceTestCases) + "EastReversed");
        yield return new TestCaseData(new object[] { 18, 26, 12, 32, 8 }).SetName(nameof(GetDistanceTestCases) + "NorthEast");
        yield return new TestCaseData(new object[] { 18, 26, 12, 20, 8 }).SetName(nameof(GetDistanceTestCases) + "NorthWest");
        yield return new TestCaseData(new object[] { 1, 1, 2, 2, 1 }).SetName(nameof(GetDistanceTestCases) + "Diagonal");
      }
    }

    #endregion Public Properties

    #region Public Methods

    [Test]
    [TestCaseSource(nameof(GeometryTests.DoesPointIntersectCircleStructTestCaseData))]
    public void DoesPointIntersectCircleStructTestCases(Point point, Point center, int radius, bool expected)
    {
      // arrange
      bool actual;

      // act
      actual = Geometry.DoesPointIntersectCircle(point, center, radius);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(GeometryTests.DoesPointIntersectCircleTestCaseData))]
    public void DoesPointIntersectCircleTestCases(int x, int y, int cx, int cy, int r, bool expected)
    {
      // arrange
      bool actual;

      // act
      actual = Geometry.DoesPointIntersectCircle(x, y, cx, cy, r);

      // assert
      Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(nameof(GeometryTests.GetDistanceTestCaseData))]
    public void GetDistanceTestCases(int x1, int y1, int x2, int y2, int expected)
    {
      // arrange
      int actual;

      // act
      actual = Geometry.GetDistance(x1, y1, x2, y2);

      // assert
      Assert.AreEqual(expected, actual);
    }

    #endregion Public Methods
  }
}