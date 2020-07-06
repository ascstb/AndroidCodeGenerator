using System;
using System.Collections.Generic;
using System.Json;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using CGTry2.helper;

namespace CGTry2.Form.CodeGenerator
{
    public partial class Android : System.Web.UI.Page
    {
        [WebMethod]
        public static string GenerateAndroidCode(string appName, string appPackageName, bool contentTypeActivities, string dataRepositories, string baseUrl, string model, string jsonString)
        {
            if(appName.Trim().Length == 0 || appPackageName.Trim().Length == 0 || dataRepositories.Trim().Length == 0 || baseUrl.Trim().Length == 0)
            {
                return "{result: 'Please verify your parameters'}";
            }

            Console.WriteLine("appName: {0}, appPackageName: {1}, activities: {2}, dataRepositories: {3}", appName, appPackageName, contentTypeActivities, dataRepositories);
            var Repositories = new List<DataRepository>();
            foreach (var repositoryDescripcion in dataRepositories.Split(','))
            {
                switch(repositoryDescripcion)
                {
                    case "server":
                        {
                            Repositories.Add(DataRepository.SERVER);
                            break;
                        }
                    case "shared-preferences":
                        {
                            Repositories.Add(DataRepository.SHARED_PREFERENCES);
                            break;
                        }
                    case "local":
                        {
                            Repositories.Add(DataRepository.LOCAL);
                            break;
                        }
                    default: break;
                }
            }
               dataRepositories.Split(',');

            var cgService = new CodeGexService(appName, appPackageName, contentTypeActivities, Repositories, baseUrl, model, jsonString);
            cgService.GenerateCode();

            return "{result: 'OK'}";
        }
    }
}
