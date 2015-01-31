//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vrooms.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookItem
    {
        public BookItem()
        {
            this.ReservedBookItems = new HashSet<ReservedBookItem>();
        }
    
        public int BookItemId { get; set; }
        public int BookId { get; set; }
        public CirculationStatuses CirculationStatusId { get; set; }
        public string RFID { get; set; }
        public string Barcode { get; set; }
        public string ShelvingLocation { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual ICollection<ReservedBookItem> ReservedBookItems { get; set; }
    }
}
