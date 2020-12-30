using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Kashaneh.DataLayer.Entities.Blog
{
    public class BlogComment
    {
        public BlogComment()
        {

        }
        [Key]
        public int BlogCommentId { get; set; }

        public int BlogId { get; set; }
       
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Name { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        public string Email { get; set; }
        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(800, ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string Comment { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "حذف شده؟")]
        public bool IsDeleted { get; set; }

        #region relations
        public virtual Blog Blog { get; set; }

        #endregion
       
    }
}
