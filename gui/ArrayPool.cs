using Cyotek.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

// Copyright © 2016-2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek
{
  internal sealed class ArrayPool<T> : IDisposable
  {
    #region Private Fields

    private static ArrayPool<T> _shared;

    private readonly object _lock = new object();

    private readonly Dictionary<int, Stack<T[]>> _pool;

    #endregion Private Fields

    #region Public Constructors

    public ArrayPool()
    {
      _pool = new Dictionary<int, Stack<T[]>>();
    }

    #endregion Public Constructors

    #region Public Properties

    public static ArrayPool<T> Shared
    {
      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      get
      {
        return Volatile.Read(ref _shared) ?? ArrayPool<T>.EnsureSharedCreated();
      }
    }

    #endregion Public Properties

    #region Public Methods

    public T[] Allocate(int size)
    {
      T[] result;

      if (size < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(size), "Must be positive.");
      }

      if (size != 0)
      {
        result = null;

        if (_pool.TryGetValue(size, out Stack<T[]> candidates))
        {
          lock (candidates)
          {
            if (candidates.Count != 0)
            {
              result = candidates.Pop();
            }
          }
        }

        if (result == null)
        {
          result = new T[size];
        }
      }
      else
      {
        result = EmptyArray<T>.Empty;
      }

      return result;
    }

    public void Clear()
    {
      lock (_lock)
      {
        _pool.Clear();
      }
    }

    public void Dispose()
    {
      this.Clear();
    }

    public void Free(T[] array)
    {
      if (array == null)
      {
        throw new ArgumentNullException(nameof(array));
      }

      if (array.Length != 0)
      {
        if (!_pool.TryGetValue(array.Length, out Stack<T[]> candidates))
        {
          lock (_lock)
          {
            if (!_pool.TryGetValue(array.Length, out candidates))
            {
              _pool.Add(array.Length, candidates = new Stack<T[]>());
            }
          }
        }

        lock (candidates)
        {
          candidates.Push(array);
        }
      }
    }

    #endregion Public Methods

    #region Private Methods

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ArrayPool<T> EnsureSharedCreated()
    {
      Interlocked.CompareExchange(ref _shared, new ArrayPool<T>(), null);

      return _shared;
    }

    #endregion Private Methods
  }
}