using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace CGTry2.helper
{
    public static class CodeHelper
    {
        public static string GenerateFiles(string MainPath, string TemplatesPath, string PackageName, bool UseFragments, string Model, string JsonString)
        {
            var CodeRootPath = Init(MainPath, PackageName);

            GenerateCore(CodeRootPath, TemplatesPath, PackageName);
            GenerateDependencyInjection(CodeRootPath, TemplatesPath, PackageName);
            GenerateModel(CodeRootPath, TemplatesPath, PackageName, Model, JsonString);
            var PresentationPath = GeneratePresentation(CodeRootPath, TemplatesPath, PackageName);
            GenerateNavigation(PresentationPath, TemplatesPath, PackageName, UseFragments);
            
            return CodeRootPath;
        }

        private static string Init(string MainPath, string PackageName)
        {
            var CurrentLevelPath = MainPath;

            foreach (var Level in PackageName.Split('.'))
            {
                var LevelPath = Path.Combine(CurrentLevelPath, Level);
                if (!Directory.Exists(LevelPath))
                    Directory.CreateDirectory(LevelPath);

                CurrentLevelPath = LevelPath;
            }

            return CurrentLevelPath;
        }

        private static void GenerateCore(string RootPath, string TemplatesPath, string PackageName)
        {
            var CorePath = Path.Combine(RootPath, "core");
            if (!Directory.Exists(CorePath))
                Directory.CreateDirectory(CorePath);

            #region Constants File
            var ConstantsFilePath = Path.Combine(CorePath, "Constants.kt");
            var TemplateConstantsFilePath = Path.Combine(TemplatesPath, "Constants.txt");

            var Constants = File.ReadAllText(TemplateConstantsFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(ConstantsFilePath, Constants);
            #endregion

            #region My App File
            var MyAppFilePath = Path.Combine(CorePath, "MyApp.kt");
            var TemplateMyAppFilePath = Path.Combine(TemplatesPath, "MyApp.txt");

            var MyApp = File.ReadAllText(TemplateMyAppFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(MyAppFilePath, MyApp);
            #endregion

            #region Session File
            var SessionFilePath = Path.Combine(CorePath, "Session.kt");
            var TemplateSessionFilePath = Path.Combine(TemplatesPath, "Session.txt");

            var Session = File.ReadAllText(TemplateSessionFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(SessionFilePath, Session);
            #endregion
        }

        private static void GenerateDependencyInjection(string RootPath, string TemplatesPath, string PackageName)
        {
            var DIPath = Path.Combine(RootPath, "di");
            if (!Directory.Exists(DIPath))
                Directory.CreateDirectory(DIPath);

            #region My App Module File
            var AppModuleFilePath = Path.Combine(DIPath, "MyAppModule.kt");
            var TemplateAppModuleFilePath = Path.Combine(TemplatesPath, "DIMyAppModule.txt");

            var MyAppModule = File.ReadAllText(TemplateAppModuleFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(AppModuleFilePath, MyAppModule);
            #endregion

            #region API Module File
            var APIModuleFilePath = Path.Combine(DIPath, "ApiModule.kt");
            var TemplateAPIModuleFilePath = Path.Combine(TemplatesPath, "DIAPIModule.txt");

            var APIModule = File.ReadAllText(TemplateAPIModuleFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(APIModuleFilePath, APIModule);
            #endregion

            #region Services Module File
            var ServicesModuleFilePath = Path.Combine(DIPath, "ServicesModule.kt");
            var TemplateServicesModuleFilePath = Path.Combine(TemplatesPath, "DIServicesModule.txt");

            var ServicesModule = File.ReadAllText(TemplateServicesModuleFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(ServicesModuleFilePath, ServicesModule);
            #endregion

            #region Presentation Module File
            var PresentationModuleFilePath = Path.Combine(DIPath, "PresentationModule.kt");
            var TemplatePresentationModuleFilePath = Path.Combine(TemplatesPath, "DIPresentationModule.txt");

            var PresentationModule = File.ReadAllText(TemplatePresentationModuleFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(PresentationModuleFilePath, PresentationModule);
            #endregion
        }

        private static void GenerateModel(string RootPath, string TemplatesPath, string PackageName, string Model, string JsonString)
        {
            var ModelPath = Path.Combine(RootPath, "model");
            if (!Directory.Exists(ModelPath))
                Directory.CreateDirectory(ModelPath);

            try
            {
                #region Get Json Properties
                if (JsonString.Trim().Length == 0) return;

                var json_serializer = new JavaScriptSerializer();
                var jsonObject = json_serializer.DeserializeObject(JsonString);

                if (jsonObject == null) return;

                Dictionary<string, object> firstElement;

                List<string> properties = new List<string>();

                if(jsonObject.GetType() == typeof(System.Object[]))
                {
                    //This is a list
                    var list = (jsonObject as Object[]);
                    if (list.Length == 0) return;

                    firstElement = list[0] as Dictionary<string, object>;
                }
                else
                {
                    firstElement = jsonObject as Dictionary<string, object>;
                }

                foreach (KeyValuePair<string, object> prop in firstElement)
                {
                    string template = Environment.NewLine + "\tvar {{key}}: {{kotlinType}}";
                    string formattedProp = template.Replace("{{key}}", prop.Key).Replace("{{kotlinType}}", prop.Value.GetType().ToString());
                    properties.Add(formattedProp.Replace("System.", "").Replace("Int32", "Int"));
                }

                string sProperties = string.Join(",", properties);
                #endregion

                #region Model File
                var ModelFilePath = Path.Combine(ModelPath, Model + ".kt");
                var TemplateModelFilePath = Path.Combine(TemplatesPath, "Model.txt");

                var ModelFileContents = File.ReadAllText(TemplateModelFilePath)
                    .Replace("{{packageName}}", PackageName)
                    .Replace("{{model}}", Model)
                    .Replace("{{properties}}", sProperties);

                File.WriteAllText(ModelFilePath, ModelFileContents);
                #endregion

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            //var jsonSerializer = new JavaScriptSerializer();
        }

        #region Presentation
        private static string GeneratePresentation(string RootPath, string TemplatesPath, string PackageName)
        {
            var PresentationPath = Path.Combine(RootPath, "presentation");
            if (!Directory.Exists(PresentationPath))
                Directory.CreateDirectory(PresentationPath);

            GenerateBase(PresentationPath, TemplatesPath, PackageName);

            return PresentationPath;
        }

        private static void GenerateBase(string PresentationPath, string TemplatesPath, string PackageName)
        {
            var BasePath = Path.Combine(PresentationPath, "base");
            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);

            #region Base Fragment
            var BaseFragmentFilePath = Path.Combine(BasePath, "BaseFragment.kt");
            var TemplateBaseFragmentFilePath = Path.Combine(TemplatesPath, "BaseFragment.txt");

            var BaseFragment = File.ReadAllText(TemplateBaseFragmentFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(BaseFragmentFilePath, BaseFragment);
            #endregion

            #region Base Fragment Listener
            var BaseFragmentListenerFilePath = Path.Combine(BasePath, "BaseFragmentListener.kt");
            var TemplateBaseFragmentListenerFilePath = Path.Combine(TemplatesPath, "BaseFragmentListener.txt");

            var BaseFragmentListener = File.ReadAllText(TemplateBaseFragmentListenerFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(BaseFragmentListenerFilePath, BaseFragmentListener);
            #endregion

            #region Base RecyclerView Adapter
            var BaseRVAdapterFilePath = Path.Combine(BasePath, "BaseRVAdapter.kt");
            var TemplateBaseRVAdapterFilePath = Path.Combine(TemplatesPath, "BaseRVAdapter.txt");


            var BaseRVAdapter = File.ReadAllText(TemplateBaseRVAdapterFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(BaseRVAdapterFilePath, BaseRVAdapter);
            #endregion

            #region Base Spinner Adapter
            var BaseSpinnerAdapterFilePath = Path.Combine(BasePath, "BaseSpinnerAdapter.kt");
            var TemplateBaseSpinnerAdapterFilePath = Path.Combine(TemplatesPath, "BaseSpinnerAdapter.txt");


            var BaseSpinnerAdapter = File.ReadAllText(TemplateBaseSpinnerAdapterFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(BaseSpinnerAdapterFilePath, BaseSpinnerAdapter);
            #endregion

            #region Base ViewModel
            var BaseViewModelFilePath = Path.Combine(BasePath, "BaseViewModel.kt");
            var TemplateBaseViewModelFilePath = Path.Combine(TemplatesPath, "BaseViewModel.txt");


            var BaseViewModel = File.ReadAllText(TemplateBaseViewModelFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(BaseViewModelFilePath, BaseViewModel);
            #endregion

            #region Base Activity
            var BaseActivityFilePath = Path.Combine(BasePath, "BaseActivity.kt");
            var TemplateBaseActivityFilePath = Path.Combine(TemplatesPath, "BaseActivity.txt");


            var BaseActivity = File.ReadAllText(TemplateBaseActivityFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(BaseActivityFilePath, BaseActivity);
            #endregion
        }

        private static void GenerateNavigation(string PresentationPath, string TemplatesPath, string PackageName, bool UseFragments)
        {
            var NavigationPath = Path.Combine(PresentationPath, "navigation");
            if (!Directory.Exists(NavigationPath))
                Directory.CreateDirectory(NavigationPath);

            #region Navigation Interface
            var NavigationFilePath = Path.Combine(NavigationPath, "Navigation.kt");
            var TemplateNavigationFilePath = UseFragments ? Path.Combine(TemplatesPath, "FragmentNavigation.txt") : Path.Combine(TemplatesPath, "ActivityNavigation.txt");

            var Navigation = File.ReadAllText(TemplateNavigationFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(NavigationFilePath, Navigation);
            #endregion

            #region Navigation Implementation
            var NavigationImplFilePath = Path.Combine(NavigationPath, "NavigationImpl.kt");
            var TemplateNavigationImplFilePath = UseFragments ? Path.Combine(TemplatesPath, "FragmentNavigationImpl.txt") : Path.Combine(TemplatesPath, "ActivityNavigationImpl.txt");

            var NavigationImpl = File.ReadAllText(TemplateNavigationImplFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(NavigationImplFilePath, NavigationImpl);
            #endregion
        }

        private static void GenerateMainActivity(string PresentationPath, string TemplatesPath, string PackageName, bool UseFragments, string Model, string ModelProperty, string ModelItemProperty)
        {
            var MainActivityFilePath = Path.Combine(PresentationPath, "MainActivity.kt");
            var TemplateMainActivityFilePath = UseFragments ? Path.Combine(TemplatesPath, "FragmentMainActivity.txt") : Path.Combine(TemplatesPath, "MainActivity.txt");

            var MainActivity = File.ReadAllText(TemplateMainActivityFilePath)
                .Replace("{{packageName}}", PackageName);

            File.WriteAllText(MainActivityFilePath, MainActivity);

            if (!UseFragments) return;

            #region Home
            var HomePath = Path.Combine(PresentationPath, "home");
            if (!Directory.Exists(HomePath))
                Directory.CreateDirectory(HomePath);

            #region Home Fragment
            var HomeFragmentFilePath = Path.Combine(PresentationPath, "HomeFragment.kt");
            var TemplateHomeFragmentFilePath = Path.Combine(TemplatesPath, "HomeFragment.txt");

            var HomeFragment = File.ReadAllText(TemplateHomeFragmentFilePath)
                .Replace("{{packageName}}", PackageName)
                .Replace("{{model}}", Model)
                .Replace("{{modelProperty}}", ModelProperty);

            File.WriteAllText(HomeFragmentFilePath, HomeFragment);
            #endregion Home Fragment

            #region Home ViewModel
            var HomeViewModelFilePath = Path.Combine(PresentationPath, "HomeViewModel.kt");
            var TemplateHomeViewModelFilePath = Path.Combine(TemplatesPath, "HomeViewModel.txt");

            var HomeViewModel = File.ReadAllText(TemplateHomeViewModelFilePath)
                .Replace("{{packageName}}", PackageName)
                .Replace("{{model}}", Model)
                .Replace("{{modelProperty}}", ModelProperty)
                .Replace("{{modelItemProperty}}", ModelItemProperty);

            File.WriteAllText(HomeViewModelFilePath, HomeViewModel);
            #endregion Home ViewModel

            #region Model Item ViewModel
            var ModelItemViewModelFilePath = Path.Combine(PresentationPath, "HomeItemViewModel.kt");
            var TemplateModelItemViewModelFilePath = Path.Combine(TemplatesPath, "HomeItemViewModel.txt");

            var ModelItemViewModel = File.ReadAllText(TemplateModelItemViewModelFilePath)
                .Replace("{{packageName}}", PackageName)
                .Replace("{{model}}", Model)
                .Replace("{{modelItemProperty}}", ModelItemProperty);

            File.WriteAllText(ModelItemViewModelFilePath, ModelItemViewModel);
            #endregion Model Item ViewModel

            #region RecyclerView Adapter
            var RVAdapterFilePath = Path.Combine(PresentationPath, "HomeRVAdapter.kt");
            var TemplateRVAdapterFilePath = Path.Combine(TemplatesPath, "HomeRVAdapter.txt");

            var RVAdapter = File.ReadAllText(TemplateRVAdapterFilePath)
                .Replace("{{packageName}}", PackageName)
                .Replace("{{model}}", Model)
                .Replace("{{modelItemProperty}}", ModelItemProperty);

            File.WriteAllText(RVAdapterFilePath, RVAdapter);
            #endregion RecyclerView Adapter
            #endregion
        }
        #endregion

        private static void GenerateRepository(string RootPath)
        {
            var RepositoryPath = Path.Combine(RootPath, "repository");
            if (!Directory.Exists(RepositoryPath))
                Directory.CreateDirectory(RepositoryPath);
        }

        private static void GenerateUtils(string RootPath)
        {
            var UtilsPath = Path.Combine(RootPath, "utils");
            if (!Directory.Exists(UtilsPath))
                Directory.CreateDirectory(UtilsPath);
        }
    }
}
