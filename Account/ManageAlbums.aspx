<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ManageAlbums.aspx.cs" Inherits="Account_ManageAlbums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>MANAGE ALBUMS</h1>
    <br/>

    
<div>
<table>
<tr>
<td >
<h1>    Album Name:</h1>
</td>
<td>
<asp:TextBox ID="album" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
</td>
</tr>
<tr>
<td >
<h1>    Id:</h1>
</td>
<td>
<asp:TextBox ID="id" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Enter a proper number" ValidationExpression="^[0-9]{0,4}$" 
        ControlToValidate="id"></asp:RegularExpressionValidator>
</td>
</tr>


<tr>
<td >
    <h1>Tag:</h1>
</td>
<td>
<asp:TextBox ID="tag" runat="server" TextMode="multiline" Columns="50" Rows="5"></asp:TextBox>
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


<table>
<tr>
<td >
    <h1>Enter name of the album to be viewed :</h1>
</td>
<td>
<asp:TextBox ID="displayalbum" runat="server" TextMode="multiline" Columns="50" Rows="1"></asp:TextBox>
</td>
</tr>
<tr>
<td>
</td>
<td>
<asp:Button ID="button" runat="server" Text="VIEW" onclick="button_Click"  />
</td>
</tr>

</table>
<center>
<br/>   
   <asp:GridView ID="gvImages"  CellPadding="4" runat="server" AutoGenerateColumns="False"
HeaderStyle-BackColor="#7779AF" HeaderStyle-ForeColor="white" AllowPaging="True" 
        ForeColor="#333333"  >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>
<asp:CommandField   ShowSelectButton="true" />
<asp:BoundField HeaderText = "ID" DataField="id" />
<asp:BoundField HeaderText = "TAG" DataField="tag" />
<asp:BoundField HeaderText = "ALBUM" DataField="album" />
<asp:TemplateField HeaderText="IMAGE">
<ItemTemplate>
<asp:Image ID="image" runat="server" Width="300px" ImageUrl='<%# "ImageHandler5.ashx?ImID="+ Eval("id")+"&album="+Eval("album") %>' />
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
<br/>
   <div id="div1" style="height:100px"  runat="server" class="main">
   </div>
   <br/>
    

    </center>
</asp:Content>

