using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Model.Models
{
    public class Product : ModelBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string Name { get; set; }
        public int NumberInStock { get; set; }
        public decimal Price { get; set; }
        public byte? SafeOff { get; set; }
        public string Description { get; set; }
        public bool HotFlag { get; set; }
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