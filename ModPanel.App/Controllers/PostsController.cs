namespace ModPanel.App.Controllers
{
   using Services.Contracts;
   using SimpleMvc.Framework.Contracts;
   using ViewModels.Posts;

   public class PostsController : BaseController
   {
      private const string CreateError =
            "<p>Check your form for errors.</p><p>Title must begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p><p>Content must be more than 10 symbols (inclusive).</p>"
         ;

      private readonly IPostService posts;

      public PostsController(IPostService posts)
      {
         this.posts = posts;
      }

      public IActionResult Create()
      {
         if (!this.User.IsAuthenticated)
         {
            return RedirectToLogin();
         }
         return View();
      }

      public IActionResult Create(CreatePostModel model)
      {

         if (!this.User.IsAuthenticated)
         {
            return RedirectToLogin();
         }
         return View();
      }
   }
}
