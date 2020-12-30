using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kashaneh.DataLayer.Entities.Blog
{
    public class Blog
    {
        public Blog()
        {

        }
        [Key]
        public int BlogId { get; set; }
        [Display(Name = "نویسنده")]
        public int UserId { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name = " عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Title { get; set; }
        [Display(Name = "توضیح کوتاه")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string ShortDescription { get; set; }
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(800, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Description { get; set; }
        [Display(Name = "تصویر")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string ImageName { get; set; }
        [Display(Name = "حذف شده؟")]
        public bool IsDeleted { get; set; }
        [Display(Name = "بازدید")]
        public int Visit { get; set; }
        #region relations

        public virtual User.User User { get; set; }
        public virtual List<BlogComment> BlogComments { get; set; }

        #endregion
    }
}
