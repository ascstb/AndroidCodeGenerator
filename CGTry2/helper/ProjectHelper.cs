using System;
using System.IO;

namespace CGTry2.helper
{
    public static class ProjectHelper
    {
        public static string GenerateFiles(string RootPath, string TemplatesPath, string AppName)
        {
            //Root
            if (!Directory.Exists(RootPath))
                Directory.CreateDirectory(RootPath);

            //Project
            var ProjectPath = Path.Combine(RootPath, AppName);

            if (!Directory.Exists(ProjectPath))
                Directory.CreateDirectory(ProjectPath);

            //Gradle File
            var TemplateProjectGradleFilePath = Path.Combine(TemplatesPath, "ProjectGradle.txt");
            var ProjectGradleFilePath = Path.Combine(RootPath, AppName, "build.gradle");

            File.Copy(TemplateProjectGradleFilePath, ProjectGradleFilePath, true);

            return ProjectPath;
        }
    }
}
