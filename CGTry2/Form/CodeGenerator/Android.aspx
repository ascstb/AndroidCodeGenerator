<%@ Page Title="" Language="C#" MasterPageFile="~/inc/master/Principal.Master" AutoEventWireup="true" CodeBehind="Android.aspx.cs" Inherits="CGTry2.Form.CodeGenerator.Android" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <input type="text" id="txtAppName" class="form-control" maxlength="500" placeholder="My App" autofocus />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="txtPackageName">Package Name</label>
                    <div class="col-sm-10">
                        <input type="text" id="txtPackageName" class="form-control" maxlength="500"
                            placeholder="com.example.myapp" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Content Type:</label>
                    <div class="col-sm-10">
                        <div class="radio radio-success radio-inline">
                            <input type="radio" name="rblContentType" id="rblContentTypeActivities" value="0" />
                            <label for="rblContentTypeActivities">Activities</label>
                        </div>
                        <div class="radio radio-danger radio-inline">
                            <input type="radio" name="rblContentType" id="rblContentTypeFragments" value="1" />
                            <label for="rblContentTypeFragments">Fragments</label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <button id="btnGenerate" type="button" class="btn btn-primary"><i class="fa fa-cogs"></i><span
                                class="hidden-sm hidden-xs">Generate</span></button>
                        <button id="btnStartOver" type="button" class="btn btn-default"><i class='fa fa-refresh'></i><span
                                class="hidden-sm hidden-xs">Start Over</span></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PiePagina" runat="server">
</asp:Content>