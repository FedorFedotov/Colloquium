using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISPU.ViewModel
{
    using System.Collections.Generic;
    using SISPU.Models;

    public class UserVM
    {

        public int id;
        public bool status;
        public string user_name;
        public string user_surname;
        public string login;
        public string password;
        public int year;
        public GroupVM user_group;

        public UserVM(User use)
        {
            this.id = use.Id;
            this.status = use.Status;
            this.user_name = use.Name;
            this.user_surname = use.Surname;
            this.login = use.Login;
            this.password = use.Password;
            this.year = use.Year;

            user_group = new GroupVM();
            // if (use.Group.IsDeleted == false)
            // {
            //     user_group = new GroupVM(use.Group);
            // }
        }

        public UserVM()
        {
        }

    }
}
