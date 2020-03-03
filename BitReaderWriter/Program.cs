using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitReaderWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the source file path: ");
            string sourcePath = Console.ReadLine();

            Console.WriteLine("Enter the destination file path: ");
            string destinationPath = Console.ReadLine();

            long numberOfRemainingBits = new System.IO.FileInfo(sourcePath).Length * 8;
            int numberOfBits;

            BitReader reader = new BitReader(sourcePath);
            BitWriter writer = new BitWriter(destinationPath);
            Random rand = new Random();

            while (numberOfRemainingBits > 0)
            {
                numberOfBits = 1 + rand.Next(0, 32);
                if(numberOfRemainingBits < numberOfBits)
                {
                    numberOfBits = (int)numberOfRemainingBits;
                }
                int value = reader.readNBits(numberOfBits);
                writer.writeNBits(value, numberOfBits);
                numberOfRemainingBits -= numberOfBits;
            }
        }
    }
}
