using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static BaseSource.Common.Enums;

namespace BaseSource.Model.Models
{
    public class Customer : ModelBase<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public GENDER Gender { get; set; }

        public virtual IEnumerable<Order> OrderList { get; set; }
    }
}