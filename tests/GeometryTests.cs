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

    #endregion Public Methods
  }
}