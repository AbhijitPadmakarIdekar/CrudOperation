using CrudOperation.DataAccess.Repositories;
using CrudOperation.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private bool _disposed = false;

        public IDeveloperRepository Developer { get; private set; }
        public IProjectRepository Project { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Developer = new DeveloperRepository(_context);
            Project = new ProjectRepository(_context);
        }

        public async Task<int> SavaAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
