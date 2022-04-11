using System;
using System.Collections.Generic;
using System.IO;
using Json.Net;

namespace Ezekiel
{
    public class FileSort
    {
        Dictionary<string, string> extensionsAndDirectories;
        string sortingDirectory;

        public FileSort(string sortingDirectory)
        {
            extensionsAndDirectories = new Dictionary<string, string>();

            extensionsAndDirectories = JsonConfig.ReadConfigFile();

            this.sortingDirectory = sortingDirectory;
        }

        public void Sort()
        {
            string[] files = Directory.GetFiles(sortingDirectory);

            int movedFilesCount = 0;

            foreach (string file in files)
            {

                //Пропускаем точку в расширении файла
                string fileExt = Path.GetExtension(file).Substring(1).ToLower();
                string pathForFileMove;
                string fileName = Path.GetFileName(file);

                extensionsAndDirectories.TryGetValue(fileExt, out pathForFileMove);
                try
                {
                    if (pathForFileMove != null)
                    {
                        File.Move(file, $"{pathForFileMove}\\{fileName}");
                        Console.WriteLine($"Перенесён файл {fileName} в папку {pathForFileMove}");
                        movedFilesCount++;
                    }
                    else
                    {
                        Console.WriteLine($"Неизвестно куда класть файлы с {fileExt} расширением");
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine($"Для расширения \"{fileExt}\" не найдена папка {pathForFileMove}. Файл {fileName} пропущен");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            Console.WriteLine($"Перенесено файлов {movedFilesCount}");
        }
    }
}
