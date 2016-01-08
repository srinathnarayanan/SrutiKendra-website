<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Mailing.aspx.cs" Inherits="Account_Mailing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>MAILING LIST</h1>
    <br/>
<table>
<tr>
<td >
<h1>    NAME   </h1>
</td>
<td>
<asp:TextBox ID="name" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
</td>
</tr>
<tr>
<td >
<h1>    EMAIL ID</h1>
</td>
<td>
<asp:TextBox ID="email" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Enter a proper email id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        ControlToValidate="email"></asp:RegularExpressionValidator>
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

<h2>upload excel sheet formatted as : id,name,email</h2>
<asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="Button1" runat="server" Text="Upload"
            OnClick="btnUpload_Click2" />
<br />
<br/>
<center>
    <asp:GridView ID="gvImages"  CellPadding="4" runat="server" AutoGenerateColumns="False"
HeaderStyle-BackColor="#7779AF" HeaderStyle-ForeColor="white" AllowPaging="True" 
        ForeColor="#333333"  >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>
<asp:CommandField   ShowSelectButton="true" />
<asp:BoundField HeaderText = "ID" DataField="id" />
<asp:BoundField HeaderText = "NAME" DataField="name" />
<asp:BoundField HeaderText = "EMAIL ID" DataField="email" />
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
</center>    
<table>
<tr>
<td >
<h1>    SUBJECT   </h1>
</td>
<td>
<asp:TextBox ID="subject" runat="server" TextMode="multiline" Columns="50" Rows="3"></asp:TextBox>
</td>
</tr>
<tr>
<td >
<h1>    Enter Bulk Email Message :  </h1>
</td>
<td>
<asp:TextBox ID="message" runat="server" TextMode="multiline" Columns="75" Rows="20"></asp:TextBox>
</td>
</tr>
<tr>
<td>
</td>
<td>
<asp:Button ID="Button2" runat="server" Text="SEND" onclick="btn2_Click" />
</td>
</tr>

</table>
<br/>
</asp:Content>

