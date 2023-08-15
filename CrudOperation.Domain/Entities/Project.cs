using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperation.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
    }
}
