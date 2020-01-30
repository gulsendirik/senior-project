using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SF
{
    public partial class basket : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text = "Send";
            Label1.Text = "Sepet Toplamları";
            DropDownList1.Items.Add("Barınak1");
            DropDownList1.Items.Add("Barınak2");
            Label2.Visible = false;
            Label.Visible = false;

        }

        public string Totalprice()
        {
            SqlConnection baglanti = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Administrator\source\repos\SF\SF\App_Data\adminlogin.mdf;Integrated Security = True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(price) from Cats", baglanti);
            decimal Totalprice = Convert.ToDecimal(cmd.ExecuteScalar().ToString());
            baglanti.Close();
            return Convert.ToString(Totalprice);

        }

        public string Totalprice2()
        {
            SqlConnection baglanti = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Gülşen Dirik\source\repos\SF;Integrated Security = True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(price) from Dogs", baglanti);
            decimal Totalprice = Convert.ToDecimal(cmd.ExecuteScalar().ToString());
            baglanti.Close();
            return Convert.ToString(Totalprice);
        }

        public string Total()
        {
            SqlConnection baglanti = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Gülşen Dirik\source\repos\SF;Integrated Security = True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM(price) from Cats", baglanti);
            decimal Totalprice = Convert.ToDecimal(cmd.ExecuteScalar().ToString());
            SqlCommand cmd2 = new SqlCommand("SELECT SUM(price) from Dogs", baglanti);
            decimal Totalprice2 = Convert.ToDecimal(cmd2.ExecuteScalar().ToString());

            decimal Total = Convert.ToDecimal(Totalprice + Totalprice2);
            baglanti.Close();
            return Convert.ToString(Total);

        }

        protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Gülşen Dirik\source\repos\SF;Integrated Security = True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO basket(totalprice, shelter) VALUES(@totalprice, @shelter)", baglanti);
            cmd.Parameters.AddWithValue("totalprice", Total().ToString());
            cmd.Parameters.AddWithValue("shelter", DropDownList1.SelectedValue);
            int sonuc = cmd.ExecuteNonQuery();

            if (sonuc > 0)
            {
                Label.Visible = true;
                Label.Text = "Kayıt ekleme yapıldı.";
            }
            else
            {
                Label.Visible = true;
                Label.Text = "Kayıt ekleme yapılamadı.";
            }

            baglanti.Close();
        }
    }
}
