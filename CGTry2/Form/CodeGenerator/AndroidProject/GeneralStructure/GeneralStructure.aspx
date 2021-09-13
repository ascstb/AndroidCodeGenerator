<%@ Page Title="" Language="C#" MasterPageFile="~/inc/master/Principal.Master" AutoEventWireup="true" CodeBehind="GeneralStructure.aspx.cs" Inherits="CGTry2.Form.CodeGenerator.AndroidProject.GeneralStructure.GeneralStructure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["UrlPrincipal"].ToString() %>inc/lib/Inspinia/css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet" />

    <script src="GeneralStructure.js?Id=<%= DateTime.Now.ToString("ddMMyyyyhhmmss") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Encabezado" runat="server">
    <h2>Android - General Structure</h2>
    <ol class="breadcrumb">
        <li>
            <a
                href="<%=System.Configuration.ConfigurationManager.AppSettings["UrlPrincipal"].ToString() %>Default.aspx"><i
                    class="fa fa-home fa-fw"></i>Home</a>
        </li>
        <li>
            <a href="<%=System.Configuration.ConfigurationManager.AppSettings["UrlPrincipal"].ToString() %>"><i
                    class="fa fa-android"></i>Android</a>
        </li>
        <li class="active">
            <a href="GeneralStructure.aspx"><i class="fa fa-android fa-fw"></i><strong>General Structure</strong></a>
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
                            placeholder="com.r2devpros.mytestapp" value="com.r2devpros.mytestapp" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Security Type</label>
                    <div class="col-sm-10">
                        <div class="radio radio-success radio-inline">
                            <input type="radio" name="rblSecurityType" id="rblSecurityTypeNone" value="0"
                                checked="checked" />
                            <label for="rblSecurityTypeNone">None</label>
                        </div>
                        <div class="radio radio-success radio-inline">
                            <input type="radio" name="rblSecurityType" id="rblSecurityTypeKeycloak" value="1" />
                            <label for="rblSecurityTypeKeycloak">Keycloak</label>
                        </div>
                        <div class="radio radio-success radio-inline">
                            <input type="radio" name="rblSecurityType" id="rblSecurityTypeSocialMedia" value="2" />
                            <label for="rblSecurityTypeSocialMedia">Social Media</label>
                        </div>
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