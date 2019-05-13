<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteImage.aspx.cs" Inherits="Assn7.DeleteImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Delete An Image from DB</title>
</head>

    <body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td><b>Choose Image to Delete:</b></td>
    </tr>

        <tr>
            <td class="style1">
           Image List:
            </td>

        </tr>

    </table>
    </div>

    <asp:GridView ID="gvDisplayImages" runat="server" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black" AutoGenerateColumns="false" DataKeyNames="Id"
        onrowdeleting="gvDisplayImages_RowDeleting">
        <Columns>
            <asp:BoundField DataField="ImageName" HeaderText="ImageName" 
                    SortExpression="ImageName" />
            <asp:CommandField SelectText="Delete" ShowDeleteButton="true" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>

    </form>
    </body>

</html>
