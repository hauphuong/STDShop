using System;
using System.ComponentModel.DataAnnotations;

namespace STDShop.Model.Abstract
{
    public abstract class Auditable : IAuditTable
    {
        [MaxLength(256)]
        public string CreatedBy
        {
            set; get;
        }

        public DateTime? CreatedDate
        {
            set; get;
        }

        [MaxLength(256)]
        public string MetaDescription
        {
            set; get;
        }

        [MaxLength(256)]
        public string MetaKeyword
        {
            set; get;
        }

        public bool Status
        {
            set; get;
        }

        [MaxLength(256)]
        public string UpdateBy
        {
            set; get;
        }

        public DateTime? UpdatedDate
        {
            set; get;
        }
    }
}