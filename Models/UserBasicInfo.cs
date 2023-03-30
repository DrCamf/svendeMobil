using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace svendeMobil.Models
{
    public class UserBasicInfo
    {
        public string firstName ; 
        public string lastName;

        public string FullName
        {
            set
            {
                firstName = value;
                lastName = value;
            }
            get
            {
                return firstName + " " + lastName;
            }
        }
    }
}
