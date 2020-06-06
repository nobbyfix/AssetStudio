using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static AssetStudioGUI.Studio;

namespace AssetStudioGUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Console.Out.WriteLine(args.ToString());
            if (args.Length < 3)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AssetStudioGUIForm());
            }
            else
            {
                ExecuteNoGUI(args);
            }
        }
        static void ExecuteNoGUI(string[] args)
        {
            string savepath = null;
            List<string> folder = new List<string>();
            List<string> files = new List<string>();

            for (uint i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if (arg.StartsWith("-o"))
                {
                    if (++i < args.Length)
                        savepath = args[i];
                }
                else if (Directory.Exists(arg))
                {
                    folder.Add(arg);

                }
                else if (File.Exists(arg))
                {
                    files.Add(arg);

                }
            }

            if (savepath == null)
            {
                Console.Error.WriteLine("No output directory specified!");
                Console.Error.WriteLine("Use '-o <directory>' to specify output directory.");
                Application.Exit();
            }

            foreach (string f in folder)
            {
                DirectoryInfo d = new DirectoryInfo(f);
                foreach (FileInfo file in d.GetFiles())
                {
                    if (!file.Attributes.HasFlag(FileAttributes.Directory))
                        files.Add(file.FullName);
                }
            }

            assetsManager.LoadFiles(files.ToArray());

            BuildAssetData();
            while (exportableAssets.Count < 1)
            {
                Thread.Sleep(20);
            }

            List<AssetItem> assets = new List<AssetItem>();
            foreach (var asset in exportableAssets)
            {
                if (asset.Type == AssetStudio.ClassIDType.Texture2D)
                    assets.Add(asset);
            }

            ExportAssets(savepath, assets, ExportType.Convert);
            int worker, worker2;
            do
            {
                ThreadPool.GetAvailableThreads(out worker, out _);
                ThreadPool.GetMaxThreads(out worker2, out _);
                Thread.Sleep(50);
            } while (worker < worker2);
        }
    }
}
