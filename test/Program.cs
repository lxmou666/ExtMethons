using ExtMethods;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var list = new List<test>();
            for (int i = 0; i < 100000; i++)
            {
                var t = new test();
                if (i%2==0)
                {
                    t.a = 5;
                    t.c = true;
                    t.e = Guid.NewGuid();
                    t.g = i + "string";
                    t.i = DateTime.Now;
                }
                else
                {
                    t.b = 5;
                    t.d = true;
                    t.f = Guid.NewGuid();
                    t.h = i + "string";
                    t.j = DateTime.Now;
                }
                list.Add(t);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var a = list.ToDataTable();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalSeconds);
            Console.ReadKey();
        }
    }

    internal class test
    {
        public int a { get; set; }
        public int b { get; set; }
        public bool c { get; set; }
        public bool d { get; set; }
        public Guid e { get; set; }
        public Guid f { get; set; }
        public string g { get; set; }
        public string h { get; set; }
        public DateTime i { get; set; }
        public DateTime j { get; set; }
    }
}
