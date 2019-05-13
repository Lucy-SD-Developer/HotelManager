using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assn7
{
    public partial class BookHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reload();
        }

        protected void btnAddHotel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddHotel.aspx");

        }

        protected void btnHomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bing.aspx");
        }
        
        protected void gvHotelInfo_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int hotelId = (int)gvHotelInfo.DataKeys[e.NewSelectedIndex]["Id"];
            int availableRooms = int.Parse(gvHotelInfo.Rows[e.NewSelectedIndex].Cells[2].Text);
            int bookedRooms = int.Parse(gvHotelInfo.Rows[e.NewSelectedIndex].Cells[3].Text);

            // Update database
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HotelDB"].ToString()))
            {
                connection.Open();
                string query = "UPDATE HotelInfo SET AvailableRooms = @availableRooms, BookedRooms = @bookedRooms WHERE Id = @Id";

                SqlCommand com = new SqlCommand(query, connection);
                com.Parameters.AddWithValue("@availableRooms", --availableRooms);
                com.Parameters.AddWithValue("@bookedRooms", ++bookedRooms);
                com.Parameters.AddWithValue("@Id", hotelId);
                com.ExecuteNonQuery();
            }

            ((DataTable)gvHotelInfo.DataSource).Rows[e.NewSelectedIndex].ItemArray[3] = availableRooms;
            ((DataTable)gvHotelInfo.DataSource).Rows[e.NewSelectedIndex].ItemArray[4] = bookedRooms;
            gvHotelInfo.DataBind();
        }

        protected void gvHotelInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int hotelId = (int)gvHotelInfo.DataKeys[e.RowIndex]["Id"];
            string hotelName = gvHotelInfo.Rows[e.RowIndex].Cells[0].Text;

            // Remove from database
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HotelDB"].ToString()))
            {
                connection.Open();
                string query = "DELETE FROM HotelInfo WHERE Id = @Id";

                SqlCommand com = new SqlCommand(query, connection);
                com.Parameters.AddWithValue("@Id", hotelId);
                com.ExecuteNonQuery();
            }

            ((DataTable)gvHotelInfo.DataSource).Rows.RemoveAt(e.RowIndex);
            gvHotelInfo.DataBind();
        }


        private void reload()
        {
            // Load hotel info from db
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["HotelDB"].ToString()))
            {
                connection.Open();
                string query = "SELECT Id, HotelName, PricePerNight, AvailableRooms, BookedRooms FROM HotelInfo ORDER BY Id";

                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    gvHotelInfo.DataSource = dt;
                    gvHotelInfo.DataBind();
                }
            }
        }

    }
}