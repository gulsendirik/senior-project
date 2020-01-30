using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;



namespace SF
{
    public partial class SignUpCustomer : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            label.Visible = false;
        }

        private void SignUp()
        {
            SqlConnection baglanti = new SqlConnection(@"Server=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Administrator\source\repos\SF\SF\App_Data\adminlogin.mdf;Integrated Security = True");
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers(name, last_name, email, phone, birth_date, gender, password) VALUES(@name, @last_name, @email, @phone, @birth_date, @gender, @password)", baglanti);
            cmd.Parameters.AddWithValue("name", TextBox1.Text);
            cmd.Parameters.AddWithValue("last_name", TextBox2.Text);
            cmd.Parameters.AddWithValue("email", TextBox3.Text);
            cmd.Parameters.AddWithValue("phone", TextBox4.Text);
            cmd.Parameters.AddWithValue("birth_date", DropDownList1.SelectedValue + "." + DropDownList2.SelectedValue + "." + DropDownList3.SelectedValue);
            cmd.Parameters.AddWithValue("gender", DropDownList4.SelectedValue);
            cmd.Parameters.AddWithValue("password", TextBox5.Text);
            int sonuc = cmd.ExecuteNonQuery();

            if (sonuc > 0)
            {
                label.Visible = true;
                label.Text = "Kayıt ekleme yapıldı.";


            }
            else
            {
                label.Visible = true;
                label.Text = "Kayıt ekleme yapılamadı.";
            }


            baglanti.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SignUp();
        }


    }
}
