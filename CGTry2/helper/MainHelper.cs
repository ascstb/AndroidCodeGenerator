using System;
using System.IO;

namespace CGTry2.helper
{
    public static class MainHelper
    {
        public static string GenerateFiles(string AppPath, string TemplatesPath, string PackageName)
        {
            var MainPath = Init(AppPath);
            GenerateManifest(MainPath, TemplatesPath, PackageName);
            return MainPath;
        }

        private static string Init(string AppPath)
        {
            var SrcPath = Path.Combine(AppPath, "src");
            if (!Directory.Exists(SrcPath))
                Directory.CreateDirectory(SrcPath);

            var MainPath = Path.Combine(SrcPath, "main");
            if (!Directory.Exists(MainPath))
                Directory.CreateDirectory(MainPath);

            return MainPath;
        }

        private static void GenerateManifest(string MainPath, string TemplatesPath, string PackageName)
        {
            var ManifestFilePath = Path.Combine(MainPath, "Android.Manifest.xml");
            var TemplateManifestFilePath = Path.Combine(TemplatesPath, "Manifest.txt");

            var Manifest = File.ReadAllText(TemplateManifestFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(ManifestFilePath, Manifest);
        }
    }
}
