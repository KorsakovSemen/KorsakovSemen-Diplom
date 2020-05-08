﻿using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Newtonsoft.Json;
using SystAnalys_lr1.Classes;
using SystAnalys_lr1.Forms;
using SystAnalys_lr1.Strings;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

namespace SystAnalys_lr1
{
    public partial class Main : MetroForm
    {
        public enum DeleteType
        {
            None,
            TrafficLight,
            BusStops,
            VertexAndEdge,
            All,
            TheBuses
        }

        PictureBox AnimationBox;
        Graphics AnimationGraphics;
        Bitmap AnimationBitmap;
        Coordinates coordinates;
        Report r;
        CrossroadsSettings crossSettings;
        AddRoute addR;
        AddGrid addG;
        public EpicSettings epSet;
        LoadingForm loadingForm;
        readonly Constructor c = new Constructor();

        public static string average;
        public static DeleteType delType;
       
        public static string selectedRoute;
        public static int firstCrossRoads = 0;
        public static int firstCrossRoadsGreenLight = 0;
        public static int firstCrossRoadsRedLight = 0;
        public static int secondCrossRoads = 0;
        //временно тут УБИРАЙ
        public static string EpicSizeParamSave = "radioEpicMedium";       
        public static List<string> MovingEpicParamet;        
        public static string EpicFreqMovingSave = null;
        public static int EpicFreqMovingParam = 0;    
        public static string EpicFreqSpreadingSave = null;
        public static int EpicFreqSpreadingParam = 0;   
        public static string EpicPhaseSavingSave = null;
        public static int EpicPhaseSavingParam = 1;
        public static bool SavePictures = false;
        public static bool extendedSavePictures = false;
        //
        string savepath;          
        public static Classes.Grid g;   
        public static DrawGraph G;

        public static int selected1; //выбранные вершины, для соединения линиями
        public static int selected2;

        bool lang = false;

        delegate void Del(string text);
        delegate void DelInt(int text);
        delegate void DelBool(bool text);
        delegate void DelBmp(Bitmap bmp);

        Image saveImage;
        readonly Random rnd = new Random();

        //вторая форма
        static public DisplayEpicenters Ep;

        int wsheet;
        int hsheet;
        static public Image globalMap;
        static public int zoom, scrollX, scrollY;
        public static bool yes;

        int rCount;
        int oldChart;

        static public string globalDel = "All";
        public static int EpicSizeParam = 25;
        public static string saveF = "xml";        
        List<int> selected = new List<int>();
        static public int refreshLights = 0;
        public static bool flag = false;
     
       

        public Main()
        {
            // Если в настройках есть язык, устанавлияем его для текущего потока, в котором выполняется приложение.
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                // ВАЖНО: Устанавливать язык нужно до создания элементов формы!
                // Это можно сделать глобально, в рамках приложения в классе Program (см. файл Program.cs).
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }
            InitializeComponent();
            InitializeElements();
            LoadSettings();
            AnimationSettings();           

        }


        private void AddInComboBox()
        {
            changeRoute.Items.Clear();
            changeRoute.Items.Add(MainStrings.none);
            changeRoute.Items.Add(MainStrings.network);
            foreach (var r in Data.routes)
            {
                changeRoute.Items.Add(r.Key);
            };
            changeRoute.Text = MainStrings.network;
        }


        private void ConstructorOnNetwork()
        {
            addTraficLight.Enabled = true;
            delAllBusesOnRoute.Enabled = false;
            stopPointButton.Enabled = true; 
            allBusSettings.Enabled = false;
            drawEdgeButton.Enabled = true;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            deleteALLButton.Enabled = true;
            deleteRoute.Enabled = true;
            addBus.Enabled = false;
            deleteBus.Enabled = true;
            selectRoute.Enabled = true;
        }

        //class jopa
        private void InitializeElements()
        {
            MovingEpicParamet = new List<string>();
            timer.Interval = BusStop.stopTime / 10;
            r = new Report();
            loadingForm = new LoadingForm();
            rCount = 0;
            coordinates = new Coordinates();
            g = new Classes.Grid(0, 0, 0, 0, 80, 40);
           
            StyleManager = msmMain;
            addTraficLight.Enabled = false;
            delAllBusesOnRoute.Enabled = false;
            stopPointButton.Enabled = false;
            allBusSettings.Enabled = false;
            drawEdgeButton.Enabled = false;
            selectButton.Enabled = false;
            drawVertexButton.Enabled = false;
            deleteButton.Enabled = false;
            deleteALLButton.Enabled = false;
            deleteRoute.Enabled = false;
            addBus.Enabled = false;
            deleteBus.Enabled = false;
            selectRoute.Enabled = false;
            G = new DrawGraph();

            zoom = 1;
            scrollX = 0;
            scrollY = 0;

        }

