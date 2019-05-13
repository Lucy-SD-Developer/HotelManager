<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookHotel.aspx.cs" Inherits="Assn7.BookHotel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book a Hotel</title>
</head>
<body>
    <form id="formHotel" runat="server">
        <div>
    <table>
    <tr>
    <td><b>Booking a Hotel:<br />
        <br />
        </b></td>
    </tr>

        <tr>
            <td class="style1">
           Hotel Information:
            </td>
<td class="style1">
    <br />
</td>
        </tr>
    </table>

        </div>
    <asp:GridView ID="gvHotelInfo" runat="server" BackColor="#CCCCCC" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black" AutoGenerateColumns="False" DataKeyNames="Id"
        onInfoDisplay="gvHotelInfo_Display" OnSelectedIndexChanging="gvHotelInfo_SelectedIndexChanging" OnRowDeleting="gvHotelInfo_RowDeleting">

        <Columns><asp:BoundField DataField="HotelName" HeaderText="Hotel Name" SortExpression="HotelName" /></Columns>          
        <Columns><asp:BoundField DataField="PricePerNight" HeaderText="Price per Night" SortExpression="HotelName"></asp:BoundField></Columns>
        <Columns><asp:BoundField DataField="AvailableRooms" HeaderText="Availble Rooms" SortExpression="HotelName"></asp:BoundField></Columns>
        <Columns><asp:BoundField DataField="BookedRooms" HeaderText="Booked Rooms" SortExpression="HotelName"></asp:BoundField></Columns>
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Book" Visible='<%# (int)Eval("AvailableRooms") > 0 %>' CommandName="Select"/>
                    <asp:LinkButton runat="server" Text="Delete" Visible='<%# (int)Eval("AvailableRooms") == 0 %>' CommandName="Delete"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

            
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnAddHotel" runat="server" Text="Add"  OnClick="btnAddHotel_Click"/>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="btnHomePage" runat="server" Text="Home" OnClick="btnHomePage_Click"/>
        </p>
    </form>
</body>
</html>
