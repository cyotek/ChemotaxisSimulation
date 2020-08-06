// Copyright © 2015 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Collections
{
  public static class EmptyArray<T>
  {
    #region Constants

    private static readonly T[] _empty = new T[0];

    #endregion

    #region Static Properties

    public static T[] Empty
    {
      get { return _empty; }
    }

    #endregion
  }
}
