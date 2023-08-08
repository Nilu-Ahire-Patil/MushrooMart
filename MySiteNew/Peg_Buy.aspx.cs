using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MySiteNew
{
    public partial class Peg_Buy : System.Web.UI.Page
    {
        public static string select_price;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Pro_id = "1"; // Request.QueryString["id"];

            String mycon = ConfigurationManager.ConnectionStrings["mydatabase"].ConnectionString;
            SqlConnection conn = new SqlConnection(mycon);
            conn.Open();
            if (!string.IsNullOrWhiteSpace(Pro_id))
            {
                string Query = "select image,pro_name,price,id from peg_products where id='" + Pro_id + "'";
                DataTable Dt = new DataTable();
                SqlCommand Cmd = new SqlCommand(Query, conn);
                Cmd.CommandTimeout = 0;
                SqlDataAdapter Da = new SqlDataAdapter(Cmd);
                Da.Fill(Dt);
                rep_buy_pro.DataSource = Dt;
                rep_buy_pro.DataBind();

                string Offer_quiry = "select off_volume,off_price,off_id from peg_offer where pro_id='" + Pro_id + "'";
                DataTable dt1 = new DataTable();
                SqlCommand cmd1 = new SqlCommand(Offer_quiry, conn);
                cmd1.CommandTimeout = 0;
                SqlDataAdapter Da1 = new SqlDataAdapter(cmd1);
                Da1.Fill(dt1);
                rep_offer.DataSource = dt1;
                rep_offer.DataBind();
            }
            
        }

        protected void OfferSelect_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            select_price = btn.CommandArgument;
            txt_amount.Text = select_price.ToString();
            txt_amount.Focus();
        }

        
    }
}