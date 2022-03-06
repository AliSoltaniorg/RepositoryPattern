using Core.Common.Interfaces;
using Core.Common.Services;
using Data.Context;
using Data.Entities;
using Data.Interfaces;
using System.Threading.Tasks;

namespace Core.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPatternDbContext _context;

        public UnitOfWork(IPatternDbContext db)
        {
            _context = db;
        }


        private IRepository<User, int> _userRepository;
        public IRepository<User, int> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new Repository<User, int>(_context);
                return _userRepository;
            }
        }

        private IRepository<Comment, int> _commentRepository;
        public IRepository<Comment, int> CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new Repository<Comment, int>(_context);
                return _commentRepository;
            }
        }


        //When have Dependency Container
        //private readonly IPatternDbContext _context;
        //public UnitOfWork(IPatternDbContext context)
        //{
        //    _context = context;
        //}

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync(false);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
