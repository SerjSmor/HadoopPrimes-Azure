using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeReducer
{
    class PrimeReducer
    {

        static void Main(string[] args)
        {
            string word = null;

            if (args.Length > 0)
            {
                Console.SetIn(new StreamReader(args[0]));
            }

            while ((word = Console.ReadLine()) != null)
            {
                int num;
                string[] line = word.Split(' ');
                bool result = Int32.TryParse(line[0], out num);

                if (result) // succeded to parse
                {
                    Console.WriteLine("{0} isPrime: {1}", num, IsPrime(num));
                }
                else // failed to parse
                {
                    Console.WriteLine("failed to parse:{0}", word);
                }

                //Console.WriteLine("word: {0}", word);
            }

            //ParseFile("primes.txt");
        }

        // a simple prime checker that wastes CPU on purpose (we can improve by square root for example)
        private static bool IsPrime(int num)
        {
            int loopLength = num / 2;
            for (int i = 2; i < loopLength; i++)
            {
                int modResult = num % i;
                if (modResult == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //private static void ParseFile(String fileName)
        //{
        //    using (FileStream fs = File.Open(fileName, FileMode.Open))
        //    using (BufferedStream bs = new BufferedStream(fs))
        //    using (StreamReader sr = new StreamReader(bs))
        //    {
        //        string s;
        //        while ((s = sr.ReadLine()) != null)
        //        {
        //            int num;
                    
        //            string[] line = s.Split(' ');
        //            bool result = Int32.TryParse(line[1], out num);

        //            if (result) // succeded to parse
        //            {
        //                Console.WriteLine("{0} isPrime: {1}", num, IsPrime(num));
        //            }
        //            else // failed to parse
        //            {
        //                Console.WriteLine("failed to parse:{0}", s);
        //            }
        //        }
        //    }
        //}
    }

    
}


