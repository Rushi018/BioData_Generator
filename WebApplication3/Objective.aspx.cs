﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication3
{
    public partial class Objective : System.Web.UI.Page
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
            string checkIdQuery = "SELECT COUNT(Id) FROM Objective WHERE Id = @Id";
            com = new SqlCommand(checkIdQuery, con);
            com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);

            int existingRecords = (int)com.ExecuteScalar();

            if (existingRecords > 0)
            {
                // ID already exists, perform an update

                string updateQuery = "UPDATE Objective SET Your_objective = @Your_objective WHERE Id = @Id";
                com = new SqlCommand(updateQuery, con);

                // Pass Control To Query
                com.Parameters.AddWithValue("Your_objective", txtObj.Text);

                // ID parameter for update
                com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);

                // Perform update
                com.ExecuteNonQuery();

                Response.Write("<script>alert('Record Updated Successfully')</script>");
            }
            else
            {
                // ID doesn't exist, perform an insert

                string insertQuery = "Insert into Objective (Id, Your_objective) Values(@Id, @Your_objective)";
                com = new SqlCommand(insertQuery, con);

                // Pass Control To Query
                com.Parameters.AddWithValue("Id", (string)Session["GeneratedId"]);
                com.Parameters.AddWithValue("Your_objective", txtObj.Text);

                // Perform insert
                com.ExecuteNonQuery();

                Response.Write("<script>alert('Record Updated Successfully')</script>");
            }

            // Close the connection
            con.Close();
        }


        protected void btnResume_Click(object sender, EventArgs e)
        {
            Response.Redirect("Resume.aspx");
        }
    }
}