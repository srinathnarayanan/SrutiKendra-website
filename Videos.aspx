<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Videos.aspx.cs" Inherits="Videos" %>
<%@ Register TagPrefix="ByteBlocks" Assembly="ByteBlocks.YouTubeWeb" Namespace="ByteBlocks.Web.Control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<h1>VIDEOS</h1>
<br/>

<div style="float:left" id='div1' runat="server">
</div>
<center>
<ByteBlocks:YouTube ID="YouTube1" runat='server' Width='480' Height='385' VideoUrl='https://www.youtube.com/watch?v=GFJYoKwC7JQ'/>
</center>
</asp:Content>
