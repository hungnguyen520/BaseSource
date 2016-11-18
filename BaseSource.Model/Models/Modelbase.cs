using System;

namespace BaseSource.Model.Models
{
    public class ModelBase<TKey>
    {
        TKey Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
