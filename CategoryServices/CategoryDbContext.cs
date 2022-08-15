using CategoryServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryServices
{
    public class CategoryDbContext : DbContext
    {
        public CategoryDbContext(DbContextOptions<CategoryDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                //Create creater Database
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                // Khởi tạo thành công 
                if (databaseCreator != null)
                {
                    //Nếu chưa có database thì tạo database
                    if (!databaseCreator.CanConnect())
                    {
                        databaseCreator.Create();
                    }
                    //Nếu chưa có table thì tạo table
                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public DbSet<Category> Categories { get; set; }
    }
}
