using System;
using System.Collections.Generic;
using System.Text;
using Kashaneh.Core.DTOs;
using Kashaneh.DataLayer.Entities.User;

namespace Kashaneh.Core.Services.Interfaces
{
  public interface IUserService
  {
        #region userAccount

        bool IsExistEmail(string email);
        bool IsExistUserName(string userName);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);
        User GetUserByEmail(string email);
        User GetUserByActiveCode(string activeCode);
        void UpdateUser(User user);
        bool ActiveAccount(string activeCode);
        User GetUserByUserName(string userName);
        User GetUserByUserId(int userId);
      //  EditUserViewModel GetUserByIdForEditInAdmin(int userId);
        User GetUserInformation(int id);
        void DeleteUser(int userId);
        bool CompareOldPassword(string oldPassword, string userName);
        void ChangeUserPassword(string userName, string newPassword);
        int GetUserIdByUserName(string userName);
       // IEnumerable<UsersViewModel> GetAllUsers(int take = 0, int pageId = 1);
       // IEnumerable<UsersViewModel> GetDeleteUsers(int take = 0, int pageId = 1);
        int AddUserForAdmin(User user);
      //  void EditUserFromAdmin(EditUserViewModel editUser);
      int UserCount();
        void Save();
        #endregion

        #region Usermessages
        List<UserMessage> GetAllUserMessages(int take = 0, int pageId = 1);
        UserMessage GetUserMessageById(int userMessageId);
        bool InsertUserMessage(UserMessage userMessage);
        bool UpdateUserMessage(UserMessage userMessage);
        void DeleteUserMessage(int messageId);
        int UserMessageCount();

        #endregion

        #region UserRole

        List<UserRole> GetAllUserRoles();
        UserRole GetUserRoleById(int userRoleId);
        bool InsertUserRole(UserRole userRole);
        bool UpdateUserRole(UserRole userRole);
        void DeleteUserRole(UserRole userRole);

        #endregion

        #region newsletter

        List<NewsLetter> GetAllEmails();
        bool AddEmail(NewsLetter newsLetter);
        bool IsExistEmailForNewsLetter(string email);

        #endregion
    }
}
