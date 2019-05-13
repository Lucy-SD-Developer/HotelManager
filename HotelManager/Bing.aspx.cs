using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assn7
{
    public partial class Bing : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            reload();
        }

        protected void btnNextImage_Click(object sender, EventArgs e)
        {
            pnlBgImg.BackImageUrl = "../Images/Background/" + getImageName(true);
        }

        protected void btnPrevImage_Click(object sender, EventArgs e)
        {
            pnlBgImg.BackImageUrl = "../Images/Background/" + getImageName(false);
        }


        protected void mnuMain_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (mnuMain.SelectedValue == "By Name")
            {
                Session["BackgroundOrder"] = true;
            }
            else if (mnuMain.SelectedValue == "By Time")
            {
                Session["BackgroundOrder"] = false;
            }
            reload();
        }


        private string getImageName(bool next)
        {
            int imageIndex = Session["imageIndex"] == null ? 0 : (int)Session["imageIndex"];
            List<string> backgroundImages = Session["BackgroundImages"] == null ? null : (List<string>)Session["BackgroundImages"];
            if (backgroundImages == null)
            {
                return null;
            }
            if (next)
            {
                imageIndex++;
            }
            else
            {
                imageIndex--;
            }
            imageIndex = (imageIndex + backgroundImages.Count) % backgroundImages.Count;
            Session["imageIndex"] = imageIndex;
            return backgroundImages[imageIndex];
        }

        private void reload()
        {

            bool orderByName;
            if (Session["BackgroundOrder"] == null)
            {
                orderByName = true;
            }
            else
            {
                orderByName = (bool)Session["BackgroundOrder"];
            }
            // Load image names from db
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ImageDB"].ToString()))
            {
                connection.Open();
                string query = "SELECT ImageName, UploadDateTime FROM Images ORDER BY ";
                if (orderByName)
                {
                    query += "ImageName";
                }
                else
                {
                    query += "UploadDateTime";
                }

                SqlCommand com = new SqlCommand(query, connection);
                List<string> backgroundImages = new List<string>();
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string imageName = reader.GetString(0);
                            DateTime uploadDateTime = reader.GetDateTime(1);
                            backgroundImages.Add(imageName);
                        }
                    }
                }
                Session["BackgroundImages"] = backgroundImages;
                pnlBgImg.BackImageUrl = "../Images/Background/" + backgroundImages[0];
            }
        }
    }
}