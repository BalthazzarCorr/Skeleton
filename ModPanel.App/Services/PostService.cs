namespace ModPanel.App.Services
{
   using Contracts;
   using Data;
   using Data.EntityModels;

   public class PostService : IPostService
   {
      public void Create(string title, string content, int userId)
      {
         using (var db = new ModPanelDbContext())
         {
            var post = new Post
            {
               Title = title,
               Content = content,
               UserId = userId

            };
            db.Posts.Add(post);
            db.SaveChanges();

         }
      }
   }
}
