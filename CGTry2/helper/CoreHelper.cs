using System;
using System.IO;

namespace CGTry2.helper
{
    public static class CoreHelper
    {
        public static string GenerateFiles(string CodePath, string TemplatesPath, string PackageName)
        {
            var CorePath = Init(CodePath);

            CreateConstantsFile(CorePath, TemplatesPath, PackageName);
            CreateMyAppFile(CorePath, TemplatesPath, PackageName);
            CreateSessionFile(CorePath, TemplatesPath, PackageName);

            return CorePath;
        }

        private static string Init(string CodePath)
        {
            var CorePath = Path.Combine(CodePath, "core");
            if (!Directory.Exists(CorePath))
                Directory.CreateDirectory(CorePath);

            return CorePath;
        }

        private static void CreateConstantsFile(string CorePath, string TemplatesPath, string PackageName)
        {
            var ConstantsFilePath = Path.Combine(CorePath, "Constants.kt");
            var TemplateConstantsFilePath = Path.Combine(TemplatesPath, "Constants.txt");

            var Constants = File.ReadAllText(TemplateConstantsFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(ConstantsFilePath, Constants);
        }

        private static void CreateMyAppFile(string CorePath, string TemplatesPath, string PackageName)
        {
            var MyAppFilePath = Path.Combine(CorePath, "MyApp.kt");
            var TemplateMyAppFilePath = Path.Combine(TemplatesPath, "MyApp.txt");

            var MyApp = File.ReadAllText(TemplateMyAppFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(MyAppFilePath, MyApp);
        }

        private static void CreateSessionFile(string CorePath, string TemplatesPath, string PackageName)
        {
            var SessionFilePath = Path.Combine(CorePath, "Session.kt");
            var TemplateSessionFilePath = Path.Combine(TemplatesPath, "Session.txt");

            var Session = File.ReadAllText(TemplateSessionFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(SessionFilePath, Session);
        }
    }
}
