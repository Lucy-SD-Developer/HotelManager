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
    public partial class DeleteImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reload();
        }

        protected void gvDisplayImages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int imageId = (int)gvDisplayImages.DataKeys[e.RowIndex]["Id"];
            string imageName = gvDisplayImages.Rows[e.RowIndex].Cells[0].Text;

            // Remove from database
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ImageDB"].ToString()))
            {
                connection.Open();
                string query = "DELETE FROM Images WHERE Id = @Id";
                
                SqlCommand com = new SqlCommand(query, connection);
                com.Parameters.AddWithValue("@Id", imageId);
                com.ExecuteNonQuery();
            }


            // Delete from disk
            string path = Server.MapPath("~/Images/Background/" + imageName);
            if (!File.Exists(path))
            {
                File.Delete(path);
            }
            ((DataTable)gvDisplayImages.DataSource).Rows.RemoveAt(e.RowIndex);
            gvDisplayImages.DataBind();
        }

        private void reload()
        {
            // Load image info from db
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ImageDB"].ToString()))
            {
                connection.Open();
                string query = "SELECT Id, ImageName, UploadDateTime FROM Images ORDER BY Id";

                SqlCommand com = new SqlCommand(query, connection);
                List<string> backgroundImages = new List<string>();
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    gvDisplayImages.DataSource = dt;
                    gvDisplayImages.DataBind();
                }
            }
        }
    }
}