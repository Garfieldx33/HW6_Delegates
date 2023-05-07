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
        public List<FileInfo> FileInfoList = new List<FileInfo>();

        bool SearchCancelled = false;

        delegate void OnFileFound(FileArgs fileArgs);
        event OnFileFound FileFoundNotifyEvent;

        delegate void OnSearchCancel(ConsoleKeyInfo keyEvent);
        event OnSearchCancel FileSearchingCanceledEvent;

        public FileSearcher()
        {
            FileFoundNotifyEvent += FileFoundEventHandler;
            FileSearchingCanceledEvent += SearchingCanceledEventHandler;
        }

        public void ScanFolderForFiles(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                foreach (var fileName in Directory.GetFiles(folderPath).ToList())
                {
                    if (!SearchCancelled && !Console.KeyAvailable)
                    {
                        FileInfo fileInfo = new FileInfo($"{fileName}");
                        FileFoundNotifyEvent?.Invoke(new FileArgs { FoundFileInfo = fileInfo });
                        FileInfoList.Add(fileInfo);
                    }
                    else
                    {
                        Console.WriteLine("Поиск отменен пользователем");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Папка по пути {folderPath} не найдена");
            }
        }
        private void FileFoundEventHandler(FileArgs fileArgs)
        {
            Task.Delay(300).Wait();
            Console.WriteLine($"Найден файл {fileArgs.FoundFileInfo.Name} размером {fileArgs.FoundFileInfo.Length} байт");
        }
        private void SearchingCanceledEventHandler(ConsoleKeyInfo keyEvent)
        {
            if (keyEvent.Key == ConsoleKey.Spacebar)
            {
                SearchCancelled = true;
            }
        }
    }

    internal class FileArgs : EventArgs
    {
        public FileInfo FoundFileInfo;
    }
}
