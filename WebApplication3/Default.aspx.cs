using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;    //Library
using System.Configuration;

namespace WebApplication3
{
    public partial class Default : System.Web.UI.Page
    {
        //Create Object
        SqlConnection con;

        SqlCommand com;

        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // Step1: Open DataBase
                string path = ConfigurationManager.AppSettings["Mydb"];
                con = new SqlConnection(path);
                con.Open();

                // Step2: Apply Command (Parameterised Method)
                string k = "SELECT COUNT(Id)+1 FROM Details";
                com = new SqlCommand(k, con);
                txtId.Text = "BIO-" + DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MMMM") + "00-" + com.ExecuteScalar().ToString();

                // Store the generated ID in a session variable
                Session["GeneratedId"] = txtId.Text;

                // Close the connection after getting the ID
                con.Close();
            }
            

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Steps For Coding

            // Step1: Open DataBase
            string path = ConfigurationManager.AppSettings["Mydb"];
            con = new SqlConnection(path);
            con.Open();

            // Step2: Check if ID already exists
            string checkIdQuery = "SELECT COUNT(Id) FROM Details WHERE Id = @Id";
            com = new SqlCommand(checkIdQuery, con);
            com.Parameters.AddWithValue("Id", txtId.Text);

            int existingRecords = (int)com.ExecuteScalar();

            if (existingRecords > 0)
            {
                // ID already exists, perform an update

                string updateQuery = "UPDATE Details SET Name = @Name, Email = @Email, Mobile = @Mobile, City = @City, Address = @Address, Pincode = @Pincode, Image = @Image WHERE Id = @Id";
                com = new SqlCommand(updateQuery, con);

                // Pass Control To Query
                com.Parameters.AddWithValue("Name", txtName.Text);
                com.Parameters.AddWithValue("Email", txtEmail.Text);
                com.Parameters.AddWithValue("Mobile", txtMobile.Text);
                com.Parameters.AddWithValue("City", ddlCity.Text);
                com.Parameters.AddWithValue("Address", txtAddress.Text);
                com.Parameters.AddWithValue("Pincode", txtPin.Text);

                FileUpload1.SaveAs(Server.MapPath("~") + "//Upload//" + FileUpload1.FileName);
                com.Parameters.AddWithValue("Image", FileUpload1.FileName);

                // ID parameter for update
                com.Parameters.AddWithValue("Id", txtId.Text);

                // Perform update
                com.ExecuteNonQuery();

                Response.Write("<script>alert('Record Updated Successfully')</script>");
            }
            else
            {
                // ID doesn't exist, perform an insert

                string insertQuery = "Insert into Details (Id, Name, Email, Mobile, City, Address, Pincode, Image) Values(@Id, @Name, @Email, @Mobile, @City, @Address, @Pincode, @Image)";
                com = new SqlCommand(insertQuery, con);

                // Pass Control To Query
                com.Parameters.AddWithValue("Id", txtId.Text);
                com.Parameters.AddWithValue("Name", txtName.Text);
                com.Parameters.AddWithValue("Email", txtEmail.Text);
                com.Parameters.AddWithValue("Mobile", txtMobile.Text);
                com.Parameters.AddWithValue("City", ddlCity.Text);
                com.Parameters.AddWithValue("Address", txtAddress.Text);
                com.Parameters.AddWithValue("Pincode", txtPin.Text);

                FileUpload1.SaveAs(Server.MapPath("~") + "//Upload//" + FileUpload1.FileName);
                com.Parameters.AddWithValue("Image", FileUpload1.FileName);

                // Perform insert
                com.ExecuteNonQuery();

                Response.Write("<script>alert('Record Updated Successfully')</script>");
            }

            // Close the connection
            con.Close();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Qualification.aspx");
        }
    }
}
