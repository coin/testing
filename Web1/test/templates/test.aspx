<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Web1.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:DetailsView ID="DetailsView1" runat="server" 
        DataSourceID="ObjectDataSource1" Height="50px" Width="125px" 
        DefaultMode="Insert" AutoGenerateInsertButton="True" 
        AutoGenerateRows="False">
        <Fields>
            <asp:TemplateField AccessibleHeaderText="nome" HeaderText="nome">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField AccessibleHeaderText="idade" DataField="idade" 
                HeaderText="idade" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        TypeName="Web1.Classes.AlunoDB" InsertMethod="AddAluno">
    </asp:ObjectDataSource>
    </form>
    </body>
</html>
