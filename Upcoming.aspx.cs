using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Upcoming : System.Web.UI.Page
{

    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        byte[] image = new byte[100];
        String title,longdesc,shortdesc;
        String t = "";
        String t1="",t2="",t0="";
        SqlConnection connection = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select title,short,long,image FROM Upcoming";
        cmd.Connection = connection;
        connection.Open();
        SqlDataReader myReader = cmd.ExecuteReader();
        while (myReader.HasRows)
        {
            while (myReader.Read())
            {
                image=(byte[])myReader["image"];
                longdesc = myReader["long"].ToString().Replace(Environment.NewLine,"<br/>");
                shortdesc = myReader["short"].ToString().Replace(Environment.NewLine, "<br/>");
                title = myReader["title"].ToString().Replace(Environment.NewLine, "<br/>");
                t0 = "data:image/png;base64," + Convert.ToBase64String(image);
                t1 = "<image style='float:left;padding: 10px 10px 10px 10px' height='250px' runat='server' src='" + t0 + "' />";
                t2 = "<div style='padding:10px; border: 2px solid;border-radius: 25px;'><center><h1 style='font-size:32px'><b>" + title + "</b></h1><h2 style='font-size:16px'><i>" + shortdesc + "</i></h2></center>" + t1 + "<h2 >" + longdesc + "</h2></div><br/>";
                t += t2+"<br/>";
            }
            myReader.NextResult();
        }
        div1.InnerHtml = t;
       
                
        connection.Close();

    }

    public object linebreak { get; set; }
}