using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._1
{
    public class CustomString
    {
        private char[] line;

        public int Length => line.Length;

        public bool Equals(CustomString obj)
        {
            if (this.Length != obj.Length)
                return false;
            for (int i = 0; i < Length; i++)
            { 
                if (this.line[i] != obj.line[i])
                    return false;
            }
            return true;
        }

        public bool Contains(string subStr)
        {
            return line.ToString().Contains(subStr);
        }

        public CustomString Concat(CustomString str)
        {
            char[] newLine = new char[this.Length + str.Length];

            this.line.CopyTo(newLine, 0);
            str.line.CopyTo(newLine, this.Length);

            this.line = newLine;

            return this;
        }

        public List<double> FindNumbers()
        {
            List<double> numbers = new List<double>();
            StringBuilder number = new StringBuilder();
            double val;

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    while (i < line.Length && char.IsDigit(line[i]))
                    {
                        number.Append(line[i]);
                        i++;
                        if (i + 1 < line.Length && line[i] == '.')
                        {
                            if (char.IsDigit(line[i + 1]))
                            {
                                number.Append(',');
                                i++;
                                while (i < line.Length && char.IsDigit(line[i]))
                                {
                                    number.Append(line[i]);
                                    i++;
                                }
                            }
                        }
                    }
                    if (double.TryParse(number.ToString(), out val))
                    {
                        val = double.Parse(number.ToString());
                        numbers.Add(val);
                    }
                    number.Clear();
                }
            }
            return numbers;
        }

        public List<CustomString> FindWords()
        {
            List<CustomString> words = new List<CustomString>();
            StringBuilder word = new StringBuilder();
            CustomString str = new CustomString();

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsLetter(line[i]))
                {
                    while (i < line.Length && char.IsLetter(line[i]))
                    {
                        word.Append(line[i]);
                        i++;
                    }
                    str = new CustomString(word.ToString().ToCharArray());
                    word.Clear();
                    words.Add(str);
                }
            }
            return words;
        }

        public CustomString Validator()
        {
            char[] newLine = line;
            char[] temp;

            if (char.IsLetter(newLine[0]))
            {
                temp = newLine[0].ToString().ToUpper().ToCharArray();
                newLine[0] = temp[0];
            }
            for (int i = 1; i < newLine.Length; i++)
            {
                if (newLine[i].Equals('.')
                    || newLine[i].Equals('?')
                    || newLine[i].Equals('!'))
                {
                    while (i < newLine.Length && !char.IsLetter(newLine[i]))
                        i++;
                    if (i < newLine.Length)
                    {
                        temp = newLine[i].ToString().ToUpper().ToCharArray();
                        newLine[i] = temp[0];
                    }
                }
            }

            return new CustomString(newLine);
        }

        public char this[int i]
        {
            get => line[i];
            set => line[i] = value;
        }

        public CustomString(char[] charArray)
        {
            line = charArray;
        }

        public CustomString()
        {
            line = new char[0];
        }

        public static CustomString operator +(CustomString str1, CustomString str2)
        {
            char[] newLine = new char[str1.Length + str2.Length];

            str1.line.CopyTo(newLine, 0);
            str2.line.CopyTo(newLine, str2.Length);

            str1.line = newLine;

            return str1;
        }

        public static implicit operator CustomString(char[] charArray)
        {
            return new CustomString { line = charArray };
        }
        public static implicit operator CustomString(string str)
        {
            return new CustomString { line = str.ToCharArray() };
        }
        public static explicit operator char[](CustomString str)
        {
            char[] charArray = new char[str.Length];
            Array.Copy(str.line, charArray, str.Length);
            return charArray;
        }
        public static explicit operator string(CustomString str)
        {
            return new string(str.line);
        }

        public override string ToString()
        {
            return new string(line);
        }
    }
}
