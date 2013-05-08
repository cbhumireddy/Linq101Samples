using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq101Samples
{
    public static class RestrictionOperators
    {
        public static void Simple1Where()
        {
            int[] numbers = { 1,3,4,5,6,7,8,2};

             var q = numbers.Where(n => n < 6);

             var p = from n in numbers
                     where n<6
                     select n;

             foreach (var item in q)
             {
                 Console.WriteLine(" Number :" + item);
             }

             foreach (var item in p)
             {
                 Console.WriteLine(" Item :" + item);
             }

             Console.ReadLine();
        }

        public static void Simple2Where()
        {
            List<Product> products = Lists.GetProductList();

            var list = products.Where(p => p.UnitsInStock == 0);

            var qlist = from p in products
                        where p.UnitsInStock == 0
                        select p;

            foreach (var item in list)
            {
                Console.WriteLine("Name:"+item.ProductName + "\t Price"+item.UnitPrice);
                
            }

            foreach (var item in qlist)
            {
                Console.WriteLine("Name1:" + item.ProductName + "\t Price1" + item.UnitPrice);

            }

            Console.ReadLine();
        }

        //This sample uses where to find all products that are in stock and cost more than 3.00 per unit.
        public static void Simple3Where()
        {
            List<Product> products = Lists.GetProductList();

            var list = products
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
            var count = 0;
            foreach (var item in list)
            {
                ++count;
                Console.WriteLine("Count: "+count+"\tName:" + item.ProductName + "\t Price" + item.UnitPrice);
            }

            count = 0;
            var qlist = from p in products
                        where p.UnitPrice > 3.00M && p.UnitsInStock > 0
                        select p;

            foreach (var item in qlist)
            {
                ++count;
                Console.WriteLine("Count: " + count + "\tName:" + item.ProductName + "\t Price" + item.UnitPrice);
            }
            Console.ReadLine();
        }

        public static void SampleDrillDown()
        {
            var customers = Lists.GetCustomerList();

            var list = customers.Where(c => c.Region == "WA");

            var qlist = from c in customers
                        where c.Region == "CA"
                        select c;

            foreach (var item in list)
            {
                Console.WriteLine(item.CompanyName);
                foreach (var item2 in item.Orders)
                {
                    Console.WriteLine(item2.OrderID + "----" + item2.OrderDate + "-------" + item2.Total);
                }
            }
            Console.ReadLine();
        }

        public static void IndexedWhere()
        {
            string[] digits = { "zero", "one", "two", "three", "four", 
                                  "five", "six", "seven", "eight", "nine" };

            var shortdigits = digits.Where((d, i) => d.Length < i);

            foreach (var d in shortdigits)
            {
                Console.WriteLine("The word {0} is shorter than its value.", d);
            }
            Console.ReadLine();
        }

    }
}
