using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ajax
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-Q1MH196\SQLEXPRESS;database=sql;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToLocalTime().ToLongTimeString();
            if (!IsPostBack)
            {

                string str = "select name,id from winT1";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownList2.DataSource = ds;
                DropDownList2.DataTextField = "name";
                DropDownList2.DataValueField = "id";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, "-select-");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "select * from winT1 where id=" + DropDownList2.SelectedItem.Value + "";
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        
        
    }
}