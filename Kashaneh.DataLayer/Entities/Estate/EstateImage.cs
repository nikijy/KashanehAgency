using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kashaneh.DataLayer.Entities.Estate
{
    public class EstateImage
    {

        [Key]
        public int EstateImageId { get; set; }
        [Display(Name = "ملک")]
        public int EstateId { get; set; }
        [Display(Name = "تصویر ملک")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Image { get; set; }

        #region relations

        [ForeignKey("EstateId")]
        public virtual Estate Estate { get; set; }


        #endregion
    }
}

