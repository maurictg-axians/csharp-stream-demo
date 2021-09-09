using System;
using System.IO;
using System.Text;

namespace CSStreamDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var outP = Console.OpenStandardOutput();
            
            var b = new Block();
            b.Subscribe(outP);

            var b2 = new Block();
            b.Subscribe(b2.Stream);
            
            b.Write(Encoding.UTF8.GetBytes("Hello world!"));
            
            Console.WriteLine("\n");
            
            Console.WriteLine($"Data: {Encoding.UTF8.GetString(b2.Read())}");
            
        }
    }
}