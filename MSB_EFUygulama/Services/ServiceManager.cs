using MSB_EFUygulama.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSB_EFUygulama.Services
{
    public static class ServiceManager
    {
        public static class RoleService
        {
            public static void Add(string name, bool write, bool read, bool view)
            {
                var role = new Role();
                role.Name = name;
                role.Write = write;
                role.Read = read;
                role.View = view;
                using (var dbCtx = new ProjectContext())
                {
                    dbCtx.Role.Add(role);
                    dbCtx.SaveChanges();
                }
            }
            public static void Edit(Role role, string name, bool write, bool read, bool view)
            {
                Role _role;
                using (var dbCtx = new ProjectContext())
                {
                    _role = dbCtx.Role.Where(r => r.ID == role.ID).FirstOrDefault<Role>();

                }
                if (_role.ID > 0)
                {
                    _role.Name = name;
                    _role.Write = write;
                    _role.Read = read;
                    _role.View = view;
                }
                using (var dbCtx = new ProjectContext())
                {
                    dbCtx.Entry(_role).State = EntityState.Modified;
                    dbCtx.SaveChanges();
                }
            }
            public static void Delete(Role role)
            {
                Role _role;
                using (var dbCtx = new ProjectContext())
                {
                    _role = dbCtx.Role.Where(r => r.ID == role.ID).FirstOrDefault<Role>();
                }
                using (var dbCtx = new ProjectContext())
                {
                    dbCtx.Entry(_role).State = EntityState.Deleted;
                    dbCtx.SaveChanges();
                }
            }

        }

        public static class UserService
        {

            public static void Add(string userName, string password, string firstName, string lastName, DateTime dob)
            {
                User user = new User();
                user.UserName = userName;
                user.Password = password;
                UserProfile userprofile = new UserProfile();
                userprofile.User = user;
                userprofile.FirstName = firstName;
                userprofile.LastName = lastName;
                userprofile.DOB = dob;
                using (var dbCtx = new ProjectContext())
                {
                    dbCtx.UserProfile.Add(userprofile);
                    dbCtx.SaveChanges();

                }
            }
            public static void Delete(User user)
            {
                User usr;
                using (var dbCtx = new ProjectContext())
                {
                    usr = dbCtx.User.Where(u => u.ID == user.ID).FirstOrDefault<User>();
                }
                using (var dbCtx = new ProjectContext())
                {
                    dbCtx.Entry(usr).State = EntityState.Deleted;
                }
            }
            public static void Edit(User user, string userName, string password, string firstName, string lastName, DateTime dob)
            {
                User usr;
                UserProfile usrp;
                using (var dbCtx = new ProjectContext())
                {
                    usr = dbCtx.User.Where(u => u.ID == user.ID).FirstOrDefault<User>();
                    usrp = dbCtx.UserProfile.Where(p => p.ID == usr.UserProfile.ID).FirstOrDefault<UserProfile>();
                }
                if (usr.ID > 0 && usrp.ID > 0)
                {
                    usr.UserName = userName;
                    usr.Password = password;
                    usrp.FirstName = firstName;
                    usrp.LastName = lastName;
                    usrp.DOB = dob;
                }
                using (var dbCtx = new ProjectContext())
                {
                    dbCtx.Entry(usr).State = EntityState.Modified;
                    dbCtx.Entry(usrp).State = EntityState.Modified;
                    dbCtx.SaveChanges();
                }
            }

            public static void AddRole(User user, params Role[] role)
            {
                User usr;
                UserProfile usrp;

                Role _role;
                using (var dbCtx = new ProjectContext())
                {
                    usr = dbCtx.User.Where(u => u.ID == user.ID).FirstOrDefault<User>();
                    usrp = dbCtx.UserProfile.Where(p => p.ID == usr.UserProfile.ID).FirstOrDefault<UserProfile>();
                    foreach (Role rl in role)
                    {
                        _role = dbCtx.Role.Where(r => r.ID == rl.ID).FirstOrDefault<Role>();
                        usrp.Roles.Add(_role);
                    }
                    dbCtx.SaveChanges();
                }

            }

            public static void EditRole(User user, params Role[] role)
            {
                User usr;
                UserProfile usrp;
                Role _role;
                using (var dbCtx = new ProjectContext())
                {
                    usr = dbCtx.User.Where(u => u.ID == user.ID).FirstOrDefault<User>();
                    usrp = dbCtx.UserProfile.Where(p => p.ID == usr.UserProfile.ID).FirstOrDefault<UserProfile>();
                    List<Role> Rlist = usrp.Roles.ToList<Role>();
                    foreach (Role rl in Rlist)
                    {
                        usrp.Roles.Remove(rl);
                    }
                    foreach (Role rl in role)
                    {
                        _role = dbCtx.Role.Where(r => r.ID == rl.ID).FirstOrDefault<Role>();
                        usrp.Roles.Add(_role);
                    }
                    dbCtx.SaveChanges();
                }

            }
        }

    }


}

