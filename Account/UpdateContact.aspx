<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="UpdateContact.aspx.cs" Inherits="Account_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1> UPDATE CONTACTS </h1>
    

<div>
<table>
<tr>
<td >
<h1>    Name:</h1>
</td>
<td>
<asp:TextBox ID="name" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
</td>
</tr>
<tr>
<td >
    <h1>Designation:</h1>
</td>
<td>
<asp:TextBox ID="designation" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
</td>
</tr>
<tr>
<td >
    <h1>Phone number:</h1>
</td>
<td>
<asp:TextBox ID="phone" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="phone" ErrorMessage="invalid phone number" 
        ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
</td>
</tr>
<tr>
<td >
    <h1>Email Id:</h1>
</td>
<td>
<asp:TextBox ID="email" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="email" ErrorMessage="invalid email id" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
<asp:BoundField HeaderText = "NAME" DataField="name" />
<asp:BoundField HeaderText = "DESIGNATION" DataField="designation" />
<asp:BoundField HeaderText = "PHONE NUMBER" DataField="phone" />
<asp:BoundField HeaderText = "EMAIL ID" DataField="email" />
<asp:TemplateField HeaderText="IMAGE">
<ItemTemplate>
<asp:Image ID="image" runat="server" ImageUrl='<%# "ImageHandler3.ashx?ImID="+ Eval("name") %>' />
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

