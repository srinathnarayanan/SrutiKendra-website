using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Books : System.Web.UI.Page
{

    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        byte[] image = new byte[100];
        String name,cost,description;
        String t = "";
        String t1 = "", t2 = "", t0 = "";
        SqlConnection connection = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select name,cost,description,image FROM Book";
        cmd.Connection = connection;
        connection.Open();
        SqlDataReader myReader = cmd.ExecuteReader();
        while (myReader.HasRows)
        {
            while (myReader.Read())
            {
                image = (byte[])myReader["image"];
                name = myReader["name"].ToString().Replace(Environment.NewLine, "<br/>");
                cost = myReader["cost"].ToString().Replace(Environment.NewLine, "<br/>");
                cost = "Rs." + cost;
                description = myReader["description"].ToString().Replace(Environment.NewLine, "<br/>");
                t0 = "data:image/png;base64," + Convert.ToBase64String(image);
                t1 = "<center><image runat='server' src='" + t0 + "' /><h1 style='font-size:32px'>"+cost+"</h1></center>";
                t2 = "<div style='padding:10px; border: 2px solid;border-radius: 25px;'><center><h1 style='font-size:32px'><b>" + name + "</b></h1></center>" + t1 + "<h2 >" + description + "</h2></div><br/>";
                t += t2 + "<br/>";
            }
            myReader.NextResult();
        }
        div1.InnerHtml = t;


        connection.Close();

    }
}

