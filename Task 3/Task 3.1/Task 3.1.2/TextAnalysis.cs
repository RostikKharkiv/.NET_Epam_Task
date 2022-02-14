using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3._1._2
{
    public class TextAnalysis
    {
        private Dictionary<string, int> _words = new Dictionary<string, int>();

        private string _text;

        public IEnumerable<KeyValuePair<string, int>> Words 
            => _words.OrderByDescending(w => w.Value);

        public IEnumerable<KeyValuePair<string, int>> FrequentlyUsedWords
            => Words.Where(w => w.Value >= Math.Round((double)(WordsCount / 100 * Frequency)));

        public int WordsCount { get; private set; }

        public int Frequency { get; set; }

        public TextAnalysis(string text)
        {
            _text = text;
            Frequency = 5;
            FindWords();
        }

        private void FindWords()
        {
            StringBuilder word = new StringBuilder();

            for (int i = 0; i < _text.Length; i++)
            {
                if (char.IsLetter(_text[i]))
                {
                    while (i < _text.Length && char.IsLetter(_text[i]))
                    {
                        word.Append(_text[i]);
                        i++;
                    }

                    if (_words.ContainsKey(word.ToString()))
                    {
                        _words[word.ToString()]++;
                    }
                    else
                    {
                        _words.Add(word.ToString(), 1);
                    }

                    WordsCount++;

                    word.Clear();
                }
            }
        }
    }
}
