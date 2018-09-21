using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CopyUSB
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1 = @"I:\";
            string path2 = @"H:\";
            string path3 = @"F:\";
            string pathToCopy;
            string[] files;
            
            string newPath = (@"C:\Users\rugce\Desktop\CopiedUSB\");
            if (Directory.Exists(path1))
            {
                pathToCopy = path1;
            }
            else if (Directory.Exists(path2))
            {
                pathToCopy = path2;
            }
            else
            {
                pathToCopy = path3;
            }
            int x = 0;
            Decision:
            Console.WriteLine("Do you want to copy the files in: " + pathToCopy + "?   y/n");
            string answer = Console.ReadLine();
            if(answer=="y" || answer == "Y")
            {
                try
                {
                    files = Directory.GetFiles(pathToCopy, ".",SearchOption.TopDirectoryOnly);
                    int numFiles = files.Length;
                    Console.WriteLine("Copy all the " + numFiles.ToString() + " files?");
                    string ans = Console.ReadLine();
                    if (ans.ToLower() == "yes" || ans.ToLower()=="y")
                    {
                        foreach (var fil in files)
                        {
                            FileInfo fileInf = new FileInfo(fil);
                            File.Copy(fil, newPath + fileInf.Name, true);
                            x++;
                        }
                        Console.WriteLine("All " + x + " file copied");
                    }
                    else { Console.WriteLine("No files were copied!"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else if(answer=="n" || answer == "N")
            {

            }
            else{
                goto Decision;
            }
            Console.Read();
        }
    }
}
