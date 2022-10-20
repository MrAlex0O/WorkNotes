using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Contexts
{
    public interface IWebContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NoteCategory> NoteCategories { get; set; }
        public Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
        public bool SaveChanges();
        public EntityEntry Update<TEntity>(TEntity entity);
        public bool Dispose();
    }
}
