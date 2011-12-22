<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_GridView_DataSource.ascx.cs" Inherits="Web1.test.UC.WebUserControl1" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" 
    DataSourceID="SqlDataSource1" KeyFieldName="id">
    <Columns>
        <dx:GridViewCommandColumn VisibleIndex="0">
            <EditButton Visible="True">
            </EditButton>
            <NewButton Visible="True">
            </NewButton>
            <DeleteButton Visible="True">
            </DeleteButton>
            <ClearFilterButton Visible="True">
            </ClearFilterButton>
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1">
            <EditFormSettings Visible="False" />
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="nome" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="idade" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
    </Columns>
    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
</dx:ASPxGridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:bd_testConnectionString %>" 
    DeleteCommand="DELETE FROM aluno WHERE (id = @id)" 
    InsertCommand="INSERT INTO aluno(nome, idade) VALUES (@nome, @idade)" 
    ProviderName="<%$ ConnectionStrings:bd_testConnectionString.ProviderName %>" 
    SelectCommand="SELECT * FROM aluno" 
    UpdateCommand="UPDATE aluno SET nome = @nome, idade = @idade WHERE (id = @id)">
</asp:SqlDataSource>

