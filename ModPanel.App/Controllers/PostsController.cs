namespace ModPanel.App.Controllers
{
   using Data.EntityModels;
   using Services;
   using Services.Contracts;
   using SimpleMvc.Framework.Attributes.Methods;
   using SimpleMvc.Framework.Contracts;
   using ViewModels.Posts;

   public class PostsController : BaseController
   {
      private const string CreateError =
            "<p>Check your form for errors.</p><p>Title must begin with uppercase letter and has length between 3 and 100 symbols (inclusive).</p><p>Content must be more than 10 symbols (inclusive).</p>";

      private readonly IPostService posts ;

      public PostsController()
      {
         this.posts = new PostService();
      }

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


      [HttpPost]
      public IActionResult Create(PostModel model)
      {

         if (!this.User.IsAuthenticated)
         {
            return RedirectToLogin();

         }
         if (!this.IsValidModel(model))
         {
            this.ShowError(CreateError);
            return this.View();
         }

         this.posts.Create(
            model.Title,
            model.Content,
            this.Profile.Id);


         if (this.IsAdmin)
         {
            this.Log(LogType.CreatePost,model.Title);
         }


         return this.RedirectToHome();
      }
   }
}
