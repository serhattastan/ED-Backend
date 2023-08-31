﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Database Simulation
            _products = new List<Product> { 
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice= 15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice= 500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice= 1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice= 150, UnitsInStock=65}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /*
            Product productToDelete = null;
            foreach (var p in _products) 
            { 
                if (p.ProductId == productToDelete.ProductId)
                {
                    productToDelete = p;
                }
            }*/
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId );

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürün id'sini bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}