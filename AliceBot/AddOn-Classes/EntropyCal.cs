using System;
using System.Collections.Generic;
using System.Linq;

namespace AliceBot
{
    class EntropyCal
    {
        public double EntropyValue(string password) {
            Dictionary<char, int> kkk = password.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            double EntropyValue = 0;
            foreach (var character in kkk)
            {
                float PR = character.Value / (float)password.Length;
                EntropyValue += PR * Math.Log(PR, 2);
            }
            EntropyValue = -EntropyValue;
            return EntropyValue;
        }

        public double EntropyBits(string password) {
            Dictionary<char, int> kkk = password.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            double EntropyValue = 0;
            foreach (var character in kkk)
            {
                float PR = character.Value / (float)password.Length;
                EntropyValue += PR * Math.Log(PR, 2);
            }
            EntropyValue = -EntropyValue;
            double EntropyBits = Math.Ceiling(EntropyValue) * password.Length;
            return EntropyBits;
        }
    }

    }