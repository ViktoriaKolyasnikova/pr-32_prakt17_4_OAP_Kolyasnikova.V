using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace pr_32_prakt17_4_OAP_Kolyasnikova.V
{
    internal class Program
    {
        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("t1.txt");
            StreamWriter sk = new StreamWriter("t2.txt");

            List<S> o = new List<S>();
            string str;
            while ((str = sr.ReadLine()) != null)
            {
                string[] t = str.Split(' ');
                o.Add(new S { F = t[0], I = t[1], O = t[2], G = t[3], B = Convert.ToDouble(t[4]) });
            }
         
            var s = from x in o
                    where x.B >= 4
                    select x;
            foreach (S z in s)
            {
                sk.WriteLine($"{z.F} {z.I} {z.O} {z.G} {z.B}");
            }
            sk.Close();

            StreamReader srr = new StreamReader("t2.txt");
            List<SS> oo = new List<SS>();
            string str1;
            while ((str1 = srr.ReadLine()) != null)
            {
                string[] t = str1.Split(' ');
                oo.Add(new SS { F = t[0], I = t[1], O = t[2], G = t[3], B = Convert.ToDouble(t[4]) });
            }

            var sg = from st in oo
                                 group st by st.G into g
                                 select new
                                 {
                                     Name = g.Key,
                                     Count = g.Count(),
                                     Studentes = from p in g select p
                                 };
            foreach (var group in sg)
            {
                Console.WriteLine($"{group.Name} : {group.Count}");
                foreach (SS st in group.Studentes)
                {
                    Console.WriteLine($"{st.F} {st.I} {st.O} {st.G} {st.B}");
                }
                Console.WriteLine();
            }
            srr.Close();
            Console.ReadLine();
        }
    }
    
}