        //class jopa
        private void LoadSettings()
        {
            if (File.Exists("../../SaveConfig/save.txt"))
            {
                using (FileStream fstream = File.OpenRead("../../SaveConfig/save.txt"))
                {
                    byte[] array = new byte[fstream.Length];
                    // асинхронное чтение файла
                    fstream.Read(array, 0, array.Length);
                    savepath = System.Text.Encoding.Default.GetString(array);
                    try
                    {
                        if (savepath != null && savepath.Length > 2 && Directory.Exists(savepath))
                        {
                            savepath = Path.GetFullPath(savepath);
                            try
                            {
                                if (Directory.Exists(savepath))
                                {
                                    Console.WriteLine(savepath);
                                    LoadRoutes(savepath + @"\");
                                }
                            }
                            catch (Exception exc)
                            {
                                StackTrace stackTrace = new StackTrace(exc, true);
                                if (stackTrace.FrameCount > 0)
                                {
                                    BringToFront();
                                    MetroMessageBox.Show(this, $"{exc.StackTrace}", MainStrings.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    catch
                    {
                        BringToFront();
                        MetroMessageBox.Show(this, MainStrings.errorPath, MainStrings.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Console.WriteLine($"Текст из файла: {savepath}");

                }
            }
            else
            {
                File.Create("../../SaveConfig/save.txt");
            }
            if (File.Exists("../../SaveConfig/theme.txt"))
            {
                using (FileStream fstream = File.OpenRead("../../SaveConfig/theme.txt"))
                {
                    byte[] array = new byte[fstream.Length];
                    // асинхронное чтение файла
                    fstream.Read(array, 0, array.Length);
                    if (System.Text.Encoding.Default.GetString(array) == "Dark\r\n")
                    {
                        msmMain.Theme = MetroThemeStyle.Dark;
                        toolStripMenu.BackColor = Color.FromArgb(17, 17, 17);
                        toolStripMenu.ForeColor = Color.FromArgb(153, 153, 153);
                        fstream.Close();
                        themes.Checked = true;
                    }
                    if (System.Text.Encoding.Default.GetString(array) == "Light\r\n")
                    {
                        msmMain.Theme = MetroThemeStyle.Light;
                        toolStripMenu.BackColor = Color.FromArgb(255, 255, 255);
                        toolStripMenu.ForeColor = Color.FromArgb(0, 0, 0);
                        fstream.Close();
                        themes.Checked = false;
                    }
                    if (System.Text.Encoding.Default.GetString(array) == "Default\r\n")
                    {
                        msmMain.Theme = MetroThemeStyle.Default;
                        toolStripMenu.BackColor = Color.FromArgb(255, 255, 255);
                        toolStripMenu.ForeColor = Color.FromArgb(0, 0, 0);
                        fstream.Close();
                        themes.Checked = false;
                    }
                    Console.WriteLine($"Текст из файла: {savepath}");

                }
            }
            else
            {
                File.Create("../../SaveConfig/theme.txt");
            }
            string text = "Default";
            if (File.Exists("../../SaveConfig/style.txt"))
            {
                using (FileStream fstream = File.OpenRead("../../SaveConfig/style.txt"))
                {
                    byte[] array = new byte[fstream.Length];
                    // асинхронное чтение файла
                    fstream.Read(array, 0, array.Length);
                    text = System.Text.Encoding.Default.GetString(array).Replace(Environment.NewLine, "");
                    msmMain.Style = (MetroFramework.MetroColorStyle)Convert.ToInt32(text);
                    Console.WriteLine($"Текст из файла: {savepath}");

                }
                changeTheme.SelectedIndex = Convert.ToInt32(text);
                //       changeTheme.Text = text;
            }
            else
            {
                File.Create("../../SaveConfig/style_text.txt");
            }
            if (sheet.Image == null)
            {
                addRouteToolStripMenuItem.Enabled = false;
                openEpicFormToolStripMenuItem.Enabled = false;
                createGridToolStripMenuItem.Enabled = false;
            }

            mainPanel.MaximumSize = new System.Drawing.Size(sheet.Width, sheet.Height);
            mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            mainPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(Panel6_MouseWheel);
            Optimization.countWithoutSensors = Data.buses.Count;
            matrix.MatrixCreate();
            hint.Visible = false;
            r.ch.Titles.Add(MainStrings.report);
            r.ch.Series[rCount].LegendText = "1";
        }
        //class jopa
        public void AnimationSettings()
        {

            AnimationBitmap = new Bitmap(sheet.Width, sheet.Height);
            AnimationBitmap.MakeTransparent();
            AnimationBox = new PictureBox
            {
                Image = AnimationBitmap
            };
            AnimationGraphics = Graphics.FromImage(AnimationBitmap);
            sheet.Controls.Add(AnimationBox);
            AnimationBox.SizeMode = sheet.SizeMode;
            AnimationBox.Location = new Point(0, 0);
            AnimationBox.BackColor = Color.Transparent;
            AnimationBox.Size = sheet.Size;
            AnimationBox.MouseClick += Sheet_MouseClick_1;
        }

        //class grid
        private void Panel6_MouseWheel(object sender, MouseEventArgs e)
        {
            Bus.ScrollX = mainPanel.AutoScrollPosition.X;
            Bus.ScrollY = mainPanel.AutoScrollPosition.Y;
        }
        private void Panel6_Scroll(object sender, ScrollEventArgs e)
        {

            Bus.ScrollX = mainPanel.AutoScrollPosition.X;
            Bus.ScrollY = mainPanel.AutoScrollPosition.Y;

        }

        private void Panel6_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(10, 10);
        }

        public Panel GetMainPanel()
        {
            return panelSettings;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            AddRoute f = new AddRoute
            {
                Owner = this
            };
            f.ShowDialog();
            Ep.ERefreshRouts();
        }

        //в textBox1 можно вводить только цифры
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }

        }

        //возвращает картинку карты(нужно для 2 формы)
        public PictureBox GetSheet()
        {
            return sheet;
        }
        public Panel GetMapPanel()
        {
            return mainPanel;
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            G.ClearSheet();
            G.DrawALLGraph(Data.V, Data.E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            GridCreator.DrawGrid(sheet);
        }

        private void AddBus_Click(object sender, EventArgs e)
        {
            addBus.Enabled = false;
            deleteBus.Enabled = true;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = false;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            allBusSettings.Enabled = true;
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selectRoute.Enabled = true;
            trafficLightLabel.Visible = false;
            selected = new List<int>();
            addTraficLight.Enabled = false;
            GridCreator.DrawGrid(sheet);
        }

        private void ButtonOn()
        {
            changeRoute.Invoke(new DelBool((s) => changeRoute.Enabled = s), true);
            optimize.Invoke(new DelBool((s) => optimize.Enabled = s), true);
            //.Invoke(new DelBool((s) => createCoordinates.Enabled = s), true);
            launchBuses.Invoke(new DelBool((s) => launchBuses.Enabled = s), true);
            stopBuses.Invoke(new DelBool((s) => launchBuses.Enabled = s), true);
            pollutionOptions.Invoke(new DelBool((s) => pollutionOptions.Enabled = s), true);
            toolStripMenu.Invoke((System.Action)(() =>
            {
                saveButton.Enabled = true;
                loadButton.Enabled = true;
            }));
        }
        private void ButtonOff()
        {
            changeRoute.Invoke(new DelBool((s) => changeRoute.Enabled = s), false);
            optimize.Invoke(new DelBool((s) => optimize.Enabled = s), false);
            //createCoordinates.Invoke(new DelBool((s) => createCoordinates.Enabled = s), false);
            launchBuses.Invoke(new DelBool((s) => launchBuses.Enabled = s), false);
            stopBuses.Invoke(new DelBool((s) => launchBuses.Enabled = s), false);
            pollutionOptions.Invoke(new DelBool((s) => pollutionOptions.Enabled = s), false);
            toolStripMenu.Invoke((System.Action)(() =>
            {
                saveButton.Enabled = false;
                loadButton.Enabled = false;
                selectButton.Enabled = false;
                drawVertexButton.Enabled = false;
                drawEdgeButton.Enabled = false;
                deleteButton.Enabled = false;
                deleteALLButton.Enabled = false;
                deleteRoute.Enabled = false;
                addBus.Enabled = false;
                deleteBus.Enabled = false;
                delAllBusesOnRoute.Enabled = false;
                stopPointButton.Enabled = false;
                addTraficLight.Enabled = false;
                selectRoute.Enabled = false;
            }));

        }
        private void DelBus()
        {
            deleteBus.Enabled = false;
            addBus.Enabled = true;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = false;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            allBusSettings.Enabled = false;
            addTraficLight.Enabled = false;
            selectRoute.Enabled = true;
            G.ClearSheet();
            G.DrawALLGraph(Data.V, Data.E);
            G.DrawALLGraph(Data.routes[(changeRoute.Text)], Data.routesEdge[(changeRoute.Text)], 1);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            stopPointButton.Enabled = true;
            selected = new List<int>();
            trafficLightLabel.Visible = false;
            GridCreator.DrawGrid(sheet);
            CheckBusesOnRoute();
        }
        //class zoom
        public static Image ResizeBitmap(Image sourceBMP, int width, int height)
        {

            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(sourceBMP, 0, 0, width, height);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            }
            return result;

        }

        public MetroTrackBar GetTrackBar()
        {
            return zoomBar;
        }

        public static string NormalizePath(string path)
        {
            return Path.GetFullPath(new Uri(path).LocalPath)
                       .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                       .ToUpperInvariant();
        }
        //class saver
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sheet.Image != null)
                {
                    string date = DateTime.Now.ToShortDateString() + ":-:" + DateTime.Now.ToLocalTime();
                    if (savepath != null)
                    {
                        if (!File.Exists(savepath + "/Map.png"))
                            saveImage.Save(savepath + "/Map.png", System.Drawing.Imaging.ImageFormat.Png);
                        SaveRoutes(saveF, savepath + @"\");
                        BringToFront();
                        MetroMessageBox.Show(this, "", MainStrings.done, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {

                        using (var dialog = new FolderBrowserDialog())
                        {
                            dialog.SelectedPath = System.Windows.Forms.Application.StartupPath;
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                string path = dialog.SelectedPath;
                                File.WriteAllText("../../SaveConfig/save.txt", string.Empty);
                                savepath = path + @"\" + string.Format("{0}_{1}_{2}_{3}_{4}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute);
                                Directory.CreateDirectory(savepath);
                                saveImage.Save(savepath + "/Map.png", System.Drawing.Imaging.ImageFormat.Png);
                                SaveRoutes(saveF, savepath + @"\");
                                using (StreamWriter fileV = new StreamWriter("../../SaveConfig/save.txt"))
                                {
                                    fileV.WriteLine(savepath.ToString());
                                }
                                BringToFront();
                                MetroMessageBox.Show(this, "", MainStrings.done, MessageBoxButtons.OK, MessageBoxIcon.Question);

                            }
                        }
                    }
                    config.Text = MainStrings.config + savepath;
                    stopPointButton.Enabled = true;
                }

            }
            catch (Exception exc)
            {
                StackTrace stackTrace = new StackTrace(exc, true);
                if (stackTrace.FrameCount > 0)
                {
                    MetroMessageBox.Show(this, $"{exc.StackTrace}", MainStrings.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
       
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            yes = false;
            DeleteForm df = new DeleteForm();
            StyleManager.Clone(df);
            if (changeRoute.Text == MainStrings.network)
            {
                df.theBuses.Enabled = false;
                allBusSettings.Enabled = false;
                addBus.Enabled = false;
                deleteBus.Enabled = false;
                drawEdgeButton.Enabled = true;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = true;
                deleteButton.Enabled = false;
                addTraficLight.Enabled = true;
                CheckBuses();
            };
            if (changeRoute.SelectedIndex > 1)
            {
                df.theBuses.Enabled = true;
                allBusSettings.Enabled = false;
                addBus.Enabled = true;
                deleteBus.Enabled = true;
                drawEdgeButton.Enabled = true;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = false;
                deleteButton.Enabled = false;
                addTraficLight.Enabled = false;
                G.DrawALLGraph(Data.routes[(changeRoute.Text)], Data.routesEdge[(changeRoute.Text)], 1);
                CheckBusesOnRoute();
            }
            df.ShowDialog();
            trafficLightLabel.Text = globalDel;
            trafficLightLabel.Visible = true;
            selected = new List<int>();
            selectRoute.Enabled = true;
            stopPointButton.Enabled = true;
            sheet.Image = G.GetBitmap();
            GridCreator.DrawGrid(sheet);
            if (delType == DeleteType.None)
                deleteButton.Enabled = true;

        }


        private void DrawVertexButton_Click(object sender, EventArgs e)
        {
            deleteBus.Enabled = false;
            addBus.Enabled = false;
            allBusSettings.Enabled = false;
            drawVertexButton.Enabled = false;
            Console.WriteLine("DrawVert");
            selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.ClearSheet();
            G.DrawALLGraph(Data.V, Data.E);
            selectRoute.Enabled = true;
            sheet.Image = G.GetBitmap();
            stopPointButton.Enabled = true;
            trafficLightLabel.Visible = false;
            addTraficLight.Enabled = true;
            GridCreator.DrawGrid(sheet);
            selected = new List<int>();
        }
        //class constructor
        private void DeleteRoute_Click(object sender, EventArgs e)
        {
            try
            {
                LoadingForm loadingForm = new LoadingForm();
                loadingForm.loading.Value = 0;
                loadingForm.loading.Maximum = 100;
                allBusSettings.Enabled = false;
                addBus.Enabled = true;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = true;
                drawEdgeButton.Enabled = true;
                deleteButton.Enabled = true;
                string message = MainStrings.deleteGraph;
                string caption = MainStrings.delete;
                var MBSave = MetroMessageBox.Show(this, message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (Data.routes != null && Data.routesEdge != null && Data.E != null && Data.V != null && Data.buses != null)
                {
                    if (MBSave == DialogResult.Yes && changeRoute.Text != "" && changeRoute.Text != MainStrings.network)
                    {
                        loadingForm.Show();
                        List<Bus> busTest = new List<Bus>();
                        loadingForm.loading.Value = 20;
                        foreach (var b in Data.buses)
                        {
                            if (b.Route == changeRoute.Text)
                            {
                                // mainPanel.Controls.Remove(b.busPic);
                                busTest.Add(b);
                            };
                        };
                        loadingForm.loading.Value = 40;
                        foreach (var b in busTest)
                        {
                            Data.buses.Remove(b);
                        }

                        Data.routes.Remove(changeRoute.Text);
                        Data.routesEdge.Remove(changeRoute.Text);
                        Data.AllCoordinates.Remove(changeRoute.Text);
                        AddInComboBox();
                        changeRoute.Text = changeRoute.Items[0].ToString();
                        G.ClearSheet();
                        G.DrawALLGraph(Data.V, Data.E);
                        sheet.Image = G.GetBitmap();
                        GridCreator.DrawGrid(sheet);
                        loadingForm.loading.Value = 60;
                    }
                    else
                    {
                        loadingForm.close = true;
                        loadingForm.Close();
                    }
                    if (MBSave == DialogResult.Yes && changeRoute.Text == MainStrings.network)
                    {
                        loadingForm = new LoadingForm();
                        loadingForm.Show();
                        loadingForm.loading.Value = 20;
                        Data.buses.Clear();
                        addBus.Enabled = false;
                        deleteBus.Enabled = false;
                        loadingForm.loading.Value = 40;
                        Data.V.Clear();
                        Data.E.Clear();
                        addTraficLight.Enabled = true;
                        Data.routes.Clear();
                        Data.routesEdge.Clear();
                        AddInComboBox();
                        Data.AllCoordinates.Clear();
                        G.ClearSheet();
                        G.DrawALLGraph(Data.V, Data.E);
                        sheet.Image = G.GetBitmap();
                        GridCreator.DrawGrid(sheet);
                        CheckBuses();
                        loadingForm.loading.Value = 60;
                    }
                    else
                    {
                        loadingForm.close = true;
                        loadingForm.Close();
                    }
                }
                if (changeRoute.Text == MainStrings.network)
                {
                    deleteBus.Enabled = false;
                    addBus.Enabled = false;
                    drawVertexButton.Enabled = true;
                    addTraficLight.Enabled = true;
                };
                loadingForm.loading.Value = 70;
                trafficLightLabel.Visible = false;
                selectRoute.Enabled = true;
                selected = new List<int>();
                stopPointButton.Enabled = true;
                Ep.ERefreshRouts();
                loadingForm.loading.Value = 85;
                loadingForm.loading.Value = 100;
                loadingForm.close = true;
                loadingForm.Close();
                BringToFront();
            }
            catch (Exception exc)
            {
                StackTrace stackTrace = new StackTrace(exc, true);
                if (stackTrace.FrameCount > 0)
                {
                    BringToFront();
                    MetroMessageBox.Show(this, $"{exc.StackTrace}", MainStrings.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //saver/loader
        private void NewModelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog fb = new OpenFileDialog
            {
                FilterIndex = 1,
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };
            if (fb.ShowDialog() == DialogResult.OK)
            {
                savepath = null;
                if (Ep != null)
                {
                    Ep.EG = new DrawGraph();
                    Ep.Close();
                }
                Data.buses.Clear();
                config.Text = MainStrings.config;
                foreach (var tl in Data.traficLights)
                {
                    tl.Stop();
                }
                Data.TraficLightsInGrids.Clear();
                Data.stopPointsInGrids.Clear();
                Data.V.Clear();
                Data.E.Clear();
                G.bitmap = null;
                if (G.bitmap != null)
                {
                    ZoomHelper();
                    G.ClearSheet();
                    G.ClearSheet2();
                }
                Data.routes.Clear();
                Data.routesEdge.Clear();
                changeRoute.Items.Clear();
                Data.AllCoordinates.Clear();
                Data.allstopPoints.Clear();
                Data.stopPoints.Clear();
                Data.traficLights.Clear();
                sheet.Image = Image.FromFile(fb.FileName);
                saveImage = sheet.Image;
                zoomBar.Value = 1;
                wsheet = sheet.Width;
                hsheet = sheet.Height;
                globalMap = sheet.Image;
                G.SetBitmap();
                GridCreator.CreateGrid(sheet);
                Modeling.CreatePollutionInRoutes();
                AddInComboBox();
                Ep = new DisplayEpicenters(this);
                StyleManager.Clone(Ep);
                Ep.Show();

                openEpicFormToolStripMenuItem.Enabled = true;
                addRouteToolStripMenuItem.Enabled = true;
                createGridToolStripMenuItem.Enabled = true;
                matrix.MatrixCreate();
                BringToFront();
                timer.Dispose();
                timer.Start();
                MetroMessageBox.Show(this, "", MainStrings.done, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }


        private void DeleteALLButton_Click(object sender, EventArgs e)
        {
            try
            {
                yes = false;
                DeleteForm df = new DeleteForm();
                StyleManager.Clone(df);
                df.VandE.Enabled = false;
                df.All.Text = MainStrings.graphClear;
                df.ShowDialog();
                LoadingForm loadingForm = new LoadingForm();
                loadingForm.loading.Value = 0;
                loadingForm.loading.Maximum = 100;                
                string message = MainStrings.clearGraph;
                string caption = MainStrings.delete;
                DialogResult MBSave = DialogResult.No;
                if (yes)
                    MBSave = MetroMessageBox.Show(this, message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else
                    return;
                switch (delType)
                {
                    case DeleteType.All:
                        if (MBSave == DialogResult.Yes && changeRoute.Text != MainStrings.network)
                        {
                            loadingForm.Show();
                            Data.routes[changeRoute.Text].Clear();
                            Data.routesEdge[changeRoute.Text].Clear();
                            loadingForm.loading.Value = 20;
                            List<Bus> busTest = new List<Bus>();
                            foreach (var b in Data.buses)
                            {
                                if (b.Route == changeRoute.Text)
                                {
                                    busTest.Add(b);
                                };
                            };
                            loadingForm.loading.Value = 40;
                            foreach (var b in busTest)
                            {
                                Data.buses.Remove(b);
                            }
                            loadingForm.loading.Value = 50;
                            Data.AllCoordinates[changeRoute.Text].Clear();
                            G.ClearSheet();
                            G.DrawALLGraph(Data.V, Data.E);
                            sheet.Image = G.GetBitmap();
                            GridCreator.DrawGrid(sheet);

                        }
                        if (MBSave == DialogResult.Yes && changeRoute.Text == MainStrings.network)
                        {
                            loadingForm.Show();
                            loadingForm.loading.Value = 20;
                            Data.buses.Clear();
                            Data.routes.Keys.ToList().ForEach(x => Data.routes[x] = new List<Vertex>());
                            Data.routesEdge.Keys.ToList().ForEach(x => Data.routesEdge[x] = new List<Edge>());
                            loadingForm.loading.Value = 40;
                            Data.AllCoordinates.Clear();
                            G.ClearSheet();
                            sheet.Image = G.GetBitmap();
                            GridCreator.DrawGrid(sheet);
                            loadingForm.loading.Value = 50;
                        };
                        break;
                    case DeleteType.BusStops:
                        if (MBSave == DialogResult.Yes && changeRoute.Text != MainStrings.network)
                        {
                            loadingForm.Show();
                            loadingForm.loading.Value = 20;
                            Data.stopPoints[changeRoute.Text].Clear();
                            Data.stopPointsInGrids[changeRoute.Text].Clear();
                            loadingForm.loading.Value = 40;
                            G.ClearSheet();
                            sheet.Image = G.GetBitmap();
                            GridCreator.DrawGrid(sheet);
                            loadingForm.loading.Value = 50;
                        }
                        if (MBSave == DialogResult.Yes && changeRoute.Text == MainStrings.network)
                        {
                            loadingForm.Show();
                            loadingForm.loading.Value = 20;
                            Data.allstopPoints.Clear();
                            Data.stopPoints.Clear();
                            Data.stopPointsInGrids.Clear();
                            loadingForm.loading.Value = 40;
                            G.ClearSheet();
                            sheet.Image = G.GetBitmap();
                            GridCreator.DrawGrid(sheet);
                            loadingForm.loading.Value = 50;
                        }
                        break;
                    case DeleteType.TrafficLight:
                        if (MBSave == DialogResult.Yes)
                        {
                            loadingForm.Show();
                            loadingForm.loading.Value = 20;
                            foreach (var tf in Data.traficLights)
                                tf.Stop();
                            Data.traficLights.Clear();
                            Data.TraficLightsInGrids.Clear();
                            loadingForm.loading.Value = 40;
                            G.ClearSheet();
                            sheet.Image = G.GetBitmap();
                            GridCreator.DrawGrid(sheet);
                            loadingForm.loading.Value = 50;
                        }
                        break;
                    case DeleteType.TheBuses:
                        if (MBSave == DialogResult.Yes)
                        {
                            loadingForm.Show();
                            loadingForm.loading.Value = 20;
                            DelAllBus();
                            loadingForm.loading.Value = 40;
                            loadingForm.loading.Value = 50;
                        }
                        break;
                }

                G.DrawALLGraph(Data.V, Data.E);
                selectRoute.Enabled = true;
                loadingForm.loading.Value = 80;
                trafficLightLabel.Visible = false;
                selected = new List<int>();
                stopPointButton.Enabled = true;
                if (!Ep.IsDisposed)
                {
                    Ep.ERefreshRouts();
                }
                loadingForm.loading.Value = 100;
                loadingForm.close = true;
                loadingForm.Close();
                if (changeRoute.Text == MainStrings.network)
                {
                    selectRoute.Enabled = true;
                    deleteBus.Enabled = true;
                    allBusSettings.Enabled = false;
                    drawEdgeButton.Enabled = true;
                    selectButton.Enabled = true;
                    drawVertexButton.Enabled = true;
                    deleteButton.Enabled = true;
                    deleteALLButton.Enabled = true;
                    deleteRoute.Enabled = true;
                    addBus.Enabled = false;
                    deleteBus.Enabled = false;
                    stopPointButton.Enabled = true;
                    addTraficLight.Enabled = true;
                    CheckBuses();
                };
                if (changeRoute.SelectedIndex > 1)
                {
                    selectRoute.Enabled = true;
                    deleteBus.Enabled = true;
                    allBusSettings.Enabled = false;
                    drawEdgeButton.Enabled = true;
                    selectButton.Enabled = true;
                    drawVertexButton.Enabled = true;
                    deleteButton.Enabled = true;
                    deleteALLButton.Enabled = true;
                    deleteRoute.Enabled = true;
                    addBus.Enabled = false;
                    deleteBus.Enabled = false;
                    stopPointButton.Enabled = true;
                    addTraficLight.Enabled = true;
                    CheckBusesOnRoute();
                }
                BringToFront();
            }

            catch (Exception exc)
            {
                StackTrace stackTrace = new StackTrace(exc, true);
                if (stackTrace.FrameCount > 0)
                {
                    BringToFront();
                    MetroMessageBox.Show(this, $"{exc.StackTrace}", MainStrings.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //loading.Visible = false;
                }
            }

        }


        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (changeRoute.Text == MainStrings.network)
            {
                addBus.Enabled = false;
                allBusSettings.Enabled = false;
                selectButton.Enabled = false;
                drawVertexButton.Enabled = true;
                drawEdgeButton.Enabled = true;
                addTraficLight.Enabled = true;
                CheckBuses();
            };
            if (changeRoute.SelectedIndex > 1)
            {
                addBus.Enabled = true;
                deleteBus.Enabled = true;
                allBusSettings.Enabled = false;
                selectButton.Enabled = false;
                drawVertexButton.Enabled = false;
                drawEdgeButton.Enabled = true;
                addTraficLight.Enabled = false;
                CheckBusesOnRoute();
            }
            trafficLightLabel.Visible = false;
            selectRoute.Enabled = true;
            stopPointButton.Enabled = true;
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected = new List<int>();
            GridCreator.DrawGrid(sheet);
        }
       
        public bool NextBool()
        {
            // as simple as possible
            return rnd.Next(0, 2) == 1;
        }
      
        public int? GetKeyByValue(int? value)
        {
            foreach (var recordOfDictionary in Optimization.percentMean)
            {
                if (recordOfDictionary.Value.Equals(value))
                    return recordOfDictionary.Key;
            }
            return null;
        }

    
   
        private async void Optimize_ClickAsync(object sender, EventArgs e)
        {
            if (optText.Text != "" && speed.Text != "" && Data.buses.Count != 0 && int.Parse(optText.Text) > 0 && int.Parse(speed.Text) > 0 && Data.buses != null)
            {
                Optimization.withoutSensorsBuses = new List<int>();
                Optimization.countWithoutSensors = Data.buses.Count;
                bool check = false;
                foreach (var bus in Data.buses)
                {
                    if (bus.Tracker == true)
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    //foreach (var bus in Data.buses)
                    //    bus.Stop();
                    timer.Stop();
                    foreach (var tl in Data.traficLights)
                        tl.TimerLight.Interval = 1;
                    Optimization.OptiCount = int.Parse(optText.Text);
                    Optimization.OptiSpeed = int.Parse(speed.Text);

                    ButtonOff();
               
                    matrix.MatrixCreate();
                    if (speed.Text != "" && int.TryParse(speed.Text, out int sp))
                    {
                        if (int.Parse(speed.Text) / 20 == 0)
                            Modeling.T = 1;
                        else
                            Modeling.T = int.Parse(speed.Text) / 20;
                    }
                    var style = msmMain.Style;
                    if (msmMain.Style == (MetroFramework.MetroColorStyle)Convert.ToInt32(13))
                        msmMain.Style = (MetroFramework.MetroColorStyle)Convert.ToInt32(14);
                    else
                        msmMain.Style = (MetroFramework.MetroColorStyle)Convert.ToInt32(13);
                    loadingForm = new LoadingForm
                    {
                        Theme = msmMain.Theme,
                        Style = msmMain.Style
                    };
                    if (!Ep.IsDisposed)
                    {
                        StyleManager.Clone(Ep);
                        Ep.Refresh();
                    }
                    if (SavePictures == true)
                    {
                        Ep.Hide();
                        Directory.CreateDirectory(Optimization.pathOpt + "/Epics");
                    }          
                    loadingForm.Show();
                    loadingForm.Refresh();
                    await Task.Run(() =>
                    {
                        Optimization.Opt(matrix, loadingForm);
                    });

                    mean.Text = average;

                    loadingForm.close = true;
                    loadingForm.Close();
                    loadingForm.Dispose();
                    
                    matrix.MatrixCreate();
                    ResMatrix();
                    msmMain.Style = style;                
                    MetroMessageBox.Show(this, "", MainStrings.done, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    if (!Ep.IsDisposed)
                    {                     
                        StyleManager.Clone(Ep);
                        Ep.Refresh();
                    }
                    BringToFront();
                    timer.Start();
                    ButtonOn();
                    ResChart();    

                    foreach (var tl in Data.traficLights)
                        tl.TimerLight.Interval = 1000;
                }
                else
                {
           
                }

            }
        }
        //class opt
        public void ResMatrix()
        {
            results.Rows.Clear();
            results.Refresh();
            results.RowCount = 5;
            int i = 0;
            foreach (var pm in Optimization.percentMean)
            {
                results.Rows[i].HeaderCell.Value = pm.Key.ToString();
                if (pm.Value != 0)
                    results.Rows[i].Cells[0].Value = (pm.Value / 60).ToString();
                else
                    results.Rows[i].Cells[0].Value = MainStrings.notFound;
                i += 1;
            }
        }
        //class opt
        public void ResChart()
        {
            if (oldChart == (int)Optimization.percentMean.Keys.Sum())
            {
                int iCh = 0;
                StyleManager.Clone(r);
                if (rCount != 0)
                    r.ch.Series.Add(rCount.ToString());
                r.ch.Series[rCount].LegendText = rCount.ToString();
                foreach (var pm in Optimization.percentMean)
                {
                    if (pm.Value == null)
                    {
                        r.ch.Series[rCount].Points.AddY(0);
                    }
                    else
                    {
                        r.ch.Series[rCount].Points.AddY(pm.Value / 60 != 0 ? (double)pm.Value / 60 : (double)pm.Value);
                    }
                    if (rCount == 0)
                        r.ch.ChartAreas[rCount].AxisX.CustomLabels.Add(new CustomLabel(iCh, iCh + 2, pm.Key.ToString(), 0, LabelMarkStyle.LineSideMark));
                    iCh++;
                }
                r.ch.SaveImage(Optimization.pathOpt + "/" + MainStrings.chart + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                r.TopMost = true;
                r.Show();
                r.BringToFront();

                rCount += 1;
            }
            else
            {
                try
                {
                    r.ch.Legends.Clear();
                    rCount = 0;
                    // r.ch.Series[rCount].LegendText = rCount.ToString();
                    foreach (var series in r.ch.Series)
                    {
                        series.Points.Clear();
                    }
                    oldChart = (int)Optimization.percentMean.Keys.Sum();
                    int iCh = 0;
                    StyleManager.Clone(r);
                    if (rCount != 0)
                        r.ch.Series.Add(rCount.ToString());
                    r.ch.Series[rCount].LegendText = rCount.ToString();
                    foreach (var pm in Optimization.percentMean)
                    {
                        if (pm.Value == null)
                        {
                            r.ch.Series[rCount].Points.AddY(0);
                        }
                        else
                        {
                            r.ch.Series[rCount].Points.AddY(pm.Value / 60 != 0 ? (double)pm.Value / 60 : (double)pm.Value);
                        }
                        if (rCount == 0)
                            r.ch.ChartAreas[rCount].AxisX.CustomLabels.Add(new CustomLabel(iCh, iCh + 2, pm.Key.ToString(), 0, LabelMarkStyle.LineSideMark));
                        iCh++;
                    }
                    r.ch.SaveImage(Optimization.pathOpt + "/" + MainStrings.chart + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    r.TopMost = true;
                    r.Show();
                    r.BringToFront();

                    rCount += 1;
                }
                catch { }
            }

        }
        public bool GetSavePictruesCheckBox()
        {
            return SavePictures;
        }
        //class loader
        private void LoadFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (!Directory.Exists(savepath))
                {
                    dialog.SelectedPath = Path.GetFullPath("../../Configs/");
                }
                else
                {
                    dialog.SelectedPath = Path.GetFullPath(savepath);
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(dialog.SelectedPath))
                        {
                            ToolStripMenuButtonOn();

                            LoadRoutes(dialog.SelectedPath + @"\");
                            savepath = dialog.SelectedPath;

                            File.WriteAllText("../../SaveConfig/save.txt", string.Empty);
                            using (StreamWriter fileV = new StreamWriter("../../SaveConfig/save.txt"))
                            {
                                fileV.WriteLine(savepath.ToString());
                            }

                            MetroMessageBox.Show(this, MainStrings.done, "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }

                    }
                    catch (Exception exc)
                    {
                        StackTrace stackTrace = new StackTrace(exc, true);
                        if (stackTrace.FrameCount > 0)
                        {
                            MetroMessageBox.Show(this, $"{exc.StackTrace}", MainStrings.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        savepath = "";
                    }
                }
            }
        }
        public void ToolStripMenuButtonOn()
        {
            openEpicFormToolStripMenuItem.Enabled = true;
            addRouteToolStripMenuItem.Enabled = true;
            createGridToolStripMenuItem.Enabled = true;
        }

        public FolderBrowserDialog NewBasePath(FolderBrowserDialog dialog)
        {
            if (!Directory.Exists(savepath))
            {
                dialog.SelectedPath = Path.GetFullPath("../../Configs/");
            }
            else
            {
                dialog.SelectedPath = Path.GetFullPath(savepath);
            }
            return dialog;

        }

        //class loader
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (savepath != null && savepath.Length > 2 && Directory.Exists(savepath))
            {
                try
                {
                    ToolStripMenuButtonOn();
                    LoadRoutes(savepath + @"\");                    
                }
                catch (Exception exc)
                {
                    try
                    {
                        using (var dialog = new FolderBrowserDialog())
                        {
                            if (!Directory.Exists(savepath))
                            {
                                dialog.SelectedPath = Path.GetFullPath("../../Configs/");
                            }
                            else
                            {
                                dialog.SelectedPath = Path.GetFullPath(savepath);
                            }

                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                if (!string.IsNullOrWhiteSpace(dialog.SelectedPath))
                                {
                                    ToolStripMenuButtonOn();

                                    LoadRoutes(dialog.SelectedPath + @"\");

                                    File.WriteAllText("../../SaveConfig/save.txt", string.Empty);
                                    savepath = dialog.SelectedPath;
                                    using (StreamWriter fileV = new StreamWriter("../../SaveConfig/save.txt"))
                                    {
                                        fileV.WriteLine(savepath.ToString());
                                    }

                                    MetroMessageBox.Show(this, MainStrings.done, "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                }
                            }
                        }
                    }
                    catch
                    {
                        StackTrace stackTrace = new StackTrace(exc, true);
                        if (stackTrace.FrameCount > 0)
                        {
                            MetroMessageBox.Show(this, $"{exc.StackTrace}", MainStrings.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        savepath = "";
                    }
                }
            }
            else
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    if (!Directory.Exists(savepath))
                    {
                        dialog.SelectedPath = Path.GetFullPath("../../Configs/");
                    }
                    else
                    {
                        dialog.SelectedPath = Path.GetFullPath(savepath);
                    }
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!string.IsNullOrWhiteSpace(dialog.SelectedPath))
                        {
                            ToolStripMenuButtonOn();

                            LoadRoutes(dialog.SelectedPath + @"\");
                            savepath = dialog.SelectedPath;
                            File.WriteAllText("../../SaveConfig/save.txt", string.Empty);

                            using (StreamWriter fileV = new StreamWriter("../../SaveConfig/save.txt"))
                            {
                                fileV.WriteLine(savepath);
                            }

                            MetroMessageBox.Show(this, MainStrings.done, "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }

                    }
                }
            }
            changeRoute.Text = MainStrings.network;
        }

        private void DrawEdgeButton_Click(object sender, EventArgs e)
        {
            G.ClearSheet();
            G.DrawALLGraph(Data.V, Data.E);
            if (changeRoute.Text == MainStrings.network)
            {
                allBusSettings.Enabled = false;
                addBus.Enabled = false;
                deleteBus.Enabled = false;
                drawEdgeButton.Enabled = false;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = true;
                addTraficLight.Enabled = true;
                deleteButton.Enabled = true;
                CheckBuses();
            };
            if (changeRoute.SelectedIndex > 1)
            {
                allBusSettings.Enabled = false;
                addBus.Enabled = true;
                deleteBus.Enabled = true;
                drawEdgeButton.Enabled = false;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = false;
                deleteButton.Enabled = true;
                addTraficLight.Enabled = false;
                G.DrawALLGraph(Data.routes[changeRoute.Text], Data.routesEdge[changeRoute.Text], 1);
                CheckBusesOnRoute();
            }
            selectRoute.Enabled = true;
            trafficLightLabel.Visible = false;
            delAllBusesOnRoute.Enabled = true;
            stopPointButton.Enabled = true;
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
            selected = new List<int>();
            GridCreator.DrawGrid(sheet);
        }
        //class saver

        private void SaveRoutes(string saveFormat = "xml", string save = "../../Configs/")
        {
            try
            {
                loadingForm = new LoadingForm();
                loadingForm.loading.Value = 0;
                loadingForm.Show();
                loadingForm.close = false;
                loadingForm.loading.Maximum = 100;
                if (saveFormat == "xml")
                {
                    Saver.saveXML(save, loadingForm, saveFormat);
                }
                if (saveFormat == "json")
                {
                    Saver.saveJSON(save, loadingForm, saveFormat);
                }

            }
            catch (Exception exc)
            {
                StackTrace stackTrace = new StackTrace(exc, true);
                if (stackTrace.FrameCount > 0)
                {
                    MetroMessageBox.Show(this, $"{exc.StackTrace}", MainStrings.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loadingForm.close = true;
                    loadingForm.Close();
                }

            }
        }

        private void DeleteAll()
        {
            if (Ep != null)
            {
                if (!Ep.IsDisposed)
                {
                    Ep.EG.ClearSheet2();
                    Ep.Dispose();
                    Ep.Close();
                }
            }

            foreach (var bus in Data.buses)
            {
                bus.Coordinates.Clear();
                bus.Coordinates.TrimExcess();
                bus.BusPic.Dispose();
            }
            Data.buses.Clear();


            foreach (var tl in Data.traficLights)
            {
                tl.Stop();
                tl.TimerLight.Dispose();
            }

            Data.routes.Clear();
            Data.routesEdge.Clear();
            changeRoute.Items.Clear();
            Data.AllCoordinates.Clear();

            Data.allstopPoints.Clear();
            Data.stopPoints.Clear();
            Data.stopPointsInGrids.Clear();

            Data.traficLights.Clear();
            Data.traficLights.TrimExcess();
            Data.TraficLightsInGrids.Clear();

            Data.V.Clear();
            Data.E.Clear();
        
        }

        //class loader
        private void LoadRoutes(string load)
        {
            try
            {
                DeleteAll();
                Loader.Load(load, loadingForm, sheet, timer);                

                LoadOptions(load);

                loadingForm.loading.Value = 100;
                loadingForm.close = true;
                loadingForm.Close();               

                matrix.MatrixCreate();
                //Ep.BringToFront();
                BringToFront();

            }
            catch (Exception exc)
            {
                StackTrace stackTrace = new StackTrace(exc, true);
                if (stackTrace.FrameCount > 0)
                {
                    MetroMessageBox.Show(this, $"{exc.StackTrace}", MainStrings.error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loadingForm.close = true;
                    loadingForm.Close();
                }

            }
        }

        private void LoadOptions(string load)
        {

            DisplayEpicenters.Path = load;
            sheet.Image = Image.FromFile(load + "/Map.png");
            saveImage = sheet.Image;
            zoomBar.Value = 1;
            wsheet = sheet.Width;
            hsheet = sheet.Height;
            ZoomHelper();
            loadingForm = new LoadingForm
            {
                close = false
            };
            loadingForm.Show();
            loadingForm.loading.Value = 0;
            globalMap = sheet.Image;
            G.SetBitmap();
            config.Text = MainStrings.config + load;
            openEpicFormToolStripMenuItem.Enabled = true;
            GridCreator.CreateGrid(sheet);
            Modeling.CreatePollutionInRoutes();
            Epicenter.CreateOneRandomEpicenter(EpicSizeParam, null);
            ConstructorOnNetwork();
            AddInComboBox();
            G.ClearSheet();
            G.DrawALLGraph(Data.V, Data.E);
            sheet.Image = G.GetBitmap();
            GridCreator.DrawGrid(sheet);
            if (Ep != null)
                Ep.Close();
            Ep = new DisplayEpicenters(this);
            StyleManager.Clone(Ep);
            Ep.Show();

            if (Data.AllCoordinates.Count != 0)
                coordinates.CreateAllCoordinates();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            matrix.MatrixCreate();
        }


        public double GetDistance(double x1, double y1, double x2, double y2)
        {
            return (int)Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }


        private void AddTrafficLight(MouseEventArgs e)
        {
            if (firstCrossRoads > 0 || secondCrossRoads > 0)
            {
                if (firstCrossRoads > 0)
                {
                    trafficLightLabel.Visible = true;
                    c.FirstTrafficLight(e, Data.traficLights, sheet, Data.TheGrid);
                    trafficLightLabel.Text = MainStrings.putTrafficLights1 + " " + firstCrossRoads.ToString();
                    if (firstCrossRoads == 0)
                        trafficLightLabel.Text = MainStrings.putTrafficLights2 + " " + secondCrossRoads.ToString();
                    return;
                }
                if (firstCrossRoads <= 0 && secondCrossRoads > 0)
                {
                    trafficLightLabel.Text = MainStrings.putTrafficLights2 + " " + secondCrossRoads.ToString();
                    c.SecondTrafficLight(e, Data.traficLights, sheet, Data.TheGrid);
                    trafficLightLabel.Text = MainStrings.putTrafficLights2 + " " + (secondCrossRoads - 1).ToString();
                }
            }
            if (firstCrossRoads <= 0 && secondCrossRoads <= 0)
            {
                trafficLightLabel.Visible = false;
                Data.traficLights.ForEach((tl) =>
                {
                    tl.Set();
                    tl.Start();
                });
                selectedRoute = null;
                selectRoute.Enabled = true;
                deleteBus.Enabled = true;
                allBusSettings.Enabled = false;
                drawEdgeButton.Enabled = true;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = true;
                deleteButton.Enabled = true;
                deleteALLButton.Enabled = true;
                deleteRoute.Enabled = true;
                addBus.Enabled = false;
                deleteBus.Enabled = false;
                stopPointButton.Enabled = true;
                addTraficLight.Enabled = true;
            }
        }


        private void Sheet_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (changeRoute.Text == MainStrings.network)
            {
                if (selectRoute.Enabled == false)
                {
                    bool check = false;
                    check = c.CheckV(e, check);
                    c.SelectRoute(e, Data.V, Data.E, sheet, c, selected, check);
                }
                if (addTraficLight.Enabled == false)
                {
                    AddTrafficLight(e);
                }
                if (stopPointButton.Enabled == false)
                {
                    c.AddStopPoints(e, Data.allstopPoints, sheet, Data.TheGrid);
                }
                if (selectButton.Enabled == false)
                {
                    c.Select(e, Data.V, Data.E, sheet, 0);
                }
                if (drawVertexButton.Enabled == false)
                {
                    c.DrawVertex(e, Data.V, sheet);
                }
                if (drawEdgeButton.Enabled == false)
                {
                    c.DrawEdge(e, Data.V, Data.E, sheet);
                }
                if (deleteButton.Enabled == false)
                {
                    switch (delType)
                    {
                        case DeleteType.All:
                            c.AsDelete(e, Data.V, Data.E, sheet, Data.routesEdge);
                            break;
                        case DeleteType.BusStops:
                            c.DeleteBS(e, Data.V, Data.E, sheet, Data.routesEdge);
                            break;
                        case DeleteType.TrafficLight:
                            c.DeleteTF(e, Data.V, Data.E, sheet, Data.routesEdge);
                            break;
                        case DeleteType.VertexAndEdge:
                            c.DeleteVE(e, Data.V, Data.E, sheet, Data.routesEdge);
                            break;
                    }
                    if (flag)
                    {
                        c.MapUpdateNetwork(sheet, Data.V, Data.E);
                    }
                }
                return;
            }

            if (changeRoute.SelectedIndex > 1)
            {
                List<Vertex> routeV = Data.routes[changeRoute.Text];
                if (stopPointButton.Enabled == false)
                {
                    c.AddStopPointsInRoutes(e, Data.allstopPoints, sheet, Data.TheGrid, changeRoute.Text);
                }
                //нажата кнопка "выбрать вершину", ищем степень вершины
                if (selectButton.Enabled == false)
                {
                    c.Select(e, routeV, Data.routesEdge[changeRoute.Text], sheet, 1);
                }
                if (selectRoute.Enabled == false)
                {
                    c.SelectRouteInRoute(e, routeV, Data.routesEdge[changeRoute.Text], sheet, selected);
                }
                //нажата кнопка addBus
                if (addBus.Enabled == false)
                {
                    try
                    {
                        c.AddBus(e, trackerCheck.Checked, backsideCheck.Checked, changeRoute.Text);
                    }
                    catch
                    {
                        MetroMessageBox.Show(this, MainStrings.error);
                    }

                }
                if (deleteBus.Enabled == false)
                {
                    c.DeleteBus(e, routeV, Data.routesEdge[changeRoute.Text], sheet, changeRoute.Text, mainPanel.AutoScrollPosition.X, mainPanel.AutoScrollPosition.Y);
                }

                //нажата кнопка "рисовать ребро"
                if (drawEdgeButton.Enabled == false)
                {
                    c.DrawEdgeInRoute(e, routeV, Data.routesEdge[changeRoute.Text], sheet, changeRoute.Text);
                }
                //нажата кнопка "удалить элемент"
                if (deleteButton.Enabled == false)
                {
                    switch (delType)
                    {
                        case DeleteType.All:
                            c.DeleteOnRoute(e, routeV, Data.routesEdge[changeRoute.Text], sheet, changeRoute.Text);
                            break;
                        case DeleteType.BusStops:
                            c.DeleteStopsOnRoute(e, routeV, sheet, changeRoute.Text);
                            break;
                        case DeleteType.TrafficLight:
                            c.DeleteTFOnRoute(e, routeV, Data.routesEdge[changeRoute.Text], sheet, Data.traficLights);
                            break;
                        case DeleteType.VertexAndEdge:
                            c.DeleteVandE(e, routeV, Data.routesEdge[changeRoute.Text], sheet);
                            break;
                        case DeleteType.TheBuses:
                            DelBus();
                            break;
                    }
                    if (flag)
                    {
                        c.MapUpdateRoute(sheet, routeV, Data.routesEdge[changeRoute.Text]);
                    }
                }
                coordinates.CreateOneRouteCoordinates(changeRoute.Text);
                return;
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (G.bitmap != null)
            {
                AddGrid f = new AddGrid
                {
                    Owner = this
                };
                f.ShowDialog();
                c.MapUpdate(sheet);
                GridCreator.DrawGrid(sheet);
                if (!Ep.IsDisposed)
                {
                    Ep.EDrawGrid();
                }

            }
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            if (changeRoute.Text == MainStrings.network)
            {
                selectRoute.Enabled = false;
                deleteBus.Enabled = false;
                addBus.Enabled = false;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = true;
                drawEdgeButton.Enabled = true;
                deleteButton.Enabled = true;
                allBusSettings.Enabled = false;
                selectRoute.Enabled = true;
                addTraficLight.Enabled = true;
                CheckBuses();
            };
            if (changeRoute.SelectedIndex > 1)
            {
                selectRoute.Enabled = true;
                deleteBus.Enabled = true;
                addBus.Enabled = true;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = false;
                drawEdgeButton.Enabled = true;
                deleteButton.Enabled = true;
                selectRoute.Enabled = true;
                allBusSettings.Enabled = false;
                addTraficLight.Enabled = false;
                CheckBusesOnRoute();
            }
            selected = new List<int>();
            selectRoute.Enabled = true;
            trafficLightLabel.Visible = false;
            delAllBusesOnRoute.Enabled = true;
            stopPointButton.Enabled = false;
        }
        private void DelAllBus()
        {
            CheckBuses();
            if (changeRoute.Text == MainStrings.network)
            {
                selectRoute.Enabled = false;
                deleteBus.Enabled = false;
                addBus.Enabled = false;
                selectButton.Enabled = true;
                selectRoute.Enabled = true;
                drawVertexButton.Enabled = true;
                drawEdgeButton.Enabled = true;
                deleteButton.Enabled = true;
                selectRoute.Enabled = true;
                allBusSettings.Enabled = false;
                stopPointButton.Enabled = true;
                addTraficLight.Enabled = true;
                Data.buses.Clear();
                delAllBusesOnRoute.Enabled = false;
            };
            CheckBusesOnRoute();
            if (changeRoute.SelectedIndex > 1)
            {
                selectRoute.Enabled = true;
                deleteBus.Enabled = true;
                addBus.Enabled = true;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = false;
                drawEdgeButton.Enabled = true;
                deleteButton.Enabled = true;
                selectRoute.Enabled = true;
                allBusSettings.Enabled = false;
                stopPointButton.Enabled = true;
                List<Bus> b = new List<Bus>();
                foreach (var bus in Data.buses)
                {
                    if (bus.Route == (changeRoute.Text))
                    {
                        b.Add(bus);
                    }
                }
                Parallel.ForEach(b, (bus) =>
                {
                    foreach (var B in Data.buses)
                    {
                        if (B == bus)
                        {
                            Data.buses.Remove(bus);
                            break;
                        }
                    }
                });
                b.Clear();
                delAllBusesOnRoute.Enabled = true;

            }
            trafficLightLabel.Visible = false;
            selected = new List<int>();

        }
        private void DelAllBusesOnRoute_Click(object sender, EventArgs e)
        {


        }
        private void CheckBuses()
        {
            if (Data.buses.Count != 0 && changeRoute.Text == MainStrings.network)
            {
                delAllBusesOnRoute.Enabled = true;
            }
        }
        private void CheckBusesOnRoute()
        {
            foreach (var bus in Data.buses)
            {
                if (bus.Route == (changeRoute.Text))
                {
                    delAllBusesOnRoute.Enabled = true;
                    break;
                }
            }
        }


        private void JSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sheet.Image != null)
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    if (!Directory.Exists(savepath))
                    {
                        dialog.SelectedPath = System.Windows.Forms.Application.StartupPath;
                    }
                    else
                    {
                        dialog.SelectedPath = Path.GetFullPath(savepath);
                    }
                    // dialog.SelectedPath = Path.GetFullPath(savepath); //System.Windows.Forms.Application.StartupPath;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = dialog.SelectedPath;
                        savepath = dialog.SelectedPath + @"\" + string.Format("{0}_{1}_{2}_{3}_{4}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute);
                        File.WriteAllText("../../SaveConfig/save.txt", string.Empty);
                        using (StreamWriter fileV = new StreamWriter("../../SaveConfig/save.txt"))
                        {
                            fileV.WriteLine(savepath.ToString());
                        }
                        if (!Directory.Exists(savepath))
                        {
                            Directory.CreateDirectory(savepath);
                            SaveRoutes("json", savepath + @"\");
                            saveImage.Save(savepath + "/Map.png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                        else
                        {
                            savepath += rnd.Next(0, 100).ToString();
                            Directory.CreateDirectory(savepath);
                            SaveRoutes("json", savepath + @"\");
                            saveImage.Save(savepath + "/Map.png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                        MetroMessageBox.Show(this, MainStrings.done, "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    config.Text = MainStrings.config + savepath;
                }
            }
            BringToFront();

        }

        private void AddTraficLight_Click(object sender, EventArgs e)
        {
            if (changeRoute.Text == MainStrings.network)
            {
                crossSettings = new CrossroadsSettings();
                this.StyleManager.Clone(crossSettings);
                crossSettings.ShowDialog();
                if (firstCrossRoads != 0 && secondCrossRoads != 0)
                {
                    selectRoute.Enabled = false;
                    deleteBus.Enabled = false;
                    addBus.Enabled = false;
                    selectButton.Enabled = true;
                    selectRoute.Enabled = true;
                    drawVertexButton.Enabled = true;
                    drawEdgeButton.Enabled = true;
                    deleteButton.Enabled = true;
                    allBusSettings.Enabled = false;
                    delAllBusesOnRoute.Enabled = false;
                    trafficLightLabel.Visible = true;
                    trafficLightLabel.Text = MainStrings.putTrafficLights1 + " " + firstCrossRoads.ToString();
                    selected = new List<int>();
                    stopPointButton.Enabled = true;
                    addTraficLight.Enabled = false;
                    selectRoute.Enabled = true;
                }
                sheet.Image = G.GetBitmap();
                selected1 = -1;
                GridCreator.DrawGrid(sheet);

            }

        }
        private void XMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (sheet.Image != null)
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    if (!Directory.Exists(savepath))
                    {
                        dialog.SelectedPath = System.Windows.Forms.Application.StartupPath;
                    }
                    else
                    {
                        dialog.SelectedPath = Path.GetFullPath(savepath);
                    }
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = dialog.SelectedPath;
                        savepath = dialog.SelectedPath + @"\" + string.Format("{0}_{1}_{2}_{3}_{4}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute);
                        File.WriteAllText("../../SaveConfig/save.txt", string.Empty);
                        using (StreamWriter fileV = new StreamWriter("../../SaveConfig/save.txt"))
                        {
                            fileV.WriteLine(savepath.ToString());
                        }
                        if (!Directory.Exists(savepath))
                        {
                            Directory.CreateDirectory(savepath);
                            SaveRoutes("xml", savepath + @"\");
                            saveImage.Save(savepath + "/Map.png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                        else
                        {
                            savepath += rnd.Next(0, 100).ToString();
                            Directory.CreateDirectory(savepath);
                            SaveRoutes("xml", savepath + @"\");
                            saveImage.Save(savepath + "/Map.png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                        MetroMessageBox.Show(this, MainStrings.done, "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    config.Text = MainStrings.config + savepath;
                }
            }
            BringToFront();
        }

        private void SelectRoute_Click(object sender, EventArgs e)
        {
            if (changeRoute.Text == MainStrings.network)
            {
                selectRoute.Enabled = false;
                deleteBus.Enabled = false;
                addBus.Enabled = false;
                addTraficLight.Enabled = true;
                stopPointButton.Enabled = true;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = true;
                drawEdgeButton.Enabled = true;
                deleteButton.Enabled = true;
                allBusSettings.Enabled = false;
                delAllBusesOnRoute.Enabled = false;
                addTraficLight.Enabled = true;
                CheckBuses();
            };
            if (changeRoute.SelectedIndex > 1)
            {
                selectRoute.Enabled = false;
                deleteBus.Enabled = true;
                addBus.Enabled = true;
                selectButton.Enabled = true;
                addTraficLight.Enabled = false;
                stopPointButton.Enabled = true;
                drawVertexButton.Enabled = false;
                drawEdgeButton.Enabled = true;
                deleteButton.Enabled = true;
                allBusSettings.Enabled = false;
                delAllBusesOnRoute.Enabled = true;
                CheckBusesOnRoute();
            }
            trafficLightLabel.Visible = false;
            stopPointButton.Enabled = true;
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            GridCreator.DrawGrid(sheet);
        }


        private void OpenEpicFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Ep.IsDisposed)
            {
                Ep.Close();

            }
            Ep = new DisplayEpicenters(this);
            StyleManager.Clone(Ep);
            Ep.Show();

        }
 
        private void AddRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addR = new AddRoute();
            this.StyleManager.Clone(addR);
            addR.ShowDialog();
            addR.Dispose();
            if (!Ep.IsDisposed)
            {
                Ep.ERefreshRouts();
            }
            if (addR.textBox1.Text != "")
            {
                if (!Data.routes.ContainsKey(this.addR.textBox1.Text))
                {
                    Data.routes.Add((this.addR.textBox1.Text), new List<Vertex>());
                    Data.routesEdge.Add((this.addR.textBox1.Text), new List<Edge>());
                    changeRoute.Items.Add(addR.textBox1.Text);
                    Data.stopPoints.Add((this.addR.textBox1.Text), new List<BusStop>());
                    changeRoute.SelectedIndex = changeRoute.Items.IndexOf(addR.textBox1.Text);
                }
            }
        }

        private void RunTrafficLightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.traficLights.ForEach((tl) =>
            {
                tl.Start();
            });
        }

        private void Themes_CheckedChanged(object sender, EventArgs e)
        {
            if (themes.Checked == true)
            {
                msmMain.Theme = MetroFramework.MetroThemeStyle.Dark;
                toolStripMenu.BackColor = Color.FromArgb(17, 17, 17);
                toolStripMenu.ForeColor = Color.FromArgb(153, 153, 153);
                selectButton.Image = new Bitmap(("../../Resources/newcursor_bt.png"));
                drawVertexButton.Image = new Bitmap(("../../Resources/circle_bt.png"));
                drawEdgeButton.Image = new Bitmap(("../../Resources/line_new_bt.png"));
                selectRoute.Image = new Bitmap(("../../Resources/line-chart_bt.png"));
                addTraficLight.Image = new Bitmap("../../Resources/traffic-light.png");


            }
            else
            {
                msmMain.Theme = MetroFramework.MetroThemeStyle.Light;
                toolStripMenu.BackColor = Color.FromArgb(255, 255, 255);
                toolStripMenu.ForeColor = Color.FromArgb(0, 0, 0);
                selectButton.Image = new Bitmap(("../../Resources/newcursor.png"));
                drawVertexButton.Image = new Bitmap(("../../Resources/circle1.png"));
                drawEdgeButton.Image = new Bitmap(("../../Resources/new_line__.png"));
                selectRoute.Image = new Bitmap(("../../Resources/line-chart.png"));
                addTraficLight.Image = new Bitmap("../../Resources/traffic-light_.png");

            }
            using (StreamWriter fileV = new StreamWriter("../../SaveConfig/theme.txt"))
            {
                fileV.WriteLine(msmMain.Theme);
            }

            this.StyleManager.Clone(Ep);
            if (Ep != null)
            {
                Ep.Refresh();

            }
        }


        private void ChangeTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            msmMain.Style = (MetroFramework.MetroColorStyle)Convert.ToInt32(changeTheme.Items.IndexOf(changeTheme.Text));
            StyleManager.Clone(Ep);
            using (StreamWriter fileV = new StreamWriter("../../SaveConfig/style.txt"))
            {
                fileV.WriteLine(Convert.ToInt32(changeTheme.Items.IndexOf(changeTheme.Text)));
            }
            if (Ep != null)
            {
                Ep.Refresh();
            }


        }

        private void LaunchBuses_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void StopBuses_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }



        private async void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = changeLanguage.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            await Task.Delay(1000);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Заносим список поддерживаемых языков.
            changeLanguage.DataSource = new System.Globalization.CultureInfo[]{
                 System.Globalization.CultureInfo.GetCultureInfo("ru-RU"),
                 System.Globalization.CultureInfo.GetCultureInfo("en-US")
            };

            // Каждый элемент списка comboBox1 будет являться экземпляром класса CultureInfo.

            changeLanguage.DisplayMember = "NativeName"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").NativeName
            changeLanguage.ValueMember = "Name"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").Name

            // Если в настройках есть язык, выбираем его в списке.
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                changeLanguage.SelectedValue = Properties.Settings.Default.Language;
            }
            lang = true;
        }

        private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lang == true)
            {
                hint.Visible = true;
                hint.Text = MainStrings.hint;
            }
        }

        private void ZoomHelper()
        {
            sheet.Image = ResizeBitmap(new Bitmap(saveImage), wsheet * zoomBar.Value, hsheet * zoomBar.Value);
            globalMap = sheet.Image;
            mainPanel.AutoScrollPosition = new Point(scrollX * zoomBar.Value, scrollY * zoomBar.Value);
            scrollX = mainPanel.AutoScrollPosition.X;
            scrollY = mainPanel.AutoScrollPosition.Y;
            zoom = zoomBar.Value;
            Bus.ScrollX = mainPanel.AutoScrollPosition.X;
            Bus.ScrollY = mainPanel.AutoScrollPosition.Y;
            Bus.ZoomCoef = zoomBar.Value;
        }

        private void MetroTrackBar1_ScrollAsync(object sender, ScrollEventArgs e)
        {
            //try
            //{
            if (sheet.Image != null && saveImage != null)
            {
                ZoomHelper();

                G.ClearSheet();
                if (changeRoute.SelectedIndex > 1)
                {
                    G.DrawALLGraph(Data.V, Data.E);
                    G.DrawALLGraph(Data.routes[(changeRoute.Text)], Data.routesEdge[(changeRoute.Text)], 1);
                }
                else if (changeRoute.Text == MainStrings.none)
                {
                    G.ClearSheet();
                }
                else
                {
                    G.DrawALLGraph(Data.V, Data.E);
                }

                if (timer.Enabled == false)
                {
                    AnimationBitmap.Dispose();
                    AnimationBitmap = new Bitmap(sheet.Width, sheet.Height);
                    AnimationBitmap.MakeTransparent();
                    AnimationGraphics.Dispose();
                    AnimationGraphics = Graphics.FromImage(AnimationBitmap);
                    foreach (var bus in Data.buses)
                    {

                        AnimationGraphics.DrawImage(bus.BusPic, bus.Coordinates[bus.PositionAt].X * zoomBar.Value - bus.BusPic.Width / 2, bus.Coordinates[bus.PositionAt].Y * zoomBar.Value - bus.BusPic.Height / 2);
                    }
                    AnimationBox.Image = AnimationBitmap;
                    //AnimationBox.Update();
                }
                // AnimationBox.Update();
                sheet.Image = G.GetBitmap();
                // GridCreator.CreateGrid(sheet);
                GridCreator.DrawGrid(sheet);


            }
            //}
            //catch//(OutOfMemoryException ex)
            //{
            //    Console.WriteLine("ex");
            //}
        }
   

        private void BusSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void OptText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void Speed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void MetroButton1_Click_1(object sender, EventArgs e)
        {
            coordinates.AsyncCreateAllCoordinates();
        }

        //

        private void MetroButton2_Click(object sender, EventArgs e)
        {
            epSet = new EpicSettings();
            StyleManager.Clone(epSet);
            epSet.ShowDialog();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            AnimationBitmap = new Bitmap(sheet.Width, sheet.Height);
            AnimationBitmap.MakeTransparent();
            AnimationGraphics = Graphics.FromImage(AnimationBitmap);
            foreach (var bus in Data.buses)
            {
                try
                {
                    bus.MoveWithGraphics(AnimationGraphics);
                    AnimationBox.Image = AnimationBitmap; // поместил в трай
                }
                catch { }
            }
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            timer.Start();
        }

        private void ReportTool_Click(object sender, EventArgs e)
        {
            r.Show();
            r.BringToFront();
        }

        private void StopBuses_Click_1(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void LaunchBuses_Click_1(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void ChangeRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changeRoute.Text == MainStrings.none)
            {
                selectedRoute = null;
                deleteBus.Enabled = false;
                allBusSettings.Enabled = false;
                selectButton.Enabled = false;
                drawVertexButton.Enabled = false;
                drawEdgeButton.Enabled = false;
                deleteButton.Enabled = false;
                deleteALLButton.Enabled = false;
                addTraficLight.Enabled = false;
                stopPointButton.Enabled = false;
                deleteRoute.Enabled = false;
                addBus.Enabled = false;
                selectRoute.Enabled = false;
                delAllBusesOnRoute.Enabled = false;
                G.ClearSheet();
                G.DrawStopPoints();
                G.DrawTrafficLights();
                sheet.Image = G.GetBitmap();
                trafficLightLabel.Visible = false;
                selected = new List<int>();
                return;
            };
            if (changeRoute.Text == MainStrings.network)
            {
                selectedRoute = null;
                selectRoute.Enabled = true;
                deleteBus.Enabled = true;
                allBusSettings.Enabled = false;
                drawEdgeButton.Enabled = true;
                selectButton.Enabled = true;
                drawVertexButton.Enabled = true;
                deleteButton.Enabled = true;
                deleteALLButton.Enabled = true;
                deleteRoute.Enabled = true;
                addBus.Enabled = false;
                deleteBus.Enabled = false;
                stopPointButton.Enabled = true;
                addTraficLight.Enabled = true;
                CheckBuses();
                G.ClearSheet();
                G.DrawALLGraph(Data.V, Data.E);
                trafficLightLabel.Visible = false;
                sheet.Image = G.GetBitmap();
                GridCreator.DrawGrid(sheet);
                Console.WriteLine(MainStrings.network);
                selected = new List<int>();
                return;
            };
            for (int i = 0; i < Data.routes.Count; i++)
            {
                if (Data.routes.ElementAt(i).Key == (changeRoute.Text))
                {
                    selectedRoute = (changeRoute.Text);
                    selectRoute.Enabled = true;
                    selectButton.Enabled = true;
                    deleteBus.Enabled = true;
                    allBusSettings.Enabled = false;
                    drawVertexButton.Enabled = false;
                    drawEdgeButton.Enabled = true;
                    deleteButton.Enabled = true;
                    deleteALLButton.Enabled = true;
                    deleteRoute.Enabled = true;
                    addBus.Enabled = true;
                    stopPointButton.Enabled = true;
                    trafficLightLabel.Visible = false;
                    addTraficLight.Enabled = false;
                    CheckBusesOnRoute();
                    G.ClearSheet();
                    G.DrawALLGraph(Data.V, Data.E);
                    G.DrawALLGraph(Data.routes[(changeRoute.Text)], Data.routesEdge[(changeRoute.Text)], 1);
                    sheet.Image = G.GetBitmap();
                    GridCreator.DrawGrid(sheet);
                    selected = new List<int>();
                    return;
                };
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            clearButton.Enabled = false;
            //
            openEpicFormToolStripMenuItem.Enabled = false;
            addRouteToolStripMenuItem.Enabled = false;
            createGridToolStripMenuItem.Enabled = false;
            savepath = null; 
            sheet.Image = null;
            if (Ep != null)
            {
                Ep.EG.ClearSheet2();
                Ep.Close();
            }
            Data.buses.Clear();
            Data.buses.TrimExcess();
            config.Text = MainStrings.config;
            foreach (var tl in Data.traficLights)
            {
                tl.Stop();
                tl.TimerLight.Dispose();
            }
            Data.TraficLightsInGrids.Clear();
            Data.stopPointsInGrids.Clear();
            Data.V.Clear();
            Data.E.Clear();
            if (G.GetBitmap() != null)
            {
                G.ClearSheet();
                G.ClearSheet2();
                G = new DrawGraph();
                globalMap.Dispose();

            }
            Data.routes.Clear();
            Data.routesEdge.Clear();
            changeRoute.Items.Clear();
            changeRoute.Items.Add(MainStrings.none);
            changeRoute.Items.Clear();
            changeRoute.Text = "";
            Data.AllCoordinates.Clear();
            Data.allstopPoints.Clear();
            Data.stopPoints.Clear();
            Data.traficLights.Clear();
            Data.traficLights.TrimExcess();
            zoomBar.Value = 1;
            deleteBus.Enabled = false;
            allBusSettings.Enabled = false;
            selectButton.Enabled = false;
            drawVertexButton.Enabled = false;
            drawEdgeButton.Enabled = false;
            deleteButton.Enabled = false;
            deleteALLButton.Enabled = false;
            addTraficLight.Enabled = false;
            stopPointButton.Enabled = false;
            deleteRoute.Enabled = false;
            addBus.Enabled = false;
            selectRoute.Enabled = false;
            delAllBusesOnRoute.Enabled = false;
            File.WriteAllText("../../SaveConfig/save.txt", string.Empty);
            BringToFront();
            matrix.MatrixCreate();
            Data.TheGrid = new List<GridPart>();
            Data.TheGrid.TrimExcess();
            timer.Stop();
            timer.Dispose();
            AnimationBox.Image = null;
            AnimationGraphics.Dispose();
            AnimationBitmap.Dispose();
            clearButton.Enabled = true;
            Refresh();

        }





        private void CreateGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (G.bitmap != null)
            {
                addG = new AddGrid();
                this.StyleManager.Clone(addG);
                addG.ShowDialog();
                G.ClearSheet();
                if (!Ep.IsDisposed)
                {
                    Ep.EG.ClearSheet2();
                }
                G.DrawALLGraph(Data.V, Data.E);
                GridCreator.CreateGrid(sheet);

                sheet.Image = G.GetBitmap();
                GridCreator.DrawGrid(sheet);
                if (!Ep.IsDisposed)
                {
                    Ep.EDrawGrid();
                }

                coordinates.CreateAllCoordinates();
                Modeling.CreatePollutionInRoutes();
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            if (G.bitmap != null)
            {
                EpicSettings f = new EpicSettings
                {
                    Owner = this
                };
                f.ShowDialog();
            }
        }


    }
}
