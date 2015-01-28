using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vrooms.Domain.Abstract;
using Vrooms.Domain.Entities;

namespace Vrooms.Domain.Concrete
{
    public class EFBookItemRepository : IBookItemRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<BookItem> BookItems
        {
            get { return context.BookItems;  }
        }

    }
}
