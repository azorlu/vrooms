using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Vrooms.Domain.Entities
{
    [MetadataType(typeof(BookMetadata))]
    public partial class Book
    {
        
    }

    public class BookMetadata
    {
        [HiddenInput(DisplayValue = false)]
        public int BookId { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<BookItem> BookItems { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual Language Language { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter an author.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please enter a publisher.")]
        public string Publisher { get; set; }

        [Range(minimum: 0, maximum: 2100, ErrorMessage = "Please enter a valid year.")]
        public Nullable<short> PublicationYear { get; set; }

        [Range(minimum: 0, maximum: long.MaxValue, ErrorMessage = "Please enter a valid ISBN.")]
        public Nullable<long> ISBN { get; set; }

        [Required(ErrorMessage = "Please select a language.")]
        public int LanguageId { get; set; }
    }
}
