namespace ModPanel.App.Controllers
{
   using SimpleMvc.Framework.Contracts;

   public class PostsController : BaseController
    {
       public IActionResult Create()
       {
          if (!this.User.IsAuthenticated)
          {
             return RedirectToLogin();
          }
          return View();
       }
    }
}
