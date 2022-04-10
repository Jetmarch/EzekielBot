using System;
using System.Text;

namespace Ezekiel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            FileSort fileSort = new FileSort("C:\\Users\\kranz\\Desktop");

            fileSort.Sort();
        }
    }
}
