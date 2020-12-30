using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Kashaneh.DataLayer.Entities.User
{
    public class Role
    {
        public Role()
        {
            
        }
        [Key]
        public int RoleId { get; set; }
        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(200,ErrorMessage = "{0}نمیتواند بیشتر از {1}کاراکتر باشد")]
        public string RoleTitle { get; set; }

        public bool IsDeleted { get; set; }

        #region MyRegion

        public virtual List<UserRole> UserRoles { get; set; }
      

        #endregion
    }
}
