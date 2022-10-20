using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Contexts
{
    public class Context : DbContext, IWebContext
    {
        string _connectionString;
        public Context(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];

        }
        public Context(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        public DbSet<User> Users { get ; set ; }
        public DbSet<Note> Notes { get ; set ; }
        public DbSet<Subscription> Subscriptions { get ; set ; }
        public DbSet<SubscriptionType> SubscriptionTypes { get ; set ; }
        public DbSet<Category> Categories { get ; set ; }
        public DbSet<NoteCategory> NoteCategories { get ; set ; }

        bool IWebContext.Dispose()
        {
            try
            {
                base.Dispose();
            }
            catch (Exception e)
            {
                //handle with some logger
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        bool IWebContext.SaveChanges()
        {
            try
            {
                base.SaveChanges();
            }
            catch (Exception e)
            {
                //handle with some logger
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        async Task<bool> IWebContext.SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                //handle with some logger
                return false;
            }

            return true;
        }

        EntityEntry IWebContext.Update<TEntity>(TEntity entity)
        {
            try
            {
                return base.Update(entity);
            }
            catch (Exception e)
            {
                //handle with some logger
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
