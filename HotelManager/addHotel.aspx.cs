using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assn7
{
    public partial class AddHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HotelDB"].ToString()))
            {
                connection.Open();
                SqlCommand com = new SqlCommand(
                    @"INSERT INTO Hotelinfo
                        (HotelName, PricePerNight, AvailableRooms, BookedRooms)
                    VALUES (@hotelName, @pricePerNight, @availableRooms, @bookedRooms)", connection);

                com.Parameters.AddWithValue("@hotelName", txtHotelName.Text);
                com.Parameters.AddWithValue("@pricePerNight", double.Parse(txtPrice.Text));
                com.Parameters.AddWithValue("@availableRooms", int.Parse(txtAvailable.Text));
                com.Parameters.AddWithValue("@bookedRooms", 0);
                com.ExecuteNonQuery();
            }
            Response.Redirect("BookHotel.aspx");
        }
    }
}