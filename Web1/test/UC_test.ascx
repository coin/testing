<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_test.ascx.cs" Inherits="Web1.test.WebUserControl1" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<dx:ASPxGridView ID="_gridview" runat="server">
    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
</dx:ASPxGridView>
