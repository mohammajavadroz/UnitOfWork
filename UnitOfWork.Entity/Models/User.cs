using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Entity.Models
{
    public class User : BaseEntity<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Fullname { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
    }
}
