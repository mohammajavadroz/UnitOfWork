using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Shared.InfraStructure.Repository;

namespace UnitOfWork.Domain.Product
{
    public interface IProductRepository : IRepository<Product, long>
    {
    }
}
