using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Xml;
using AutoAssess.Data.PersistentObjects;
using NHibernate;
using System.Text.RegularExpressions;
using AutoAssess.Data.BusinessObjects;
using System.Net.Mail;

namespace AutoAssess.Web
{
	public partial class CreateProfile : AutoAssessPage
	{	
		protected void btnCreateProfile_Click(object sender, EventArgs e)
		{
			string url = ConfigurationManager.AppSettings["API"] + "/CreateProfile.ashx" +
				"?WebUserID=" + this.CurrentUser.ID.ToString() +
				"&UserID=" + ConfigurationManager.AppSettings["UserID"] + 
				"&ClientID=" + ConfigurationManager.AppSettings["ClientID"] + 
				"&ProfileRange=" + txtRange.Text + 
				"&ProfileSchedule=" + "30" +
				"&ProfileDescription=" + txtDesc.Text +  
				"&ProfileName=" + txtName.Text;
			
			WebRequest request = WebRequest.Create(url);
			
			string xml = string.Empty;
			
			using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream()))					
					xml = reader.ReadToEnd();
			
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);
			
			PersistentProfile profile = new PersistentProfile(doc.FirstChild);
			
			this.CurrentProfile = profile;
			
			Response.Redirect("/ViewProfile.aspx?pid=" + profile.ID.ToString());
		}
	}
}