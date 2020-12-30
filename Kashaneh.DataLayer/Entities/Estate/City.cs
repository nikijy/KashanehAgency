using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kashaneh.DataLayer.Entities.Estate
{
    public class City
    {
        public City()
        {

        }
        [Key]
        public int CityId { get; set; }
        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string CityName { get; set; }
        [Display(Name = "نام منطقه")]
        public int? ParentId { get; set; }

        #region relations

        [ForeignKey("ParentId")]
        public virtual List<City> Cities { get; set; }

        public virtual List<Estate> Estates { get; set; }

        #endregion
    }
}
