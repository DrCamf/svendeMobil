using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svendeMobil.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public int Zzipcode_id { get; set; }
        public string Phone { get; set; }
        public int Role_id { get; set; }
        public string BirthDate { get; set; }
        public string PicturePath { get; set; }
    }
}
