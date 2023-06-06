using Dotnet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Service
{
    internal class UserService
    {
        public List<User> FindAll()
        {
            using ApplicationContext db = new();
            return db.Users.ToList();
        }

        public User Register(string? name)
        {
            using ApplicationContext db = new();

            User? user = db.Users.FirstOrDefault(u => u.Name == name);

            if (user == null)
            {
                user = new();
                user.Name = name;
                db.Users.Add(user);
                db.SaveChanges();
            }
            return user;
        }

        public void MakeWinner(User user)
        {
            using ApplicationContext db = new();
            user.Wins++;
            db.Users.Update(user);
            db.SaveChanges();
        }

        internal void MakeLooser(User user)
        {
            using ApplicationContext db = new();
            user.Losses++;
            db.Users.Update(user);
            db.SaveChanges();
        }
    }
}
