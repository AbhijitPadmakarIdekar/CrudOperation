using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IDeveloperRepository? Developer { get; }
        public IProjectRepository? Project { get; }
        public Task<int> SavaAsync();
    }
}
