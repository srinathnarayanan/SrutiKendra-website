<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="UpdateBook.aspx.cs" Inherits="Account_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1> UPDATE BOOK AND CD DETAILS</h1>
    

<div>
<table>
<tr>
<td >
<h1>    Title:</h1>
</td>
<td>
<asp:TextBox ID="name" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
</td>
</tr>
<tr>
<td >
    <h1>Cost:</h1>
</td>
<td>
<asp:TextBox ID="cost" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="invalid cost" ControlToValidate="cost" 
        ValidationExpression="^[0-9]{2,5}$"></asp:RegularExpressionValidator>
</td>
</tr>
<tr>
<td >
    <h1>Description:</h1>
</td>
<td>
<asp:TextBox ID="description" runat="server" TextMode="multiline" Columns="80" Rows="8"></asp:TextBox>
</td>
</tr>

<tr>
<td>
   <h1>Upload Image :</h1>:
</td>
<td>
<asp:FileUpload ID="fileuploadImage" runat="server" />
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
    <br />
</div>
<center>
<div style="margin-left: 40px">
    <asp:GridView ID="gvImages"  CellPadding="4" runat="server" AutoGenerateColumns="False"
HeaderStyle-BackColor="#7779AF" HeaderStyle-ForeColor="white" AllowPaging="True" 
        ForeColor="#333333"  >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>
<asp:CommandField   ShowSelectButton="true" />
<asp:BoundField HeaderText = "TITLE" DataField="name" />
<asp:BoundField HeaderText = "COST" DataField="cost" />
<asp:BoundField HeaderText = "DESCRIPTION" DataField="description" />
<asp:TemplateField HeaderText="IMAGE">
<ItemTemplate>
<asp:Image ID="image" runat="server" ImageUrl='<%# "ImageHandler4.ashx?ImID="+ Eval("name") %>' />
</ItemTemplate>
</asp:TemplateField>
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

    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="DELETE" 
        style="height: 26px" />
    <br />
    <br />
    <br />
    
</div>
</center>


    </asp:Content>

