using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using CGTry2.helper;

namespace CGTry2.Form.CodeGenerator.AndroidProject.GeneralStructure
{
    public partial class GeneralStructure : System.Web.UI.Page
    {
        [WebMethod]
        public static string GenerateProjectStructure(string appName, string appPackageName, string securityType)
        {
            string DirectorioPrincipal = System.Configuration.ConfigurationManager.AppSettings["DirectorioPrincipal"].ToString();
            string RootPath = Path.Combine(DirectorioPrincipal, "result");
            string TemplatesPath = Path.Combine(DirectorioPrincipal, "inc/templates");

            var ProjectPath = ProjectHelper.GenerateFiles(RootPath, TemplatesPath, appName);

            var AppPath = AppHelper.Init(ProjectPath);
            AppHelper.GenerateConfig(AppPath, "");
            AppHelper.GenerateGradle(AppPath, TemplatesPath, appPackageName, appName);

            var MainPath = MainHelper.GenerateFiles(AppPath, TemplatesPath, appPackageName, appName);

            var CodePath = CodeHelper.GenerateFiles2(MainPath, appPackageName);
            var CorePath = CoreHelper.GenerateFiles(CodePath, TemplatesPath, appPackageName);
            var DIPath = DIHelper.GenerateFiles(CodePath, TemplatesPath, appPackageName);
            var PermissionsPath = PermissionsHelper.GenerateFiles(CodePath, TemplatesPath, appPackageName);
            var PresentationPath = PresentationHelper.GenerateFiles(CodePath, TemplatesPath, appPackageName);
            var BasePath = BaseHelper.GenerateFiles(PresentationPath, TemplatesPath, appPackageName);
            var NavigationPath = NavigationHelper.GenerateFiles(PresentationPath, TemplatesPath, appPackageName);

            var ResPath = ResourceHelper.GenerateFiles(MainPath);

            return "{result: 'OK'}";
        }
    }
}
