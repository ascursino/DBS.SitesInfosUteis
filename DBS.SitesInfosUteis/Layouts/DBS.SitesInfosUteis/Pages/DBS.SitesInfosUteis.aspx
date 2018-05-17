<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBS.SitesInfosUteis.aspx.cs" Inherits="DBS.SitesInfosUteis.Layouts.DBS.SitesInfosUteis.DBS" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <asp:Label runat="server" ID = "lblErro" ForeColor="Red"></asp:Label>

    <p class="subtitulo_pagina">:: Sites e Informações Úteis</p>
    <p>&nbsp;</p>
    
    <p class="texto_pagina">Selecione a área de interesse: 
      <asp:DropDownList ID="cboBusca" runat="server" CssClass="texto_pagina">
      </asp:DropDownList>
      
      <asp:Button ID="btnBusca" runat="server" Text="Exibir" OnClick="btnBusca_OnClick" />
    </p>
    
    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="grid_tabela">
      <tr class="grid_cabecalho">
        <td width="39%">Descrição</td>
        <td>Telefone</td>
        <td width="41%">Site</td>
      </tr>

      <asp:Literal ID="ltrConteudo" runat="server" />
      
      <!--
      <tr class="grid_conteudo">
        <td>descricao</td>
        <td>telefone</td>
        <td>site</td>
      </tr>
      -->

    </table>
    <p>&nbsp;</p>

</asp:Content>

