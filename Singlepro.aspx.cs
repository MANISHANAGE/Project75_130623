using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project75_130623
{
    public partial class Singlepro : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection("Data Source=LAPTOP-8E1LD448\\SQLEXPRESS;initial catalog=db75_130623;integrated security=true");
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-8E1LD448\\SQLEXPRESS;initial catalog=db75_130623_2026feb;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Show();
        }
        public void Show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Empsinglepro", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "select");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            Gvemp.DataSource = dt;
            Gvemp.DataBind();
        }
        public void Clear()
        {
            txtname.Text = "";
            txtcity.Text = "";
            txtage.Text = "";
            txtsal.Text = "";
            btnsave.Text = "Save";
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Empsinglepro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action","insert");
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@City", txtcity.Text);
                cmd.Parameters.AddWithValue("@Salary", txtsal.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Show();
                Clear();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Empsinglepro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action","update");
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@City", txtcity.Text);
                cmd.Parameters.AddWithValue("@Salary", txtsal.Text);
                cmd.Parameters.AddWithValue("@id", ViewState["pp"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Show();
                Clear();
            }
        }

        protected void Gvemp_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Empsinglepro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action","delete");
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Show();
            }
            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Empsinglepro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action","edit");
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["Name"].ToString();
                txtage.Text = dt.Rows[0]["Age"].ToString();
                txtcity.Text = dt.Rows[0]["City"].ToString();
                txtsal.Text = dt.Rows[0]["Salary"].ToString();
                btnsave.Text = "Update";
                ViewState["pp"] = e.CommandArgument;


            }
        }


    }
}