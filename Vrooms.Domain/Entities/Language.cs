using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vrooms.Domain.Entities
{
    public class Language
    {
        public Language()
        {
            this.Books = new HashSet<Book>();
        }

        public int LanguageId { get; set; }
        public string Iso3 { get; set; }
        public string LanguageName_En { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
