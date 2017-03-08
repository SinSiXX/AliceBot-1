using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceBot
{
    class Converters
    {
        public char[] NonBinaryChar = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h',
            'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
            'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
            'y', 'z', '2', '3', '4', '5',
            '6', '7', '8', '9', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
            'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            'U', 'V', 'W', 'X', 'Y', 'Z', '!', '@',
            '#', '$', '%', '^', '&', '(', ')', '+',
            '-', '*', '/', '[', ']', '{', '}', '=',
            '<', '>', '?', '_', '"', '.', ','
        };

        public char[] NonMorseChar = { '!', '@',
            '#', '$', '%', '^', '&', '(', ')', '+',
            '-', '*', '/', '[', ']', '{', '}', '=',
            '<', '>', '?', '_', '"', '.', ',', ' ' };

        public class Binaries
        {
            public string ToBinary(string Input)
            {
                ASCIIEncoding encode = new ASCIIEncoding();
                string output = "";
                foreach (char c in Input)
                {
                    output += Convert.ToString(c, 2).PadLeft(8, '0') + " ";
                }
                return output;
            }

            public string FromBinary(string binary)
            {
                string output = "";
                binary = binary.Replace(" ", "");
                for (int i = 0; i < binary.Length; i += 8)
                {
                    string C = binary.Substring(i, 8);
                    output += (char)Convert.ToByte(C, 2);
                }
                return output;
            }
        }

        public class Morse {
            Dictionary<char, string> Txt;

            public Morse()
            {
                Txt = new Dictionary<char, string>();
                Txt.Add('A', ".-");
                Txt.Add('B', "-...");
                Txt.Add('C', "-.-.");
                Txt.Add('D', "-..");
                Txt.Add('E', ".");
                Txt.Add('F', "..-.");
                Txt.Add('G', "--.");
                Txt.Add('H', "....");
                Txt.Add('I', "..");
                Txt.Add('J', ".---");
                Txt.Add('K', "-.-");
                Txt.Add('L', ".-..");
                Txt.Add('M', "--");
                Txt.Add('N', "-.");
                Txt.Add('O', "---");
                Txt.Add('P', ".--.");
                Txt.Add('Q', "--.-");
                Txt.Add('R', ".-.");
                Txt.Add('S', "...");
                Txt.Add('T', "-");
                Txt.Add('U', "..-");
                Txt.Add('V', "...-");
                Txt.Add('W', ".--");
                Txt.Add('X', "-..-");
                Txt.Add('Y', "-.--");
                Txt.Add('Z', "--..");
                Txt.Add('1', ".----");
                Txt.Add('2', "..---");
                Txt.Add('3', "...--");
                Txt.Add('4', "....-");
                Txt.Add('5', ".....");
                Txt.Add('6', "-....");
                Txt.Add('7', "--...");
                Txt.Add('8', "---..");
                Txt.Add('9', "----.");
                Txt.Add('0', "-----");
            }

            private string ConvertChar(char ch)
            {
                if (Txt.Keys.Contains(ch))
                    return Txt[ch];
                else
                    return string.Empty;
            }

            private string ConvertWord(string word)
            {
                StringBuilder strbuild = new StringBuilder();
                foreach (char ch in word)
                {
                    if (strbuild.Length != 0 && strbuild[strbuild.Length - 1] != ' ')
                        strbuild.Append(" ");
                    strbuild.Append(ConvertChar(ch));
                }
                return strbuild.ToString();
            }

            public string ConvertText(string Input)
            {
                string[] words = Input.ToUpper().Split(' ');
                StringBuilder strbuild = new StringBuilder();
                foreach (string word in words)
                {
                    if (strbuild.Length != 0)
                        strbuild.Append("/");
                    strbuild.Append(ConvertWord(word));
                }
                return strbuild.ToString();
            }

        }

    }
}
