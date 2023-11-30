using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;



namespace pageLogin
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn=new SqlConnection(@"Data Source=DESKTOP-UQPST9J;Initial Catalog=LoginDB;Integrated Security=True"))
            {
                conn.Open();
                string query = "select count(1) from tblUser where UserName=@UserName and Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName",txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password",txtPassword.Text.Trim());
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if(count==1)
                {

                    Session["UserName"] = txtUserName.Text.Trim();
                    Response.Redirect("ogtmen.aspx");
                }




            }
        }
    }
}