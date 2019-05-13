<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHotel.aspx.cs" Inherits="Assn7.AddHotel" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>add hotel</title>
</head>

<body>

     <div>Add Hotel Information</div>

    <form id="addHotel" runat="server">
        <asp:Label runat="server" AssociatedControlID="txtHotelName">Hotel Name</asp:Label>
        <asp:TextBox runat="server" ID="txtHotelName"></asp:TextBox>
        <br />
        <asp:Label runat="server" AssociatedControlID="txtPrice">Price Per Night</asp:Label>
        <asp:TextBox runat="server" ID="txtPrice" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Label runat="server" AssociatedControlID="txtAvailable">Available Number Of Rooms</asp:Label>
        <asp:TextBox runat="server" ID="txtAvailable" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click"></asp:Button>
    </form>
</body>

</html>
