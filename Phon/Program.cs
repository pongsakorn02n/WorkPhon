using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Phon
{
    class Program : IHomework09
    {
        static IEnumerable<IProduct> cart = new List<Product>();

        static void Main(string[] args)
        {
            string input = "";
            Program program = new Program();
            IEnumerable<IProduct> data_reading = program.GetAllProducts();

            while (true)
            {
                Console.WriteLine("\nProducts in your cart are");

                IQueryable<IProduct> selectProduct = data_reading.AsQueryable().Where((item, index) => (item.SKU == input));
                if(selectProduct.Count() > 0)
                {
                    //add to cart
                    program.AddProductToCart(selectProduct.ElementAt(0));
                }


                double total_price = 0;
                int numOfProduct = 1;
                foreach (Product p in program.GetProductsInCart().ToList())
                {
                    Console.WriteLine("{0}.{1} \t\t {2}", numOfProduct, p.Name, String.Format(CultureInfo.InvariantCulture, "{0:#,#.00}", p.Price));
                    total_price = total_price + p.Price;
                    numOfProduct++;
                }

                Console.WriteLine("---");
                Console.WriteLine("Total amount: {0} baht", String.Format(CultureInfo.InvariantCulture,"{0:#,#.00}", total_price));
                Console.Write("Please input a product key: ");
                input = Console.ReadLine();
            }
        }

        public void AddProductToCart(IProduct product)
        {
            cart = cart.Append(product);
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            var data_reading = File.ReadAllLines("C:\\product.csv").Select(l => l.Split(',').ToArray()).ToArray();
            IQueryable<String[]> itemProduct = data_reading.AsQueryable().Where((item, index) => (index != 0));
            IEnumerable<IProduct> product_list = new List<Product>();

            foreach(String [] item in itemProduct)
            {
                Product p = new Product();
                p.SKU = item[0];
                p.Name = item[1];
                p.Price = double.Parse(item[2], System.Globalization.CultureInfo.InvariantCulture);

                product_list = product_list.Append(p);
            }

            return product_list;
        }

        public IEnumerable<IProduct> GetProductsInCart()
        {
            return cart;
        }
    }
}
