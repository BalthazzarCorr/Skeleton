
namespace ModPanel.App.Controllers
{
   using System.Linq;
   using Services;
   using Services.Contracts;
   using SimpleMvc.Framework.Contracts;
   using Infrastructure;

   public class AdminController : BaseController
   {
      private readonly IUserService users;

      public AdminController()
      {
         this.users = new UserService();
      }

      public IActionResult Log()
      {


         return this.View();
      }

      public IActionResult Users()
      {
         if (!this.IsAdmin)
         {
            return RedirectToHome();
         }


         var rows = this.users
            .All()
            .Select(u => $@"
                    <tr>
                        <td>{u.Id}</td>
                        <td>{u.Email}</td>
                        <td>{u.Position.ToFriendlyName()}</td>
                        <td>{u.Posts}</td>
                        <td>
                            {
                  (u.IsApproved
                     ? string.Empty
                     : $@"<a class=""btn btn-primary btn-sm"" href=""/admin/approve?id={u.Id}"">Approve</a>")
               }
                        </td>
                    </tr>");
         

         this.ViewModel["users"] = string.Join(string.Empty, rows);

         return this.View();
      }


      public IActionResult Approve(int id)
      {
         if (!this.IsAdmin)
         {
            return this.RedirectToLogin();
         }

         //var userEmail = this.users.Approve(id);

         //if (userEmail != null)
         //{
         //   this.Log(LogType.UserApproval, userEmail);
         //}

         this.users.Approve(id);

         return this.Redirect("/admin/users");
      }
   }
}
