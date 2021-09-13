using System;
using System.IO;
using System.Linq;

namespace CGTry2.helper
{
    public static class AppHelper
    {
        public static string GenerateFiles(string ProjectPath, string TemplatesPath, string PackageName, string AppName, string BaseUrl)
        {
            var AppPath = Init(ProjectPath);

            GenerateGradle(AppPath, TemplatesPath, PackageName, AppName);
            GenerateConfig(AppPath, BaseUrl);

            return AppPath;
        }

        public static string Init(string ProjectPath)
        {
            var AppPath = Path.Combine(ProjectPath, "app");

            if (!Directory.Exists(AppPath))
                Directory.CreateDirectory(AppPath);

            return AppPath;
        }

        public static void GenerateGradle(string AppPath, string TemplatesPath, string PackageName, string AppName)
        {
            var AppGradleFilePath = Path.Combine(AppPath, "build.gradle");
            var TemplateAppGradleFilePath = Path.Combine(TemplatesPath, "AppGradle.txt");
            var AppPackage = PackageName.Split('.').ToList().Last();

            var AppGradle = File.ReadAllText(TemplateAppGradleFilePath)
                .Replace("{{packageName}}", PackageName)
                .Replace("{{appPackage}}", AppPackage)
                .Replace("{{appName}}", AppName);

            File.WriteAllText(AppGradleFilePath, AppGradle);
        }

        public static void GenerateConfig(string AppPath, string BaseUrl)
        {
            var ConfigPath = Path.Combine(AppPath, "config");
            if (!Directory.Exists(ConfigPath))
                Directory.CreateDirectory(ConfigPath);

            var DevPropertiesFilePath = Path.Combine(ConfigPath, "dev.properties");
            File.WriteAllText(DevPropertiesFilePath, "API_SERVER=\""+ BaseUrl + "\"");

            var ConfigPropertiesFilePath = Path.Combine(ConfigPath, "production.properties");
            File.WriteAllText(ConfigPropertiesFilePath, "API_SERVER=\"" + BaseUrl + "\"");
        }
    }
}
