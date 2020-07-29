using System;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\tTask #1\r\n");
            HelpService hs = new HelpService();

            await hs.ReadTextFile();
            hs.ShowThirdReverseSentence();
        }
    }
}