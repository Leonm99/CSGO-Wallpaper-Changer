namespace CSGO_Shortcut_hookup
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="Program" />
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/></param>
        internal static void Main(string[] args)
        {




            string currentVersion = @"1.1.5";
            string saveFileVersion = @"1.1.5";


            int wallpaperAmount;

            string steamInstallPath;//Folder containing steam.exe

            string csgoInstallPath;//Folder containing csgo.exe

            string panoramaWallpaperStoragePath = "Folder not selected...";//Folder with all 'inactive' pano wallpapers

            string panoramaWallpaperPath;//Folder with 'active' pano wallpapers and the folder above

            string activeWallpaper = @"no wallpaper";//Wallpaper that will be replaced by selected wallpaper

            bool revealChosenWallpaper = true;

            string selectedWallpaper;//Wallpaper that will replace active wallpaper

            string saveFile = "C:\\ProgramData\\Panorama Wallpaper Changer\\saveddata.txt";

            string[] wallpapers;



            using (StreamReader sr = File.OpenText(saveFile))
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

            wallpapers = Directory.GetDirectories(panoramaWallpaperStoragePath);



            if (wallpapers != null)
            {
                while (true)
                {
                    //Get a random number within range of wallpapers
                    Random r = new Random();
                    int i = r.Next(0, wallpaperAmount);

                    selectedWallpaper = wallpapers[i];


                    if (File.Exists(selectedWallpaper + "\\sirocco.webm"))
                    {

                        SetWallpaper();
                        break;
                    }
                    else
                    {


                        break;
                    }
                }
            }


            void SetWallpaper()
            {
                try
                {
                    //Replace active wallpaper with new wallpaper
                    File.Copy(selectedWallpaper + "\\sirocco.webm", panoramaWallpaperPath + "\\sirocco.webm", true);
                    File.Copy(selectedWallpaper + activeWallpaper + "\\sirocco540.webm", panoramaWallpaperPath + "\\sirocco540.webm", true);
                    File.Copy(selectedWallpaper + activeWallpaper + "\\sirocco720.webm", panoramaWallpaperPath + "\\sirocco720.webm", true);

                    //Update activeWallpaper here and in save file
                    activeWallpaper = selectedWallpaper;

                    using (StreamWriter sw = File.CreateText(saveFile))
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
                catch
                {

                }
            }


            ProcessStartInfo startInfo = new ProcessStartInfo(steamInstallPath + "\\Steam.exe");
            startInfo.Arguments = "-applaunch 730";
            Process.Start(startInfo);
        }
    }
}
