using System.IO;
using FileConverterService.Helpers;

namespace FileConverterService
{
    public class ConverterService: IConverterService
    {
        public FileSystemWatcher Watcher { get; set; }

        public bool Start()
        {
            if(!Directory.Exists(Constants.WatchedFolder)) { Directory.CreateDirectory(Constants.WatchedFolder);}

            Watcher = new FileSystemWatcher(Constants.WatchedFolder, Constants.FilesFilter);

            Watcher.Created += FileCreated;

            Watcher.IncludeSubdirectories = false;

            Watcher.EnableRaisingEvents = true;

            return true;
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            var content = File.ReadAllText(e.FullPath);

            var upperContent = content.ToUpperInvariant();

            var directory = Path.GetDirectoryName(e.FullPath);

            var convertedFileName = $"{Path.GetFileName(e.FullPath)}.converted";

            var convertedPath = Path.Combine(directory, convertedFileName);            

            File.WriteAllText(convertedPath, upperContent);
        }

        public bool Stop()
        {
            Watcher.Dispose();

            return true;
        }
    }
}
