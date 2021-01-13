using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Kashaneh.DataLayer.Entities.User
{
    public class User
    {
        public User()
        {
            
        }
        [Key]
        public int UserId { get; set; }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string UserName { get; set; }
        [Display(Name = "املاک پسندیده شده")]
        public int? LikedEstateId { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمیباشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "نام")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string LastName { get; set; }

        [Display(Name = "شماره همراه")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "شماره همراه معتبر نمیباشد")]
        public string Mobile { get; set; }

        [Display(Name = "کد فعالسازی")]
         [MaxLength(50,ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string ActiveCode { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "آواتار")]
         [MaxLength(200,ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string UserAvatar { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "حذف شده؟")]
        public bool IsDeleted { get; set; }

        #region MyRegion

        public virtual List<UserRole> UserRoles { get; set; }
        public virtual List<Blog.Blog> Blogs { get; set; }
        public virtual List<Estate.Estate> Estates { get; set; }
        public virtual List<LikedEstate> LikedEstates { get; set; }
        
        #endregion
    }
}
