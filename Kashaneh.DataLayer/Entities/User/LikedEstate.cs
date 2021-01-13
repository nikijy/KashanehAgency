using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kashaneh.DataLayer.Entities.User
{
   public class LikedEstate
    {
        public LikedEstate()
        {
            
        }
        [Key]
        public int LikedEstateId { get; set; }
        public int UserId { get; set; }
        public int EstateId { get; set; }

        #region relations

        public virtual User User { get; set; }
        public virtual List<Estate.Estate> Estates { get; set; }

        #endregion

    }
}
