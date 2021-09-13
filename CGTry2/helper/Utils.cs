using System;
using System.Collections.Generic;
using System.IO;

namespace CGTry2.helper
{
    public abstract class Utils
    {
        public static string CreateDirectory(string ParentFolderPath, string DirectoryName)
        {
            var FolderPath = Path.Combine(ParentFolderPath, DirectoryName);
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            return FolderPath;
        }

        public static void CreateFile(string ParentFolderPath, string FileName,
            string TemplatesPath, string TemplateName, Dictionary<string, string> keys)
        {
            var FilePath = Path.Combine(ParentFolderPath, FileName);
            var TemplateFilePath = Path.Combine(TemplatesPath, TemplateName);

            var template = File.ReadAllText(TemplateFilePath);
            var Code = "";

            foreach (var entry in keys)
            {
                Code = template.Replace(entry.Key, entry.Value);
            }

            File.WriteAllText(FilePath, Code);
        }
    }
}
