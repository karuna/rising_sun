using System;
using System.Web;
using System.Web.UI;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using AutoAssess.Web.Data;
using System.Collections.Generic;
using System.Configuration;
using FluentNHibernate.Cfg;
using System.Net;
using System.Xml;
using System.IO;
using AutoAssess.Data.PersistentObjects;
using NHibernate.Criterion;

namespace AutoAssess.Web.Admin
{
	public partial class CreateScan : System.Web.UI.Page
	{
		
		protected override void OnInit (EventArgs e)
		{
			base.OnInit (e);
			
			string conn = "Server=" + ConfigurationManager.AppSettings ["PostgreSQL"] + ";";
			conn += "Port=" + ConfigurationManager.AppSettings ["PostgreSQLPort"] + ";";
			conn += "Database=autoassess_web;";
			conn += "User Id=" + ConfigurationManager.AppSettings ["PostgreSQLUser"] + ";";
			conn += "Password=" + ConfigurationManager.AppSettings ["PostgreSQLPass"] + ";";
			conn += "SSL=true;";
			
			IPersistenceConfigurer config = PostgreSQLConfiguration.PostgreSQL82
				.ConnectionString (conn);
			
			ISessionFactory factory = Fluently.Configure ()
				.Database (config)
				.Mappings (m =>
						m.FluentMappings.AddFromAssemblyOf<WebUser> ())
				.BuildSessionFactory ();
			
			using (ISession session = factory.OpenSession())
			{
				ddlUser.DataSource = session.CreateCriteria<WebUser>().List<WebUser>();
				ddlUser.DataTextField = "Username";
				ddlUser.DataValueField = "UserID";
				ddlUser.DataBind();
			}
		}
		protected void btnCreateScan_Click(object sender, EventArgs e)
		{
			string profileID = MakeProfile();
			
			
			Dictionary<string, string> parms = new Dictionary<string, string>();
			
			parms.Add("Name", txtScanName.Text);
			parms.Add("ParentProfileID", profileID);
			parms.Add("ScanIsBasicBruteforce", chkBruteforce.Checked.ToString());			
			parms.Add("ScanIsSQLMap", chkSQLMap.Checked.ToString());
			parms.Add("ScanIsDSXS", chkDSXS.Checked.ToString());
			parms.Add("ScanIsOpenVAS", chkOpenVAS.Checked.ToString());
			parms.Add("ScanIsNessus", chkNessus.Checked.ToString());
			parms.Add("ScanIsNexpose", chkNexpose.Checked.ToString());
			parms.Add("ScanIsMetasploit", chkMetasploit.Checked.ToString());
			
			MakeScan(parms);
		}
		
		private void MakeScan(Dictionary<string, string> opts)
		{
			string url = ConfigurationManager.AppSettings["API"] + "/CreateScan.ashx";
			url = url + "?WebUserID=" + ddlUser.SelectedValue;
			url = url + "&UserID=" + ConfigurationManager.AppSettings["UserID"];
			url = url + "&ClientID=" + ConfigurationManager.AppSettings["ClientID"];

			foreach (KeyValuePair<string, string> kv in opts)
				url = url + "&" + kv.Key + "=" + kv.Value;
			
			WebRequest request = WebRequest.Create(url);

			string xml = string.Empty;
			using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))					
					xml = reader.ReadToEnd();

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);
		}

		private string MakeProfile ()
		{
			string url = ConfigurationManager.AppSettings["API"] + "/CreateProfile.ashx" +
				"?WebUserID=" + ddlUser.SelectedValue +
				"&UserID=" + ConfigurationManager.AppSettings["UserID"] + 
				"&ClientID=" + ConfigurationManager.AppSettings["ClientID"] + 
				"&ProfileDomain=" + txtHosts.Text + 
				"&ProfileSchedule=" + "30" + //30 days
				"&ProfileDescription=" + "Created through the admin interface" +  
				"&ProfileName=" + txtProfileName.Text;
			
			WebRequest request = WebRequest.Create(url);
			
			string xml = string.Empty;
			
			using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))					
					xml = reader.ReadToEnd();
			
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);
			
			PersistentProfile profile = new PersistentProfile(doc.FirstChild);
			return profile.ID.ToString();
		}
		
		private void MakeProfileHost(string hostAddress)
		{
			
		}
	}
}

