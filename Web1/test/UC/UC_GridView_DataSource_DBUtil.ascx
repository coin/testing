<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_GridView_DataSource_DBUtil.ascx.cs" Inherits="Web1.test.UC.WebUserControl2" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<dx:ASPxGridView ID="ASPxGridView1" runat="server" 
    DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" 
    EnableCallbackCompression="False" KeyFieldName="id">
    <Columns>
        <dx:GridViewCommandColumn VisibleIndex="0">
            <EditButton Visible="True">
            </EditButton>
            <NewButton Visible="True">
            </NewButton>
            <DeleteButton Visible="True">
            </DeleteButton>
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn Caption="Nome" FieldName="nome" VisibleIndex="1">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="Idade" FieldName="idade" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
    </Columns>
    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
</dx:ASPxGridView>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    InsertMethod="InsertAluno" SelectMethod="GetAlunos" 
    TypeName="Web1.Classes.AlunoDB" DeleteMethod="DeleteAluno" 
    UpdateMethod="UpdateAluno">
    <DeleteParameters>
        <asp:Parameter Name="id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="nome" Type="String" />
        <asp:Parameter Name="idade" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="id" Type="Int32" />
        <asp:Parameter Name="nome" Type="String" />
        <asp:Parameter Name="idade" Type="String" />
    </UpdateParameters>
</asp:ObjectDataSource>

