using Core.Common.Interfaces;
using Data.Entities;
using System;
using System.Threading.Tasks;

namespace Core.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChanges();

        public IRepository<User,int> UserRepository { get; }
        public IRepository<Comment,int> CommentRepository { get; }
    }
}
