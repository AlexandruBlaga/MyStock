﻿using MyStock.Data;
using MyStock.ViewModels;
using MyStock.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStock.Mappings
{
    public class ProductMap
    {
        public static ProductVM ProductToProductVM(Product product)
        {
            var productVM = new ProductVM
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Type = product.Type,
                Brand = (BrandEnum)product.Brand
            };

            return productVM;
        }

        public static Product ProductVMToProduct(ProductVM productVM)
        {
            var product = new Product
            {
                ProductId = productVM.ProductId,
                Name = productVM.Name,
                Price = productVM.Price,
                Type = productVM.Type,
                Brand = (int)productVM.Brand
            };

            return product;
        }
    }
}