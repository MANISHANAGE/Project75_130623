<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Singlepro.aspx.cs" Inherits="Project75_130623.Singlepro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="color:mediumvioletred;">Employee Details</h1>
            
            <table border="1" style="background-color:darkblue;color:white" width="500px">
            <tr>
                <td>Name:</td>
                <td><asp:TextBox ID="txtname" runat="server" width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Age:</td>
                <td><asp:TextBox ID="txtage" runat="server" width="50px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>City:</td>
                <td><asp:TextBox ID="txtcity" runat="server" width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Salary:</td>
                <td><asp:TextBox ID="txtsal" runat="server" width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnsave" runat="server" Text="Save" Onclick="btnsave_Click"  forecolor="Black" Font-Size="Large" BackColor="deeppink"/></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Gridview ID="Gvemp" runat="server" AutoGenerateColumns="false" OnRowCommand="Gvemp_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Emp id">
                            <ItemTemplate>
                                <%#Eval("id")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Emp Name">
                            <ItemTemplate>
                                <%#Eval("Name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Emp Age">
                            <ItemTemplate>
                                <%#Eval("Age")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Emp City">
                            <ItemTemplate>
                                <%#Eval("City")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Emp Salary">
                            <ItemTemplate>
                                <%#Eval("Salary")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btndelete" runat="server" Text="Delete"  ForeColor="white" CommandName="A" CommandArgument='<%#Eval("id")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnedit" runat="server" Text="Edit" ForeColor="white" CommandName="B" CommandArgument='<%#Eval("id")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    </asp:Gridview></td>
            </tr>
            </table>

        </div>
    </form>
</body>
</html>
