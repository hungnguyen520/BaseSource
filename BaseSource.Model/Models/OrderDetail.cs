﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseSource.Model.Models
{
    public class OrderDetail : ModelBase<Guid>
    {
        [Key]
        [Column(Order = 1)]
        public Guid OrderId { set; get; }

        [Key]
        [Column(Order = 2)]
        public Guid ProductId { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        [ForeignKey("OrderId")]
        public virtual Order OrderRef { set; get; }

        [ForeignKey("ProductId")]
        public virtual Product ProductRef { set; get; }
    }
}