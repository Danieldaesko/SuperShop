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
using SuperShop.Helpers;


namespace SuperShop.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly Random _random;
       
        private readonly IUserHelper _userHelper;
        public SeedDb(DataContext context,  IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("danielkololo2018@gmail.com");
            if(user == null)
            {
                user = new User
                {
                    FirstName = "Daniel",
                    LastName = "Kololo",
                    Email = "danielkololo2018@gmail.com",
                    UserName="danielkololo2018@gmail.com",
                    PhoneNumber = "920080877"
                };
               var result = await _userHelper.AddUserAsync(user, "Daesko2@26");
                if (result !=IdentityResult.Success) 
                {
                    throw new InvalidOperationException("Could not create the user in seeding process.");
                }
                
            }

            if (!_context.Products.Any())
            {
                AddProduct("iPhone X",user);
                AddProduct("Magic Mouse",user);
                AddProduct("iWatch Series",user);
                AddProduct("iPad mini",user);

                // CRÍTICO: Guarda as alterações na base de dados
                await _context.SaveChangesAsync();
            }
        }

        // Método ajustado para aceitar apenas o nome e preencher o resto
        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(100, 1000), // Exemplo de preço aleatório
                IsAvailable = true,
                Stock = _random.Next(100), // Atenção ao nome da propriedade (Stock vs Stack)
                User=user,
            });
        }
    }
}