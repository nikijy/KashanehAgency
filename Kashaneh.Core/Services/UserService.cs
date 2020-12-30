using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kashaneh.Core.Convertors;
using Kashaneh.Core.DTOs;
using Kashaneh.Core.Generator;
using Kashaneh.Core.Security;
using Kashaneh.Core.Services.Interfaces;
using Kashaneh.DataLayer.Context;
using Kashaneh.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;


namespace Kashaneh.Core.Services
{
    public class UserService : IUserService
    {
        private KashanehContext _context;

        public UserService(KashanehContext context)
        {
            _context = context;
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public int AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public User LoginUser(LoginViewModel login)
        {
            string password = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixEmail(login.Email);
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
                return false;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            _context.SaveChanges();

            return true;
        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == userName);
        }

        public User GetUserByUserId(int userId)
        {
            return _context.Users.Find(userId);
        }

        //public EditUserViewModel GetUserByIdForEditInAdmin(int userId)
        //{
        //    return _context.Users.Where(u => u.UserId == userId)
        //        .Select(u => new EditUserViewModel()
        //        {
        //            UserId = u.UserId,
        //            Email = u.Email,
        //            UserName = u.UserName,
        //            UserRoles = u.UserRoles.Select(r => r.RoleId).ToList()
        //        }).Single();
        //}

        public User GetUserInformation(int id)
        {
            var user = GetUserByUserId(id);

            return user;
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserByUserId(userId);
            user.IsDeleted = true;
            UpdateUser(user);
        }

        public bool CompareOldPassword(string oldPassword, string userName)
        {
            string hashOldPassword = PasswordHelper.EncodePasswordMd5(oldPassword);
            return _context.Users.Any(u => u.UserName == userName && u.Password == hashOldPassword);
        }

        public void ChangeUserPassword(string userName, string newPassword)
        {
            var user = GetUserByUserName(userName);
            user.Password = PasswordHelper.EncodePasswordMd5(newPassword);
            UpdateUser(user);
        }

        public int GetUserIdByUserName(string userName)
        {
            return _context.Users.Single(u => u.UserName == userName).UserId;
        }

        //public IEnumerable<UsersViewModel> GetAllUsers(int take = 0, int pageId = 1)
        //{
        //    if (take == 0)
        //        take = 12;
        //    int skip = (pageId - 1) * take;
        //    return _context.Users
        //        .Select(u => new UsersViewModel()
        //        {
        //            UserId = u.UserId,
        //            Email = u.Email,
        //            UserName = u.UserName,
        //            RegisterDate = u.RegisterDate,
        //            IsDeleted = u.IsDeleted,
        //            IsActive = u.IsActive
        //        }).Skip(skip).Take(take).ToList();
        //}

        //public IEnumerable<UsersViewModel> GetDeleteUsers(int take = 0, int pageId = 1)
        //{
        //    if (take == 0)
        //        take = 12;
        //    int skip = (pageId - 1) * take;

        //    return _context.Users.IgnoreQueryFilters().Where(u => u.IsDeleted.Value)
        //        .Select(u => new UsersViewModel()
        //        {
        //            UserName = u.UserName,
        //            Email = u.Email,
        //            IsActive = u.IsActive,
        //            RegisterDate = u.RegisterDate,
        //            UserId = u.UserId,
        //            IsDeleted = u.IsDeleted
        //        }).Skip(skip).Take(take).ToList();
        //}

        public int AddUserForAdmin(User user)
        {
            User addUser = new User();
            addUser.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            addUser.ActiveCode = NameGenerator.GenerateUniqCode();
            addUser.Email = user.Email;
            addUser.IsActive = true;
            addUser.RegisterDate = DateTime.Now;
            addUser.UserName = user.UserName;
            addUser.IsDeleted = false;
            return AddUser(addUser);
        }

        //public void EditUserFromAdmin(EditUserViewModel editUser)
        //{
        //    User user = GetUserByUserId(editUser.UserId);
        //    user.Email = editUser.Email;
        //    if (!string.IsNullOrEmpty(editUser.Password))
        //    {
        //        user.Password = PasswordHelper.EncodePasswordMd5(editUser.Password);
        //    }
        //    _context.Users.Update(user);
        //    _context.SaveChanges();
        //}

        
        public int UserCount()
        {
            return _context.Users.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public List<UserMessage> GetAllUserMessages(int take = 0, int pageId = 1)
        {
            if (take == 0)
                take = 12;
            int skip = (pageId - 1) * take;
            return _context.UserMessages.Skip(skip).Take(take).ToList();
        }

        public UserMessage GetUserMessageById(int userMessageId)
        {
            return _context.UserMessages.Find(userMessageId);
        }

        public bool InsertUserMessage(UserMessage userMessage)
        {
            try
            {
                _context.UserMessages.Add(userMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUserMessage(UserMessage userMessage)
        {
            try
            {
                _context.UserMessages.Update(userMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DeleteUserMessage(int messageId)
        {
            var message = GetUserMessageById(messageId);
            message.IsDeleted = true;
            UpdateUserMessage(message);
        }

        public int UserMessageCount()
        {
            return _context.UserMessages.Count();
        }

        public List<UserRole> GetAllUserRoles()
        {
            return _context.UserRoles.ToList();
        }

        public UserRole GetUserRoleById(int userRoleId)
        {
            return _context.UserRoles.Find(userRoleId);
        }

        public bool InsertUserRole(UserRole userRole)
        {
            try
            {
                _context.UserRoles.Add(userRole);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUserRole(UserRole userRole)
        {
            try
            {
                _context.UserRoles.Update(userRole);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DeleteUserRole(UserRole userRole)
        {
            _context.Entry(userRole).State = EntityState.Deleted;
        }

        public List<NewsLetter> GetAllEmails()
        {
            return _context.NewsLetters.ToList();
        }

        public bool AddEmail(NewsLetter newsLetter)
        {
            try
            {
                _context.NewsLetters.Add(newsLetter);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsExistEmailForNewsLetter(string email)
        {
            return _context.NewsLetters.Any(n => n.Email == email);
        }
    }
}
