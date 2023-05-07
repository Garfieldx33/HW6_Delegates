// See https://aka.ms/new-console-template for more information
using HW6_Delegates;
using System.Collections;

FileSearcher scaner =new();
scaner.ScanFolderForFiles(@"C:\Users\LAS\source\repos\HW6_Delegates\HW6_Delegates\TestFiles");
FileInfo theBiggestFile = SearchMaxExtention<FileInfo>.GetMax(scaner.FileInfoList, GetParams);
Console.WriteLine($"Самый большой файл {theBiggestFile.Name} занимает {theBiggestFile.Length} байт");
Console.ReadKey();



float GetParams(FileInfo fileInfos)
{
    return fileInfos.Length;
}