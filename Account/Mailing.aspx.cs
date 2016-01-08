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
using System.Net.Mail;
using Microsoft.VisualBasic;

public partial class Account_Mailing : System.Web.UI.Page
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
        SqlCommand cmd = new SqlCommand("INSERT INTO Mail (name,email) VALUES (@InsertName,@InsertEmail)", connection);
        cmd.Parameters.Add("@InsertName", SqlDbType.NVarChar, 1000).Value = name.Text;
        cmd.Parameters.Add("@InsertEmail", SqlDbType.NVarChar, 1000).Value = email.Text;

        int count = cmd.ExecuteNonQuery();
        connection.Close();
        if (count == 1)
        {
            BindGridData();
            name.Text = string.Empty;
            email.Text = string.Empty;
        }    
   
    }

    private void BindGridData()
    {
        SqlConnection connection = new SqlConnection(strcon);
        SqlCommand command = new SqlCommand("SELECT id,name,email from [Mail]", connection);
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
            cmd.CommandText = "Delete FROM Mail where id='" + id + "'";
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
    protected void btn2_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            MailAddress fromAddress = new MailAddress("info@srutikendra.com");
            mailMessage.From = fromAddress;

            foreach (GridViewRow row in gvImages.Rows)
            {
                MailAddress to = new MailAddress(row.Cells[3].Text);
                mailMessage.To.Add(to);

            }

            mailMessage.Body = message.Text;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject.Text;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "localhost";
            smtpClient.Send(mailMessage);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' mail sent')", true);
            subject.Text = string.Empty;
            message.Text = string.Empty;
                
        }
         catch (Exception ex)
         {
             ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' mail not sent')", true);            
         }

    }
    protected void btnUpload_Click2(object sender, EventArgs e)
    {

        //Upload and save the file
        string csvPath = Server.MapPath("Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
        FileUpload1.SaveAs(csvPath);

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("id", typeof(int)),
            new DataColumn("name", typeof(string)),
            new DataColumn("email",typeof(string)) });


        string csvData = File.ReadAllText(csvPath);
        foreach (string row in csvData.Split('\n'))
        {
            if (!string.IsNullOrEmpty(row))
            {
                dt.Rows.Add();
                int i = 0;
                foreach (string cell in row.Split(','))
                {
                    dt.Rows[dt.Rows.Count-1][i] = cell;
                    i++;
                }
            }
        }

        SqlConnection connection = new SqlConnection(strcon);

        connection.Open();

        foreach (DataRow row in dt.Rows)
        {
        String newname = row["name"].ToString();
        String newemail = row["email"].ToString();
        SqlCommand cmd = new SqlCommand("INSERT INTO Mail (name,email) VALUES (@InsertName,@InsertEmail)", connection);
        cmd.Parameters.Add("@InsertName", SqlDbType.NVarChar, 1000).Value = newname;
        cmd.Parameters.Add("@InsertEmail", SqlDbType.NVarChar, 1000).Value = newemail;
        int count = cmd.ExecuteNonQuery();
        if (count == 1)
            BindGridData();
        
        }
        
        connection.Close();
            
   

    }

      
}