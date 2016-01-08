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
        cmd.CommandText = "Select image from Recent" +
                          " where title =@title";
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.Connection = con;

        SqlParameter ImageID = new SqlParameter
                            ("@title", System.Data.SqlDbType.NVarChar);
        ImageID.Value = context.Request.QueryString["ImID"];
        cmd.Parameters.Add(ImageID);
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