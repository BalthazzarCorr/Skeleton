﻿namespace ModPanel.App.Infrastructure
{
   using ViewModels.Logs;

   public  static class HtmlHelpers
   {
      
         public static string ToHtml(this LogModel log)
            => $@"
                <div class=""card border-{log.Type.ToViewClassName()} mb-1"">
                    <div class=""card-body"">
                        <p class=""card-text"">{log}</p>
                    </div>
                </div>";
      
   }
}
