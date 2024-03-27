using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Demo.User;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Demo
{
    public class UserController
    {
        private List<User> users;

        public List<User> Users { get { return users; } }

        static User currentUser = null;

        public UserController()
        {
            // Инициализируем список пользователей
            users = new List<User>
            {
                new User("admin", "admin", User.UserRole.Administrator),
                new User("chef", "chef", User.UserRole.Chef),
                new User("waiter", "waiter", User.UserRole.Waiter)
            };
        }

        public bool RegisterUser(string username, string password, UserRole role)
        {
            foreach(User user in users)
            {
                if(user.Username == username)
                {
                    return false;
                }
            }

            users.Add(new User(username, password, role));
            return true;
        }

        public bool Authenticate(string username, string password)
        {
            // Проверяем наличие пользователя с указанным именем и паролем
            foreach (User user in users)
            {
                if(!user.isFired)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        currentUser = user;
                        return true; // Пользователь найден
                    }
                }
            }
            return false; // Пользователь не найден
        }

        public void AddShift(string Username, DateTime time)
        {
            foreach (User user in users)
            {
                if (user.Username == Username)
                {
                    user.shifts.Add(time);
                } 
                    
            }
        }

        public void FireEmployee(string Username, bool state)
        {
            foreach(User user in users)
            {
                if(user.Username == Username) user.isFired = state;
            }
        }

        public static User GetCurrentUser()
        {
            // Возвращаем текущего пользователя
            return currentUser;
        }
    }
}
