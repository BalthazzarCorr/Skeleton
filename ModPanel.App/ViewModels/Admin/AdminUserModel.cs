﻿namespace ModPanel.App.ViewModels.Admin
{
   using Data.EntityModels;

   public class AdminUserModel
    {
       public int Id { get; set; }

       public string Email { get; set; }

       public PositionType Position { get; set; }

       public int Posts { get; set; }

       public bool IsApproved { get; set; }
    }
}