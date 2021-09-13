using System;
using System.Collections.Generic;

namespace CGTry2.helper
{
    public static class NavigationHelper
    {
        public static string GenerateFiles(string PresentationPath, string TemplatesPath, string PackageName)
        {
            var NavigationFolderPath = Utils.CreateDirectory(PresentationPath, "navigation");

            GenerateNavigationRouteFile(NavigationFolderPath, TemplatesPath, PackageName);
            GenerateNavigationFile(NavigationFolderPath, TemplatesPath, PackageName);
            GeneraterNavigationImplFile(NavigationFolderPath, TemplatesPath, PackageName);

            return NavigationFolderPath;
        }

        private static void GenerateNavigationRouteFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("{{packageName}}", PackageName);
            Utils.CreateFile(ParentFolderPath, "NavigationRoute.kt", TemplatesPath, "NavigationRoute.txt", parameters);
        }

        private static void GenerateNavigationFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("{{packageName}}", PackageName);
            Utils.CreateFile(ParentFolderPath, "Navigation.kt", TemplatesPath, "Navigation.txt", parameters);
        }

        private static void GeneraterNavigationImplFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("{{packageName}}", PackageName);
            Utils.CreateFile(ParentFolderPath, "NavigationImpl.kt", TemplatesPath, "NavigationImpl.txt", parameters);
        }
    }
}
