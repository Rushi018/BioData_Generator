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
    public partial class Resume : System.Web.UI.Page
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

                // Steps For Coding

                // Step1: Open DataBase

                string path = ConfigurationManager.AppSettings["Mydb"];
                con = new SqlConnection(path);
                con.Open();

                // Step2: Retrieve data from Details table

                string detailsQuery = "SELECT * FROM Details WHERE Id = @Id";
                com = new SqlCommand(detailsQuery, con);
                com.Parameters.AddWithValue("Id", lblId.Text);
                dr = com.ExecuteReader();

                if (dr.Read())
                {
                    // Display data from the Details table
                    Image1.ImageUrl = "~/Upload/" + dr["Image"].ToString();
                    lblName.Text = dr["Name"].ToString();
                    lblEmail.Text = dr["Email"].ToString();
                    lblMobile.Text = dr["Mobile"].ToString();
                    lblCity.Text = dr["City"].ToString();
                    lblAddress.Text = dr["Address"].ToString();
                    lblPin.Text = dr["Pincode"].ToString();
                    
                }

                dr.Close();

                // Step3: Retrieve data from Qualification table

                string qualificationQuery = "SELECT * FROM Qualification WHERE Id = @Id";
                com = new SqlCommand(qualificationQuery, con);
                com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);
                dr = com.ExecuteReader();

                if (dr.Read())
                {
                    // Display data from the Qualification table
                    lblDegree.Text = dr["Degree"].ToString();
                    lblNUG.Text = dr["Name_Of_UG"].ToString();
                    lblYOP.Text = dr["Year_Of_Passing"].ToString();
                }

                dr.Close();

                // Step4: Retrieve data from Experience table

                string experienceQuery = "SELECT * FROM Experience WHERE Id = @Id";
                com = new SqlCommand(experienceQuery, con);
                com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);
                dr = com.ExecuteReader();

                if (dr.Read())
                {
                    // Display data from the Experience table
                    lblYOE.Text = dr["Year_Of_Exp"].ToString();
                    lblNOC.Text = dr["Name_of_company"].ToString();
                    lblDOJ.Text = dr["Date_Of_Joining"].ToString();
                    lblOE.Text = dr["Other_Exp"].ToString();
                    
                }

                dr.Close();

                // Step5: Retrieve data from Objective table

                string objectiveQuery = "SELECT * FROM Objective WHERE Id = @Id";
                com = new SqlCommand(objectiveQuery, con);
                com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);
                dr = com.ExecuteReader();

                if (dr.Read())
                {
                    // Display data from the Objective table
                    lblObjective.Text = dr["Your_objective"].ToString();
                }

                dr.Close();

                // Close the connection
                con.Close();
            }
        }
    }
}