using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication3
{
    public partial class Qualification : System.Web.UI.Page
    {
        //Create Object
        SqlConnection con;

        SqlCommand com;

        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string generatedId = Session["GeneratedId"] as string;
                lblId.Text = generatedId;
            }
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Step1: Open DataBase
            string path = ConfigurationManager.AppSettings["Mydb"];
            con = new SqlConnection(path);
            con.Open();

            // Step2: Check if ID already exists
            string checkIdQuery = "SELECT COUNT(Id) FROM Qualification WHERE Id = @Id";
            com = new SqlCommand(checkIdQuery, con);
            com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);

            int existingRecords = (int)com.ExecuteScalar();

            if (existingRecords > 0)
            {
                // ID already exists, perform an update

                string updateQuery = "UPDATE Qualification SET Degree = @Degree, Name_Of_UG = @Name_Of_UG, Year_Of_Passing = @Year_Of_Passing WHERE Id = @Id";
                com = new SqlCommand(updateQuery, con);

                // Pass Control To Query
                com.Parameters.AddWithValue("Degree", ddlDegree.SelectedItem.ToString());
                com.Parameters.AddWithValue("Name_Of_UG", txtUg.Text);
                com.Parameters.AddWithValue("Year_Of_Passing", txtYearPass.Text);

                // ID parameter for update
                com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);

                // Perform update
                com.ExecuteNonQuery();

                Response.Write("<script>alert('Record Updated Successfully')</script>");
            }
            else
            {
                // ID doesn't exist, perform an insert

                string insertQuery = "Insert into Qualification (Id, Degree, Name_Of_UG, Year_Of_Passing) Values(@Id, @Degree, @Name_Of_UG, @Year_Of_Passing)";
                com = new SqlCommand(insertQuery, con);

                // Pass Control To Query
                com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);
                com.Parameters.AddWithValue("Degree", ddlDegree.SelectedItem.ToString());
                com.Parameters.AddWithValue("Name_Of_UG", txtUg.Text);
                com.Parameters.AddWithValue("Year_Of_Passing", txtYearPass.Text);

                int enteredYear = int.Parse(txtYearPass.Text);

                if (enteredYear >= 2012 && enteredYear <= 2016)
                {

                    com.ExecuteNonQuery();
                    Response.Write("<script>alert('Record Updated Successfully')</script>");
                }
                else
                {
                    // Show an alert box for invalid year range
                    Response.Write("<script>alert('Enter a year between 2012 and 2016');</script>");
                }
            }

            // Close the connection
            con.Close();
        }


        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Experience.aspx");
        }
    }
}