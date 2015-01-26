using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vrooms.Domain.Entities;

namespace Vrooms.Domain.Abstract
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> Languages { get; }
    }
}
