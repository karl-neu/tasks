using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class HelpService
    {
        private string FilePath { get; set; }
        private string FormatedText { get; set; }
        private string OriginalText { get; set; }

        public HelpService()
        {
            var path = Environment.CurrentDirectory + "\\text.txt";
            if (File.Exists(path))
            {
                FilePath = path;
            }
        }

        public void SetPath(string str)
        {
            do
            {
                Console.Clear();
                Console.Write("Enter file path: ");
                str = Console.ReadLine();
            } while (!File.Exists(str));
            FilePath = str;
            Console.Clear();
        }

        public async Task ReadTextFile()
        {
            try
            {
                using var sr = new StreamReader(FilePath);
                OriginalText = await sr.ReadToEndAsync();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void ShowOriginalText()
        {
            Console.WriteLine(OriginalText);
        }

        public void ShowFormatedText()
        {
            Console.WriteLine(FormatedText);
        }

        public void DeleteSubstr()
        {
            Console.Write("Enter Char/String for delete: ");
            var str = Console.ReadLine();

            int index = OriginalText.IndexOf(str);

            if (index >= 0)
                FormatedText = OriginalText.Replace(str, "");
            else Console.WriteLine($"Char/String \"{str}\" not found!");
        }

        public void ShowCountWords()
        {
            string[] words = OriginalText.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',', '\\', '\r', '\n', ')', '(', '\"' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Count of words: {words.Length}");

            Console.WriteLine("Every 10th word: ");
            for (int i = 0; i < words.Length; i++)
            {
                if ((i + 1) % 10 == 0) Console.Write(words[i] + ", ");
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
            string reverseWordString = string.Join(" ", str.Split(' ').Select(x => new String(x.Reverse().ToArray())));
            return reverseWordString;
        }
    }
}