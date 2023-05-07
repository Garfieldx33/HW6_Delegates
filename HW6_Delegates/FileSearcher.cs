using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_Delegates
{
    public class FileSearcher
    {
        delegate void OnFileFound(FileArgs fileArgs);
        event OnFileFound FileFoundNotify;
        public List<FileInfo> FileInfoList = new List<FileInfo>();
        public FileSearcher()
        {
            FileFoundNotify += FileFoundEventHandler;
        }

        public void ScanFolderForFiles(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                foreach (var fileName in Directory.GetFiles(folderPath).ToList())
                {
                    FileInfo fileInfo = new FileInfo($"{fileName}");
                    FileFoundNotify?.Invoke(new FileArgs { FoundFileInfo = fileInfo } );
                    FileInfoList.Add(fileInfo);
                }
            }
        }

        private void FileFoundEventHandler(FileArgs fileArgs)
        {
            Task.Delay(300).Wait();
            Console.WriteLine($"Найден файл {fileArgs.FoundFileInfo.Name} размером {fileArgs.FoundFileInfo.Length} байт");
        }
    }

    internal class FileArgs : EventArgs
    {
        public FileInfo FoundFileInfo;
    }
}
