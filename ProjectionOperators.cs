using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq101Samples
{
    public static class ProjectionOperators
    {
        //This sample uses select to produce a sequence of 
        //ints one higher than those in an existing array of ints.
        public static void Sample1Select()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var list = numbers.Select(n => n + 1);

            var qlist = from n in numbers
                        select n + 1;

            foreach (var item in list) //qlist
            {
                Console.WriteLine("Item value:" + item);
            }

            Console.ReadLine();
        }

        //This sample uses select to return a sequence of just the names of a list of products.
        public static void Sample2Select()
        {
            List<Product> products = Lists.GetProductList();

            var list = products.Select(p => p.ProductName);

            var qlist = from p in products
                        select p.ProductName;

            foreach (var item in list) //qlist
            {
                Console.WriteLine("Product Name:" + item);
            }

            Console.ReadLine();
        }

        //This sample uses select to produce a sequence of strings representing the text version of a sequence of ints.
        public static void Sample3Select()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var list = numbers.Select(n => strings[n]);

            var qlist = from n in numbers
                        select strings[n];

            foreach (var item in list) //qlist
            {
                Console.WriteLine("Text Version:" + item);
            }

            Console.ReadLine();
        }


        //This sample uses select to produce a sequence of the uppercase and lowercase versions of each word in the original array
        public static void SelectAnonymous()
        {
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var list = strings.Select(s => new { Upper = s.ToUpper(), Lower = s.ToLower() });

            var qlist = from s in strings
                        select new { Upper = s.ToUpper(), Lower = s.ToLower() };

            foreach (var item in list) //qlist
            {
                Console.WriteLine("Uppercase:" + item.Upper + "\t Lower case:" + item.Lower);
            }

            Console.ReadLine();
        }

        //This sample uses select to produce a sequence containing text representations 
        //of digits and whether their length is even or odd.
        public static void SelectAnonymous2()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var list = numbers.Select(n => new { Text = strings[n], Even = (n % 2 == 0) });

            var qlist = from n in numbers
                        select new { Text = strings[n], Even = (n % 2 == 0) };

            foreach (var d in qlist) //qlist
            {
                Console.WriteLine("The digit {0} is {1}.", d.Text, d.Even ? "even" : "odd");
            }

            Console.ReadLine();
        }

        //This sample uses select to produce a sequence containing some properties of Products,
        //including UnitPrice which is renamed to Price in the resulting type.
        public static void SelectAnonymous3()
        {
            List<Product> products = Lists.GetProductList();

            var list = products.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });

            var qlist = from p in products
                        select new { p.ProductName, p.Category, Price = p.UnitPrice };

            foreach (var d in list) //qlist
            {
                Console.WriteLine("The Product with Name {0} falls under {1} with Price {2}.", d.ProductName, d.Category, d.Price);
            }

            Console.ReadLine();
        }

        //This sample uses an indexed Select clause to determine 
        //if the value of ints in an array match their position in the array.
        public static void SelectIndexed()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var list = numbers.Select((n, i) => new { Matched = n == i ? "Matched" : "Not" });


            foreach (var d in list) //qlist
            {
                Console.WriteLine("Macthed: " + d.Matched);
            }

            Console.ReadLine();
        }

        //This sample combines select and where to make a simple query 
        //that returns the text form of each digit less than 5.
        public static void SelectFiltered()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var list = numbers.Where(p => p < 5).Select(n => digits[n]);

            var qlist = from n in numbers
                        where n < 5
                        select digits[n];


            foreach (var d in qlist) //qlist
            {
                Console.WriteLine("Item: " + d);
            }

            Console.ReadLine();
        }

        //This sample uses a compound from clause to make a query that returns all pairs of numbers from both 
        //arrays such that the number from numbersA is less than the number from numbersB.
        public static void SelectManyCompound1()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select new { a, b };

            Console.WriteLine("Pairs where a < b:");
            foreach (var pair in pairs)
            {
                Console.WriteLine("{0} is less than {1}", pair.a, pair.b);
            }

        }

        //This sample uses a compound from clause to select all orders where the order total is less than 500.00.
        public static void SelectManyCompound2()
        {
            List<Customer> customers = Lists.GetCustomerList();

            var orders = customers.SelectMany(o => o.Orders).Where(o => o.Total < 500.00M);

            var qorders = from c in customers
                          from o in c.Orders
                          where o.Total < 500.00M
                          select new { c.CustomerID, o.OrderID, o.Total };

            foreach (var o in qorders)
            {
                Console.WriteLine(o.Total);
            }

            Console.ReadLine();
        }

        //This sample uses a compound from clause to select all orders where the 
        //order was made in 1998 or later.
        public static void SelectManyCompound3()
        {
            List<Customer> customers = Lists.GetCustomerList();

            var orders = customers.SelectMany(o => o.Orders).Where(o => o.OrderDate >= new DateTime(1998, 1, 1));

            var qorders = from c in customers
                          from o in c.Orders
                          where o.OrderDate >= new DateTime(1998, 1, 1)
                          select new { c.CustomerID, o.OrderID, o.OrderDate };

            foreach (var o in orders)
            {
                Console.WriteLine(o.OrderID);
            }

            Console.ReadLine();
        }
        //This sample uses multiple from clauses so that filtering on customers can be done before selecting their orders. This makes the query more efficient 
        //by not selecting and then discarding orders for customers outside of Washington.
        public static void SelectManyMultiplefrom()
        {
            List<Customer> customers = Lists.GetCustomerList();

            DateTime cutoffDate = new DateTime(1997, 1, 1);

            //var orders = customers.Where(c => c.Country == "WA").SelectMany(o => o.Orders).Where(o => o.OrderDate < cutoffDate);

            var orders =
                from c in customers
                where c.Region == "WA"
                from o in c.Orders
                where o.OrderDate >= cutoffDate
                select new { c.CustomerID, o.OrderID };

            foreach (var o in orders)
            {
                Console.WriteLine(o.OrderID + "--" + o.CustomerID);
            }

            Console.ReadLine();

        }

        //This sample uses an indexed SelectMany clause to select all orders, while 
        //referring to customers by the order in which they are returned from the query.
        public static void SelectManyIndex()
        {
            List<Customer> customers = Lists.GetCustomerList();

            var custorders = customers.SelectMany((c, i) => c.Orders.Select(o => "Customer #" + (i + 1) +
                                    " has an order with OrderID " + o.OrderID));

            foreach (var o in custorders)
            {
                Console.WriteLine(o);
            }

            Console.ReadLine();
        }


    }


}
