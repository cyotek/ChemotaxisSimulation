namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal static class Filters
  {
    #region Public Fields

    public const string AllFiles = "All Files (*.*)|*.*";

    public const string General = Filters.Simulation + "|" + Filters.ScriptFiles + "|" + Filters.AllFiles;

    public const string ScriptFiles = "Script Files (*.js)|*.js";

    public const string Simulation = "Simulation Files (*.sim)|*.sim";

    #endregion Public Fields
  }
}