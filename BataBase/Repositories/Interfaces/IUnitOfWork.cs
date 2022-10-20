using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        public BaseRepository<User> Users {get; }
        public BaseRepository<Note> Notes{get; }
        public BaseRepository<Category> Categories{get; }
        public BaseRepository<NoteCategory> NoteCategories{get; }
        public BaseRepository<Subscription> Subscriprions{get; }
        public BaseRepository<SubscriptionType> SubscriptionTypes { get; }
        public void SaveChanges();

        public Task SaveChangesAsync();

        public void Dispose(bool disposing);

        public void Dispose();
    }
}
