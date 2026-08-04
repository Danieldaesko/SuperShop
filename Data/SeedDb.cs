using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;


namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Products.Any())
            {
                AddProduct("iPhone X");
                AddProduct("Magic Mouse");
                AddProduct("iWatch Series");
                AddProduct("iPad mini");

                // CRÍTICO: Guarda as alterações na base de dados
                await _context.SaveChangesAsync();
            }
        }

        // Método ajustado para aceitar apenas o nome e preencher o resto
        private void AddProduct(string name)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(100, 1000), // Exemplo de preço aleatório
                IsAvailable = true,
                Stock = _random.Next(100) // Atenção ao nome da propriedade (Stock vs Stack)
            });
        }
    }
}