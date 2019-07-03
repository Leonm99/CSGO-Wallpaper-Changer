namespace CSGO_Wallpaper
{
    using IWshRuntimeLibrary;
    using Microsoft.Win32;
    using Microsoft.WindowsAPICodePack.Dialogs;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        //============================================================================================================-Variables-==========================================================================================================

        public string activeWallpaper = @"no wallpaper"; //Wallpaper thats currently active.
        public string csgoInstallPath; //CS:GOs installation path.
        public string currentVersion = @"1.0"; //Version.
        public string panoramaWallpaperPath; //Original wallpaper Path.
        public string panoramaWallpaperStoragePath = "Folder not selected..."; //Saved wallpaper path.
        public bool revealChosenWallpaper = true; //Show selected wallpaper in log.
        public string saveFile = "C:\\ProgramData\\Panorama Wallpaper Changer\\saveddata.txt"; //Savefile path.
        public string selectedWallpaper; //Path of selected wallpaper.
        public string steamInstallPath; //Steams installation path.
        public int wallpaperAmount; //Amount of present wallpapers.
        public string[] wallpapers; //Wallpaper array.

        internal string desktopPath; //Path to users desktop.
        internal string saveFileVersion; //Version of the savefile.
        internal string[] steamLibraries = new string[32]; //Active Steam Librarys.
        internal string thisdir; //Path from this program.

        //============================================================================================================-Variables-==========================================================================================================

        //============================================================================================================-Important-Stuff-==========================================================================================================

        public Form1()
        {
            //Initialize Components.
            InitializeComponent();
        }

        internal void Start()
        {
            //Clear list on startup.
            listBox1.Items.Clear();

            //First check if a panorama wallpaper changer save file is found.
            if (System.IO.File.Exists(saveFile))
            {
                AddText(richTextBox1, "Saveddata found!", Color.Green);

                //Read save file and set variables
                ReadData();

                //if wallpaper path isnt empty and exists load wallpaper list.
                if (Directory.Exists(panoramaWallpaperStoragePath) && Directory.GetFileSystemEntries(panoramaWallpaperStoragePath).Length != 0)
                {
                    try
                    {
                        wallpapers = Directory.GetDirectories(panoramaWallpaperStoragePath);
                        textBox1.Text = "" + panoramaWallpaperStoragePath;
                        AddText(richTextBox1, "Wallpaper path was found!", Color.Green);
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
                        + "Make sure that you’ve put your wallpapers in seperate folders in:\n"
                        + panoramaWallpaperStoragePath
                        + "\n"
                        + "\nIn the stored folder every wallpaper needs to be in a seperat folder.\n"
                        + "In each folder you need 3 Webm files and you have to rename them to\n"
                        + "[sirocco.webm], [sirocco540.webm] and [sirocco720.webm].\n"
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
                            textBox1.Text = "" + dialog.FileName;
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
                            wallpapers = Directory.GetDirectories(panoramaWallpaperStoragePath);
                            AddText(richTextBox1, "Wallpaper path set to " + panoramaWallpaperStoragePath, Color.White);
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
                    //If amount of wallpapers from save file and actual amount is not equal, change it.
                    if (wallpaperAmount != wallpapers.Length)
                    {
                        if (wallpapers.Length < wallpaperAmount)
                        {
                            AddText(richTextBox1, "Removed " + "" + (wallpaperAmount - wallpapers.Length) + " wallpapers.", Color.Yellow);
                        }
                        else
                        {
                            AddText(richTextBox1, "Added " + "" + (wallpapers.Length - wallpaperAmount) + " wallpapers.", Color.Yellow);
                        }
                        wallpaperAmount = wallpapers.Length;
                    }

                    WriteData();
                }
            }
            else
            {
                //Save file was not found, so user will now do setup

                Setup();
            }
        }

        public void Setup()
        {
            //if something isnt right setup is here to save our day!!!! :D
            AddText(richTextBox1, "No save file was found. Proceeding with setup.", Color.Red);

            //check if savefile directory exists if not create it.
            if (!Directory.Exists("C:\\ProgramData\\Panorama Wallpaper Changer\\"))
            {
                Directory.CreateDirectory("C:\\ProgramData\\Panorama Wallpaper Changer\\");
                AddText(richTextBox1, "Creating directory for saving data...", Color.White);
            }

            //check if savefile exists if not create it... who would have thought lol.
            if (!System.IO.File.Exists("C:\\ProgramData\\Panorama Wallpaper Changer\\saveddata.txt"))
            {
                using (var myFile = System.IO.File.Create("C:\\ProgramData\\Panorama Wallpaper Changer\\saveddata.txt"))
                {
                }

                AddText(richTextBox1, "Creating saveddata file...", Color.White);
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
                                AddText(richTextBox1, "Steam Library found at " + "" + steamLibraries[n], Color.Green);
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
                        AddText(richTextBox1, "CSGO found!", Color.Green);

                        csgoInstallPath = csgoSearchPath;
                        break;
                    }
                }
            }

            panoramaWallpaperPath = csgoInstallPath + "csgo\\panorama\\videos\\";

            //Write data to savefile
            WriteData();
            AddText(richTextBox1, "Setup complete.", Color.Green);
            //run start again, hopefulle it works now lol.
            Start();
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
                revealChosenWallpaper = bool.Parse(sr.ReadLine());
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
                sw.WriteLine(revealChosenWallpaper);
            }
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
                    if (selectedWallpaper != activeWallpaper && System.IO.File.Exists(selectedWallpaper + "\\sirocco.webm"))
                    {
                        SetWallpaper();
                        break;
                    }
                    else
                    {
                        AddText(richTextBox1, "Selected wallpaper is already in use or cant be used!", Color.Red);
                        break;
                    }
                }
            }
        }

        public void SetWallpaper()
        {
            string sirocco1 = selectedWallpaper + "\\sirocco.webm";
            string sirocco2 = selectedWallpaper + "\\sirocco540.webm";
            string sirocco3 = selectedWallpaper + "\\sirocco720.webm";

            //Replace active wallpaper with new wallpaper
            if (System.IO.File.Exists(sirocco1))
            {
                //check if the needed file is there.
                System.IO.File.Copy(sirocco1, panoramaWallpaperPath + "\\sirocco.webm", true);
                AddText(richTextBox1, "Copy files...", Color.White);

                if (System.IO.File.Exists(sirocco2))
                {
                    System.IO.File.Copy(sirocco2, panoramaWallpaperPath + "\\sirocco540.webm", true);
                }

                if (System.IO.File.Exists(sirocco3))
                {
                    System.IO.File.Copy(sirocco3, panoramaWallpaperPath + "\\sirocco720.webm", true);
                }
            }
            else
            {
                AddText(richTextBox1, "No sirocco.webm file found!", Color.Red);
            }

            //Update activeWallpaper here and in save file
            activeWallpaper = selectedWallpaper;
            WriteData();

            if (revealChosenWallpaper)
            {
                AddText(richTextBox1, "Wallpaper set to " + activeWallpaper.Remove(0, panoramaWallpaperStoragePath.Length + 1), Color.Gold);
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

        public void ShowWP()
        {
            //gets wallpapers and lists them
            listBox1.Items.Clear();
            string[] files = Directory.GetFiles(panoramaWallpaperStoragePath);
            string[] dirs = Directory.GetDirectories(panoramaWallpaperStoragePath);

            foreach (string s in files)
            {
                listBox1.Items.Add(Path.GetFileName(s));
            }

            foreach (string dir in dirs)
            {
                listBox1.Items.Add(Path.GetFileName(dir));
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

        //============================================================================================================-Important-Stuff-==========================================================================================================

        //============================================================================================================-UI-Elements-==========================================================================================================

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {// shows about section
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //prompts the user to change path for Wallpapers
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = thisdir;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBox1.Text = "" + dialog.FileName;
                panoramaWallpaperStoragePath = dialog.FileName;

                if (Directory.Exists(panoramaWallpaperStoragePath) && Directory.GetFileSystemEntries(panoramaWallpaperStoragePath).Length != 0)
                {
                    activeWallpaper = "no wallpaper";

                    wallpapers = Directory.GetDirectories(dialog.FileName);
                    wallpaperAmount = wallpapers.Length;

                    WriteData();
                    AddText(richTextBox1, "Changed wallpaper path" + " " + panoramaWallpaperStoragePath, Color.White);
                    ShowWP();
                }
                else
                {
                    MessageBox.Show("The Folder you’ve choosen is empty!");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Activate choosen wallpaper
            ChooseWallpaper();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //runCS
            RunCS();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //clear log
            richTextBox1.Clear();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //check selected item from list
            if (listBox1.SelectedItem != null)
            {
                var sel = listBox1.SelectedItem.ToString();
                selectedWallpaper = panoramaWallpaperStoragePath + @"\" + sel;
                if (System.IO.File.Exists(selectedWallpaper + @"\sirocco.webm"))
                {
                    SetWallpaper();
                }
                else
                {
                    AddText(richTextBox1, "Selected item is not a Folder with a webm Wallpaper in it!", Color.Red);
                }
            }
            else
            {
                AddText(richTextBox1, "No item selected!", Color.Red);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //creates the shortcut
            DialogResult result = MessageBox.Show("This will create a shortcut for CSGO on your Desktop.\nif you use it it will randomly change the wallpaper and then start CSGO.", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    CreateShortcut("CSGO Wallpaper", desktopPath, thisdir + @"\files\CSGO_start.exe", thisdir);
                    AddText(richTextBox1, "Shortcut created successfully on desktop,", Color.Green);
                    AddText(richTextBox1, "use this shortcut instead of CSGO’s for random wallpaper every launch.", Color.Yellow);
                }
                catch
                {
                    AddText(richTextBox1, "Error while creating shortcut!", Color.Red);
                }
            }
            else if (result == DialogResult.No)
            {
            }
            else
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this one is the start of everything bro.. like the big bang or some shit
            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            thisdir = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            textBox1.Text = "" + panoramaWallpaperStoragePath;

            Start();
        }

        private void GitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show my github page cause im fucking awesome
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Leonm99/CSGO-Wallpaper-Changer");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //much emptiness is present here but thats not your buisiness
        }

        private void HowToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //shows a little howto
            Form2 howto = new Form2();
            howto.Show();
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

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            //much emptiness is present here but thats not your buisiness
        }

        //============================================================================================================-UI-Elements-==========================================================================================================
    }
}