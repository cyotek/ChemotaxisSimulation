using System.Text;
using Enc = System.Text.Encoding;

namespace Cyotek.ChemotaxisSimulation
{
  internal static class Encoding
  {
    #region Private Fields

    private static readonly Enc _utf8bomless = new UTF8Encoding(false);

    #endregion Private Fields

    #region Public Properties

    public static Enc UTF8NoIdentifier
    {
      get { return _utf8bomless; }
    }

    #endregion Public Properties
  }
}