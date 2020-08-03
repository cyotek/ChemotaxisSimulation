namespace Cyotek.Demo
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      Cyotek.Windows.Forms.Line line;
      Cyotek.Windows.Forms.Line line1;
      Cyotek.Windows.Forms.Line line2;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.bacteriaStrandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.bacteriaStrandTailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.foodSourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.foodSourceDetectionZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.noxiousSourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.noxiousSourceDetectionZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.nextMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
      this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
      this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.scaleToolStripTrackBar = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripTrackBar();
      this.nextMoveToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.playToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.pauseToolStripButton = new System.Windows.Forms.ToolStripButton();
      this.speedToolStripTrackBar = new Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripTrackBar();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.standsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.attractorsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.repellentsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.renderPanel = new Cyotek.Demo.Windows.Forms.BufferedPanel();
      this.splitContainer = new System.Windows.Forms.SplitContainer();
      this.setupGroupBox = new System.Windows.Forms.GroupBox();
      this.repellentCollisionModeComboBox = new System.Windows.Forms.ComboBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.attractorCollisionModeComboBox = new System.Windows.Forms.ComboBox();
      this.maximumRepellentSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.minimumRepellentSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.maximumAttractorSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.minimumAttractorSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.movementSeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.initializeButton = new System.Windows.Forms.Button();
      this.environmentSeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.repellentsNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.attractorsNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label2 = new System.Windows.Forms.Label();
      this.strandsNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.timer = new Cyotek.Demo.Timer();
      this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
      this.simulationToolStrip = new System.Windows.Forms.ToolStrip();
      this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
      this.respawnAttractorsCheckBox = new System.Windows.Forms.CheckBox();
      this.allowBinaryFissionCheckBox = new System.Windows.Forms.CheckBox();
      line = new Cyotek.Windows.Forms.Line();
      line1 = new Cyotek.Windows.Forms.Line();
      line2 = new Cyotek.Windows.Forms.Line();
      this.menuStrip.SuspendLayout();
      this.toolStrip.SuspendLayout();
      this.statusStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
      this.splitContainer.Panel1.SuspendLayout();
      this.splitContainer.Panel2.SuspendLayout();
      this.splitContainer.SuspendLayout();
      this.setupGroupBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.maximumRepellentSizeNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minimumRepellentSizeNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.maximumAttractorSizeNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.minimumAttractorSizeNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.movementSeedNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.environmentSeedNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repellentsNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.attractorsNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.strandsNumericUpDown)).BeginInit();
      this.toolStripContainer.ContentPanel.SuspendLayout();
      this.toolStripContainer.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer.SuspendLayout();
      this.simulationToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // line
      // 
      line.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      line.Location = new System.Drawing.Point(9, 71);
      line.Name = "line";
      line.Size = new System.Drawing.Size(277, 2);
      line.Text = "line1";
      // 
      // line1
      // 
      line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      line1.Location = new System.Drawing.Point(6, 170);
      line1.Name = "line1";
      line1.Size = new System.Drawing.Size(277, 2);
      line1.Text = "line1";
      // 
      // line2
      // 
      line2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      line2.Location = new System.Drawing.Point(9, 243);
      line2.Name = "line2";
      line2.Size = new System.Drawing.Size(277, 2);
      line2.Text = "line2";
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.simulationToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(1008, 24);
      this.menuStrip.TabIndex = 0;
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
      this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.newToolStripMenuItem.Text = "&New";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
      this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.openToolStripMenuItem.Text = "&Open";
      // 
      // toolStripSeparator
      // 
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
      this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.saveAsToolStripMenuItem.Text = "Save &As";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
      // 
      // printToolStripMenuItem
      // 
      this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
      this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printToolStripMenuItem.Name = "printToolStripMenuItem";
      this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
      this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.printToolStripMenuItem.Text = "&Print";
      // 
      // printPreviewToolStripMenuItem
      // 
      this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
      this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
      this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
      this.editToolStripMenuItem.Text = "&Edit";
      // 
      // undoToolStripMenuItem
      // 
      this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
      this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
      this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.undoToolStripMenuItem.Text = "&Undo";
      // 
      // redoToolStripMenuItem
      // 
      this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
      this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
      this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.redoToolStripMenuItem.Text = "&Redo";
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
      // 
      // cutToolStripMenuItem
      // 
      this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
      this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
      this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
      this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.cutToolStripMenuItem.Text = "Cu&t";
      // 
      // copyToolStripMenuItem
      // 
      this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
      this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
      this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.copyToolStripMenuItem.Text = "&Copy";
      // 
      // pasteToolStripMenuItem
      // 
      this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
      this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
      this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
      this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.pasteToolStripMenuItem.Text = "&Paste";
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
      // 
      // selectAllToolStripMenuItem
      // 
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
      this.selectAllToolStripMenuItem.Text = "Select &All";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bacteriaStrandsToolStripMenuItem,
            this.bacteriaStrandTailsToolStripMenuItem,
            this.foodSourcesToolStripMenuItem,
            this.foodSourceDetectionZonesToolStripMenuItem,
            this.noxiousSourcesToolStripMenuItem,
            this.noxiousSourceDetectionZonesToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.viewToolStripMenuItem.Text = "&View";
      // 
      // bacteriaStrandsToolStripMenuItem
      // 
      this.bacteriaStrandsToolStripMenuItem.Checked = true;
      this.bacteriaStrandsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.bacteriaStrandsToolStripMenuItem.Name = "bacteriaStrandsToolStripMenuItem";
      this.bacteriaStrandsToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.bacteriaStrandsToolStripMenuItem.Text = "Bacteria &Strands";
      this.bacteriaStrandsToolStripMenuItem.Click += new System.EventHandler(this.BacteriaStrandsToolStripMenuItem_Click);
      // 
      // bacteriaStrandTailsToolStripMenuItem
      // 
      this.bacteriaStrandTailsToolStripMenuItem.Checked = true;
      this.bacteriaStrandTailsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.bacteriaStrandTailsToolStripMenuItem.Name = "bacteriaStrandTailsToolStripMenuItem";
      this.bacteriaStrandTailsToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.bacteriaStrandTailsToolStripMenuItem.Text = "Bacteria Strand &Tails";
      this.bacteriaStrandTailsToolStripMenuItem.Click += new System.EventHandler(this.BacteriaStrandTailsToolStripMenuItem_Click);
      // 
      // foodSourcesToolStripMenuItem
      // 
      this.foodSourcesToolStripMenuItem.Checked = true;
      this.foodSourcesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.foodSourcesToolStripMenuItem.Name = "foodSourcesToolStripMenuItem";
      this.foodSourcesToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.foodSourcesToolStripMenuItem.Text = "&Food Sources";
      this.foodSourcesToolStripMenuItem.Click += new System.EventHandler(this.FoodSourcesToolStripMenuItem_Click);
      // 
      // foodSourceDetectionZonesToolStripMenuItem
      // 
      this.foodSourceDetectionZonesToolStripMenuItem.Checked = true;
      this.foodSourceDetectionZonesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.foodSourceDetectionZonesToolStripMenuItem.Name = "foodSourceDetectionZonesToolStripMenuItem";
      this.foodSourceDetectionZonesToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.foodSourceDetectionZonesToolStripMenuItem.Text = "Food Source &Detection Zones";
      this.foodSourceDetectionZonesToolStripMenuItem.Click += new System.EventHandler(this.FoodSourceDetectionZonesToolStripMenuItem_Click);
      // 
      // noxiousSourcesToolStripMenuItem
      // 
      this.noxiousSourcesToolStripMenuItem.Checked = true;
      this.noxiousSourcesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.noxiousSourcesToolStripMenuItem.Name = "noxiousSourcesToolStripMenuItem";
      this.noxiousSourcesToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.noxiousSourcesToolStripMenuItem.Text = "&Noxious Sources";
      this.noxiousSourcesToolStripMenuItem.Click += new System.EventHandler(this.NoxiousSourcesToolStripMenuItem_Click);
      // 
      // noxiousSourceDetectionZonesToolStripMenuItem
      // 
      this.noxiousSourceDetectionZonesToolStripMenuItem.Checked = true;
      this.noxiousSourceDetectionZonesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
      this.noxiousSourceDetectionZonesToolStripMenuItem.Name = "noxiousSourceDetectionZonesToolStripMenuItem";
      this.noxiousSourceDetectionZonesToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
      this.noxiousSourceDetectionZonesToolStripMenuItem.Text = "N&oxious Source Detection Zones";
      this.noxiousSourceDetectionZonesToolStripMenuItem.Click += new System.EventHandler(this.NoxiousSourceDetectionZonesToolStripMenuItem_Click);
      // 
      // simulationToolStripMenuItem
      // 
      this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.toolStripMenuItem1,
            this.nextMoveToolStripMenuItem});
      this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
      this.simulationToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
      this.simulationToolStripMenuItem.Text = "&Simulation";
      // 
      // runToolStripMenuItem
      // 
      this.runToolStripMenuItem.Image = global::Cyotek.Demo.EColiSimulation.Properties.Resources.Play;
      this.runToolStripMenuItem.Name = "runToolStripMenuItem";
      this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.runToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.runToolStripMenuItem.Text = "&Run";
      this.runToolStripMenuItem.Click += new System.EventHandler(this.PlayToolStripButton_Click);
      // 
      // pauseToolStripMenuItem
      // 
      this.pauseToolStripMenuItem.Image = global::Cyotek.Demo.EColiSimulation.Properties.Resources.Pause;
      this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
      this.pauseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
      this.pauseToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.pauseToolStripMenuItem.Text = "&Pause";
      this.pauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripButton_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 6);
      // 
      // nextMoveToolStripMenuItem
      // 
      this.nextMoveToolStripMenuItem.Image = global::Cyotek.Demo.EColiSimulation.Properties.Resources.Next;
      this.nextMoveToolStripMenuItem.Name = "nextMoveToolStripMenuItem";
      this.nextMoveToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
      this.nextMoveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.nextMoveToolStripMenuItem.Text = "&Next Move";
      this.nextMoveToolStripMenuItem.Click += new System.EventHandler(this.NextMoveToolStripButton_Click);
      // 
      // toolsToolStripMenuItem
      // 
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      // 
      // customizeToolStripMenuItem
      // 
      this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
      this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
      this.customizeToolStripMenuItem.Text = "&Customize";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
      this.optionsToolStripMenuItem.Text = "&Options";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      // 
      // contentsToolStripMenuItem
      // 
      this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
      this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.contentsToolStripMenuItem.Text = "&Contents";
      // 
      // indexToolStripMenuItem
      // 
      this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
      this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.indexToolStripMenuItem.Text = "&Index";
      // 
      // searchToolStripMenuItem
      // 
      this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
      this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.searchToolStripMenuItem.Text = "&Search";
      // 
      // toolStripSeparator5
      // 
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
      // 
      // toolStrip
      // 
      this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator6,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator7,
            this.helpToolStripButton,
            this.scaleToolStripTrackBar});
      this.toolStrip.Location = new System.Drawing.Point(3, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size(312, 25);
      this.toolStrip.TabIndex = 0;
      // 
      // newToolStripButton
      // 
      this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
      this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.newToolStripButton.Name = "newToolStripButton";
      this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.newToolStripButton.Text = "&New";
      // 
      // openToolStripButton
      // 
      this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
      this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.openToolStripButton.Name = "openToolStripButton";
      this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.openToolStripButton.Text = "&Open";
      // 
      // saveToolStripButton
      // 
      this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
      this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.saveToolStripButton.Name = "saveToolStripButton";
      this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.saveToolStripButton.Text = "&Save";
      // 
      // printToolStripButton
      // 
      this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
      this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.printToolStripButton.Name = "printToolStripButton";
      this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.printToolStripButton.Text = "&Print";
      // 
      // toolStripSeparator6
      // 
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
      // 
      // cutToolStripButton
      // 
      this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
      this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cutToolStripButton.Name = "cutToolStripButton";
      this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.cutToolStripButton.Text = "C&ut";
      // 
      // copyToolStripButton
      // 
      this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
      this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.copyToolStripButton.Name = "copyToolStripButton";
      this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.copyToolStripButton.Text = "&Copy";
      // 
      // pasteToolStripButton
      // 
      this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
      this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pasteToolStripButton.Name = "pasteToolStripButton";
      this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.pasteToolStripButton.Text = "&Paste";
      // 
      // toolStripSeparator7
      // 
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
      // 
      // helpToolStripButton
      // 
      this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
      this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.helpToolStripButton.Name = "helpToolStripButton";
      this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.helpToolStripButton.Text = "He&lp";
      // 
      // scaleToolStripTrackBar
      // 
      this.scaleToolStripTrackBar.LargeChange = 10;
      this.scaleToolStripTrackBar.Maximum = 100;
      this.scaleToolStripTrackBar.Minimum = 1;
      this.scaleToolStripTrackBar.Name = "scaleToolStripTrackBar";
      this.scaleToolStripTrackBar.Size = new System.Drawing.Size(104, 22);
      this.scaleToolStripTrackBar.Text = "20";
      this.scaleToolStripTrackBar.TickFrequency = 10;
      this.scaleToolStripTrackBar.Value = 20;
      this.scaleToolStripTrackBar.ValueChanged += new System.EventHandler(this.ScaleToolStripTrackBar_ValueChanged);
      // 
      // nextMoveToolStripButton
      // 
      this.nextMoveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.nextMoveToolStripButton.Image = global::Cyotek.Demo.EColiSimulation.Properties.Resources.Next;
      this.nextMoveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.nextMoveToolStripButton.Name = "nextMoveToolStripButton";
      this.nextMoveToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.nextMoveToolStripButton.Text = "Next Move";
      this.nextMoveToolStripButton.Click += new System.EventHandler(this.NextMoveToolStripButton_Click);
      // 
      // playToolStripButton
      // 
      this.playToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.playToolStripButton.Image = global::Cyotek.Demo.EColiSimulation.Properties.Resources.Play;
      this.playToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.playToolStripButton.Name = "playToolStripButton";
      this.playToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.playToolStripButton.Text = "Play";
      this.playToolStripButton.Click += new System.EventHandler(this.PlayToolStripButton_Click);
      // 
      // pauseToolStripButton
      // 
      this.pauseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.pauseToolStripButton.Image = global::Cyotek.Demo.EColiSimulation.Properties.Resources.Pause;
      this.pauseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.pauseToolStripButton.Name = "pauseToolStripButton";
      this.pauseToolStripButton.Size = new System.Drawing.Size(23, 22);
      this.pauseToolStripButton.Text = "Pause";
      this.pauseToolStripButton.Click += new System.EventHandler(this.PauseToolStripButton_Click);
      // 
      // speedToolStripTrackBar
      // 
      this.speedToolStripTrackBar.LargeChange = 100;
      this.speedToolStripTrackBar.Maximum = 1000;
      this.speedToolStripTrackBar.Minimum = 1;
      this.speedToolStripTrackBar.Name = "speedToolStripTrackBar";
      this.speedToolStripTrackBar.Size = new System.Drawing.Size(104, 22);
      this.speedToolStripTrackBar.Text = "100";
      this.speedToolStripTrackBar.TickFrequency = 100;
      this.speedToolStripTrackBar.Value = 100;
      this.speedToolStripTrackBar.ValueChanged += new System.EventHandler(this.SpeedToolStripTrackBar_ValueChanged);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.standsToolStripStatusLabel,
            this.attractorsToolStripStatusLabel,
            this.repellentsToolStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 639);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(1008, 22);
      this.statusStrip.TabIndex = 2;
      // 
      // statusToolStripStatusLabel
      // 
      this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
      this.statusToolStripStatusLabel.Size = new System.Drawing.Size(954, 17);
      this.statusToolStripStatusLabel.Spring = true;
      this.statusToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // standsToolStripStatusLabel
      // 
      this.standsToolStripStatusLabel.Name = "standsToolStripStatusLabel";
      this.standsToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
      this.standsToolStripStatusLabel.Text = "0";
      // 
      // attractorsToolStripStatusLabel
      // 
      this.attractorsToolStripStatusLabel.Name = "attractorsToolStripStatusLabel";
      this.attractorsToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
      this.attractorsToolStripStatusLabel.Text = "0";
      // 
      // repellentsToolStripStatusLabel
      // 
      this.repellentsToolStripStatusLabel.Name = "repellentsToolStripStatusLabel";
      this.repellentsToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
      this.repellentsToolStripStatusLabel.Text = "0";
      // 
      // renderPanel
      // 
      this.renderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.renderPanel.Location = new System.Drawing.Point(0, 0);
      this.renderPanel.Name = "renderPanel";
      this.renderPanel.Size = new System.Drawing.Size(706, 565);
      this.renderPanel.TabIndex = 0;
      this.renderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RenderPanel_Paint);
      // 
      // splitContainer
      // 
      this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer.Location = new System.Drawing.Point(0, 0);
      this.splitContainer.Name = "splitContainer";
      // 
      // splitContainer.Panel1
      // 
      this.splitContainer.Panel1.Controls.Add(this.renderPanel);
      // 
      // splitContainer.Panel2
      // 
      this.splitContainer.Panel2.Controls.Add(this.setupGroupBox);
      this.splitContainer.Size = new System.Drawing.Size(1008, 565);
      this.splitContainer.SplitterDistance = 706;
      this.splitContainer.TabIndex = 0;
      // 
      // setupGroupBox
      // 
      this.setupGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.setupGroupBox.Controls.Add(this.allowBinaryFissionCheckBox);
      this.setupGroupBox.Controls.Add(this.respawnAttractorsCheckBox);
      this.setupGroupBox.Controls.Add(this.repellentCollisionModeComboBox);
      this.setupGroupBox.Controls.Add(this.label10);
      this.setupGroupBox.Controls.Add(this.label11);
      this.setupGroupBox.Controls.Add(this.attractorCollisionModeComboBox);
      this.setupGroupBox.Controls.Add(line2);
      this.setupGroupBox.Controls.Add(this.maximumRepellentSizeNumericUpDown);
      this.setupGroupBox.Controls.Add(this.minimumRepellentSizeNumericUpDown);
      this.setupGroupBox.Controls.Add(this.label9);
      this.setupGroupBox.Controls.Add(this.label8);
      this.setupGroupBox.Controls.Add(this.label7);
      this.setupGroupBox.Controls.Add(this.maximumAttractorSizeNumericUpDown);
      this.setupGroupBox.Controls.Add(this.minimumAttractorSizeNumericUpDown);
      this.setupGroupBox.Controls.Add(this.label6);
      this.setupGroupBox.Controls.Add(line1);
      this.setupGroupBox.Controls.Add(this.movementSeedNumericUpDown);
      this.setupGroupBox.Controls.Add(this.label5);
      this.setupGroupBox.Controls.Add(line);
      this.setupGroupBox.Controls.Add(this.initializeButton);
      this.setupGroupBox.Controls.Add(this.environmentSeedNumericUpDown);
      this.setupGroupBox.Controls.Add(this.label4);
      this.setupGroupBox.Controls.Add(this.repellentsNumericUpDown);
      this.setupGroupBox.Controls.Add(this.label3);
      this.setupGroupBox.Controls.Add(this.attractorsNumericUpDown);
      this.setupGroupBox.Controls.Add(this.label2);
      this.setupGroupBox.Controls.Add(this.strandsNumericUpDown);
      this.setupGroupBox.Controls.Add(this.label1);
      this.setupGroupBox.Location = new System.Drawing.Point(2, 3);
      this.setupGroupBox.Name = "setupGroupBox";
      this.setupGroupBox.Size = new System.Drawing.Size(292, 337);
      this.setupGroupBox.TabIndex = 0;
      this.setupGroupBox.TabStop = false;
      this.setupGroupBox.Text = "Scenario Setup";
      // 
      // repellentCollisionModeComboBox
      // 
      this.repellentCollisionModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.repellentCollisionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.repellentCollisionModeComboBox.FormattingEnabled = true;
      this.repellentCollisionModeComboBox.Items.AddRange(new object[] {
            "Destroy Self",
            "Destroy Other",
            "Reduce Self",
            "Reduce Other"});
      this.repellentCollisionModeComboBox.Location = new System.Drawing.Point(171, 143);
      this.repellentCollisionModeComboBox.Name = "repellentCollisionModeComboBox";
      this.repellentCollisionModeComboBox.Size = new System.Drawing.Size(115, 21);
      this.repellentCollisionModeComboBox.TabIndex = 13;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(168, 76);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(37, 13);
      this.label10.TabIndex = 5;
      this.label10.Text = "Action";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(102, 76);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(35, 13);
      this.label11.TabIndex = 4;
      this.label11.Text = "Count";
      // 
      // attractorCollisionModeComboBox
      // 
      this.attractorCollisionModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.attractorCollisionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.attractorCollisionModeComboBox.FormattingEnabled = true;
      this.attractorCollisionModeComboBox.Items.AddRange(new object[] {
            "Destroy Self",
            "Destroy Other",
            "Reduce Self",
            "Reduce Other"});
      this.attractorCollisionModeComboBox.Location = new System.Drawing.Point(171, 117);
      this.attractorCollisionModeComboBox.Name = "attractorCollisionModeComboBox";
      this.attractorCollisionModeComboBox.Size = new System.Drawing.Size(115, 21);
      this.attractorCollisionModeComboBox.TabIndex = 10;
      // 
      // maximumRepellentSizeNumericUpDown
      // 
      this.maximumRepellentSizeNumericUpDown.Location = new System.Drawing.Point(171, 217);
      this.maximumRepellentSizeNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
      this.maximumRepellentSizeNumericUpDown.Name = "maximumRepellentSizeNumericUpDown";
      this.maximumRepellentSizeNumericUpDown.Size = new System.Drawing.Size(60, 20);
      this.maximumRepellentSizeNumericUpDown.TabIndex = 21;
      this.maximumRepellentSizeNumericUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
      // 
      // minimumRepellentSizeNumericUpDown
      // 
      this.minimumRepellentSizeNumericUpDown.Location = new System.Drawing.Point(105, 217);
      this.minimumRepellentSizeNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
      this.minimumRepellentSizeNumericUpDown.Name = "minimumRepellentSizeNumericUpDown";
      this.minimumRepellentSizeNumericUpDown.Size = new System.Drawing.Size(60, 20);
      this.minimumRepellentSizeNumericUpDown.TabIndex = 20;
      this.minimumRepellentSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(6, 219);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(98, 13);
      this.label9.TabIndex = 19;
      this.label9.Text = "Re&pellent Strength:";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(168, 175);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(27, 13);
      this.label8.TabIndex = 15;
      this.label8.Text = "Max";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(102, 175);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(24, 13);
      this.label7.TabIndex = 14;
      this.label7.Text = "Min";
      // 
      // maximumAttractorSizeNumericUpDown
      // 
      this.maximumAttractorSizeNumericUpDown.Location = new System.Drawing.Point(171, 191);
      this.maximumAttractorSizeNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
      this.maximumAttractorSizeNumericUpDown.Name = "maximumAttractorSizeNumericUpDown";
      this.maximumAttractorSizeNumericUpDown.Size = new System.Drawing.Size(60, 20);
      this.maximumAttractorSizeNumericUpDown.TabIndex = 18;
      this.maximumAttractorSizeNumericUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
      // 
      // minimumAttractorSizeNumericUpDown
      // 
      this.minimumAttractorSizeNumericUpDown.Location = new System.Drawing.Point(105, 191);
      this.minimumAttractorSizeNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
      this.minimumAttractorSizeNumericUpDown.Name = "minimumAttractorSizeNumericUpDown";
      this.minimumAttractorSizeNumericUpDown.Size = new System.Drawing.Size(60, 20);
      this.minimumAttractorSizeNumericUpDown.TabIndex = 17;
      this.minimumAttractorSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 193);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(93, 13);
      this.label6.TabIndex = 16;
      this.label6.Text = "Attra&ctor Strength:";
      // 
      // movementSeedNumericUpDown
      // 
      this.movementSeedNumericUpDown.Location = new System.Drawing.Point(109, 45);
      this.movementSeedNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
      this.movementSeedNumericUpDown.Name = "movementSeedNumericUpDown";
      this.movementSeedNumericUpDown.Size = new System.Drawing.Size(77, 20);
      this.movementSeedNumericUpDown.TabIndex = 3;
      this.movementSeedNumericUpDown.Value = new decimal(new int[] {
            1622,
            0,
            0,
            0});
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 47);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(88, 13);
      this.label5.TabIndex = 2;
      this.label5.Text = "&Movement Seed:";
      // 
      // initializeButton
      // 
      this.initializeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.initializeButton.Location = new System.Drawing.Point(211, 308);
      this.initializeButton.Name = "initializeButton";
      this.initializeButton.Size = new System.Drawing.Size(75, 23);
      this.initializeButton.TabIndex = 18;
      this.initializeButton.Text = "&Initialise";
      this.initializeButton.UseVisualStyleBackColor = true;
      this.initializeButton.Click += new System.EventHandler(this.InitializeButton_Click);
      // 
      // environmentSeedNumericUpDown
      // 
      this.environmentSeedNumericUpDown.Location = new System.Drawing.Point(109, 19);
      this.environmentSeedNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
      this.environmentSeedNumericUpDown.Name = "environmentSeedNumericUpDown";
      this.environmentSeedNumericUpDown.Size = new System.Drawing.Size(77, 20);
      this.environmentSeedNumericUpDown.TabIndex = 1;
      this.environmentSeedNumericUpDown.Value = new decimal(new int[] {
            20200803,
            0,
            0,
            0});
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 21);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(97, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "E&nvironment Seed:";
      // 
      // repellentsNumericUpDown
      // 
      this.repellentsNumericUpDown.Location = new System.Drawing.Point(105, 144);
      this.repellentsNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.repellentsNumericUpDown.Name = "repellentsNumericUpDown";
      this.repellentsNumericUpDown.Size = new System.Drawing.Size(60, 20);
      this.repellentsNumericUpDown.TabIndex = 12;
      this.repellentsNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 146);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(60, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "&Repellents:";
      // 
      // attractorsNumericUpDown
      // 
      this.attractorsNumericUpDown.Location = new System.Drawing.Point(105, 118);
      this.attractorsNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.attractorsNumericUpDown.Name = "attractorsNumericUpDown";
      this.attractorsNumericUpDown.Size = new System.Drawing.Size(60, 20);
      this.attractorsNumericUpDown.TabIndex = 9;
      this.attractorsNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 120);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "&Attractors:";
      // 
      // strandsNumericUpDown
      // 
      this.strandsNumericUpDown.Location = new System.Drawing.Point(105, 92);
      this.strandsNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.strandsNumericUpDown.Name = "strandsNumericUpDown";
      this.strandsNumericUpDown.Size = new System.Drawing.Size(60, 20);
      this.strandsNumericUpDown.TabIndex = 7;
      this.strandsNumericUpDown.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 94);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(46, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "St&rands:";
      // 
      // timer
      // 
      this.timer.Tick += new System.EventHandler(this.Timer_Tick);
      // 
      // toolStripContainer
      // 
      // 
      // toolStripContainer.ContentPanel
      // 
      this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer);
      this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1008, 565);
      this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStripContainer.Location = new System.Drawing.Point(0, 24);
      this.toolStripContainer.Name = "toolStripContainer";
      this.toolStripContainer.Size = new System.Drawing.Size(1008, 615);
      this.toolStripContainer.TabIndex = 1;
      // 
      // toolStripContainer.TopToolStripPanel
      // 
      this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
      this.toolStripContainer.TopToolStripPanel.Controls.Add(this.simulationToolStrip);
      // 
      // simulationToolStrip
      // 
      this.simulationToolStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.simulationToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripButton,
            this.pauseToolStripButton,
            this.toolStripSeparator8,
            this.nextMoveToolStripButton,
            this.toolStripSeparator9,
            this.speedToolStripTrackBar});
      this.simulationToolStrip.Location = new System.Drawing.Point(3, 25);
      this.simulationToolStrip.Name = "simulationToolStrip";
      this.simulationToolStrip.Size = new System.Drawing.Size(197, 25);
      this.simulationToolStrip.TabIndex = 1;
      // 
      // toolStripSeparator8
      // 
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripSeparator9
      // 
      this.toolStripSeparator9.Name = "toolStripSeparator9";
      this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
      // 
      // respawnAttractorsCheckBox
      // 
      this.respawnAttractorsCheckBox.AutoSize = true;
      this.respawnAttractorsCheckBox.Checked = true;
      this.respawnAttractorsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.respawnAttractorsCheckBox.Location = new System.Drawing.Point(9, 251);
      this.respawnAttractorsCheckBox.Name = "respawnAttractorsCheckBox";
      this.respawnAttractorsCheckBox.Size = new System.Drawing.Size(119, 17);
      this.respawnAttractorsCheckBox.TabIndex = 22;
      this.respawnAttractorsCheckBox.Text = "Respa&wn Attractors";
      this.respawnAttractorsCheckBox.UseVisualStyleBackColor = true;
      // 
      // allowBinaryFissionCheckBox
      // 
      this.allowBinaryFissionCheckBox.AutoSize = true;
      this.allowBinaryFissionCheckBox.Location = new System.Drawing.Point(9, 274);
      this.allowBinaryFissionCheckBox.Name = "allowBinaryFissionCheckBox";
      this.allowBinaryFissionCheckBox.Size = new System.Drawing.Size(118, 17);
      this.allowBinaryFissionCheckBox.TabIndex = 23;
      this.allowBinaryFissionCheckBox.Text = "Allow &Binary Fission";
      this.allowBinaryFissionCheckBox.UseVisualStyleBackColor = true;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1008, 661);
      this.Controls.Add(this.toolStripContainer);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.menuStrip);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip;
      this.MaximizeBox = true;
      this.MinimizeBox = true;
      this.Name = "MainForm";
      this.ShowIcon = true;
      this.ShowInTaskbar = true;
      this.Text = "Form1";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.splitContainer.Panel1.ResumeLayout(false);
      this.splitContainer.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
      this.splitContainer.ResumeLayout(false);
      this.setupGroupBox.ResumeLayout(false);
      this.setupGroupBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.maximumRepellentSizeNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minimumRepellentSizeNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.maximumAttractorSizeNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.minimumAttractorSizeNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.movementSeedNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.environmentSeedNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repellentsNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.attractorsNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.strandsNumericUpDown)).EndInit();
      this.toolStripContainer.ContentPanel.ResumeLayout(false);
      this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
      this.toolStripContainer.TopToolStripPanel.PerformLayout();
      this.toolStripContainer.ResumeLayout(false);
      this.toolStripContainer.PerformLayout();
      this.simulationToolStrip.ResumeLayout(false);
      this.simulationToolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.ToolStripButton newToolStripButton;
    private System.Windows.Forms.ToolStripButton openToolStripButton;
    private System.Windows.Forms.ToolStripButton saveToolStripButton;
    private System.Windows.Forms.ToolStripButton printToolStripButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    private System.Windows.Forms.ToolStripButton cutToolStripButton;
    private System.Windows.Forms.ToolStripButton copyToolStripButton;
    private System.Windows.Forms.ToolStripButton pasteToolStripButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    private System.Windows.Forms.ToolStripButton helpToolStripButton;
    private System.Windows.Forms.StatusStrip statusStrip;
    private Cyotek.Demo.Windows.Forms.BufferedPanel renderPanel;
    private System.Windows.Forms.SplitContainer splitContainer;
    private System.Windows.Forms.ToolStripButton nextMoveToolStripButton;
    private Cyotek.Demo.Timer timer;
    private Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripTrackBar scaleToolStripTrackBar;
    private System.Windows.Forms.ToolStripButton playToolStripButton;
    private System.Windows.Forms.ToolStripButton pauseToolStripButton;
    private Cyotek.Windows.Forms.ToolStripControllerHosts.ToolStripTrackBar speedToolStripTrackBar;
    private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem nextMoveToolStripMenuItem;
    private System.Windows.Forms.ToolStripContainer toolStripContainer;
    private System.Windows.Forms.ToolStrip simulationToolStrip;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem bacteriaStrandsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem bacteriaStrandTailsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem foodSourcesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem foodSourceDetectionZonesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem noxiousSourcesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem noxiousSourceDetectionZonesToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel standsToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel attractorsToolStripStatusLabel;
    private System.Windows.Forms.ToolStripStatusLabel repellentsToolStripStatusLabel;
    private System.Windows.Forms.GroupBox setupGroupBox;
    private System.Windows.Forms.NumericUpDown environmentSeedNumericUpDown;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown repellentsNumericUpDown;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown attractorsNumericUpDown;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown strandsNumericUpDown;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button initializeButton;
    private System.Windows.Forms.NumericUpDown movementSeedNumericUpDown;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown maximumAttractorSizeNumericUpDown;
    private System.Windows.Forms.NumericUpDown minimumAttractorSizeNumericUpDown;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown maximumRepellentSizeNumericUpDown;
    private System.Windows.Forms.NumericUpDown minimumRepellentSizeNumericUpDown;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox attractorCollisionModeComboBox;
    private System.Windows.Forms.ComboBox repellentCollisionModeComboBox;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.CheckBox allowBinaryFissionCheckBox;
    private System.Windows.Forms.CheckBox respawnAttractorsCheckBox;
  }
}

