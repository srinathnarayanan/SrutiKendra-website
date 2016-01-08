<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Albums.aspx.cs" Inherits="Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js">
</script>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        ShowImagePreview();
    });
    // Configuration of the x and y offsets
    function ShowImagePreview() {
        xOffset = -20;
        yOffset = 40;

        $("a.preview").hover(function (e) {
            this.t = this.title;
            this.title = "";
            var c = (this.t != "") ? "<br/>" + this.t : "";
            $("body").append("<p id='preview'><img src='" + this.href + "' alt='Image preview' />" + c + "</p>");
            $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px")
.fadeIn("slow");
        },

function () {
    this.title = this.t;
    $("#preview").remove();
});

        $("a.preview").mousemove(function (e) {
            $("#preview")
.css("top", (e.pageY - xOffset) + "px")
.css("left", (e.pageX + yOffset) + "px");
        });
    };

</script>
<style type="text/css">
#preview{
position:absolute;
border:3px solid #ccc;
background:#333;
padding:5px;
display:none;
color:#fff;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>ALBUMS</h1>
<br/>    
<div id="div1" runat="server"></div>
<div id="div2" runat="server"></div>
<br/>
<asp:ListView ID="ListView1" GroupItemCount="3" runat="server" 
       >
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="groupPlaceholderContainer" runat="server" border="0" style="">
                            <tr ID="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                    ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                    ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <GroupTemplate>
            <tr ID="itemPlaceholderContainer" runat="server">
                <td ID="itemPlaceholder" runat="server">
                </td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td runat="server" style="">
            <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("Name") %>' NavigateUrl='<%# "ImageHandler6.ashx?ImID=" + Eval("id")+"&album="+Eval("album") %>' runat="server">
        <asp:Image
            id="picAlbum" runat="server" Width='300px'
            ImageUrl='<%# "ImageHandler6.ashx?ImID=" + Eval("id")+"&album="+Eval("album") %>' />        
</asp:HyperLink>
                <br />
            <h1><center><%# Eval("tag") %></center></h1>    
                <br />
            </td>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <td runat="server" style="">
        <asp:HyperLink ID="HyperLink1" class="preview" ToolTip='<%#Bind("Name") %>' NavigateUrl='<%# "ImageHandler6.ashx?ImID=" + Eval("id")+"&album="+Eval("album") %>' runat="server">
        <asp:Image
            id="picAlbum" runat="server" Width='300px' 
            ImageUrl='<%# "ImageHandler6.ashx?ImID=" + Eval("id")+"&album="+Eval("album") %>' />        
 </asp:HyperLink>
                <br />
            <h1><center><%# Eval("tag") %></center></h1>    
                <br />
            </td>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>
                      </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>           
           
            <td runat="server" />
           
        </EmptyItemTemplate>
        
    </asp:ListView>
</asp:Content>

