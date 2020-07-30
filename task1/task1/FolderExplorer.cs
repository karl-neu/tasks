using System;
using System.Collections.Generic;
using System.IO;

namespace task1
{
    public class FolderExplorer
    {
        private string Path { get; set; }
        private DirectoryInfo[] Folders { get; set; }
        private FileInfo[] Files { get; set; }
        private int SelectItem = 0;


        public FolderExplorer()
        {
            Path = @"C:\";
        }

        public void SetPath()
        {
            string path;
            bool f = false;
            do
            {
                Console.Clear();
                Console.Write("Enter file path: ");
                path = Console.ReadLine();

                if (File.Exists(path)) f = true;
                else if (Directory.Exists(path)) f = true;
            } while (!f);
            Path = path;
            Console.Clear();
        }

        private void GetContentByPath()
        {
            try
            {
                Folders = new DirectoryInfo(Path).GetDirectories();
                Files = new DirectoryInfo(Path).GetFiles();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ShowTree()
        {
            GetContentByPath();
            Console.WriteLine("{0,-30} {1,-25} {2,-25} {3,-25}", "Name", "Date modified", "Type", "Size");

            if (Path.IndexOf(':') != (Path.Length - 2))
            {
                if (SelectItem == -1)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(@"..\");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else Console.WriteLine(@"..\");
            }

            for (int i = 0; i < Folders.Length; i++)
            {
                if (SelectItem == i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("{0,-30} {1,-25} {2,-25}", Folders[i].Name, Folders[i].LastWriteTime, "File folder");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                    Console.WriteLine("{0,-30} {1,-25} {2,-25}", Folders[i].Name, Folders[i].LastWriteTime, "File folder");
            }

            foreach (FileInfo file in Files)
                Console.WriteLine("{0,-30} {1,-25} {2,-25} {3,-25}", file.Name, file.LastWriteTime, file.Extension, file.Length / 1000 + " KB");

        }

        public void WalkingTree()
        {
            ConsoleKeyInfo cki;

            do
            {
                Console.Clear();
                Console.WriteLine("\tPlease for walking by tree press arrows!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" Esc enter - exit.");
                Console.ForegroundColor = ConsoleColor.White;
                ShowTree();
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.UpArrow) ClickUp();
                else if (cki.Key == ConsoleKey.DownArrow) ClickDown();
                else if (cki.Key == ConsoleKey.Enter) ClickEnter();
            } while (cki.Key != ConsoleKey.Escape);
        }

        private void ClickEnter()
        {
            if (SelectItem == -1)
                Path = Path.Substring(0, Path.LastIndexOf(@"\"));
            else
                Path = Folders[SelectItem].FullName;


            if (Path.IndexOf(':') != (Path.Length - 1))
                SelectItem = -1;
            else
            {
                Path += @"\";
                SelectItem = 0;
            }
        }

        private void ClickUp()
        {
            if (SelectItem != -1) SelectItem--;
        }

        private void ClickDown()
        {
            if (SelectItem != Folders.Length - 1) SelectItem++;
        }
    }
}
