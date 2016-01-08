<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ManageVideos.aspx.cs" Inherits="Account_UpdateArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>MANAGE VIDEOS</h1>
<br/>
<table>
<tr>
<td >
<h1>    DESCRIPTION:</h1>
</td>
<td>
<asp:TextBox ID="desc" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
</td>
</tr>
<tr>
<td >
<h1>    URL:</h1>
</td>
<td>
<asp:TextBox ID="url" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
 </td>
</tr>
<tr>
<td>
</td>
<td>
<asp:Button ID="btnUpload" runat="server" Text="Upload" onclick="btnUpload_Click" />
</td>
</tr>

</table>
<br/> 
<center>
    <asp:GridView ID="gvImages"  CellPadding="4" runat="server" AutoGenerateColumns="False"
HeaderStyle-BackColor="#7779AF" HeaderStyle-ForeColor="white" AllowPaging="True" 
        ForeColor="#333333"  >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>
<asp:CommandField   ShowSelectButton="true" />
<asp:BoundField HeaderText = "ID" DataField="id" />
<asp:BoundField HeaderText = "URL" DataField="url" />
<asp:BoundField HeaderText = "DESCRIPTION" DataField="description" />
</Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

<HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
    <br />

    <asp:Button ID="Button3" runat="server" Text="DELETE" 
        style="height: 26px" onclick="Button3_Click" />
    <br />
    <br />
    <center>
    <br />
   </asp:Content>

