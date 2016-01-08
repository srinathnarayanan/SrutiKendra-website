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

public partial class Albums : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        String album = "";
        String t = "<div style='height:100px'><h1>CLICK ON THE LINK TO VIEW THE ALBUM ";
        SqlConnection connection = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select distinct album FROM Album";
        cmd.Connection = connection;
        connection.Open();
        SqlDataReader myReader = cmd.ExecuteReader();
        while (myReader.HasRows)
        {
            while (myReader.Read())
            {
                album = myReader["album"].ToString();
                t +="<br/><a href='ALbums.aspx?album="+album+"'>"+ album +"</a>";
            }
            myReader.NextResult();
        }
        t += "</h1></div>";
        div1.InnerHtml = t;
        connection.Close();
        connection = new SqlConnection(strcon);
        connection.Open();
        String a=Request.QueryString["album"];
        SqlCommand command = new SqlCommand("SELECT id,album,image,tag from [Album] where album='"+a+"'", connection);
        SqlDataAdapter daimages = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        daimages.Fill(dt);

        ListView1.DataSource = dt;
        ListView1.DataBind();
        div2.InnerHtml = "<center><h1 style='font-size:40px'>" + a + "</center></h1>";
        
        connection.Close();

    }
}