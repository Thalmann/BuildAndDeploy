using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Octokit;

namespace BuildAndDeploy
{
    class Program
    {
        private static FileSystemWatcher fs;
        static void Main(string[] args)
        {
            fs = new FileSystemWatcher(@"C:\Users\-\Documents\GitHub\SW701\code\CityBikes");
            
            fs.Changed += fs_Changed;
            fs.Created += fs_Changed;
            fs.Deleted += fs_Changed;
            fs.Renamed += fs_Changed;
            fs.EnableRaisingEvents = true;
            fs.NotifyFilter = NotifyFilters.LastAccess;
            fs.Filter = "*.*";

            Console.WriteLine("Application running - press any key to exit.");
            Console.ReadKey();
        }

        static void fs_Changed(object sender, FileSystemEventArgs e)
        {
            var pinfo = new ProcessStartInfo();
            pinfo.FileName = @"C:\Users\-\Documents\GitHub\SW701\deploy.bat";
            var pr = Process.Start(pinfo);
        }

    }
}
