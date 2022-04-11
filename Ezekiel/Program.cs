using System;
using System.Text;
using Json.Net;

namespace Ezekiel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            foreach (string arg in args)
            {
                FileSort fileSort = new FileSort(arg);
                fileSort.Sort();
            }

            Console.ReadLine();
        }
    }
}
