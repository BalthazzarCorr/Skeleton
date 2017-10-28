namespace ModPanel.App.Services.Contracts
{
   using System.Collections.Generic;
   using Data.EntityModels;
   using ViewModels.Admin;

   public interface IUserService
    {

       bool Create(string email, string password, PositionType position);

       bool UserExists(string email, string password);

       bool UserIsApproved(string email);


       IEnumerable<AdminUserModel> All();

       void Approve(int id);
    }
}
