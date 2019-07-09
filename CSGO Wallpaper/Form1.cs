namespace CSGO_Wallpaper
{
    using IWshRuntimeLibrary;
    using MaterialSkin;
    using MaterialSkin.Controls;
    using Microsoft.Win32;
    using Microsoft.WindowsAPICodePack.Dialogs;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public partial class Form1 : MaterialForm
    {
        //============================================================================================================-Variables-==========================================================================================================

        public string activeWallpaper = @"no wallpaper"; //Wallpaper thats currently active.
        public string csgoInstallPath; //CS:GOs installation path.
        public string currentVersion = @"1.2"; //Version.
        public string panoramaWallpaperPath; //Original wallpaper Path.
        public string panoramaWallpaperStoragePath = "Folder not selected..."; //Saved wallpaper path.
        public string saveFile = "C:\\ProgramData\\Panorama Wallpaper Changer\\saveddata.txt"; //Savefile path.
        public string selectedWallpaper; //Path of selected wallpaper.
        public string steamInstallPath; //Steams installation path.
        public int wallpaperAmount; //Amount of present wallpapers.
        public string[] wallpapers; //Wallpaper array.

        internal Color darkbluegray = Color.FromArgb(38, 50, 56);
        internal string desktopPath; //Path to users desktop.
        internal Color lightbluegray = Color.FromArgb(96, 125, 139);
        internal Color lightgreen = Color.FromArgb(102, 187, 106);
        internal Color lightred = Color.FromArgb(255, 82, 82);
        internal string saveFileVersion; //Version of the savefile.
        internal string[] steamLibraries = new string[32]; //Active Steam Librarys.
        internal string thisdir; //Path from this program.
        //============================================================================================================-Variables-==========================================================================================================

        //============================================================================================================-Important-Stuff-==========================================================================================================

        public Form1()
        {
            InitializeComponent();

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey800, Accent.Orange200,
                TextShade.WHITE
            );
        }

        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation, string thisdir)
        {
            //create a shortcut to the exe that i use to pick a random wallpaper then start csgo.
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Shortcut for CS:GO wallpaper changer.";   // The description of the shortcut
            shortcut.IconLocation = thisdir + @"\files\icon.ico";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }

        public void ChooseWallpaper()
        {
            if (wallpapers != null)
            {
                while (true)
                {
                    //Get a random number within range of wallpapers
                    Random r = new Random();
                    int i = r.Next(0, wallpaperAmount);

                    selectedWallpaper = wallpapers[i];

                    //if wallpaper isnt active and has a sirocco.webm then set it as active
                    if (selectedWallpaper != activeWallpaper && System.IO.File.Exists(selectedWallpaper))
                    {
                        SetWallpaper();
                        break;
                    }
                    else
                    {
                        AddText(richTextBox1, "Selected wallpaper is already in use or cant be used!", lightred);
                        break;
                    }
                }
            }
        }

        public void ReadData()
        {
            //this should be obvious but if you cant read this reads the data from savefile.
            using (StreamReader sr = System.IO.File.OpenText(saveFile))
            {
                saveFileVersion = sr.ReadLine();
                wallpaperAmount = int.Parse(sr.ReadLine());
                steamInstallPath = sr.ReadLine();
                csgoInstallPath = sr.ReadLine();
                panoramaWallpaperPath = sr.ReadLine();
                panoramaWallpaperStoragePath = sr.ReadLine();
                activeWallpaper = sr.ReadLine();
            }
        }

        public void RunCS()
        {
            //uhh this one you should know.
            AddText(richTextBox1, "Starting CS:GO", Color.Cyan);

            ProcessStartInfo startInfo = new ProcessStartInfo(steamInstallPath + "\\Steam.exe");
            startInfo.Arguments = "-applaunch 730";
            Process.Start(startInfo);
        }

        public void Setup()
        {
            //if something isnt right setup is here to save our day!!!! :D
            AddText(richTextBox1, "No save file was found. Proceeding with setup.", lightred);

            //check if savefile directory exists if not create it.
            if (!Directory.Exists("C:\\ProgramData\\Panorama Wallpaper Changer\\"))
            {
                Directory.CreateDirectory("C:\\ProgramData\\Panorama Wallpaper Changer\\");
                AddText(richTextBox1, "Creating directory for saving data...", lightbluegray);
            }

            //check if savefile exists if not create it... who would have thought lol.
            if (!System.IO.File.Exists("C:\\ProgramData\\Panorama Wallpaper Changer\\saveddata.txt"))
            {
                using (var myFile = System.IO.File.Create("C:\\ProgramData\\Panorama Wallpaper Changer\\saveddata.txt"))
                {
                }

                AddText(richTextBox1, "Creating saveddata file...", lightbluegray);
            }

            //Find Steam install path in registry (thank you u/DontRushB)
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Valve\Steam"))
            {
                if (key != null)
                {
                    steamInstallPath = key.GetValue("InstallPath").ToString();
                }
                else
                {
                    using (RegistryKey key2 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Valve\Steam"))
                    {
                        if (key != null)
                        {
                            steamInstallPath = key.GetValue("InstallPath").ToString();
                        }
                        else
                        {
                            MessageBox.Show("Steam Install Path was not found, please choose Steam path!");

                            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                            dialog.InitialDirectory = "C:\\Users";
                            dialog.IsFolderPicker = true;
                            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                            {
                                steamInstallPath = "" + dialog.FileName;
                            }
                        }
                    }
                }
            }

            //Look through Steam libraries until CSGO is found
            if (System.IO.File.Exists(steamInstallPath + "\\steamapps\\common\\Counter-Strike Global Offensive\\csgo.exe"))
            {
                csgoInstallPath = steamInstallPath + "\\steamapps\\common\\Counter-Strike Global Offensive\\";
            }
            else
            {
                string[] fileInput = System.IO.File.ReadAllLines(steamInstallPath + @"\steamapps\libraryfolders.vdf");

                for (int n = 0; n < (fileInput.Length); n++)
                {
                    steamLibraries[n] = fileInput[n];
                }

                for (int n = 0; n < steamLibraries.Length; n++)
                {
                    try
                    {
                        if (steamLibraries[n].Length > 4)
                        {
                            steamLibraries[n] = steamLibraries[n].Trim();
                            steamLibraries[n] = steamLibraries[n].Remove(0, 3);
                            steamLibraries[n] = steamLibraries[n].Trim();
                            steamLibraries[n] = steamLibraries[n].Trim(new char[] { '"' });
                            steamLibraries[n] = steamLibraries[n].Trim();
                            if (steamLibraries[n].EndsWith("SteamLibrary"))
                            {
                                AddText(richTextBox1, "Steam Library found at " + "" + steamLibraries[n], lightgreen);
                            }
                            else
                            {
                                steamLibraries[n] = null;
                            }
                        }
                    }
                    catch (NullReferenceException) { }
                }

                for (int n = 0; n < steamLibraries.Length; n++)
                {
                    string csgoSearchPath = steamLibraries[n] + "\\steamapps\\common\\Counter-Strike Global Offensive\\";
                    if (System.IO.File.Exists(csgoSearchPath + "csgo.exe"))
                    {
                        AddText(richTextBox1, "CSGO found!", lightgreen);

                        csgoInstallPath = csgoSearchPath;
                        break;
                    }
                }
            }

            panoramaWallpaperPath = csgoInstallPath + "csgo\\panorama\\videos\\";

            //Write data to savefile
            WriteData();
            AddText(richTextBox1, "Setup complete.", lightgreen);
            //run start again, hopefulle it works now lol.
            Start();
        }

        public void SetWallpaper()
        {
            //Replace active wallpaper with new wallpaper
            if (System.IO.File.Exists(selectedWallpaper))
            {
                //check if the needed file is there.
                System.IO.File.Copy(selectedWallpaper, panoramaWallpaperPath + "\\sirocco.webm", true);
            }
            else
            {
                AddText(richTextBox1, "No .webm file found!", lightred);
            }

            //Update activeWallpaper here and in save file
            activeWallpaper = selectedWallpaper;
            WriteData();

            AddText(richTextBox1, "Wallpaper set to " + activeWallpaper.Remove(0, panoramaWallpaperStoragePath.Length + 1), lightgreen);
        }

        public void ShowWP()
        {
            //gets wallpapers and lists them
            materialListView1.Items.Clear();
            string[] files = Directory.GetFiles(panoramaWallpaperStoragePath, "*.webm");

            foreach (string s in files)
            {
                materialListView1.Items.Add(Path.GetFileName(s));
            }
        }

        public void WriteData()
        {
            //this should be obvious but if you cant read this writes the data to savefile.
            using (StreamWriter sw = System.IO.File.CreateText(saveFile))
            {
                sw.WriteLine(currentVersion);
                sw.WriteLine(wallpaperAmount);
                sw.WriteLine(steamInstallPath);
                sw.WriteLine(csgoInstallPath);
                sw.WriteLine(panoramaWallpaperPath);
                sw.WriteLine(panoramaWallpaperStoragePath);
                sw.WriteLine(activeWallpaper);
            }
        }

        internal void AddText(RichTextBox rtb, string txt, Color col)
        {
            //this one sparks joy because it pushes text to the log.. and its even with COLOR :O
            if (String.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.SelectionColor = col;
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                richTextBox1.AppendText(txt);
            }
            else
            {
                richTextBox1.SelectionColor = col;
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                richTextBox1.AppendText(Environment.NewLine + txt);
            }

            richTextBox1.ScrollToCaret();
        }

        internal void Start()
        {
            //Clear list on startup.
            materialListView1.Items.Clear();

            //First check if a panorama wallpaper changer save file is found.
            if (System.IO.File.Exists(saveFile))
            {
                AddText(richTextBox1, "Saveddata found!", lightbluegray);

                //Read save file and set variables
                ReadData();

                //if wallpaper path isnt empty and exists load wallpaper list.
                if (Directory.Exists(panoramaWallpaperStoragePath) && Directory.GetFileSystemEntries(panoramaWallpaperStoragePath).Length != 0)
                {
                    try
                    {
                        wallpapers = Directory.GetFiles(panoramaWallpaperStoragePath, "*.webm");
                        materialSingleLineTextField1.Text = "" + panoramaWallpaperStoragePath;
                        AddText(richTextBox1, "Wallpaper path was found!", lightbluegray);
                        ShowWP();
                    }
                    catch (ArgumentException)
                    {
                        //If path is empty, go to setup
                        Setup();
                    }
                }
                else
                {
                    //if path isnt set or doesnt exist promt user to choose.
                    MessageBox.Show("Wallpaper path is empty or doesnt exist!\n"
                        + "\n"
                        + "If you are running this program for the first time\n"
                        + "you now need to set a wallpaper folder."
                        + "\n"
                        + "\n"
                        + "Make sure that you’ve put your wallpapers in the folder:\n"
                        + panoramaWallpaperStoragePath
                        + "\n"
                        + "\nIn the choosen folder every wallpaper needs to be a .webm video file.\n"

                        + "You can download Webm files or just convert a normal video with an online Webm converter\n"
                        + "\n"
                        + "Now select your Wallpaper folder."
                        , "Select Wallpaper folder...");

                    try
                    {
                        CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                        dialog.InitialDirectory = thisdir;
                        dialog.IsFolderPicker = true;
                        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            materialSingleLineTextField1.Text = "" + dialog.FileName;
                            panoramaWallpaperStoragePath = dialog.FileName;
                        }
                    }
                    catch
                    {
                    }

                    if (Directory.Exists(panoramaWallpaperStoragePath) && Directory.GetFileSystemEntries(panoramaWallpaperStoragePath).Length != 0)
                    {
                        try
                        {
                            wallpapers = Directory.GetFiles(panoramaWallpaperStoragePath, "*.webm");
                            AddText(richTextBox1, "Wallpaper path set to " + panoramaWallpaperStoragePath, lightbluegray);
                            ShowWP();
                        }
                        catch (ArgumentException)
                        {
                            //If path is empty, go to setup
                            Setup();
                        }
                    }
                }

                string[] currentVersionSplit = currentVersion.Split('.');
                string[] saveFileVersionSplit = saveFileVersion.Split('.');

                if (currentVersionSplit[0] != saveFileVersionSplit[0])
                {
                    //New version is not backwards compatible, so user will need to go through setup again.
                    Setup();
                }
                else
                {
                    try
                    {  //If amount of wallpapers from save file and actual amount is not equal, change it.
                        if (wallpaperAmount != wallpapers.Length)
                        {
                            if (wallpapers.Length < wallpaperAmount)
                            {
                                AddText(richTextBox1, "Removed " + "" + (wallpaperAmount - wallpapers.Length) + " wallpapers.", lightbluegray);
                            }
                            else
                            {
                                AddText(richTextBox1, "Added " + "" + (wallpapers.Length - wallpaperAmount) + " wallpapers.", lightbluegray);
                            }
                            wallpaperAmount = wallpapers.Length;
                        }

                        WriteData();
                    }
                    catch
                    {
                        MessageBox.Show("Folder is empty! \n Please add .webm video files to the folder or select another folder.");
                    }
                }
            }
            else
            {
                //Save file was not found, so user will now do setup

                Setup();
            }
        }

        //============================================================================================================-Important-Stuff-==========================================================================================================

        //============================================================================================================-UI-Elements-==========================================================================================================

        private void Button4_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this one is the start of everything bro.. like the big bang or some shit

            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            thisdir = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            materialSingleLineTextField1.Text = "" + panoramaWallpaperStoragePath;
            materialSingleLineTextField2.Text = "" + csgoInstallPath;
            materialSingleLineTextField1.SelectAll();
            materialSingleLineTextField1.Focus();
            richTextBox1.BackColor = Color.FromArgb(55, 71, 79);
            button4.BackColor = Color.FromArgb(55, 71, 79);
            materialListView1.HideSelection = true;

            Start();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //launches explorer in the wallpaper path
            if (Directory.Exists(panoramaWallpaperStoragePath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = panoramaWallpaperStoragePath,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
        }

        private void LinkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Leonm99/CSGO-Wallpaper-Changer");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //opens howto
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Leonm99/CSGO-Wallpaper-Changer/wiki/How-to-use...");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void MaterialFlatButton1_Click_1(object sender, EventArgs e)
        {
            //prompts the user to change path for Wallpapers
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = thisdir;
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                materialSingleLineTextField1.Text = "" + dialog.FileName;
                panoramaWallpaperStoragePath = dialog.FileName;

                if (Directory.Exists(panoramaWallpaperStoragePath) && Directory.GetFileSystemEntries(panoramaWallpaperStoragePath).Length != 0)
                {
                    activeWallpaper = "no wallpaper";

                    wallpapers = Directory.GetFiles(dialog.FileName);
                    wallpaperAmount = wallpapers.Length;

                    WriteData();
                    AddText(richTextBox1, "Changed wallpaper path" + " " + panoramaWallpaperStoragePath, lightbluegray);
                    ShowWP();
                }
                else
                {
                    MessageBox.Show("The Folder you’ve choosen is empty!");
                }
            }
        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            //prompts the user to change path for Wallpapers
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"c:\";
            dialog.IsFolderPicker = true;
            dialog.Multiselect = false;
            dialog.Title = "Choose your Counter-Strike Global Offensive folder";

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (Directory.Exists(dialog.FileName + "\\csgo\\panorama\\videos\\"))
                {
                    materialSingleLineTextField2.Text = "" + dialog.FileName;
                    csgoInstallPath = dialog.FileName;
                    panoramaWallpaperPath = csgoInstallPath + "\\csgo\\panorama\\videos\\";

                    WriteData();
                    AddText(richTextBox1, "Changed CS:GO path" + " " + csgoInstallPath, lightbluegray);
                }
                else
                {
                    MessageBox.Show("The folder you have choosen is not the Counter-Strike Global Offensive folder!" +
                                        "\n \n If you have installed CS:GO in the standard path it should be in:\n" +
                                        @"C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive\n" +
                                        "If you have installed CS:GO in another directory please select it.");
                }
            }
            else
            {
                MessageBox.Show("Please select the Counter-Strike Global Offensive folder!");
            }
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            //check selected item from list
            try
            {
                if (materialListView1.SelectedItems != null)
                {
                    var sel = materialListView1.SelectedItems[0].Text;
                    selectedWallpaper = panoramaWallpaperStoragePath + @"\" + sel;
                    if (System.IO.File.Exists(selectedWallpaper))
                    {
                        SetWallpaper();
                    }
                    else
                    {
                        AddText(richTextBox1, "Selected item is not a Folder with a webm Wallpaper in it!", lightred);
                    }
                }
            }
            catch
            {
                AddText(richTextBox1, "No item selected!", lightred);
            }
        }

        private void MaterialRaisedButton2_Click(object sender, EventArgs e)
        {
            ChooseWallpaper();
        }

        private void MaterialRaisedButton3_Click(object sender, EventArgs e)
        {
            //creates the shortcut
            DialogResult result = MessageBox.Show("This will create a shortcut for CSGO on your Desktop.\nif you use it it will randomly change the wallpaper and then start CSGO.", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    CreateShortcut("CSGO Wallpaper", desktopPath, thisdir + @"\files\CSGO_start.exe", thisdir);
                    AddText(richTextBox1, "Shortcut created successfully on desktop,", lightgreen);
                    AddText(richTextBox1, "use this shortcut instead of CSGO’s for random wallpaper every launch.", lightgreen);
                }
                catch
                {
                    AddText(richTextBox1, "Error while creating shortcut!", lightred);
                }
            }
            else if (result == DialogResult.No)
            {
            }
            else
            {
            }
        }

        private void MaterialRaisedButton4_Click(object sender, EventArgs e)
        {
            RunCS();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            //much emptiness is present here but thats not your buisiness
        }

        private void MaterialFlatButton3_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(panoramaWallpaperStoragePath) && Directory.GetFileSystemEntries(panoramaWallpaperStoragePath).Length != 0)
            {
                try
                {
                    wallpapers = Directory.GetFiles(panoramaWallpaperStoragePath, "*.webm");

                    ShowWP();

                    if (wallpaperAmount != wallpapers.Length)
                    {
                        if (wallpapers.Length < wallpaperAmount)
                        {
                            AddText(richTextBox1, "Removed " + "" + (wallpaperAmount - wallpapers.Length) + " wallpapers.", lightbluegray);
                        }
                        else
                        {
                            AddText(richTextBox1, "Added " + "" + (wallpapers.Length - wallpaperAmount) + " wallpapers.", lightbluegray);
                        }
                        wallpaperAmount = wallpapers.Length;
                        WriteData();
                    }
                }
                catch (ArgumentException)
                {
                    //If path is empty, go to setup
                }
            }
        }

        private void MaterialRaisedButton5_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(csgoInstallPath + "\\csgo\\resource\\csgo_colortext.txt"))
            {
                System.IO.File.WriteAllText(csgoInstallPath + "\\csgo\\resource\\csgo_colortext.txt", CSGO_Wallpaper_Changer.Properties.Resources.csgo_colortext);
                MessageBox.Show("The mod will only work if you add [ -language colortext ] to your launch options, so please do that now for the effects wont show!", "Please add to launchoptions...");
                AddText(richTextBox1, "Added Color Text Mod by BananaGaming", lightgreen);
            }
            else
            {
                MessageBox.Show("The file is already there, please add [ -language colortext ] to your CS:GO launchoptions!", "File already exists!");
            }
        }

        private void MaterialRaisedButton6_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(csgoInstallPath + "\\csgo\\resource\\csgo_colortext.txt"))
            {
                System.IO.File.Delete(csgoInstallPath + "\\csgo\\resource\\csgo_colortext.txt");
                AddText(richTextBox1, "Text color mod removed succesfully!", lightred);
            }
            else
            {
                MessageBox.Show("The mod is already removed! make sure you delete the part from it from the launch options.", "Already removed..");
            }
        }
    }
}

//============================================================================================================-UI-Elements-==========================================================================================================