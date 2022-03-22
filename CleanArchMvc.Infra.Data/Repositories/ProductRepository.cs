﻿using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Domain.Interfaces;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryByIdAsync(int? id)
        {
            return await _productContext.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}