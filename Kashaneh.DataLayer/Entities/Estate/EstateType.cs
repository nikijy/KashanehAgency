using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kashaneh.DataLayer.Entities.Estate
{
    public class EstateType
    {
        public EstateType()
        {

        }
        [Key]
        public int EstateTypeId { get; set; }
        [Display(Name = "نوع ملک")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string Type { get; set; }
        [Display(Name = "زیرمجموعه")]
        public int? ParentId { get; set; }

        #region relaions
        [ForeignKey("ParentId")]
        public virtual List<EstateType> EstateTypes { get; set; }

        public virtual List<Estate> Estates { get; set; }


        #endregion
    }
}
