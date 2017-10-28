namespace ModPanel.App.Services.Contracts
{
   using System.Collections.Generic;
   using ViewModels.Home;
   using ViewModels.Posts;

   public interface IPostService
   {
      void Create(string title, string content, int userId);

      IEnumerable<PostListingModel> All();

      IEnumerable<HomeListingModel> AllWithDetails(string search = null);


      PostModel GetById(int id);

      void Update(int id, string title, string content);

      string Delete(int id);

   }
}
