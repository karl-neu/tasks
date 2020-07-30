using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace task1
{
    public class HelpService
    {
        private string FilePath { get; set; }
        private string OriginalText { get; set; }

        public HelpService()
        {
            var path = Environment.CurrentDirectory + "\\text.txt";
            if (File.Exists(path)) FilePath = path;
        }

        public async Task ReadTextFile()
        {
            try
            {
                using var sr = new StreamReader(FilePath);
                OriginalText = await sr.ReadToEndAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public async Task WriteToFile()
        {
            try
            {
                using StreamWriter outputFile = new StreamWriter(FilePath);
                await outputFile.WriteAsync(OriginalText);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be writed:");
                Console.WriteLine(e.Message);
            }
            
        }

        public void DeleteSubstr()
        {
            Console.Write("Enter Char/String for delete: ");
            var str = Console.ReadLine();

            int index = OriginalText.IndexOf(str);

            if (index >= 0)
            {
                OriginalText = OriginalText.Replace(str, "");
                Console.WriteLine($"Deleted!");
            }

            else Console.WriteLine($"Char/String \"{str}\" not found!");
        }

        public void ShowCountWords()
        {
            string[] words = OriginalText.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\\', '\r', '\n', ')', '(', '\"' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Count of words: {words.Length}");

            Console.WriteLine("Every 10th word: ");
            for (int i = 9; i < words.Length; i += 10)
            {
                Console.Write(words[i] + ", ");
            }
        }

        public void ShowThirdReverseSentence()
        {
            string[] sentences = OriginalText.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            if (sentences.Length > 2)
                Console.WriteLine(ReverseStr(sentences[2]));
        }

        public string ReverseStr(string str)
        {
            return string.Join(" ", str.Split(' ').Select(x => new String(x.Reverse().ToArray())));
        }
    }
}