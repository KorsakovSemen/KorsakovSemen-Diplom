﻿namespace SystAnalys_lr1
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.matrixGrid = new MetroFramework.Controls.MetroGrid();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new MetroFramework.Controls.MetroPanel();
            this.SavePictures = new MetroFramework.Controls.MetroCheckBox();
            this.label14 = new MetroFramework.Controls.MetroLabel();
            this.label13 = new MetroFramework.Controls.MetroLabel();
            this.optimize = new MetroFramework.Controls.MetroButton();
            this.mean = new MetroFramework.Controls.MetroLabel();
            this.optText = new MetroFramework.Controls.MetroTextBox();
            this.speed = new MetroFramework.Controls.MetroTextBox();
            this.stopBuses = new MetroFramework.Controls.MetroButton();
            this.launchBuses = new MetroFramework.Controls.MetroButton();
            this.panel2 = new MetroFramework.Controls.MetroPanel();
            this.createCoordinates = new MetroFramework.Controls.MetroButton();
            this.label7 = new MetroFramework.Controls.MetroLabel();
            this.textBox2 = new MetroFramework.Controls.MetroTextBox();
            this.button8 = new MetroFramework.Controls.MetroButton();
            this.changeProcent = new MetroFramework.Controls.MetroTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.panel8 = new MetroFramework.Controls.MetroPanel();
            this.label8 = new MetroFramework.Controls.MetroLabel();
            this.panel7 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.allBusSettings = new MetroFramework.Controls.MetroPanel();
            this.backsideCheck = new MetroFramework.Controls.MetroCheckBox();
            this.trackerCheck = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.busSize = new MetroFramework.Controls.MetroTextBox();
            this.changeRoute = new MetroFramework.Controls.MetroComboBox();
            this.busParkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.label12 = new MetroFramework.Controls.MetroLabel();
            this.theme = new MetroFramework.Controls.MetroLabel();
            this.changeTheme = new MetroFramework.Controls.MetroComboBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.createModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openEpicFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runTrafficLightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectButton = new System.Windows.Forms.ToolStripButton();
            this.drawVertexButton = new System.Windows.Forms.ToolStripButton();
            this.drawEdgeButton = new System.Windows.Forms.ToolStripButton();
            this.selectRoute = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.deleteALLButton = new System.Windows.Forms.ToolStripButton();
            this.deleteRoute = new System.Windows.Forms.ToolStripButton();
            this.addBus = new System.Windows.Forms.ToolStripButton();
            this.deleteBus = new System.Windows.Forms.ToolStripButton();
            this.delAllBusesOnRoute = new System.Windows.Forms.ToolStripButton();
            this.stopPointButton = new System.Windows.Forms.ToolStripButton();
            this.addTraficLight = new System.Windows.Forms.ToolStripButton();
            this.loading = new System.Windows.Forms.ToolStripProgressBar();
            this.msmMain = new MetroFramework.Components.MetroStyleManager(this.components);
            this.themes = new MetroFramework.Controls.MetroToggle();
            this.config = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.hint = new MetroFramework.Controls.MetroLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.allBusSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busParkBindingSource)).BeginInit();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msmMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // about
            // 
            resources.ApplyResources(this.about, "about");
            this.about.Name = "about";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // matrixGrid
            // 
            resources.ApplyResources(this.matrixGrid, "matrixGrid");
            this.matrixGrid.AllowUserToResizeRows = false;
            this.matrixGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.matrixGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.matrixGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.matrixGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.matrixGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.matrixGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matrixGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.matrixGrid.EnableHeadersVisualStyles = false;
            this.matrixGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.matrixGrid.Name = "matrixGrid";
            this.matrixGrid.ReadOnly = true;
            this.matrixGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.matrixGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.matrixGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.matrixGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SavePictures);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.optimize);
            this.panel1.Controls.Add(this.mean);
            this.panel1.Controls.Add(this.optText);
            this.panel1.Controls.Add(this.speed);
            this.panel1.HorizontalScrollbarBarColor = true;
            this.panel1.HorizontalScrollbarHighlightOnWheel = false;
            this.panel1.HorizontalScrollbarSize = 8;
            this.panel1.Name = "panel1";
            this.panel1.VerticalScrollbarBarColor = true;
            this.panel1.VerticalScrollbarHighlightOnWheel = false;
            this.panel1.VerticalScrollbarSize = 8;
            // 
            // SavePictures
            // 
            resources.ApplyResources(this.SavePictures, "SavePictures");
            this.SavePictures.Name = "SavePictures";
            this.SavePictures.UseSelectable = true;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // optimize
            // 
            resources.ApplyResources(this.optimize, "optimize");
            this.optimize.Name = "optimize";
            this.optimize.Style = MetroFramework.MetroColorStyle.Green;
            this.optimize.UseSelectable = true;
            this.optimize.Click += new System.EventHandler(this.optimize_Click);
            // 
            // mean
            // 
            resources.ApplyResources(this.mean, "mean");
            this.mean.Name = "mean";
            // 
            // optText
            // 
            resources.ApplyResources(this.optText, "optText");
            // 
            // 
            // 
            this.optText.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription");
            this.optText.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName");
            this.optText.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor")));
            this.optText.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize")));
            this.optText.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode")));
            this.optText.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage")));
            this.optText.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout")));
            this.optText.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock")));
            this.optText.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle")));
            this.optText.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font")));
            this.optText.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.optText.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign")));
            this.optText.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex")));
            this.optText.CustomButton.ImageKey = resources.GetString("resource.ImageKey");
            this.optText.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.optText.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.optText.CustomButton.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Margin")));
            this.optText.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize")));
            this.optText.CustomButton.Name = "";
            this.optText.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft")));
            this.optText.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.optText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.optText.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.optText.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign")));
            this.optText.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation")));
            this.optText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.optText.CustomButton.UseSelectable = true;
            this.optText.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.optText.Lines = new string[0];
            this.optText.MaxLength = 9;
            this.optText.Name = "optText";
            this.optText.PasswordChar = '\0';
            this.optText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.optText.SelectedText = "";
            this.optText.SelectionLength = 0;
            this.optText.SelectionStart = 0;
            this.optText.ShortcutsEnabled = true;
            this.optText.UseSelectable = true;
            this.optText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.optText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.optText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.optText_KeyPress);
            // 
            // speed
            // 
            resources.ApplyResources(this.speed, "speed");
            // 
            // 
            // 
            this.speed.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription1");
            this.speed.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName1");
            this.speed.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor1")));
            this.speed.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize1")));
            this.speed.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode1")));
            this.speed.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage1")));
            this.speed.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout1")));
            this.speed.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock1")));
            this.speed.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle1")));
            this.speed.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font1")));
            this.speed.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.speed.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign1")));
            this.speed.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex1")));
            this.speed.CustomButton.ImageKey = resources.GetString("resource.ImageKey1");
            this.speed.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode1")));
            this.speed.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.speed.CustomButton.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Margin1")));
            this.speed.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize1")));
            this.speed.CustomButton.Name = "";
            this.speed.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft1")));
            this.speed.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.speed.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.speed.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.speed.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign1")));
            this.speed.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation1")));
            this.speed.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.speed.CustomButton.UseSelectable = true;
            this.speed.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
            this.speed.Lines = new string[0];
            this.speed.MaxLength = 9;
            this.speed.Name = "speed";
            this.speed.PasswordChar = '\0';
            this.speed.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.speed.SelectedText = "";
            this.speed.SelectionLength = 0;
            this.speed.SelectionStart = 0;
            this.speed.ShortcutsEnabled = true;
            this.speed.UseSelectable = true;
            this.speed.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.speed.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.speed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.speed_KeyPress);
            // 
            // stopBuses
            // 
            resources.ApplyResources(this.stopBuses, "stopBuses");
            this.stopBuses.Name = "stopBuses";
            this.stopBuses.UseSelectable = true;
            this.stopBuses.Click += new System.EventHandler(this.stopBuses_Click);
            // 
            // launchBuses
            // 
            resources.ApplyResources(this.launchBuses, "launchBuses");
            this.launchBuses.Name = "launchBuses";
            this.launchBuses.UseSelectable = true;
            this.launchBuses.Click += new System.EventHandler(this.launchBuses_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.createCoordinates);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.changeProcent);
            this.panel2.HorizontalScrollbarBarColor = true;
            this.panel2.HorizontalScrollbarHighlightOnWheel = false;
            this.panel2.HorizontalScrollbarSize = 8;
            this.panel2.Name = "panel2";
            this.panel2.VerticalScrollbarBarColor = true;
            this.panel2.VerticalScrollbarHighlightOnWheel = false;
            this.panel2.VerticalScrollbarSize = 8;
            // 
            // createCoordinates
            // 
            resources.ApplyResources(this.createCoordinates, "createCoordinates");
            this.createCoordinates.Name = "createCoordinates";
            this.createCoordinates.UseSelectable = true;
            this.createCoordinates.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            // 
            // 
            // 
            this.textBox2.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription2");
            this.textBox2.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName2");
            this.textBox2.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor2")));
            this.textBox2.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize2")));
            this.textBox2.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode2")));
            this.textBox2.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage2")));
            this.textBox2.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout2")));
            this.textBox2.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock2")));
            this.textBox2.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle2")));
            this.textBox2.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font2")));
            this.textBox2.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.textBox2.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign2")));
            this.textBox2.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex2")));
            this.textBox2.CustomButton.ImageKey = resources.GetString("resource.ImageKey2");
            this.textBox2.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode2")));
            this.textBox2.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
            this.textBox2.CustomButton.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Margin2")));
            this.textBox2.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize2")));
            this.textBox2.CustomButton.Name = "";
            this.textBox2.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft2")));
            this.textBox2.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
            this.textBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox2.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
            this.textBox2.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign2")));
            this.textBox2.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation2")));
            this.textBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox2.CustomButton.UseSelectable = true;
            this.textBox2.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible2")));
            this.textBox2.Lines = new string[0];
            this.textBox2.MaxLength = 9;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.UseSelectable = true;
            this.textBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // button8
            // 
            resources.ApplyResources(this.button8, "button8");
            this.button8.Name = "button8";
            this.button8.UseSelectable = true;
            this.button8.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // changeProcent
            // 
            resources.ApplyResources(this.changeProcent, "changeProcent");
            // 
            // 
            // 
            this.changeProcent.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription3");
            this.changeProcent.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName3");
            this.changeProcent.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor3")));
            this.changeProcent.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize3")));
            this.changeProcent.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode3")));
            this.changeProcent.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage3")));
            this.changeProcent.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout3")));
            this.changeProcent.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock3")));
            this.changeProcent.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle3")));
            this.changeProcent.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font3")));
            this.changeProcent.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.changeProcent.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign3")));
            this.changeProcent.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex3")));
            this.changeProcent.CustomButton.ImageKey = resources.GetString("resource.ImageKey3");
            this.changeProcent.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode3")));
            this.changeProcent.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location3")));
            this.changeProcent.CustomButton.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Margin3")));
            this.changeProcent.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize3")));
            this.changeProcent.CustomButton.Name = "";
            this.changeProcent.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft3")));
            this.changeProcent.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size3")));
            this.changeProcent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.changeProcent.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex3")));
            this.changeProcent.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign3")));
            this.changeProcent.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation3")));
            this.changeProcent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.changeProcent.CustomButton.UseSelectable = true;
            this.changeProcent.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible3")));
            this.changeProcent.Lines = new string[0];
            this.changeProcent.MaxLength = 9;
            this.changeProcent.Name = "changeProcent";
            this.changeProcent.PasswordChar = '\0';
            this.changeProcent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.changeProcent.SelectedText = "";
            this.changeProcent.SelectionLength = 0;
            this.changeProcent.SelectionStart = 0;
            this.changeProcent.ShortcutsEnabled = true;
            this.changeProcent.UseSelectable = true;
            this.changeProcent.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.changeProcent.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.BackColor = System.Drawing.SystemColors.Menu;
            this.panel4.Controls.Add(this.metroLabel8);
            this.panel4.Controls.Add(this.metroLabel6);
            this.panel4.Controls.Add(this.metroLabel5);
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.metroTrackBar1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.HorizontalScrollbarBarColor = true;
            this.panel4.HorizontalScrollbarHighlightOnWheel = false;
            this.panel4.HorizontalScrollbarSize = 8;
            this.panel4.Name = "panel4";
            this.panel4.VerticalScrollbarBarColor = true;
            this.panel4.VerticalScrollbarHighlightOnWheel = false;
            this.panel4.VerticalScrollbarSize = 8;
            // 
            // metroLabel8
            // 
            resources.ApplyResources(this.metroLabel8, "metroLabel8");
            this.metroLabel8.Name = "metroLabel8";
            // 
            // metroLabel6
            // 
            resources.ApplyResources(this.metroLabel6, "metroLabel6");
            this.metroLabel6.Name = "metroLabel6";
            // 
            // metroLabel5
            // 
            resources.ApplyResources(this.metroLabel5, "metroLabel5");
            this.metroLabel5.Name = "metroLabel5";
            // 
            // panel8
            // 
            resources.ApplyResources(this.panel8, "panel8");
            this.panel8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.button1);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.matrixGrid);
            this.panel8.HorizontalScrollbarBarColor = true;
            this.panel8.HorizontalScrollbarHighlightOnWheel = false;
            this.panel8.HorizontalScrollbarSize = 8;
            this.panel8.Name = "panel8";
            this.panel8.VerticalScrollbarBarColor = true;
            this.panel8.VerticalScrollbarHighlightOnWheel = false;
            this.panel8.VerticalScrollbarSize = 8;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // panel7
            // 
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel7.Controls.Add(this.metroLabel4);
            this.panel7.Controls.Add(this.metroLabel3);
            this.panel7.Controls.Add(this.allBusSettings);
            this.panel7.Controls.Add(this.changeRoute);
            this.panel7.HorizontalScrollbarBarColor = true;
            this.panel7.HorizontalScrollbarHighlightOnWheel = false;
            this.panel7.HorizontalScrollbarSize = 8;
            this.panel7.Name = "panel7";
            this.panel7.VerticalScrollbarBarColor = true;
            this.panel7.VerticalScrollbarHighlightOnWheel = false;
            this.panel7.VerticalScrollbarSize = 8;
            // 
            // metroLabel4
            // 
            resources.ApplyResources(this.metroLabel4, "metroLabel4");
            this.metroLabel4.Name = "metroLabel4";
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.Name = "metroLabel3";
            // 
            // allBusSettings
            // 
            resources.ApplyResources(this.allBusSettings, "allBusSettings");
            this.allBusSettings.BackColor = System.Drawing.Color.DimGray;
            this.allBusSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.allBusSettings.Controls.Add(this.backsideCheck);
            this.allBusSettings.Controls.Add(this.stopBuses);
            this.allBusSettings.Controls.Add(this.launchBuses);
            this.allBusSettings.Controls.Add(this.trackerCheck);
            this.allBusSettings.Controls.Add(this.metroLabel2);
            this.allBusSettings.Controls.Add(this.busSize);
            this.allBusSettings.HorizontalScrollbarBarColor = true;
            this.allBusSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.allBusSettings.HorizontalScrollbarSize = 13;
            this.allBusSettings.Name = "allBusSettings";
            this.allBusSettings.Style = MetroFramework.MetroColorStyle.Blue;
            this.allBusSettings.UseStyleColors = true;
            this.allBusSettings.VerticalScrollbarBarColor = true;
            this.allBusSettings.VerticalScrollbarHighlightOnWheel = false;
            this.allBusSettings.VerticalScrollbarSize = 13;
            // 
            // backsideCheck
            // 
            resources.ApplyResources(this.backsideCheck, "backsideCheck");
            this.backsideCheck.Name = "backsideCheck";
            this.backsideCheck.UseSelectable = true;
            // 
            // trackerCheck
            // 
            resources.ApplyResources(this.trackerCheck, "trackerCheck");
            this.trackerCheck.Name = "trackerCheck";
            this.trackerCheck.UseSelectable = true;
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            // 
            // busSize
            // 
            resources.ApplyResources(this.busSize, "busSize");
            // 
            // 
            // 
            this.busSize.CustomButton.AccessibleDescription = resources.GetString("resource.AccessibleDescription4");
            this.busSize.CustomButton.AccessibleName = resources.GetString("resource.AccessibleName4");
            this.busSize.CustomButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor4")));
            this.busSize.CustomButton.AutoSize = ((bool)(resources.GetObject("resource.AutoSize4")));
            this.busSize.CustomButton.AutoSizeMode = ((System.Windows.Forms.AutoSizeMode)(resources.GetObject("resource.AutoSizeMode4")));
            this.busSize.CustomButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage4")));
            this.busSize.CustomButton.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout4")));
            this.busSize.CustomButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock4")));
            this.busSize.CustomButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("resource.FlatStyle4")));
            this.busSize.CustomButton.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font4")));
            this.busSize.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.busSize.CustomButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.ImageAlign4")));
            this.busSize.CustomButton.ImageIndex = ((int)(resources.GetObject("resource.ImageIndex4")));
            this.busSize.CustomButton.ImageKey = resources.GetString("resource.ImageKey4");
            this.busSize.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode4")));
            this.busSize.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location4")));
            this.busSize.CustomButton.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("resource.Margin4")));
            this.busSize.CustomButton.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize4")));
            this.busSize.CustomButton.Name = "";
            this.busSize.CustomButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft4")));
            this.busSize.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size4")));
            this.busSize.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.busSize.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex4")));
            this.busSize.CustomButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.TextAlign4")));
            this.busSize.CustomButton.TextImageRelation = ((System.Windows.Forms.TextImageRelation)(resources.GetObject("resource.TextImageRelation4")));
            this.busSize.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.busSize.CustomButton.UseSelectable = true;
            this.busSize.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible4")));
            this.busSize.Lines = new string[0];
            this.busSize.MaxLength = 9;
            this.busSize.Name = "busSize";
            this.busSize.PasswordChar = '\0';
            this.busSize.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.busSize.SelectedText = "";
            this.busSize.SelectionLength = 0;
            this.busSize.SelectionStart = 0;
            this.busSize.ShortcutsEnabled = true;
            this.busSize.UseSelectable = true;
            this.busSize.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.busSize.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.busSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.busSize_KeyPress);
            // 
            // changeRoute
            // 
            resources.ApplyResources(this.changeRoute, "changeRoute");
            this.changeRoute.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.busParkBindingSource, "Date", true));
            this.changeRoute.FormattingEnabled = true;
            this.changeRoute.Name = "changeRoute";
            this.changeRoute.UseSelectable = true;
            this.changeRoute.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChangedAsync);
            // 
            // busParkBindingSource
            // 
            this.busParkBindingSource.DataSource = typeof(SystAnalys_lr1.Bus);
            // 
            // metroTrackBar1
            // 
            resources.ApplyResources(this.metroTrackBar1, "metroTrackBar1");
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.LargeChange = 1;
            this.metroTrackBar1.Maximum = 3;
            this.metroTrackBar1.Minimum = 1;
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Value = 1;
            this.metroTrackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar1_ScrollAsync);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // theme
            // 
            resources.ApplyResources(this.theme, "theme");
            this.theme.Name = "theme";
            // 
            // changeTheme
            // 
            resources.ApplyResources(this.changeTheme, "changeTheme");
            this.changeTheme.FormattingEnabled = true;
            this.changeTheme.Items.AddRange(new object[] {
            resources.GetString("changeTheme.Items"),
            resources.GetString("changeTheme.Items1"),
            resources.GetString("changeTheme.Items2"),
            resources.GetString("changeTheme.Items3"),
            resources.GetString("changeTheme.Items4"),
            resources.GetString("changeTheme.Items5"),
            resources.GetString("changeTheme.Items6"),
            resources.GetString("changeTheme.Items7"),
            resources.GetString("changeTheme.Items8"),
            resources.GetString("changeTheme.Items9"),
            resources.GetString("changeTheme.Items10"),
            resources.GetString("changeTheme.Items11"),
            resources.GetString("changeTheme.Items12"),
            resources.GetString("changeTheme.Items13"),
            resources.GetString("changeTheme.Items14")});
            this.changeTheme.Name = "changeTheme";
            this.changeTheme.UseSelectable = true;
            this.changeTheme.SelectedIndexChanged += new System.EventHandler(this.changeTheme_SelectedIndexChanged);
            // 
            // mainPanel
            // 
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Controls.Add(this.sheet);
            this.mainPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel6_Scroll);
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // sheet
            // 
            resources.ApplyResources(this.sheet, "sheet");
            this.sheet.BackColor = System.Drawing.Color.White;
            this.sheet.Name = "sheet";
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick_1);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripMenu
            // 
            resources.ApplyResources(this.toolStripMenu, "toolStripMenu");
            this.toolStripMenu.BackColor = System.Drawing.Color.White;
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.loadButton,
            this.toolStripSeparator1,
            this.selectButton,
            this.drawVertexButton,
            this.drawEdgeButton,
            this.selectRoute,
            this.deleteButton,
            this.deleteALLButton,
            this.deleteRoute,
            this.addBus,
            this.deleteBus,
            this.delAllBusesOnRoute,
            this.stopPointButton,
            this.addTraficLight,
            this.toolStripSeparator2,
            this.loading});
            this.toolStripMenu.Name = "toolStripMenu";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createModelToolStripMenuItem,
            this.openEpicFormToolStripMenuItem,
            this.addRouteToolStripMenuItem,
            this.createGridToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveInToolStripMenuItem,
            this.runTrafficLightsToolStripMenuItem});
            this.saveButton.Name = "saveButton";
            // 
            // createModelToolStripMenuItem
            // 
            resources.ApplyResources(this.createModelToolStripMenuItem, "createModelToolStripMenuItem");
            this.createModelToolStripMenuItem.Name = "createModelToolStripMenuItem";
            this.createModelToolStripMenuItem.Click += new System.EventHandler(this.newModelToolStripMenuItem_Click);
            // 
            // openEpicFormToolStripMenuItem
            // 
            resources.ApplyResources(this.openEpicFormToolStripMenuItem, "openEpicFormToolStripMenuItem");
            this.openEpicFormToolStripMenuItem.Name = "openEpicFormToolStripMenuItem";
            this.openEpicFormToolStripMenuItem.Click += new System.EventHandler(this.openEpicFormToolStripMenuItem_Click);
            // 
            // addRouteToolStripMenuItem
            // 
            resources.ApplyResources(this.addRouteToolStripMenuItem, "addRouteToolStripMenuItem");
            this.addRouteToolStripMenuItem.Name = "addRouteToolStripMenuItem";
            this.addRouteToolStripMenuItem.Click += new System.EventHandler(this.addRouteToolStripMenuItem_Click);
            // 
            // createGridToolStripMenuItem
            // 
            resources.ApplyResources(this.createGridToolStripMenuItem, "createGridToolStripMenuItem");
            this.createGridToolStripMenuItem.Name = "createGridToolStripMenuItem";
            this.createGridToolStripMenuItem.Click += new System.EventHandler(this.createGridToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveInToolStripMenuItem
            // 
            resources.ApplyResources(this.saveInToolStripMenuItem, "saveInToolStripMenuItem");
            this.saveInToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jSONToolStripMenuItem,
            this.xMLToolStripMenuItem});
            this.saveInToolStripMenuItem.Name = "saveInToolStripMenuItem";
            // 
            // jSONToolStripMenuItem
            // 
            resources.ApplyResources(this.jSONToolStripMenuItem, "jSONToolStripMenuItem");
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Click += new System.EventHandler(this.jSONToolStripMenuItem_Click);
            // 
            // xMLToolStripMenuItem
            // 
            resources.ApplyResources(this.xMLToolStripMenuItem, "xMLToolStripMenuItem");
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Click += new System.EventHandler(this.xMLToolStripMenuItem_Click);
            // 
            // runTrafficLightsToolStripMenuItem
            // 
            resources.ApplyResources(this.runTrafficLightsToolStripMenuItem, "runTrafficLightsToolStripMenuItem");
            this.runTrafficLightsToolStripMenuItem.Name = "runTrafficLightsToolStripMenuItem";
            this.runTrafficLightsToolStripMenuItem.Click += new System.EventHandler(this.runTrafficLightsToolStripMenuItem_Click);
            // 
            // loadButton
            // 
            resources.ApplyResources(this.loadButton, "loadButton");
            this.loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.loadFromToolStripMenuItem});
            this.loadButton.Name = "loadButton";
            // 
            // loadToolStripMenuItem
            // 
            resources.ApplyResources(this.loadToolStripMenuItem, "loadToolStripMenuItem");
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // loadFromToolStripMenuItem
            // 
            resources.ApplyResources(this.loadFromToolStripMenuItem, "loadFromToolStripMenuItem");
            this.loadFromToolStripMenuItem.Name = "loadFromToolStripMenuItem";
            this.loadFromToolStripMenuItem.Click += new System.EventHandler(this.loadFromToolStripMenuItem_Click);
            // 
            // selectButton
            // 
            resources.ApplyResources(this.selectButton, "selectButton");
            this.selectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectButton.Image = global::SystAnalys_lr1.Properties.Resources.cursor;
            this.selectButton.Name = "selectButton";
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // drawVertexButton
            // 
            resources.ApplyResources(this.drawVertexButton, "drawVertexButton");
            this.drawVertexButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawVertexButton.Image = global::SystAnalys_lr1.Properties.Resources.vertex;
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // drawEdgeButton
            // 
            resources.ApplyResources(this.drawEdgeButton, "drawEdgeButton");
            this.drawEdgeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawEdgeButton.Image = global::SystAnalys_lr1.Properties.Resources.edge;
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);
            // 
            // selectRoute
            // 
            resources.ApplyResources(this.selectRoute, "selectRoute");
            this.selectRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectRoute.Image = global::SystAnalys_lr1.Properties.Resources.oAexz;
            this.selectRoute.Name = "selectRoute";
            this.selectRoute.Click += new System.EventHandler(this.selectRoute_Click);
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = global::SystAnalys_lr1.Properties.Resources.delete;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteALLButton
            // 
            resources.ApplyResources(this.deleteALLButton, "deleteALLButton");
            this.deleteALLButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteALLButton.Image = global::SystAnalys_lr1.Properties.Resources.deleteAll;
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // deleteRoute
            // 
            resources.ApplyResources(this.deleteRoute, "deleteRoute");
            this.deleteRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteRoute.Image = global::SystAnalys_lr1.Properties.Resources.w450h4001385925290Delete;
            this.deleteRoute.Name = "deleteRoute";
            this.deleteRoute.Click += new System.EventHandler(this.deleteRoute_Click);
            // 
            // addBus
            // 
            resources.ApplyResources(this.addBus, "addBus");
            this.addBus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addBus.Image = global::SystAnalys_lr1.Properties.Resources.shkolnyy_avtobus;
            this.addBus.Name = "addBus";
            this.addBus.Click += new System.EventHandler(this.addBus_Click);
            // 
            // deleteBus
            // 
            resources.ApplyResources(this.deleteBus, "deleteBus");
            this.deleteBus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBus.Image = global::SystAnalys_lr1.Properties.Resources.del;
            this.deleteBus.Name = "deleteBus";
            this.deleteBus.Click += new System.EventHandler(this.deleteBus_Click);
            // 
            // delAllBusesOnRoute
            // 
            resources.ApplyResources(this.delAllBusesOnRoute, "delAllBusesOnRoute");
            this.delAllBusesOnRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delAllBusesOnRoute.Image = global::SystAnalys_lr1.Properties.Resources._99e4d3f57fb77729bbc061fbf3490f69;
            this.delAllBusesOnRoute.Name = "delAllBusesOnRoute";
            this.delAllBusesOnRoute.Click += new System.EventHandler(this.delAllBusesOnRoute_Click);
            // 
            // stopPointButton
            // 
            resources.ApplyResources(this.stopPointButton, "stopPointButton");
            this.stopPointButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopPointButton.Image = global::SystAnalys_lr1.Properties.Resources._0032_h_stop_logo_14;
            this.stopPointButton.Name = "stopPointButton";
            this.stopPointButton.Click += new System.EventHandler(this.gridButton_Click);
            // 
            // addTraficLight
            // 
            resources.ApplyResources(this.addTraficLight, "addTraficLight");
            this.addTraficLight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addTraficLight.Image = global::SystAnalys_lr1.Properties.Resources.be8183118c5eb3a97558d6ea6e648d8d;
            this.addTraficLight.Name = "addTraficLight";
            this.addTraficLight.Click += new System.EventHandler(this.addTraficLight_Click);
            // 
            // loading
            // 
            resources.ApplyResources(this.loading, "loading");
            this.loading.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.loading.Name = "loading";
            this.loading.Step = 1;
            // 
            // msmMain
            // 
            this.msmMain.Owner = this;
            // 
            // themes
            // 
            resources.ApplyResources(this.themes, "themes");
            this.themes.Name = "themes";
            this.themes.UseSelectable = true;
            this.themes.CheckedChanged += new System.EventHandler(this.themes_CheckedChanged);
            // 
            // config
            // 
            resources.ApplyResources(this.config, "config");
            this.config.Name = "config";
            // 
            // metroComboBox1
            // 
            resources.ApplyResources(this.metroComboBox1, "metroComboBox1");
            this.metroComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("metroComboBox1.AutoCompleteCustomSource"),
            resources.GetString("metroComboBox1.AutoCompleteCustomSource1")});
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // hint
            // 
            resources.ApplyResources(this.hint, "hint");
            this.hint.Name = "hint";
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hint);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.config);
            this.Controls.Add(this.themes);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.theme);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.changeTheme);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.matrixGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.allBusSettings.ResumeLayout(false);
            this.allBusSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.busParkBindingSource)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msmMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroGrid matrixGrid;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.BindingSource busParkBindingSource;
        private MetroFramework.Controls.MetroButton button8;
        private MetroFramework.Controls.MetroTextBox textBox2;
        private MetroFramework.Controls.MetroLabel label7;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private MetroFramework.Controls.MetroPanel panel2;
        private MetroFramework.Controls.MetroPanel panel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton selectButton;
        private System.Windows.Forms.ToolStripButton drawVertexButton;
        private System.Windows.Forms.ToolStripButton drawEdgeButton;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton deleteALLButton;
        private System.Windows.Forms.ToolStripButton deleteRoute;
        private System.Windows.Forms.ToolStripButton addBus;
        private System.Windows.Forms.ToolStripButton deleteBus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton saveButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton loadButton;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel label8;
        private MetroFramework.Controls.MetroButton optimize;
        private MetroFramework.Controls.MetroTextBox optText;
        private System.Windows.Forms.PictureBox sheet;
        private MetroFramework.Controls.MetroLabel mean;
        public System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripButton stopPointButton;
        private System.Windows.Forms.ToolStripButton delAllBusesOnRoute;
        private MetroFramework.Controls.MetroTextBox speed;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton addTraficLight;
        public System.Windows.Forms.ToolStripProgressBar loading;
        public System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton selectRoute;
        private System.Windows.Forms.ToolStripMenuItem openEpicFormToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel label14;
        private MetroFramework.Controls.MetroLabel label13;
        private System.Windows.Forms.ToolStripMenuItem addRouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGridToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel panel8;
        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroPanel panel1;
        private System.Windows.Forms.ToolStripMenuItem runTrafficLightsToolStripMenuItem;
        private MetroFramework.Components.MetroStyleManager msmMain;
        private MetroFramework.Controls.MetroToggle themes;
        private MetroFramework.Controls.MetroComboBox changeTheme;
        private MetroFramework.Controls.MetroLabel theme;
        private MetroFramework.Controls.MetroButton stopBuses;
        private MetroFramework.Controls.MetroButton launchBuses;
        private MetroFramework.Controls.MetroLabel config;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
        private MetroFramework.Controls.MetroCheckBox SavePictures;
        private MetroFramework.Controls.MetroTextBox changeProcent;
        private MetroFramework.Controls.MetroLabel hint;
        private MetroFramework.Controls.MetroButton createCoordinates;
        private MetroFramework.Controls.MetroPanel panel7;
        private MetroFramework.Controls.MetroPanel allBusSettings;
        private MetroFramework.Controls.MetroCheckBox backsideCheck;
        private MetroFramework.Controls.MetroCheckBox trackerCheck;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox busSize;
        public MetroFramework.Controls.MetroComboBox changeRoute;
        private MetroFramework.Controls.MetroLabel label12;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel8;
    }
}

