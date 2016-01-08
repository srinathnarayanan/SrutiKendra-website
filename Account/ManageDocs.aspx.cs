using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;


public partial class Account_ManageDocs : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridviewData();
        }
    }
    // Bind Gridview Data
    private void BindGridviewData()
    {
        using (SqlConnection con = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from FileInformation";
                cmd.Connection = con;
                con.Open();
                gvDetails.DataSource = cmd.ExecuteReader();
                gvDetails.DataBind();
                con.Close();
            }
        }
    }
    // Save files to Folder and files path in database
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(fileUpload1.PostedFile.FileName);
        Stream str = fileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(str);
        Byte[] size = br.ReadBytes((int)str.Length);
        using (SqlConnection con = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "insert into FileInformation(FileName,FileType,FileData) values(@Name,@Type,@Data)";
                cmd.Parameters.AddWithValue("@Name", filename);
                cmd.Parameters.AddWithValue("@Type", "application/word");
                cmd.Parameters.AddWithValue("@Data", size);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                BindGridviewData();
            }
        }
    }
    // This button click event is used to download files from gridview
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        int fileid = Convert.ToInt32(gvDetails.DataKeys[gvrow.RowIndex].Value.ToString());
        string name, type;
        using (SqlConnection con = new SqlConnection(strcon))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select FileName, FileType, FileData from FileInformation where Id=@Id";
                cmd.Parameters.AddWithValue("@id", fileid);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Response.ContentType = dr["FileType"].ToString();
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + dr["FileName"] + "\"");
                    Response.BinaryWrite((byte[])dr["FileData"]);
                    Response.End();
                }
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        BindGridviewData();
        SqlConnection connection = new SqlConnection(strcon);
        String id;

        try
        {

            id = gvDetails.SelectedRow.Cells[1].Text;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete FROM FileInformation where id='" + id + "'";
            cmd.Connection = connection;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            BindGridviewData();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' deletion successfull')", true);
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' select a row for deletion')", true);

        }
    }
}