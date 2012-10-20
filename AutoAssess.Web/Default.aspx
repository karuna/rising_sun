<%@ Page Language="C#" Inherits="AutoAssess.Web.Default" MasterPageFile="~/MasterPage.master" %>
<asp:Content ID="contentDefault" runat="server" ContentPlaceHolderID="main">
	
	<div class="dashboardItem" style="background:#fff;vertical-align:top;">
		<div class="dashboardItemHeader">At a glance</div>
	</div>
	
	<div class="dashboardItem" style="background:#fff;">	
		<div class="dashboardItemHeader">Past 30 days</div>
		<div id="divEvents" runat="server" />
	</div>
	
	<div class="dashboardItem" style="background:#fff;">	
		<div class="dashboardItemHeader">Next steps</div>
		<p><a href="/ViewProfiles.aspx">Schedule your next scan</a></p>
		<p><a href="/CreateProfile.aspx">Add a new Profile</a></p>
	</div>
	
	<div class="dashboardItem" style="background:#fff;vertical-align:top">	
		<div class="dashboardItemHeader">Calendar</div>
			<br /><br />
	      <asp:Calendar id="calendar1" runat="server" Width="327px" Height="275px" >

           <OtherMonthDayStyle ForeColor="LightGray">
           </OtherMonthDayStyle>

           <DayStyle BackColor="gray">
           </DayStyle>

           <SelectedDayStyle BackColor="LightGray"
                             Font-Bold="True">
           </SelectedDayStyle>

      </asp:Calendar>
	</div>
</asp:Content>

