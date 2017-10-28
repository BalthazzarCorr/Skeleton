namespace ModPanel.App.Infrastructure.Validation
{
   using System.Linq;

   public  static class StringExtensions
   {

      public static string Capitalize(this string input)
      {
         if (string.IsNullOrEmpty(input))
         {
            return input;
         }

         var first = input.First();
         var rest = input.Substring(1);

         return $"{char.ToUpper(first)}{rest}";
      }
   }
}
