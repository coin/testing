<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_EmptyGrid_DB.ascx.cs" Inherits="Web1.test.UC.WebUserControl3" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<dx:ASPxComboBox ID="ASPxComboBox1" runat="server" 
    DataSourceID="ObjectDataSource1">
    <Columns>
        <dx:ListBoxColumn FieldName="nome" />
    </Columns>
</dx:ASPxComboBox>
<dx:ASPxGridView ID="ASPxGridView1" runat="server">
</dx:ASPxGridView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="GetTurmas" TypeName="Web1.Classes.TurmaDB">
</asp:ObjectDataSource>

