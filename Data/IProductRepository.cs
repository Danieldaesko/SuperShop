using SuperShop.Web.Data;
using SuperShop.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        
        public IQueryable GetAllWithUsers();
    }
}