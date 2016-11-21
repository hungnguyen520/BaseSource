using System;

namespace BaseSource.Model.Models
{
    public class ModelBase<TKey>
    {
        private TKey Id { get; set; }
        private bool IsDeleted { get; set; }
        private DateTime CreateDate { get; set; }
        private DateTime? UpdateDate { get; set; }
    }
}