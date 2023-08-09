using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IDeveloperRepository? Developers { get; }
        public IProjectRepository? Projects { get; }
        public int Complete();
    }
}
