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

public partial class Account_Home : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        DataTable taskTable = new DataTable("TaskList");

        // Create the columns.
        taskTable.Columns.Add("title", typeof(string));
        taskTable.Columns.Add("short", typeof(string));
        taskTable.Columns.Add("long", typeof(string));

        Session["TaskTable"] = taskTable;

        //Bind data to the GridView control.
       
        BindGridData();
        //}
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
            string InsertName = name.Text;
            string InsertDesignation = designation.Text;
            string InsertPhone = phone.Text;
            string InsertEmail =email.Text;
            
            //use the web.config to store the connection string
            
            SqlConnection connection = new SqlConnection(strcon);
            
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Contacts (name,designation,phone,email,image) VALUES (@InsertName,@InsertDesignation,@InsertPhone,@InsertEmail,@imagedata)", connection);
            cmd.Parameters.Add("@InsertName", SqlDbType.NVarChar, 50).Value = InsertName;
            cmd.Parameters.Add("@imagedata", SqlDbType.Image).Value = imgbyte;
            cmd.Parameters.Add("@InsertDesignation", SqlDbType.NVarChar, 50).Value = InsertDesignation;
            cmd.Parameters.Add("@InsertPhone", SqlDbType.NVarChar, 50).Value = InsertPhone;
            cmd.Parameters.Add("@InsertEmail", SqlDbType.NVarChar, 50).Value = InsertEmail;
            
            int count = cmd.ExecuteNonQuery();
            connection.Close();
            if (count == 1)
            {
                BindGridData();
                name.Text = string.Empty;
                designation.Text = string.Empty;
                phone.Text = string.Empty;
                email.Text = string.Empty;
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' insertion successfull')", true);
            }
        }
    }
    /// <summary>
    /// function is used to bind gridview
    /// </summary>


    
    private void BindGridData()
    {
        SqlConnection connection = new SqlConnection(strcon);
        SqlCommand command = new SqlCommand("SELECT name,designation,phone,email,image from [Contacts]", connection);
        SqlDataAdapter daimages = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        daimages.Fill(dt);
        
        gvImages.DataSource = dt;
        gvImages.DataBind();
        
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        BindGridData();
        SqlConnection connection = new SqlConnection(strcon);
        String id;
        
        try
        {

            id = gvImages.SelectedRow.Cells[1].Text;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete FROM Contacts where name='" + id + "'";
            cmd.Connection = connection;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            BindGridData();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' deletion successfull')", true);
        }
        catch 
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' select a row for deletion')", true);
        
        }
    }
    
}