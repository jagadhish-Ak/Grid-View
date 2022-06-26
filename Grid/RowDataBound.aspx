<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RowDataBound.aspx.cs" Inherits="Grid.RowDataBound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:demodbconn %>" SelectCommand="SELECT * FROM [employee]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="salary" HeaderText="salary" SortExpression="salary"  />
                <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
