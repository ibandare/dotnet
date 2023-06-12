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
        private readonly ApplicationContext _context = new ApplicationContext();

        public List<User> FindAll()
        {
            return _context.Users.ToList();
        }

        public User Register(string? name)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Name == name);

            if (user == null)
            {
                user = new();
                user.Name = name;
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            return user;
        }

        public void MakeWinner(User user)
        {
            user.Wins++;
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void MakeLooser(User user)
        {
            user.Losses++;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
