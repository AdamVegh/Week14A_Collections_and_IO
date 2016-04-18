using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;


namespace SeekAndArchive
{
	class Program
	{
		static List<FileInfo> foundFiles;
		static List<FileSystemWatcher> watcher;
		static List<DirectoryInfo> archiveDirs;

		static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDir)
		{
			foreach (FileInfo file in currentDir.GetFiles())
				if (file.Name == fileName)
					foundFiles.Add(file);

			foreach (DirectoryInfo dir in currentDir.GetDirectories())
				RecursiveSearch(foundFiles, fileName, dir);
		}

		static void WatcherChanged(object sender, FileSystemEventArgs e)
		{
			//if (e.ChangeType == WatcherChangeTypes.Changed)
			Console.WriteLine(e.FullPath + " has been changed!");
			FileSystemWatcher senderWatcher = (FileSystemWatcher)sender;
			int index = watcher.IndexOf(senderWatcher, 0);
			ArchiveFile(foundFiles[index], archiveDirs[index]);
		}

		static void ArchiveFile(FileInfo fileToArchive, DirectoryInfo archiveDir)
		{
			FileStream input = fileToArchive.OpenRead();
			FileStream output = File.Create(archiveDir.FullName + @"\" + fileToArchive.Name + ".gz");

			GZipStream compressor = new GZipStream(output, CompressionMode.Compress);

			int b = input.ReadByte();
			do
			{
				compressor.WriteByte((byte)b);
				b = input.ReadByte();
			} while (b != -1);

			compressor.Close();
			output.Close();
			input.Close();
		}

		static void Main(string[] args)
		{
			string fileName = args[0];
			string dirName = args[1];

			foundFiles = new List<FileInfo>();
			DirectoryInfo rootDir = new DirectoryInfo(dirName);

			if (rootDir.Exists)
				Console.WriteLine("{0} exists", rootDir.Name);
			else
				Console.WriteLine("{0} doesn't exists", rootDir.Name);

			RecursiveSearch(foundFiles, fileName, rootDir);
			Console.WriteLine("Found {0} files", foundFiles.Count);

			foreach (FileInfo file in foundFiles)
			{
				Console.WriteLine(file.FullName);
			}

			watcher = new List<FileSystemWatcher>();

			foreach (FileInfo file in foundFiles)
			{
				FileSystemWatcher newWatcher = new FileSystemWatcher(file.DirectoryName, file.Name);
				newWatcher.Changed += new FileSystemEventHandler(WatcherChanged);
				newWatcher.EnableRaisingEvents = true;
				watcher.Add(newWatcher);
			}

			archiveDirs = new List<DirectoryInfo>();
			for (int i = 0; i < foundFiles.Count; i++)
			{
				archiveDirs.Add(Directory.CreateDirectory("archive" + i.ToString()));
			}
			
			Console.ReadKey();
		}
	}
}
