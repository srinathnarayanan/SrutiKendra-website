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

public partial class Account_ManageAlbums : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        String album = "";
        String t = "<div style='height:100px'><pre><h1>The albums present are : </h1><br/><h2>"; 
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
                t+=album+"<br/>";   
            }
            myReader.NextResult();
        }
        t += "</h2></pre></div>";
        div1.InnerHtml = t;


        connection.Close();

    }


    private void BindGridData(String a)
    {
        SqlConnection connection = new SqlConnection(strcon);
        SqlCommand command = new SqlCommand("SELECT id,tag,image,album from [Album] where album='"+a+"'", connection);
        SqlDataAdapter daimages = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        daimages.Fill(dt);

        gvImages.DataSource = dt;
        gvImages.DataBind();

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //Condition to check if the file uploaded or not
        if (fileuploadImage.HasFile)
        {
            //getting length of uploaded file
            int length = fileuploadImage.PostedFile.ContentLength;
            //create a byte array to store the binary image data
            byte[] imgbyte = new byte[length];
            //store the currently selected file in memeory
            HttpPostedFile img = fileuploadImage.PostedFile;
            //set the binary data
            img.InputStream.Read(imgbyte, 0, length);
            string InsertId = id.Text;
            string InsertTag = tag.Text;
            string InsertAlbum = album.Text;

            //use the web.config to store the connection string

            SqlConnection connection = new SqlConnection(strcon);

            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Album (id,album,image,tag) VALUES (@InsertId,@InsertAlbum,@imagedata,@InsertTag)", connection);
            cmd.Parameters.Add("@InsertId", SqlDbType.Int).Value = Convert.ToInt32(InsertId);
            cmd.Parameters.Add("@imagedata", SqlDbType.Image).Value = imgbyte;
            cmd.Parameters.Add("@InsertTag", SqlDbType.NVarChar, 1000).Value = InsertTag;
            cmd.Parameters.Add("@InsertAlbum", SqlDbType.NVarChar, 100).Value = InsertAlbum;

            int count = cmd.ExecuteNonQuery();
            connection.Close();
            if (count == 1)
            {
                BindGridData(displayalbum.Text);
                id.Text = string.Empty;
                tag.Text = string.Empty;
                album.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' insertion successfull')", true);
            }
        }
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(strcon);
        String id,albumname;

        try
        {

            id = gvImages.SelectedRow.Cells[1].Text;
            albumname = gvImages.SelectedRow.Cells[3].Text;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete FROM Album where id="+Convert.ToInt32(id)+" and album='" + albumname+ "'";
            cmd.Connection = connection;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            BindGridData(displayalbum.Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' deletion successfull')", true);
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' select a row for deletion')", true);

        }
    
    }
    protected void button_Click(object sender, System.EventArgs e)
    {
            BindGridData(displayalbum.Text);
        
    }
}