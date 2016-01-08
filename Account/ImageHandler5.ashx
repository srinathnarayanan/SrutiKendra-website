<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class ImageHandler : IHttpHandler {
   
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings
                              ["ConnectionString"].ConnectionString;


        // Create SQL Command 
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "Select image from [Album] where id=@id and album=@album";
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = con;
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(context.Request.QueryString["ImID"]);
        cmd.Parameters.Add("@album", SqlDbType.NVarChar, 100).Value = context.Request.QueryString["album"];

        con.Open();
        SqlDataReader dReader = cmd.ExecuteReader();
        dReader.Read();
        context.Response.BinaryWrite((byte[])dReader["image"]);
        dReader.Close();
        con.Close();
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}