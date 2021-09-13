using System;
using System.IO;

namespace CGTry2.helper
{
    public static class DIHelper
    {
        public static string GenerateFiles(string CodePath, string TemplatesPath, string PackageName)
        {
            var DIPath = Init(CodePath);

            GenerateNavigationModule(DIPath, TemplatesPath, PackageName);
            GenerateAPIModule(DIPath, TemplatesPath, PackageName);

            return DIPath;
        }

        private static string Init(string CodePath)
        {
            var DIPath = Path.Combine(CodePath, "di");
            if (!Directory.Exists(DIPath))
                Directory.CreateDirectory(DIPath);

            return DIPath;
        }

        private static void GenerateNavigationModule(string DIPath, string TemplatesPath, string PackageName)
        {
            var AppModuleFilePath = Path.Combine(DIPath, "NavigationModule.kt");
            var TemplateAppModuleFilePath = Path.Combine(TemplatesPath, "DINavigationModule.txt");

            var MyAppModule = File.ReadAllText(TemplateAppModuleFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(AppModuleFilePath, MyAppModule);
        }

        private static void GenerateAPIModule(string DIPath, string TemplatesPath, string PackageName)
        {
            var APIModuleFilePath = Path.Combine(DIPath, "ApiModule.kt");
            var TemplateAPIModuleFilePath = Path.Combine(TemplatesPath, "DIAPIModule.txt");

            var APIModule = File.ReadAllText(TemplateAPIModuleFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(APIModuleFilePath, APIModule);
        }
    }
}
