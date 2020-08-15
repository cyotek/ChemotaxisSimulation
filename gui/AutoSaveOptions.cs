namespace Cyotek.Demo.ChemotaxisSimulation
{
  internal class AutoSaveOptions
  {
    #region Private Fields

    private bool _enabled;

    private string _saveFolder;

    #endregion Private Fields

    #region Public Properties

    public bool Enabled
    {
      get { return _enabled; }
      set { _enabled = value; }
    }

    public string SaveFolder
    {
      get { return _saveFolder; }
      set { _saveFolder = value; }
    }

    #endregion Public Properties
  }
}