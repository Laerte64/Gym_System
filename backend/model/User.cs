using Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Repository;

namespace Model
{
    internal abstract class User
    {
        private UserData _data;

        public string Name 
        {
            get { return _data.Name; }
        }

        public DateTime BirthDate
        {
            get { return _data.BirthDate; }
        }

        public string Login
        {
            get { return _data.Login; }

        }

        public User(UserData data) 
        {
            _data = data;
        }

        public User(string name, DateTime birthDate, string login, string password)
        {
            _data = new UserData() 
            {
                Name = name,
                BirthDate = birthDate,
                Login = login,
                Password = password
            };
        }

        public bool VerifyPassword(string password)
        {
            return _data.Password == password;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (!VerifyPassword(oldPassword))
                return false;
            _data.Password = newPassword;
            return true;
        }

        public static bool operator== (User left, User right)
        {
            return left._data.Id == right._data.Id;
        }

        public static bool operator!= (User left, User right)
        {
            return left._data.Id != right._data.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            var objU = obj as User;
            if (objU is not null)
                return this == objU;
            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}