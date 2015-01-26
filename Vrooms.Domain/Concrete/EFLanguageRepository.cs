using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vrooms.Domain.Abstract;
using Vrooms.Domain.Entities;

namespace Vrooms.Domain.Concrete
{
    public class EFLanguageRepository : ILanguageRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Language> Languages
        {
            get { return context.Languages;  }
        }

    }
}
