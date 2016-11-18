using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Model.Models
{
    public class Unit : ModelBase<Guid>
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
