using DataBase.Contexts;
using DataBase.Models;
using DataBase.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private BaseRepository<User>? _users ;

        private BaseRepository<Note>? _notes ;

        private BaseRepository<Category>? _categories ;

        private BaseRepository<NoteCategory>? _noteCategories ;

        private BaseRepository<Subscription>? _subscriprions ;

        private BaseRepository<SubscriptionType>? _subscriptionTypes ;


        public BaseRepository<User> Users => _users ??= new BaseRepository<User>((Context) _context);

        public BaseRepository<Note> Notes => _notes ??= new BaseRepository<Note>((Context)_context);

        public BaseRepository<Category> Categories => _categories ??= new BaseRepository<Category>((Context)_context);

        public BaseRepository<NoteCategory> NoteCategories => _noteCategories ??= new BaseRepository<NoteCategory>((Context)_context);

        public BaseRepository<Subscription> Subscriprions => _subscriprions ??= new BaseRepository<Subscription>((Context)_context);

        public BaseRepository<SubscriptionType> SubscriptionTypes => _subscriptionTypes ??= new BaseRepository<SubscriptionType>((Context)_context);

        private bool _disposed = false;
        public UnitOfWork(IWebContext context)
        {
            _context = context;
        }
        private readonly IWebContext _context;
        public void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
