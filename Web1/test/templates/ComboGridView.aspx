<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComboGridView.aspx.cs" Inherits="Web1.test.templates.WebForm1" %>

<%@ Register src="../UC/UC_EmptyGrid_DB.ascx" tagname="UC_EmptyGrid_DB" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Select &quot;Turma&quot; from the LookupGrid and it will show the &quot;Alunos&quot; Table<br />
        <uc1:UC_EmptyGrid_DB ID="UC_EmptyGrid_DB1" runat="server" />
    
    </div>
    </form>
</body>
</html>
