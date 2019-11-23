namespace VKAPI_WinForm.DBModel
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class ContextDBMySQL : DbContext
    {       
        public DbSet<GroupComplete> groupsVK { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=#############;database=VKAPIDB;");
        }
    }    
}