using System;
using System.Collections.Generic;
using System.IO;

namespace CGTry2.helper
{
    public class CodeGexService
    {
        private string AppName;
        private string PackageName;
        private bool Activities;
        private string DirectorioPrincipal;
        private string BaseUrl;
        private string JsonString;
        private string Model;
        private List<DataRepository> Repositories;

        public CodeGexService(string appName, string appPackageName, bool activities, List<DataRepository> dataRepositories, string baseUrl, string model, string jsonString)
        {
            AppName = appName;
            PackageName = appPackageName;
            Activities = activities;
            DirectorioPrincipal = System.Configuration.ConfigurationManager.AppSettings["DirectorioPrincipal"].ToString();
            Repositories = dataRepositories;
            BaseUrl = baseUrl;
            JsonString = jsonString;
            Model = model;
        }

        private string RootPath => Path.Combine(DirectorioPrincipal, "result");
        private string TemplatesPath => Path.Combine(DirectorioPrincipal, "inc/templates");

        public void GenerateCode()
        {
            var ProjectPath = ProjectHelper.GenerateFiles(RootPath, TemplatesPath, AppName);
            var AppPath = AppHelper.GenerateFiles(ProjectPath, TemplatesPath, PackageName, AppName, BaseUrl);
            var MainPath = MainHelper.GenerateFiles(AppPath, TemplatesPath, PackageName, AppName);
            var CodeRootPath = CodeHelper.GenerateFiles(MainPath, TemplatesPath, PackageName, !Activities, Model, JsonString);
        }
    }
}
