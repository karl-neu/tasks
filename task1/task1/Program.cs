using System;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\t\tTask #1");
            string key;

            HelpService hs = new HelpService();
            FolderExplorer fe = new FolderExplorer();
            do
            {
                Console.Clear();
                Console.WriteLine("\tMethods:");
                Console.WriteLine(" 1. Read text file and delete special char/string.");
                Console.WriteLine(" 2. Read text file and show count of words and every 10th word.");
                Console.WriteLine(" 3. Show 3d sentence with reverse words.");
                Console.WriteLine(" 4. Show file explorer.");
                Console.WriteLine(" 0. Exit.");

                key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        await hs.ReadTextFile();
                        hs.DeleteSubstr();
                        await hs.WriteToFile();
                        break;
                    case "2":
                        await hs.ReadTextFile();
                        hs.ShowCountWords();
                        break;
                    case "3":
                        await hs.ReadTextFile();
                        hs.ShowThirdReverseSentence();
                        break;
                    case "4":
                        fe.SetPath();
                        fe.WalkingTree();
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Oops!");
                        break;
                }
                Console.ReadLine();
            } while (key!="0");
        }
    }
}