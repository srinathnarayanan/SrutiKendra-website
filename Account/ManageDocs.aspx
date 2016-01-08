<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="ManageDocs.aspx.cs" Inherits="Account_ManageDocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>MANAGE DOCUMENTS</h1>
<center>
<br/>
<asp:FileUpload ID="fileUpload1" runat="server" style="margin-left: 0px" />
    <br />
    <br />
<asp:Button ID="btnUpload" runat="server" Text="Upload" onclick="btnUpload_Click" />
    <br />
<br/>
<asp:GridView  ID="gvDetails" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="Id" CellPadding="4" ForeColor="#333333" GridLines="None" 
        Height="90px" Width="578px">
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
<HeaderStyle BackColor="#5D7B9D" Font-Bold="true" ForeColor="White" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

<Columns>
<asp:CommandField   ShowSelectButton="true" />
<asp:BoundField DataField="Id" HeaderText="Id" />
<asp:BoundField DataField="FileName" HeaderText="FileName" />
<asp:TemplateField HeaderText="FilePath">
<ItemTemplate>
<asp:LinkButton ID="lnkDownload" runat="server" Text="Download" OnClick="lnkDownload_Click"></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>

</Columns>

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
</asp:Content>

