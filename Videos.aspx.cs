using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Videos : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        String desc = "";
        String t = "<h1>CLICK ON THE LINK TO VIEW THE VIDEO :";
        SqlConnection connection = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select id,description FROM Video";
        cmd.Connection = connection;
        connection.Open();
        SqlDataReader myReader = cmd.ExecuteReader();
        while (myReader.HasRows)
        {
            while (myReader.Read())
            {
                desc = myReader["description"].ToString();
                t += "<br/><a href='Videos.aspx?desc=" + desc+ "'>" + desc + "</a>";
            }
            myReader.NextResult();
        }
        t += "</h1>";
        div1.InnerHtml = t;
        connection.Close();
            connection = new SqlConnection(strcon);
            if (Request.QueryString["desc"]!= null)
            {
                String a = Request.QueryString["desc"].ToString();
                cmd.CommandText = "SELECT id,url,description from [Video] where description='" + a + "'";
                cmd.Connection = connection;
                connection.Open();
                myReader = cmd.ExecuteReader();
                myReader.Read();
                String t0 = myReader["url"].ToString();
                YouTube1.VideoUrl = t0;
                connection.Close();
            }
    }

}