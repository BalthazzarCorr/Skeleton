namespace ModPanel.App.Controllers
{
   using Data.EntityModels;
   using Services;
   using Services.Contracts;
   using SimpleMvc.Framework.Attributes.Methods;
   using SimpleMvc.Framework.Contracts;
   using ViewModels.Users;

   public class UsersController : BaseController
   {
      private const string RegisterError = "Password length must be at least 6 symbols and must contain at least 1 uppercase, 1 lowercase letter and 1 digit";

      private const string EmailExistsError = "Email is already taken ";

      private const string LogInError = "<p>Invalid credentials</p>";

      private const string UserIsNotApprovedError = "You must wait for your registration to be approved!"; 

      private IUserService users;

      public UsersController()
      {
         this.users = new UserService();

      }

      public IActionResult Register()
      {
         return this.View();
      }

      [HttpPost]
      public IActionResult Register(RegisterModel model)
      {
         // validate model
         // if error -> send error (display)
         // save to db 
         // redirect


         if (model.Password != model.ConfirmPassword || !this.IsValidModel(model))
         {
            this.ShowError(RegisterError);
            return this.View();
         }

         var result = this.users.Create(
            model.Email,
            model.Password,
           (PositionType)model.Position);

         if (result)
         {
            this.SignIn(model.Email);
            return this.RedirectToLogin();
         }
         else
         {
            this.ShowError(EmailExistsError);
            return this.View();
         }
      }

      public IActionResult Login() => this.View();

      [HttpPost]
      public IActionResult Login(LoginModel model)
      {

         if (!this.IsValidModel(model))
         {
            this.ShowError(LogInError);
            return this.View();
         }

         var result = this.users.UserExists(model.Email, model.Password);

         if (!this.users.UserIsApproved(model.Email))
         {
            this.ShowError(UserIsNotApprovedError);
            return this.View();
         }

         if (result)
         {
            this.SignIn(model.Email);
            return this.RedirectToHome();
         }
         else 
         {
            this.ShowError(LogInError);
            return this.View();
         }
      }

      public IActionResult Logout()
      {
         this.SignOut();
         return this.RedirectToHome();
      }
   }
}

