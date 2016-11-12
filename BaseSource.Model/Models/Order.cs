using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaseSource.Common.Enums;

namespace BaseSource.Model.Models
{
    public class Order : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public DateTime DeliveryDate { get; set; }
        public decimal Value { get; set; }
        public string Note { get; set; }
        public ORDER_STATUS Status { get; set; }
        public ORDER_PAYMENT PayMethod { get; set; }


        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer CustomerRef { get; set; }
    }
}
