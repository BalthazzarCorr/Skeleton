using System.Collections.Generic;

namespace ModPanel.App.Services.Contracts
{
   using Data.EntityModels;
   using ViewModels.Logs;

   public interface ILogService
    {
       void Create(string admin, LogType type, string additionalInformation);

       IEnumerable<LogModel> All();

   }
}
