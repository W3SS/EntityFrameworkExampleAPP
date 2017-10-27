using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB_EFUygulama.Data
{
    public class UserProfile
    {
        #region ScalarProperties
        [Key, ForeignKey("User")]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }


        #endregion

        #region NavigationalProperties
        public virtual User User { get; set; }
        public virtual  ICollection<Role> Roles { get; set; }
        #endregion

        public UserProfile()
        {
            this.Roles = new HashSet<Role>();
        }
    }
}
