using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Model.Models
{
    public class Product : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string Name { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
        public byte SafeOff { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string ImageUrl { get; set; }

        public Guid BrandId { get; set; }
        public Guid CountryId { get; set; }
        public Guid ProductCatalogId { get; set; }
        public Guid UnitId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand BrandRef { get; set; }
        [ForeignKey("ProductCatalogId")]
        public virtual ProductCatalog ProductCatalogRef { get; set; }
        [ForeignKey("UnitId")]
        public virtual Unit UnitRef { get; set; }

    }
}
