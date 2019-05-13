<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bing.aspx.cs" Inherits="Assn7.Bing" %>

<!DOCTYPE html>

<html lang="en">

<head runat="server">
    <title>Bing</title>
    <link rel="stylesheet" type="text/css" href="Shared/Bing.css" />
    <script src="Scripts/jquery/jquery-3.3.1.min.js" type="text/javascript"></script> 
    <script src="Scripts/Bing.js" type="text/javascript"></script>
</head>

<body>

<asp:Panel runat="server" ID="pnlBgImg" ClientIDMode="Static">

<form id="form1" runat="server">
            
    <div id="divMenu">
            
        <asp:Menu ID="mnuMain" runat="server" OnMenuItemClick="mnuMain_MenuItemClick">
        <Items>
            <asp:MenuItem Text="Images"></asp:MenuItem>
            <asp:MenuItem Text="Videos"></asp:MenuItem>
            <asp:MenuItem Text="Maps"></asp:MenuItem>
            <asp:MenuItem Text="News"></asp:MenuItem>
            <asp:MenuItem Text="|" Selectable="False"></asp:MenuItem>
            <asp:MenuItem Text="MSN"></asp:MenuItem>
            <asp:MenuItem Text="Office Online"></asp:MenuItem>
            <asp:MenuItem Text="Outlook.com"></asp:MenuItem>
            <asp:MenuItem Text="My Bing">
                <asp:MenuItem NavigateUrl="~/AddImage.aspx" Text="Add one more image" Value="Add one more image" runat="server"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/DeleteImage.aspx" Text="Delete one existing image" Value="Delete one existing image"></asp:MenuItem>
                <asp:MenuItem Text="Select your image replacing order" Value="Select your image replacing order">
                    <asp:MenuItem Text="By Name" Value="By Name"></asp:MenuItem>
                    <asp:MenuItem Text="By Uploading Date and Time" Value="By Time"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/BookHotel.aspx" Text="Booking a hotel" Value="Booking a hotel"></asp:MenuItem>
            </asp:MenuItem>
        </Items>
        </asp:Menu>
            
    </div>
    <div id="divSearch">
        <div id="divLogo"></div>
        <div id="divSearchBox">
            <div id="divSearchBoxForm">
                <input id="inputSearch"/>
                <input id="inputSearchIcon"/>
            </div>
        </div>
    </div>

    <div id="divBottom">
        <asp:Button id="btnNextImage" runat="server" ClientIDMode="Static" BorderStyle="None" OnClick="btnNextImage_Click" CausesValidation="False" />
        <asp:Button id="btnPrevImage" runat="server" ClientIDMode="Static" BorderStyle="None" OnClick="btnPrevImage_Click" CausesValidation="False" />
    </div>


    </form>
    
</asp:Panel>

</body>

</html>
