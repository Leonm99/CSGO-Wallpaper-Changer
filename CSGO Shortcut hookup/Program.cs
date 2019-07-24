namespace CSGO_Shortcut_hookup
{
    using System;
    using System.Diagnostics;
    using System.IO;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            string currentVersion = @"1.3";
            string saveFileVersion = @"1.3";

            int wallpaperAmount;

            string steamInstallPath;//Folder containing steam.exe

            string csgoInstallPath;//Folder containing csgo.exe

            string panoramaWallpaperStoragePath = "Folder not selected...";//Folder with all 'inactive' pano wallpapers

            string panoramaWallpaperPath;//Folder with 'active' pano wallpapers and the folder above

            string activeWallpaper = @"no wallpaper";//Wallpaper that will be replaced by selected wallpaper

            string selectedWallpaper;//Wallpaper that will replace active wallpaper

            string saveFile = "C:\\ProgramData\\Panorama Wallpaper Changer\\saveddata.txt";

            string wallpaperToReplace;

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
                wallpaperToReplace = sr.ReadLine();
            }

            wallpapers = Directory.GetFiles(panoramaWallpaperStoragePath, "*.webm");

            if (wallpapers != null)
            {
                while (true)
                {
                    //Get a random number within range of wallpapers
                    Random r = new Random();
                    int i = r.Next(0, wallpaperAmount);

                    selectedWallpaper = wallpapers[i];

                    if (File.Exists(selectedWallpaper))
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

            ProcessStartInfo startInfo = new ProcessStartInfo(steamInstallPath + "\\Steam.exe");
            startInfo.Arguments = "-applaunch 730";
            Process.Start(startInfo);

            void SetWallpaper()
            {
                string sirocco1 = selectedWallpaper;

                //Replace active wallpaper with new wallpaper
                if (System.IO.File.Exists(sirocco1))
                {
                    //check if the needed file is there.
                    System.IO.File.Copy(sirocco1, panoramaWallpaperPath + "\\" + wallpaperToReplace, true);
                }

                //Update activeWallpaper here and in save file
                activeWallpaper = selectedWallpaper;
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
        }
    }
}