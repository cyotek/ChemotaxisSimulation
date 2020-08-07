using NUnit.Framework;

namespace Cyotek.ChemotaxisSimulation.Tests
{
  internal static class SimulationAssert
  {
    #region Public Methods

    public static void AreEqual(Simulation expected, Simulation actual)
    {
      Assert.AreEqual(expected.AttractorCollisionAction, actual.AttractorCollisionAction, nameof(Simulation.AttractorCollisionAction) + " does not match.");
      Assert.AreEqual(expected.Attrition, actual.Attrition, nameof(Simulation.Attrition) + " does not match.");
      Assert.AreEqual(expected.BinaryFission, actual.BinaryFission, nameof(Simulation.BinaryFission) + " does not match.");
      Assert.AreEqual(expected.EnvironmentSeed, actual.EnvironmentSeed, nameof(Simulation.EnvironmentSeed) + " does not match.");
      Assert.AreEqual(expected.Iteration, actual.Iteration, nameof(Simulation.Iteration) + " does not match.");
      Assert.AreEqual(expected.MaximumAttractorStrength, actual.MaximumAttractorStrength, nameof(Simulation.MaximumAttractorStrength) + " does not match.");
      Assert.AreEqual(expected.MaximumRepellentStrength, actual.MaximumRepellentStrength, nameof(Simulation.MaximumRepellentStrength) + " does not match.");
      Assert.AreEqual(expected.MinimumAttractorStrength, actual.MinimumAttractorStrength, nameof(Simulation.MinimumAttractorStrength) + " does not match.");
      Assert.AreEqual(expected.MinimumRepellentStrength, actual.MinimumRepellentStrength, nameof(Simulation.MinimumRepellentStrength) + " does not match.");
      Assert.AreEqual(expected.MobileRepellents, actual.MobileRepellents, nameof(Simulation.MobileRepellents) + " does not match.");
      Assert.AreEqual(expected.MovementSeed, actual.MovementSeed, nameof(Simulation.MovementSeed) + " does not match.");
      Assert.AreEqual(expected.RepellentCollisionAction, actual.RepellentCollisionAction, nameof(Simulation.RepellentCollisionAction) + " does not match.");
      Assert.AreEqual(expected.RespawnAttractor, actual.RespawnAttractor, nameof(Simulation.RespawnAttractor) + " does not match.");
      Assert.AreEqual(expected.Size, actual.Size, nameof(Simulation.Size) + " does not match.");
      Assert.AreEqual(expected.SolidStrands, actual.SolidStrands, nameof(Simulation.SolidStrands) + " does not match.");
      Assert.AreEqual(expected.Wrap, actual.Wrap, nameof(Simulation.Wrap) + " does not match.");

      SimulationAssert.AreEqual(expected.Attractors, actual.Attractors);
      SimulationAssert.AreEqual(expected.Repellents, actual.Repellents);
      SimulationAssert.AreEqual(expected.Strands, actual.Strands);
    }

    public static void AreEqual(ChemoeffectorCollection expected, ChemoeffectorCollection actual)
    {
      Assert.AreEqual(expected.Count, actual.Count);

      for (int i = 0; i < expected.Count; i++)
      {
        SimulationAssert.AreEqual(expected[i], actual[i]);
      }
    }

    public static void AreEqual(Chemoeffector expected, Chemoeffector actual)
    {
      Assert.AreEqual(expected.Heading, actual.Heading, nameof(Chemoeffector.Heading) + " does not match.");
      Assert.AreEqual(expected.Position, actual.Position, nameof(Chemoeffector.Position) + " does not match.");
      Assert.AreEqual(expected.Strength, actual.Strength, nameof(Chemoeffector.Strength) + " does not match.");
    }

    public static void AreEqual(StrandCollection expected, StrandCollection actual)
    {
      Assert.AreEqual(expected.Count, actual.Count);

      for (int i = 0; i < expected.Count; i++)
      {
        SimulationAssert.AreEqual(expected[i], actual[i]);
      }
    }

    public static void AreEqual(Strand expected, Strand actual)
    {
      Assert.AreEqual(expected.Heading, actual.Heading, nameof(Strand.Heading) + " does not match.");
      Assert.AreEqual(expected.Position, actual.Position, nameof(Strand.Position) + " does not match.");
      Assert.AreEqual(expected.Strength, actual.Strength, nameof(Strand.Strength) + " does not match.");
      Assert.AreEqual(expected.Generation, actual.Generation, nameof(Strand.Generation) + " does not match.");
      Assert.AreEqual(expected.PreviousSensor, actual.PreviousSensor, nameof(Strand.PreviousSensor) + " does not match.");
      CollectionAssert.AreEqual(expected.PreviousPositions.ToArray(), actual.PreviousPositions.ToArray(), nameof(Strand.PreviousPositions) + " does not match.");
    }

    #endregion Public Methods
  }
}