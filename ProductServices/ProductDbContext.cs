using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductServices
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var dbCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (dbCreater != null)
                {
                    //Nếu chưa có database thì tạo database
                    if (!dbCreater.CanConnect()) dbCreater.Create();
                    //Nếu chưa có table thì tạo table
                    if (!dbCreater.HasTables()) dbCreater.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public DbSet<Product> Products { get; set; }
    }
}
