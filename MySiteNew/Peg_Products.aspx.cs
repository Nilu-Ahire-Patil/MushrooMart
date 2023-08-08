using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MySiteNew
{
    public partial class Peg_Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String mycon = ConfigurationManager.ConnectionStrings["mydatabase"].ConnectionString;
            SqlConnection conn = new SqlConnection(mycon);
            conn.Open();
            string Query = "select image,pro_name,price,id from peg_products where isdelete=0";
            DataTable Dt = new DataTable();
            SqlCommand Cmd = new SqlCommand(Query, conn);
           // Cmd.CommandTimeout = 0;
            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);
            rep_product.DataSource = Dt;
            rep_product.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            string id = btn.CommandArgument;
            Response.Redirect("Peg_Buy.aspx?id=" + id);


            //HttpCookie ProductBuyInfo = new HttpCookie("ProductBuyInfo");
            //ProductBuyInfo["ProName"] = BtnDis.
            //ProductBuyInfo.Expires.Add(new TimeSpan(0, 1, 0));
            //Response.Cookies.Add(ProductBuyInfo);
        }
    }
}