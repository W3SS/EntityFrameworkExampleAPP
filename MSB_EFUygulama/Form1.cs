using MSB_EFUygulama.Data;
using MSB_EFUygulama.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSB_EFUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ServiceManager.RoleService.Add("public",false,false,true);
            //Role rl;
            //using (var dbCtx=new ProjectContext())
            //{
            //    rl = dbCtx.Role.Where(r => r.ID == 2).FirstOrDefault<Role>();
            //}
            //ServiceManager.RoleService.Edit(rl, "admin", true, true, true);
            //ServiceManager.RoleService.Delete(rl);
            //ServiceManager.RoleService.Add("public", false, false, true);
            //ServiceManager.RoleService.Add("admin", true, true, true);
            //ServiceManager.UserService.Add("user", "1234", "ilk", "kullanıcı", DateTime.Parse("1991-03-19"));
            //Role rl2;
            //Role rl3;
            //User usr;
            //using (var dbCtx = new ProjectContext())
            //{
            //    rl2 = dbCtx.Role.Where(r => r.ID == 3).FirstOrDefault<Role>();
            //    rl3 = dbCtx.Role.Where(r => r.ID == 4).FirstOrDefault<Role>();
            //    usr = dbCtx.User.Where(u => u.ID == 4).FirstOrDefault<User>();
            //}
            //ServiceManager.UserService.AddRole(usr, rl2, rl3);
            User user;
            Role rl4;
            using (var dbCtx = new ProjectContext())
            {
                user = dbCtx.User.Where(u => u.ID == 4).FirstOrDefault<User>();
                rl4 = dbCtx.Role.Where(r => r.ID == 4).FirstOrDefault<Role>();
            }

            ServiceManager.UserService.EditRole(user, rl4);




        }
    }
}
