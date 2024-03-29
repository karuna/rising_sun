<%@ Page Language="C#" Inherits="AutoAssess.Web.CreateScan" MasterPageFile="~/MasterPage.master" %>
<asp:Content ContentPlaceHolderID="main" runat="server" >
		<fieldset><legend>Profile Information</legend>
			<div class="textboxLabel">Profile Name:</div><asp:TextBox id="txtProfileName" runat="server" ReadOnly="true" /><br />
			<div class="textboxLabel">Profile Range:</div><asp:TextBox id="txtProfileRange" runat="server" ReadOnly="true" />
		</fieldset><br /><br /><br />
		
		<fieldset><legend>Scan Information</legend>
		<div class="textboxLabel">Scan Name:</div><asp:TextBox id="txtScanName" runat="server" /><br />

		<div class="scanPlan" style="background:#fff;">
			<div class="scanPlanHeader">Basic Web Assessment</div>
			<div style="width: 200px; margin-left:auto; margin-right:auto; padding:10px;">
				The following vulnerabilities will be searched for:
				<ul>
					<li>Cross-Site Scripting</li>
					<li>Remote and Local File Include</li>
					<li>SQL Injection</li>
					<li>Information Disclosure</li>
					<li>Direct Object Reference</li>
					<li>Remote Command Execution</li>
				</ul>
			</div>
		<br />
			<div style="width: 230px; text-align: right;">
				<asp:Button id="btnBasicWebAssessment" runat="server" Text="Schedule Assessment" OnClick="btnBasicWebAssessment_Click" />
			</div>
		</div>
		<div class="scanPlan" style="float: right;background:#fff;">
			<div class="scanPlanHeader">Bruteforce</div>
			<div style="width: 200px; margin-left:auto; margin-right:auto; padding:10px;">
				The following vulnerabilities will be searched for:
				<ul>
					<li>Default Usernames/Passwords</li>
				</ul>
			</div>
		    <br />
			<br /><br /><br />
			<br /><br />
		<br />
			<div style="width: 230px; text-align: right;">
				<asp:Button id="btnBruteforce" runat="server" Text="Schedule Assessment" />
			</div>
		</div>
		<div class="scanPlan" style="float: right;background:#fff;">
			<div class="scanPlanHeader">General Profile Assessment</div>
			<div style="width: 200px; margin-left:auto; margin-right:auto; padding:10px;">
				The following vulnerabilities will be searched for:
				<ul>
					<li>Vulnerable Software Versions</li>
					<li>Unpatched services and software</li>
					<li>Common Default Usernames/Passwords</li>
				</ul>
			</div>
			<br /><br />
		<br />
			<div style="width: 230px; text-align: right;">
				<asp:Button id="btnBasicVulnAssessment" runat="server" Text="Schedule Assessment" OnClick="btnBasicVulnAssessment_Click" />
			</div>
		</div>	
		</fieldset>
</asp:Content>