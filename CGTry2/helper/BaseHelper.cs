using System;
using System.Collections.Generic;
using System.IO;

namespace CGTry2.helper
{
    public static class BaseHelper
    {
        public static string GenerateFiles(string PresentationPath, string TemplatesPath, string PackageName)
        {
            var BaseFolderPath = Utils.CreateDirectory(PresentationPath, "base");

            GenerateBaseViewModelFile(BaseFolderPath, TemplatesPath, PackageName);
            GenerateBaseActivityFile(BaseFolderPath, TemplatesPath, PackageName);
            GenerateBaseRVAdapterFile(BaseFolderPath, TemplatesPath, PackageName);
            GenerateBaseFragmentFile(BaseFolderPath, TemplatesPath, PackageName);
            GenerateBaseFragmentListenerFile(BaseFolderPath, TemplatesPath, PackageName);

            return BaseFolderPath;
        }

        private static void GenerateBaseViewModelFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("{{packageName}}", PackageName);
            Utils.CreateFile(ParentFolderPath, "BaseViewModel.kt", TemplatesPath, "BaseViewModel.txt", parameters);
        }

        public static void GenerateBaseActivityFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("{{packageName}}", PackageName);
            Utils.CreateFile(ParentFolderPath, "BaseActivity.kt", TemplatesPath, "BaseActivity.txt", parameters);
        }

        public static void GenerateBaseRVAdapterFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("{{packageName}}", PackageName);
            Utils.CreateFile(ParentFolderPath, "BaseRVAdapter.kt", TemplatesPath, "BaseRVAdapter.txt", parameters);
        }

        public static void GenerateBaseFragmentFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("{{packageName}}", PackageName);
            Utils.CreateFile(ParentFolderPath, "BaseFragment.kt", TemplatesPath, "BaseFragment.txt", parameters);
        }

        public static void GenerateBaseFragmentListenerFile(string ParentFolderPath, string TemplatesPath, string PackageName)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("{{packageName}}", PackageName);
            Utils.CreateFile(ParentFolderPath, "BaseFragmentListener.kt", TemplatesPath, "BaseFragmentListener.txt", parameters);
        }
    }
}
