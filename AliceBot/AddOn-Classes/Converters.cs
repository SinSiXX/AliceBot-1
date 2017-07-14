using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceBot
{
    
    //Code is copied from one of my resporitories.
    //https://github.com/Yeo-Wen-Qin/BaseConversions
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
        
        
        public class ToBase10
        {
            public string FromBase16(string base16)
            {
                int base10 = 0;
                base16 = base16.ToUpper();
                if (CheckIfHexaDecimal(base16))
                {
                    for (int i = 0, base16L = base16.Length - 1; base16L != -1; i++, base16L--)
                    {
                        string Digit = base16[base16L].ToString();
                        byte store = 0;
                        switch (Digit)
                        {
                            case "A":
                                store = 10;
                                base10 += (int)(store * (Math.Pow(16, i)));
                                break;
                            case "B":
                                store = 11;
                                base10 += (int)(store * (Math.Pow(16, i)));
                                break;
                            case "C":
                                store = 12;
                                base10 += (int)(store * (Math.Pow(16, i)));
                                break;
                            case "D":
                                store = 13;
                                base10 += (int)(store * (Math.Pow(16, i)));
                                break;
                            case "E":
                                store = 14;
                                base10 += (int)(store * (Math.Pow(16, i)));
                                break;
                            case "F":
                                store = 15;
                                base10 += (int)(store * (Math.Pow(16, i)));
                                break;
                            default:
                                base10 += (int)(Convert.ToSByte(Digit) * (Math.Pow(16, i)));
                                break;
                        }
                    }
                    return base10.ToString();
                }
                else
                {
                    return "Please input a valid Base16 value!";

                }
            }

            private bool CheckIfHexaDecimal(string input)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(input, @"\A\b[0-9a-fA-F]+\b\Z");
            }

            public string FromBase2(string base2)
            {
                bool Base2orNot = CheckIfBase2(base2);
                if (!Base2orNot) { return "Please enter a valid Base2 value"; }
                else
                {
                    int Base10 = 0;
                    for (int i = 0, MaxLength = base2.Length - 1; MaxLength > -1; MaxLength--, i++)
                    {
                        char digit = base2[MaxLength];
                        if (digit == '1')
                        {
                            Base10 += (int)(Math.Pow(2, i));
                        }
                    }
                    return Base10.ToString();
                }
            }

            private bool CheckIfBase2(string input)
            {
                try
                {
                    foreach (char c in input)
                    {
                        int element = Convert.ToInt32(c.ToString());
                        if (element < 0 || element > 1)
                        {
                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception) { return false; }
            }

        }

        public class ToBase2 {
            private readonly Dictionary<string, string> HexDec = new Dictionary<string, string>();

            public ToBase2()
            {
                HexDec.Add("0", "0000");
                HexDec.Add("1", "0001");
                HexDec.Add("2", "0010");
                HexDec.Add("3", "0011");
                HexDec.Add("4", "0100");
                HexDec.Add("5", "0101");
                HexDec.Add("6", "0110");
                HexDec.Add("7", "0111");
                HexDec.Add("8", "1000");
                HexDec.Add("9", "1001");
                HexDec.Add("A", "1010");
                HexDec.Add("B", "1011");
                HexDec.Add("C", "1100");
                HexDec.Add("D", "1101");
                HexDec.Add("E", "1110");
                HexDec.Add("F", "1111");
            }

            public string FromBase10(string Base10)
            {
                try
                {
                    if (Convert.ToInt32(Base10) == 0) { return "0"; }
                    string Base2 = "";
                    for (int i = 0, result = Convert.ToInt32(Base10); result != 0;)
                    {
                        i = result % 2;
                        result /= 2;
                        Base2 += i.ToString();
                    }
                    return ReverseString(Base2);
                }
                catch (Exception) { return "Please input a valid base10 value!"; }
            }

            private string ReverseString(string input)
            {
                char[] CharArray = input.ToCharArray();
                Array.Reverse(CharArray);
                return new string(CharArray);
            }

            public string FromBase16(string Base16)
            {
                try
                {
                    Base16 = Base16.ToUpper();
                    if (CheckIfHexaDecimal(Base16) == false) { return "Please input a valid Base16 value!"; }
                    string Base2 = "";
                    foreach (char element in Base16)
                    {
                        string Store = element.ToString();
                        Base2 += HexDec[Store];
                    }
                    return Base2;
                }
                catch (Exception)
                {
                    return "Please input a valid Base16 value!";
                }
            }

            private bool CheckIfHexaDecimal(string input)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(input, @"\A\b[0-9a-fA-F]+\b\Z");
            }
        }

    }
}
