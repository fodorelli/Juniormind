/*Ai un coș plin de produse.Dacă cunoști prețul fiecărui produs în parte:
Calculează care e totalul de plată pentru coșul cu cumpărături
Găsește și care e cel mai ieftin produs din coș
Elimină cel mai scump produs din coș
Adaugă un nou produs în coș
Calculează prețul mediu*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shoppings
{
    [TestClass]
    public class Shoppings
    {
        [TestMethod]
        public void TotalPriceTest()
        {
            var product = new Products[] { new Products("Oil", (decimal)1.5), new Products("Sugar", (decimal)1), new Products("Rice", (decimal)1.55), new Products("Salt", (decimal)2.5) };
            Assert.AreEqual((decimal)6.55, CalculateTotal(product));
        }
        [TestMethod]
        public void CheapestProductTest()
        {
            var product = new Products[] { new Products("Oil", (decimal)1.5), new Products("Sugar", (decimal)1), new Products("Rice", (decimal)1.55), new Products("Salt", (decimal)2.5) };
            Assert.AreEqual(product[1], CheapestProduct(product));

        }
        [TestMethod]
        public void DeletingTheMostExpensiveProductTest()
        {
            var product = new Products[] { new Products("Oil", (decimal)1.5), new Products("Sugar", (decimal)1), new Products("Rice", (decimal)1.55), new Products("Salt", (decimal)2.5) };
            DeleteTheMostExpensiveProduct(product);
            Assert.IsTrue(product[product.Length-2].ProductName != "Salt");
        }
        [TestMethod]
        public void AddingNewElementTest()
        {
            var product = new Products[] { new Products("Oil", (decimal)1.5), new Products("Sugar", (decimal)1), new Products("Rice", (decimal)1.55), new Products("Salt", (decimal)2.5), new Products("Ketchup", (decimal)3.5) };
            AddNewProduct(ref product);
            Assert.IsTrue(product[product.Length - 1].ProductName != "Ketchup");
        }
        [TestMethod]
        public void MeanValueTest()
        {
            var product = new Products[] { new Products("Oil", (decimal)1.5), new Products("Sugar", (decimal)1), new Products("Rice", (decimal)1.55), new Products("Salt", (decimal)2.5) };
            Assert.AreEqual((decimal)1.6375, CalculateMeanValue(product));
        }

        struct Products
        {
            public string ProductName;
            public decimal Price;
            public Products(string ProductName, decimal Price)
            {
                this.ProductName = ProductName;
                this.Price = Price;
            }
        }

        decimal CalculateTotal(Products[] product)
        {
            decimal total = 0;
            for (int i = 0; i < product.Length; i++)
                total += product[i].Price;
            return total;
        }

        Products CheapestProduct(Products[] product)
        {
            decimal theCheapestProduct = product[0].Price;
            int noProduct = 0;
            for (int i = 1; i < product.Length; i++)
                if (product[i].Price < theCheapestProduct)
                    noProduct = i;
            return product[noProduct];
        }
        private static int FindIndexOfTheMostExpensiveProduct(Products[] product)
        {
            decimal theCheapestProduct = product[0].Price;
            int noProduct = 0;
            for (int i = 1; i < product.Length; i++)
                if (product[i].Price > theCheapestProduct)
                    noProduct = i;
            return noProduct;
        }

        void DeleteTheMostExpensiveProduct(Products[] product)
        {
            int noProduct = FindIndexOfTheMostExpensiveProduct(product);
            product[noProduct] = product[product.Length - 1];
            Array.Resize(ref product, product.Length - 1);
        }

       

        void AddNewProduct(ref Products[] product)
        {
            Array.Resize(ref product, product.Length + 1);
            product[product.Length - 1].Price = (decimal)19.99;
            product[product.Length - 1].ProductName = "Shoes";
        }

        decimal CalculateMeanValue(Products[] product)
        {
            decimal sum = CalculateTotal(product);
            return sum / product.Length;
        }
    }
}

