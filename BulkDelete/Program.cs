using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BulkDelete
{
    internal class Program
    {
        private static string strFilePath;
        static void Main(string[] args)
        {
            if (CheckUserParameters(args))
            {
                Console.WriteLine("Deleting Process Started");
                foreach (var fil in getFiles(strFilePath))
                {
                    File.SetAttributes(fil, FileAttributes.Normal);
                    File.Delete(fil);
                    Console.WriteLine("Deleted " + fil);
                }
                Console.WriteLine("Deleting Process Finished");
            }
        }

        private static List<string> getFiles(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
        private static bool CheckUserParameters(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You must enter the location");
                return false;
            }
            else if (args.Length == 1)
            {
                strFilePath = args[0];
                return IsValidFile(strFilePath);
            }
            return true;
        }
        private static bool IsValidFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("You provided invalid file path.");
                return false;
            }
            return true;
        }
    }
}
