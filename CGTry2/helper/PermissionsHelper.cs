using System;
using System.IO;

namespace CGTry2.helper
{
    public static class PermissionsHelper
    {
        public static string GenerateFiles(string CodePath, string TemplatesPath, string PackageName)
        {
            var PermissionsPath = Init(CodePath);

            GeneratePermissionsEnumFile(PermissionsPath, TemplatesPath, PackageName);
            GeneratePermissionsManagerFile(PermissionsPath, TemplatesPath, PackageName);

            return PermissionsPath;
        }

        private static string Init(string CodePath)
        {
            var PermissionsPath = Path.Combine(CodePath, "permissions");
            if (!Directory.Exists(PermissionsPath))
                Directory.CreateDirectory(PermissionsPath);

            return PermissionsPath;
        }

        private static void GeneratePermissionsEnumFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var FilePath = Path.Combine(ParentFolderPath, "Permissions.kt");
            var TemplateFilePath = Path.Combine(TemplatesPath, "Permissions.txt");

            var Code = File.ReadAllText(TemplateFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(FilePath, Code);
        }

        private static void GeneratePermissionsManagerFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var FilePath = Path.Combine(ParentFolderPath, "PermissionManager.kt");
            var TemplateFilePath = Path.Combine(TemplatesPath, "PermissionManager.txt");

            var Code = File.ReadAllText(TemplateFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(FilePath, Code);
        }
    }
}
