using System;
using System.Json;
using System.Web;
using System.Web.Services;
using System.Web.UI;
namespace CGTry2.Form.CodeGenerator
{
    public partial class Android : System.Web.UI.Page
    {
        [WebMethod]
        public static string GenerateAndroidCode(string appName, string appPackageName, bool contentTypeActivities)
        {
            Console.WriteLine("appName: {0}, appPackageName: {1}, activities: {2}", appName, appPackageName, contentTypeActivities);
            return "{result: 'OK'}";
        }
    }
}
