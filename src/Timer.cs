using System;
using System.ComponentModel;
using System.Threading;

namespace Cyotek.Demo
{
  [DefaultEvent(nameof(Timer.Tick))]
  [DefaultProperty(nameof(Timer.Interval))]
  internal class Timer : Component
  {
    #region Private Fields

    private static readonly object _eventTick = new object();

    private bool _enabled;

    private int _interval;

    private System.Threading.Timer _timer;

    #endregion Private Fields

    #region Public Constructors

    public Timer()
    {
      _interval = 100;
    }

    public Timer(int interval)
      : this()
    {
      _interval = interval;
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Property Changed")]
    public event EventHandler Tick
    {
      add
      {
        this.Events.AddHandler(_eventTick, value);
      }
      remove
      {
        this.Events.RemoveHandler(_eventTick, value);
      }
    }

    #endregion Public Events

    #region Public Properties

    [DefaultValue(false)]
    [Category("Behavior")]
    public bool Enabled
    {
      get { return _enabled; }
      set
      {
        if (_enabled != value)
        {
          if (value)
          {
            this.Start();
          }
          else
          {
            this.Stop();
          }
        }
      }
    }

    [DefaultValue(100)]
    [Category("Behavior")]
    public int Interval
    {
      get { return _interval; }
      set
      {
        if (_interval != value)
        {
          _interval = value;
          _timer?.Change(0, value);
        }
      }
    }

    #endregion Public Properties

    #region Public Methods

    public void Restart()
    {
      this.Stop();
      this.Start();
    }

    public void Start()
    {
      _enabled = true;
      _timer = new System.Threading.Timer(this.TimerCallback, null, 0, _interval);
    }

    public void Stop()
    {
      _timer?.Change(Timeout.Infinite, Timeout.Infinite);
      _enabled = false;
    }

    #endregion Public Methods

    #region Protected Methods

    protected override void Dispose(bool disposing)
    {
      if (disposing && _timer != null)
      {
        _timer.Change(Timeout.Infinite, Timeout.Infinite);
        _timer.Dispose();
        _timer = null;
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Raises the <see cref="Tick" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnTick(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventTick];

      handler?.Invoke(this, e);
    }

    #endregion Protected Methods

    #region Private Methods

    private void TimerCallback(object state)
    {
      _timer.Change(Timeout.Infinite, Timeout.Infinite);

      this.OnTick(EventArgs.Empty);

      _timer?.Change(_interval, _interval);
    }

    #endregion Private Methods
  }
}