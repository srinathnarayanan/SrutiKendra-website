using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Contact : System.Web.UI.Page
{

    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        byte[] image = new byte[100];
        String name, designation,phone,email;
        String t = "";
        String t1 = "", t2 = "", t0 = "";
        SqlConnection connection = new SqlConnection(strcon);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select name,designation,phone,email,image FROM Contacts";
        cmd.Connection = connection;
        connection.Open();
        SqlDataReader myReader = cmd.ExecuteReader();
        while (myReader.HasRows)
        {
            while (myReader.Read())
            {
                image = (byte[])myReader["image"];
                name = myReader["name"].ToString().Replace(Environment.NewLine, "<br/>");
                designation = myReader["designation"].ToString().Replace(Environment.NewLine, "<br/>");
                phone = myReader["phone"].ToString().Replace(Environment.NewLine, "<br/>");
                email = myReader["email"].ToString().Replace(Environment.NewLine, "<br/>");
                t0 = "data:image/png;base64," + Convert.ToBase64String(image);
                t1 = "<center><image style='float:right;padding:10px 10px 10px 10px' height=180px width=150px runat='server' src='" + t0 + "' /></center>";
                t2 = t1+ "<div style='padding:10px; border: 2px solid;border-radius: 25px;'><h1 style='font-size:32px'><b>" + name + "</b><br/></h1><p style='font-size:20px'>" + designation + "<br/>PHONE :" + phone + "<br/>EMAIL :" + email + "</p></div><br/>";
                t += t2 + "<br/>";
            }
            myReader.NextResult();
        }
        div1.InnerHtml = t;


        connection.Close();

    }
}

