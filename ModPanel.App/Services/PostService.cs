namespace ModPanel.App.Services
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using Contracts;
   using Data;
   using Data.EntityModels;
   using Infrastructure.Validation;
   using ViewModels.Home;
   using ViewModels.Posts;

   public class PostService : IPostService
   {
      public void Create(string title, string content, int userId)
      {
         using (var db = new ModPanelDbContext())
         {
           var post = new Post
            {
                Title = title.Capitalize(),
                Content = content,
                UserId = userId,
                CreatedOn = DateTime.UtcNow
            };

            db.Posts.Add(post);
            db.SaveChanges();

         }
      }

      public IEnumerable<HomeListingModel> AllWithDetails(string search = null)
      {
         using (var db = new ModPanelDbContext())
         {
            var query = db.Posts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
               query = query.Where(p => p.Title.ToLower().Contains(search.ToLower()));
            }

            return query
               .OrderByDescending(p => p.Id)
               .Select(p=> new HomeListingModel
               {
                  Title = p.Title,
                  Content = p.Content,
                  CreatedOn = p.CreatedOn,
                  CreatedBy = p.User.Email
               })            
               .ToList();

         }
      }

      public IEnumerable<PostListingModel> All()
      {

         using (var db = new ModPanelDbContext())
         {
            return db.Posts.Select(p => new PostListingModel
            {
               Id = p.Id,
               Title = p.Title,
            }).ToList();
         }
      }

      public PostModel GetById(int id)
      {
         using (var db = new ModPanelDbContext())
         {
            return db.Posts.Where(p => p.Id == id).Select(p => new PostModel
            {
               Title = p.Title,
               Content = p.Content

            }).FirstOrDefault();
         }
      }

      public void Update(int id, string title, string content)
      {
         using (var db = new ModPanelDbContext())
         {
            var post = db.Posts.Find(id);

            if (post == null)
            {
               return;
            }

            post.Title = title;
            post.Content = content;

            db.SaveChanges();

         }
      }

      public string Delete(int id)
      {

         using (var db  = new ModPanelDbContext())
         {
            var post = db.Posts.Find(id);

            if (post == null)
            {
               return null;
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return post.Title;
         }
      }
   }
}
