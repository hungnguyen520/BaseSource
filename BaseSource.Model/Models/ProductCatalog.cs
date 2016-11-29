using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseSource.Model.Models
{
    public class ProductCatalog : ModelBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string Name { get; set; }
        public virtual IEnumerable<Product> ProductList { get; set; }
    }
}