using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB_EFUygulama.Data
{
    public class Role
    {
        #region ScalarProperties
        public int ID { get; set; }
        public string Name { get; set; }

        public bool Write { get; set; }
        public bool Read { get; set; }
        public bool View { get; set; }
        #endregion
        #region NavigationalProperties
        public virtual ICollection<UserProfile> UserProfile { get; set; }
        #endregion
        public Role()
        {
            this.UserProfile = new HashSet<UserProfile>();
        }
    }
}
