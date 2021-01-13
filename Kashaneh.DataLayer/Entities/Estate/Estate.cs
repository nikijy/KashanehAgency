using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Kashaneh.DataLayer.Entities.User;

namespace Kashaneh.DataLayer.Entities.Estate
{
    public class Estate
    {
        public Estate()
        {

        }

        [Key]
        public int EstateId { get; set; }
        [Display(Name = "نوع ملک")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int EstateTypeId { get; set; }
        [Display(Name = "زیرمجموعه")]
        public int? SubEstateType { get; set; }

        [Display(Name = "وضعیت ملک")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int StatusId { get; set; }
        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int CityId { get; set; }
        [Display(Name = "منطقه")]
        public int? Region { get; set; }
        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int UserId { get; set; }
        
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int Price { get; set; }
        [Display(Name = "مدت زمان ساخت")]
        public int CreateDuration { get; set; }
        [Display(Name = "مساحت")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int Area { get; set; }
        [Display(Name = "تعداد اتاق خواب")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int BedRooms { get; set; }
        [Display(Name = "تعداد حمام")]

        public int BathRooms { get; set; }
        [Display(Name = "تعداد طبقات")]

        public int Floors { get; set; }
        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Address { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "توضیح کوتاه")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string ShortDescription { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Description { get; set; }
        [Display(Name = "کلمات کلیدی")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Tags { get; set; }
        [Display(Name = "امکانات")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Facilities { get; set; }
        [Display(Name = "حذف شده؟")]
        public bool IsDeleted { get; set; }

        #region relations

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        [ForeignKey("Region")]
        public virtual City Zone { get; set; }

        public virtual EstateStatus EstateStatus { get; set; }

        [ForeignKey("EstateTypeId")]
        public virtual EstateType EstateType { get; set; }
        [ForeignKey("SubEstateType")]
        public EstateType SubType { get; set; }

        public virtual User.User User { get; set; }
        public virtual LikedEstate LikedEstate { get; set; }
        public List<EstateImage> EstateImages { get; set; }

       

        #endregion
    }
}
