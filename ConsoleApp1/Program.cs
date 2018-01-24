using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (haoziEntities haozi = new haoziEntities())
            {
                //for (var i = 0; i < 100000; i++)
                //{
                //    var guid = Guid.NewGuid().ToString();
                //    var cout = 0;
                //    cout++;
                //    var person = new test1()
                //    {
                //        Id = guid,
                //        Name = cout.ToString(),
                //        Sex = "男"
                //    };
                //    var code = new test2()
                //    {
                //        Id = guid,
                //        Yes = "yes",
                //        No = "no"
                //    };
                //    haozi.test1.Add(person);
                //    haozi.test2.Add(code);
                //}
                //haozi.SaveChanges();
                //haozi.Dispose();

                //var list = haozi.test1.Join(haozi.test2, t1 => t1.Id, t2 => t2.Id, (t1, t2) => new { t1, t2 }).ToList();
                //haozi.Dispose();

            }
            Console.ReadLine();
        }
    }

    public class Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public string Sex { get; set; }
        public string Yes { get; set; }
        public string No { get; set; }
    }

    public class Code
    {
        public string id { get; set; }
        public string Yes { get; set; }
        public string No { get; set; }
    }

}
