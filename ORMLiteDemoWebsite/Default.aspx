<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ORMLiteDemoWebsite.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Hello World!</h1>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><strong><%# DataBinder.Eval(Container.DataItem, "ID")%> : </strong> <%# DataBinder.Eval(Container.DataItem, "Name") %> aged <%# DataBinder.Eval(Container.DataItem, "Age") %> - <%# GetLatestAddressText(DataBinder.Eval(Container.DataItem, "ID"))%>
                    
                </li>

            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
