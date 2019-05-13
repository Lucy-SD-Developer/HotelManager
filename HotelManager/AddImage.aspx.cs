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
    public partial class AddImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            if (!FileUpload1.HasFile)
            {
                Label1.Visible = true;
                Label1.Text = "Please Select Image File";

            }
            else
            {
                int length = FileUpload1.PostedFile.ContentLength;
                byte[] pic = new byte[length];

                FileUpload1.PostedFile.InputStream.Read(pic, 0, length);
                
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ImageDB"].ToString()))
                {
                    connection.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO Images "
                          + "(ImageName, UploadDateTime) VALUES (@imageName, @uploadDateTime)", connection);
                    
                    com.Parameters.AddWithValue("@imageName", FileUpload1.PostedFile.FileName);
                    com.Parameters.AddWithValue("@uploadDateTime", DateTime.Now);

                    com.ExecuteNonQuery();

                    string saveAs = Server.MapPath("~/Images/Background/" + FileUpload1.PostedFile.FileName);
                    if (!File.Exists(saveAs)) {
                        FileUpload1.PostedFile.SaveAs(saveAs);
                    }

                    Label1.Visible = true;
                    Label1.Text = "Image Uploaded Sucessfully";
                }
            }

        }
    }
}