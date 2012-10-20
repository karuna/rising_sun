<%@ Page Language="C#" Inherits="AutoAssess.Web.CreateProfile"  MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="main" runat="server">

Name: <asp:TextBox id="txtName" runat="server" />
<br />
Range: <asp:TextBox id="txtRange" runat="server" />
<br />	
Desc: <asp:TextBox id="txtDesc" runat="server" />
<br />	
<asp:Button Style="float:right;" id="btnCreateProfile" runat="server" Text="Create and Go To Profile" OnClick="btnCreateProfile_Click" />

</asp:Content>