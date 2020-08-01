using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design;

// Copyright © 2009-2016 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Windows.Forms.ToolStripControllerHosts
{
  [DefaultProperty("Value")]
  [DefaultEvent("ValueChanged")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
  public class ToolStripTrackBar : ToolStripControlHost
  {
    #region Private Fields

    private static readonly object _eventValueChanged = new object();

    #endregion Private Fields

    #region Public Constructors

    public ToolStripTrackBar()
      : base(ToolStripTrackBar.CreateControlInstance())
    {
      base.AutoToolTip = true;
    }

    #endregion Public Constructors

    #region Public Events

    [Category("Property Changed")]
    public event EventHandler ValueChanged
    {
      add { this.Events.AddHandler(_eventValueChanged, value); }
      remove { this.Events.RemoveHandler(_eventValueChanged, value); }
    }

    #endregion Public Events

    #region Public Properties

    [DefaultValue(true)]
    public new bool AutoToolTip
    {
      get { return base.AutoToolTip; }
      set { base.AutoToolTip = value; }
    }

    [DefaultValue(5)]
    [Category("Behavior")]
    public int LargeChange
    {
      get { return this.TrackBar.LargeChange; }
      set { this.TrackBar.LargeChange = value; }
    }

    [DefaultValue(10)]
    [Category("Behavior")]
    public int Maximum
    {
      get { return this.TrackBar.Maximum; }
      set { this.TrackBar.Maximum = value; }
    }

    [DefaultValue(0)]
    [Category("Behavior")]
    public int Minimum
    {
      get { return this.TrackBar.Minimum; }
      set { this.TrackBar.Minimum = value; }
    }

    [DefaultValue(1)]
    [Category("Behavior")]
    public int SmallChange
    {
      get { return this.TrackBar.SmallChange; }
      set { this.TrackBar.SmallChange = value; }
    }

    [Browsable(false)]
    public override string Text
    {
      get { return base.Text; }
      set { base.Text = value; }
    }

    [DefaultValue(1)]
    [Category("Appearance")]
    public int TickFrequency
    {
      get { return this.TrackBar.TickFrequency; }
      set { this.TrackBar.TickFrequency = value; }
    }

    [DefaultValue(typeof(TickStyle), "BottomRight")]
    [Category("Appearance")]
    public TickStyle TickStyle
    {
      get { return this.TrackBar.TickStyle; }
      set { this.TrackBar.TickStyle = value; }
    }

    [Browsable(false)]
    public TrackBar TrackBar
    {
      get { return this.Control as TrackBar; }
    }

    [DefaultValue(0)]
    [Category("Behavior")]
    public int Value
    {
      get { return this.TrackBar.Value; }
      set { this.TrackBar.Value = value; }
    }

    #endregion Public Properties

    #region Protected Properties

    protected override Size DefaultSize
    {
      get { return new Size(200, 16); }
    }

    #endregion Protected Properties

    #region Protected Methods

    protected override void OnBoundsChanged()
    {
      base.OnBoundsChanged();

      this.TrackBar.Size = this.Bounds.Size;
    }

    protected override void OnSubscribeControlEvents(Control control)
    {
      ((TrackBar)control).ValueChanged += this.TrackbarValueChangedHandler;

      base.OnSubscribeControlEvents(control);
    }

    protected override void OnUnsubscribeControlEvents(Control control)
    {
      ((TrackBar)control).ValueChanged -= this.TrackbarValueChangedHandler;

      base.OnUnsubscribeControlEvents(control);
    }

    /// <summary>
    /// Raises the <see cref="ValueChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnValueChanged(EventArgs e)
    {
      EventHandler handler;

      this.Text = this.Value.ToString(CultureInfo.InvariantCulture);

      handler = (EventHandler)this.Events[_eventValueChanged];

      handler?.Invoke(this, e);
    }

    #endregion Protected Methods

    #region Private Methods

    private static TrackBar CreateControlInstance()
    {
      return new TrackBar
      {
        AutoSize = false,
        Height = 16,
        Maximum = 10,
        Minimum = 0,
        TickFrequency = 1,
        Value = 0,
        LargeChange = 5,
        SmallChange = 1,
        TickStyle = TickStyle.BottomRight
      };
    }

    private void TrackbarValueChangedHandler(object sender, EventArgs e)
    {
      this.OnValueChanged(EventArgs.Empty);
    }

    #endregion Private Methods
  }
}