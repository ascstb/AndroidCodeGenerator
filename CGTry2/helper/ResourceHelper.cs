using System;
using System.IO;

namespace CGTry2.helper
{
    public static class ResourceHelper
    {
        public static string GenerateFiles(string MainPath)
        {
            var ResPath = Path.Combine(MainPath, "res");
            if (!Directory.Exists(ResPath))
                Directory.CreateDirectory(ResPath);

            return ResPath;
        }
    }
}
