using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCore.Models
{
    public class EFProductRepository : IProductRepository
    {
        ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Product> Products => context.Products;
    }
}
