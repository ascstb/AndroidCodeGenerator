using System;
using System.IO;

namespace CGTry2.helper
{
    public static class PresentationHelper
    {
        public static string GenerateFiles(string CodePath, string TemplatesPath, string PackageName)
        {
            var PresentationPath = Init(CodePath);



            return PresentationPath;
        }

        private static string Init(string ParentFolderPath)
        {
            var FolderPath = Path.Combine(ParentFolderPath, "presentation");
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            return FolderPath;
        }
    }
}
