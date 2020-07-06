<%@ Page Title="" Language="C#" MasterPageFile="~/inc/master/Principal.Master" AutoEventWireup="true" CodeBehind="Android.aspx.cs" Inherits="CGTry2.Form.CodeGenerator.Android" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["UrlPrincipal"].ToString() %>inc/lib/Inspinia/css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet" />

    <script src="Android.js?Id=<%= DateTime.Now.ToString("ddMMyyyyhhmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Encabezado" runat="server">
    <h2>Android Code Generator</h2>
    <ol class="breadcrumb">
        <li>
            <a
                href="<%=System.Configuration.ConfigurationManager.AppSettings["UrlPrincipal"].ToString() %>Principal.aspx"><i
                    class="fa fa-home fa-fw"></i>Home</a>
        </li>
        <li>
            <a href="<%=System.Configuration.ConfigurationManager.AppSettings["UrlPrincipal"].ToString() %>"><i
                    class="fa fa-th-large"></i>Code Generator</a>
        </li>
        <li class="active">
            <a href="Android.aspx"><i class="fa fa-android fa-fw"></i><strong>Android</strong></a>
        </li>
    </ol>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div id="dvAppConfig" class="ibox float-e-margins">
        <div class="ibox-title">
            <h5><i class="fa fa-cog"></i>Android App Configuration</h5>
            <div class="ibox-tools">
                <a class="collapse-link">
                    <i class="fa fa-chevron-up"></i>
                </a>
            </div>
        </div>
        <div class="ibox-content">
            <div role="form" class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="txtAppName">App Name</label>
                    <div class="col-sm-10">
                        <input type="text" id="txtAppName" class="form-control" maxlength="500" placeholder="My App"
                            value="MyTestApp" autofocus />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="txtPackageName">Package Name</label>
                    <div class="col-sm-10">
                        <input type="text" id="txtPackageName" class="form-control" maxlength="500"
                            placeholder="com.example.myapp" value="com.example.mytestapp" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Content Type</label>
                    <div class="col-sm-10">
                        <div class="radio radio-success radio-inline">
                            <input type="radio" name="rblContentType" id="rblContentTypeActivities" value="1"
                                checked="checked" />
                            <label for="rblContentTypeActivities">Activities</label>
                        </div>
                        <div class="radio radio-danger radio-inline">
                            <input type="radio" name="rblContentType" id="rblContentTypeFragments" value="0" />
                            <label for="rblContentTypeFragments">Fragments</label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Data Repositories</label>
                    <div class="col-sm-10">
                        <div class="i-checks">
                            <label class="">
                                <input id="chkRepositoryServer" type="checkbox" class="checkbox checkbox-primary checkbox-inline styled" value="server" checked="checked" disabled="disabled"/>
                                Server
                            </label>

                            <label class="">
                                <input id="chkRepositorySharedPreferences" type="checkbox" class="checkbox checkbox-primary checkbox-inline styled" value="shared-preferences"/>
                                Shared Preferences
                            </label>

                            <label class="">
                                <input id="chkRepositoryLocal" type="checkbox" class="checkbox checkbox-primary checkbox-inline styled" value="local"/>
                                Local
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="txtBaseUrl">Base Url</label>
                    <div class="col-sm-10">
                        <input type="text" id="txtBaseUrl" class="form-control" placeholder="https://run.mocky.io/" value="https://run.mocky.io/" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="txtModel">Class Name</label>
                    <div class="col-sm-10">
                        <input type="text" id="txtModel" class="form-control" placeholder="ModelClassName" value="App" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="txtJsonModel">Json Model</label>
                    <div class="col-sm-10">
                        <textarea id="txtJsonModel" class="form-control" placeholder="[{'property':'value 1'}, {'property': 'value 2'}]" rows="10">
                            [
    {
        "appId": "1",
        "groups": [
            {
                "name": "entertainment",
                "iconResourceName": "ic_tv_retro_light",
                "iconUrl": ""
            }
        ],
        "name": "TV",
        "deepLink": "tv",
        "iconUrl": "",
        "iconResourceName": "ic_tv_retro_light",
        "adminApp": false,
        "order": 1
    },
    {
        "appId": "2",
        "groups": [
            {
                "name": "family",
                "iconResourceName": "ic_heart",
                "iconUrl": ""
            },
            {
                "name": "community",
                "iconResourceName": "ic_home_heart",
                "iconUrl": ""
            }
        ],
        "name": "Calendar",
        "deepLink": "calendar",
        "iconUrl": "",
        "iconResourceName": "ic_calendar_light",
        "adminApp": false,
        "order": 2
    },
    {
        "appId": "3",
        "groups": [
            {
                "name": "community",
                "iconResourceName": "ic_home_heart",
                "iconUrl": ""
            }
        ],
        "name": "Activities",
        "deepLink": "activities",
        "iconUrl": "",
        "iconResourceName": "ic_puzzle_piece_light",
        "adminApp": false,
        "order": 3
    },
    {
        "appId": "4",
        "groups": [
            {
                "name": "repairs",
                "iconResourceName": "ic_wrench_light",
                "iconUrl": ""
            }
        ],
        "name": "Repairs",
        "deepLink": "new-repair",
        "iconUrl": "",
        "iconResourceName": "ic_wrench_light",
        "adminApp": false,
        "order": 4
    },
    {
        "appId": "12",
        "groups": [
            {
                "name": "repairs",
                "iconResourceName": "ic_wrench_light",
                "iconUrl": ""
            }
        ],
        "name": "See All",
        "deepLink": "repairs",
        "iconUrl": "",
        "iconResourceName": "ic_wrench_light",
        "adminApp": false,
        "order": 5
    },
    {
        "appId": "5",
        "groups": [
            {
                "name": "community",
                "iconResourceName": "ic_home_heart",
                "iconUrl": ""
            }
        ],
        "name": "Dining",
        "deepLink": "dining",
        "iconUrl": "",
        "iconResourceName": "ic_utensils_light",
        "adminApp": false,
        "order": 5
    },
    {
        "appId": "6",
        "groups": [
            {
                "name": "entertainment",
                "iconResourceName": "ic_tv_retro_light",
                "iconUrl": ""
            }
        ],
        "name": "Music",
        "deepLink": "music",
        "iconUrl": "",
        "iconResourceName": "ic_music",
        "adminApp": false,
        "order": 6
    },
    {
        "appId": "7",
        "groups": [
            {
                "name": "community",
                "iconResourceName": "ic_home_heart",
                "iconUrl": ""
            }
        ],
        "name": "Weather",
        "deepLink": "weather",
        "iconUrl": "",
        "iconResourceName": "ic_sun_cloud_light",
        "adminApp": false,
        "order": 7
    },
    {
        "appId": "8",
        "groups": [
            {
                "name": "profile",
                "iconResourceName": "ic_user",
                "iconUrl": ""
            }
        ],
        "name": "Settings",
        "deepLink": "settings",
        "iconUrl": "",
        "iconResourceName": "ic_sliders_v_light",
        "adminApp": false,
        "order": 8
    },
    {
        "appId": "9",
        "groups": [
            {
                "name": "entertainment",
                "iconResourceName": "ic_tv_retro_light",
                "iconUrl": ""
            }
        ],
        "name": "HDMI Passthrough",
        "deepLink": "teaonly.rk.droidipcam",
        "iconUrl": "",
        "iconResourceName": "ic_gamepad_alt",
        "adminApp": false,
        "order": 9
    },
    {
        "appId": "11",
        "groups": [
            {
                "name": "profile",
                "iconResourceName": "ic_user",
                "iconUrl": ""
            }
        ],
        "name": "Admin Settings",
        "deepLink": "admin-settings",
        "iconUrl": "",
        "iconResourceName": "ic_baseline_settings_20px",
        "adminApp": true,
        "order": 0
    },
    {
        "appId": "13",
        "groups": [
            {
                "name": "community",
                "iconResourceName": "ic_home_heart",
                "iconUrl": ""
            }
        ],
        "name": "Exercises",
        "deepLink": "exercises",
        "iconUrl": "",
        "iconResourceName": "ic_heartbeat",
        "adminApp": false,
        "order": 0
    }
]
                        </textarea>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <button id="btnGenerate" type="button" class="btn btn-primary"><i class="fa fa-cogs"></i><span
                                class="hidden-sm hidden-xs">Generate</span></button>
                        <button id="btnStartOver" type="button" class="btn btn-default"><i
                                class='fa fa-refresh'></i><span class="hidden-sm hidden-xs">Start Over</span></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PiePagina" runat="server">
</asp:Content>