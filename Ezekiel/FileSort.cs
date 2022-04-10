using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ezekiel
{
    public class FileSort
    {
        Dictionary<string, string> extensionsAndDirectories;
        string sortingDirectory;

        public FileSort(string sortingDirectory)
        {
            extensionsAndDirectories = new Dictionary<string, string>();

            extensionsAndDirectories["txt"] = "C:\\Users\\kranz\\Desktop\\Texts";

            this.sortingDirectory = sortingDirectory;
        }

        public void Sort()
        {
            string[] files = Directory.GetFiles(sortingDirectory);

            foreach(string file in files)
            {
                //Пропускаем точку в расширении файла
                string fileExt = Path.GetExtension(file).Substring(1);
                string pathForFileMove;
                string fileName = Path.GetFileName(file);
                
                extensionsAndDirectories.TryGetValue(fileExt, out pathForFileMove);

                if(pathForFileMove != null)
                {
                    /*Directory.Move(file, pathForFileMove);*/
                    File.Move(file, $"{pathForFileMove}\\{fileName}");
                }
                else
                {
                    Console.WriteLine($"Неизвестно куда класть файлы с {fileExt} расширением");
                }
            }

        }
    }
}
