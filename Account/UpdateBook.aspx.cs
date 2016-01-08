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
            string InsertCost = cost.Text;
            string InsertDescription = description.Text;
            
            //use the web.config to store the connection string
            
            SqlConnection connection = new SqlConnection(strcon);
            
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Book (name,cost,description,image) VALUES (@InsertName,@InsertCost,@InsertDescription,@imagedata)", connection);
            cmd.Parameters.Add("@InsertName", SqlDbType.NVarChar, 50).Value = InsertName;
            cmd.Parameters.Add("@imagedata", SqlDbType.Image).Value = imgbyte;
            cmd.Parameters.Add("@InsertCost", SqlDbType.NVarChar, 50).Value = InsertCost;
            cmd.Parameters.Add("@InsertDescription", SqlDbType.NVarChar, 4000).Value = InsertDescription;

            int count = cmd.ExecuteNonQuery();
            connection.Close();
            if (count == 1)
            {
                BindGridData();
                name.Text = string.Empty;
                cost.Text = string.Empty;
                description.Text = string.Empty;
                
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
        SqlCommand command = new SqlCommand("SELECT name,cost,description,image from [Book]", connection);
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
            cmd.CommandText = "Delete FROM Book where name='" + id + "'";
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