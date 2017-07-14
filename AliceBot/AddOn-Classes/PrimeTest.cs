using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceBot
{
    //Code is copied from one of my resporitories
    //https://github.com/Yeo-Wen-Qin/PrimeTester
    class PrimeTest : Arithmetics
    {
        int NoOfTrials = 75;

        Random randy = new Random();
        Arithmetics Arith = new Arithmetics();
        MathFunctions MFunct = new MathFunctions();

    private ulong FastMod(ulong factor, ulong power, ulong modulus){
            ulong result = 1;
    while(power > 0){
        if (power % 2 == 1){
            result = (result* factor) % modulus;
            power = power-1;
        }
    power = power/2;
    factor = (factor* factor)%modulus;
    }
    return result;
}

        public bool PrimeTester(ulong inputNum){
    for (int trial = 0; trial< NoOfTrials; trial++){

                ulong randTest = Convert.ToUInt64(Math.Floor(randy.NextDouble() * (inputNum - 2))) + 2;

        if (gcd(randTest, inputNum) != 1){

        return false;
        }
        
       if (FastMod(randTest, inputNum-1,inputNum)!= 1){
        return false;
        }
        
    }
    
    return true;
 }

        private ulong gcd(ulong a, ulong b)
        {
            ulong c;
            while (a != 0)
            {
                c = a;
                a = b % a;
                b = c;
            }
            return b;
        }


    }
}
