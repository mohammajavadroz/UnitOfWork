using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Domain.Models;

namespace UnitOfWork.Domain.User
{
    public class User : BaseEntity<Guid>
    {

        public User()
        {
            Id = Guid.NewGuid();
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsDelete { get; set; }
    }
}
