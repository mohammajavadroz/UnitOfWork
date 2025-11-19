using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Domain.Models;

namespace UnitOfWork.Domain.Product
{
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; }

    }
}
