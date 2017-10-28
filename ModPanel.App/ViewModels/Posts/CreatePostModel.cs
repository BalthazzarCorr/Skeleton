﻿namespace ModPanel.App.ViewModels.Posts
{
   using Infrastructure.Validation;
   using Infrastructure.Validation.Posts;
   public class CreatePostModel
   {

      [Required]
      [Title]
      public string Title { get; set; }


      [Required]
      [Content]
      public string Content { get; set; }
   }
}
