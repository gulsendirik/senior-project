using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace SF
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Items.aspx");
        }

        private void UploadImage()
        {
            string folderPath = Server.MapPath("~/images/");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));
            Image1.ImageUrl = "~/images/" + Path.GetFileName(FileUpload1.FileName);

            Image1.Width = 200;
            Image1.Height = 150;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            UploadImage();
        }

        protected void AddItem_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Gülşen Dirik\source\repos\SF;Integrated Security = True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO urunler(photo,category,productName,explanation) VALUES(@photo, @category, @productName, @explanation)", baglanti);
            cmd.Parameters.AddWithValue("photo", Image1.ImageUrl);
            cmd.Parameters.AddWithValue("category", DropDownList1.Text);
            cmd.Parameters.AddWithValue("productName", TextBox2.Text);
            cmd.Parameters.AddWithValue("explanation", TextBox3.Text);
            TextBox3.Attributes.Add("maxlength", "200");
            int sonuc = cmd.ExecuteNonQuery();

            if (sonuc > 0)
            {
                label.Text = "Kayıt ekleme yapıldı.";
            }
            else
            {
                label.Text = "Kayıt ekleme yapılamadı.";
            }


            baglanti.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Administrator\source\repos\SF\SF\App_Data\adminlogin.mdf;Integrated Security = True");
            baglanti.Open();
            SqlCommand listele = new SqlCommand("select * from kategoriler", baglanti);

            IDataReader dr = listele.ExecuteReader();

            while (dr.Read())
            {
                DropDownList1.Items.Add(dr["baslik"].ToString());
            }
        }
    }
}

