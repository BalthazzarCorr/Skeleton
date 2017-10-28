﻿namespace ModPanel.App.Controllers
{
   using Data;
   using Data.EntityModels;
   using SimpleMvc.Framework.Controllers;
   using System.Linq;
   using SimpleMvc.Framework.Contracts;

   public abstract class BaseController : Controller
   {
      protected BaseController()
      {
         this.ViewModel["anonymousDisplay"] = "flex";
         this.ViewModel["userDisplay"] = "none";
         this.ViewModel["adminDisplay"] = "none";
         this.ViewModel["show-error"] = "none";
      }

      protected User Profile { get; private set; }

      protected bool IsAdmin => this.User.IsAuthenticated && this.Profile.IsAdmin;

      protected void ShowError(string error)
      {
         this.ViewModel["show-error"] = "flex";
         this.ViewModel["error"] = error;
      }

      protected IActionResult RedirectToHome()
      {
         return this.Redirect("/");
      }

      protected IActionResult RedirectToLogin()
      {
         return this.Redirect("/users/login");
      }

      protected override void InitializeController()
      {
         base.InitializeController();

         if (this.User.IsAuthenticated)
         {
            this.ViewModel["anonymousDisplay"] = "none";
            this.ViewModel["userDisplay"] = "flex";

            using (var db = new ModPanelDbContext())
            {
               this.Profile = db.Users.First(u => u.Email == this.User.Name);


               if (this.Profile.IsAdmin)
               {
                 
                  this.ViewModel["adminDisplay"] = "flex";
               }
            }
         }
      }



   }
}
