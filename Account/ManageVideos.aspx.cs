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

public partial class Account_UpdateArchive : System.Web.UI.Page
{

    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGridData();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(strcon);

        connection.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Video (url,description) VALUES (@InsertUrl,@InsertDescription)", connection);
        cmd.Parameters.Add("@InsertUrl", SqlDbType.NVarChar, 1000).Value = url.Text;
        cmd.Parameters.Add("@InsertDescription", SqlDbType.NVarChar, 4000).Value = desc.Text;

        int count = cmd.ExecuteNonQuery();
        connection.Close();
        if (count == 1)
        {
            BindGridData();
            url.Text = string.Empty;
            desc.Text = string.Empty;
        }    
    }


    private void BindGridData()
    {
        SqlConnection connection = new SqlConnection(strcon);
        SqlCommand command = new SqlCommand("SELECT id,url,description from [Video]", connection);
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
            cmd.CommandText = "Delete FROM Video where id='" + id + "'";
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