<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddImage.aspx.cs" Inherits="Assn7.AddImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 94px;
        }
        .style2
        {
            width: 307px;
        }
    </style>
</head>
<body bgcolor="#99ccff" text="#333333">
    <form id="form1" runat="server">
    <table style="width: 31%;">
        <tr>
            <td class="style1">
           Select Image
            </td>
            <td class="style2">
             <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>

        <tr><td class="style2"> 
           
            <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click"></asp:Button></td>

        </tr>      
    </table>   

        <p> <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="True" 
                ForeColor="#3333CC"></asp:Label>  </p>
   
    </form>
</body>

</html>
