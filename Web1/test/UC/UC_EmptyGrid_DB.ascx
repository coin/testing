<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_EmptyGrid_DB.ascx.cs" Inherits="Web1.test.UC.WebUserControl3" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridLookup" tagprefix="dx" %>

<dx:ASPxGridLookup ID="_GridLookupTurma" runat="server" 
    AutoGenerateColumns="False" AutoPostBack="True" 
    DataSourceID="ObjectDataSource1" KeyFieldName="idturma" 
    ontextchanged="ASPxGridLookup1_TextChanged" TextFormatString="{0}: {1}">
<GridViewProperties>
<SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True"></SettingsBehavior>
</GridViewProperties>
    <Columns>
        <dx:GridViewDataTextColumn Caption="Turma" FieldName="nome" VisibleIndex="0">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Nota" FieldName="nota" VisibleIndex="1">
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridLookup>
<dx:ASPxGridView ID="_GridAlunos" runat="server">
</dx:ASPxGridView>
<asp:Label ID="_label" runat="server" Text="NONE"></asp:Label>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    InsertMethod="InsertTurma" SelectMethod="GetTurmas" 
    TypeName="Web1.Classes.TurmaDB">
    <InsertParameters>
        <asp:Parameter Name="nome" Type="String" />
        <asp:Parameter Name="nota" Type="String" />
    </InsertParameters>
</asp:ObjectDataSource>

