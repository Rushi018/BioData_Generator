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
    public partial class Experience : System.Web.UI.Page
    {
        //Create Object
        SqlConnection con;

        SqlCommand com;

        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
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
            string checkIdQuery = "SELECT COUNT(Id) FROM Experience WHERE Id = @Id";
            com = new SqlCommand(checkIdQuery, con);
            com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);

            int existingRecords = (int)com.ExecuteScalar();

            if (existingRecords > 0)
            {
                // ID already exists, perform an update

                string updateQuery = "UPDATE Experience SET Year_Of_Exp = @Year_Of_Exp, Name_of_company = @Name_of_company, Date_Of_Joining = @Date_Of_Joining, Other_Exp = @Other_Exp WHERE Id = @Id";
                com = new SqlCommand(updateQuery, con);

                // Pass Control To Query
                com.Parameters.AddWithValue("Year_Of_Exp", ddlYOE.SelectedItem.ToString());
                com.Parameters.AddWithValue("Name_of_company", txtCompany.Text);
                com.Parameters.AddWithValue("Date_Of_Joining", txtDOJ.Text);
                com.Parameters.AddWithValue("Other_Exp", txtExperience.Text);

                // ID parameter for update
                com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);

                // Perform update
                com.ExecuteNonQuery();

                Response.Write("<script>alert('Record Updated Successfully')</script>");
            }
            else
            {
                // ID doesn't exist, perform an insert

                string insertQuery = "Insert into Experience (Id, Year_Of_Exp, Name_of_company, Date_Of_Joining, Other_Exp) Values(@Id, @Year_Of_Exp, @Name_of_company, @Date_Of_Joining, @Other_Exp)";
                com = new SqlCommand(insertQuery, con);

                // Pass Control To Query
                com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);
                com.Parameters.AddWithValue("Year_Of_Exp", ddlYOE.SelectedItem.ToString());
                com.Parameters.AddWithValue("Name_of_company", txtCompany.Text);
                com.Parameters.AddWithValue("Date_Of_Joining", txtDOJ.Text);
                com.Parameters.AddWithValue("Other_Exp", txtExperience.Text);

                // Perform insert
                com.ExecuteNonQuery();

                Response.Write("<script>alert('Record Updated Successfully')</script>");
            }

            // Close the connection
            con.Close();
        }


        protected void txtNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("Objective.aspx");
        }
    }
}