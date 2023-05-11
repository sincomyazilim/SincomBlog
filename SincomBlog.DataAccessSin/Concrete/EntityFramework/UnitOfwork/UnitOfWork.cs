using SincomBlog.DataAccessLayer.Abstract;
using SincomBlog.DataAccessLayer.Abstract.UnitOfwork;
using SincomBlog.DataAccessLayer.Concrete.EntityFramework.Context;
using SincomBlog.DataAccessLayer.Concrete.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.DataAccessLayer.Concrete.UnitOfwork
{//19
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SincomBlogContext _context;
        private  EfCoreArticleRepository _articleRepository;
        private  EfCoreCategoryRepository _categoryRepository;
        private  EfCoreCommentRepository _commentRepository;
        private  EfCoreRolerepository _roleRepository;
        private  EfCoreUserRepository _userRepository;

        public UnitOfWork(SincomBlogContext context)
        {
            _context = context;
        }
        //---------------------------------------------------------------------------------
        public IArticleRepository Articles => _articleRepository??new EfCoreArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository??new EfCoreCategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository??new EfCoreCommentRepository(_context);

        public IRoleRepository Roles => _roleRepository??new EfCoreRolerepository(_context);

        public IUserRepository Users => _userRepository??new EfCoreUserRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
