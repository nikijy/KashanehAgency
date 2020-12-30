using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kashaneh.DataLayer.Entities.Estate
{
   public class EstateStatus
    {
        public EstateStatus()
        {
            
        }
        [Key]
        public int StatusId { get; set; }
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string Title { get; set; }

        #region Ralations

        public virtual List<Estate> Estates { get; set; }


        #endregion
    }
}



