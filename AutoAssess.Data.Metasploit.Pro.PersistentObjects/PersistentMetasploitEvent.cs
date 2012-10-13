using System;
using AutoAssess.Data.Metasploit.Pro.BusinessObjects;

namespace AutoAssess.Data.Metasploit.Pro.PersistentObjects
{
	[Serializable]
	public class PersistentMetasploitEvent : MetasploitEvent
	{
		public PersistentMetasploitEvent ()
		{
		}
		
		public PersistentMetasploitEvent(MetasploitEvent evnt)
		{
			this.Info = evnt.Info;
			this.ModuleName = evnt.ModuleName;
			this.ModuleRHOST = evnt.ModuleRHOST;
			this.Name = evnt.Name;
			this.RemoteCreatedAt = evnt.RemoteCreatedAt;
			this.RemoteHostID = evnt.RemoteHostID;
			this.RemoteID = evnt.RemoteID;
			this.RemoteUpdatedAt = evnt.RemoteUpdatedAt;
			this.RemoteWorkspaceID = evnt.RemoteWorkspaceID;
			this.Username = evnt.Username;
		}
		
		public virtual Guid ID { get; set; }
		
		public virtual Guid CreatedBy { get; set; }
		
		public virtual DateTime CreatedOn { get; set; }
		
		public virtual Guid LastModifiedBy { get;set; }
		
		public virtual DateTime LastModifiedOn { get; set; }
		
		public virtual bool IsActive { get; set; }
		
		public virtual void SetCreationInfo(Guid owner)
		{
			DateTime now = DateTime.Now;
			
			this.ID = Guid.NewGuid();
			this.CreatedBy = owner;
			this.CreatedOn = now;
			this.LastModifiedBy = owner;
			this.LastModifiedOn = now;
			this.IsActive = true;
		}
		
		public virtual void SetUpdateInfo(Guid modifier)
		{
			this.LastModifiedBy = modifier;
			this.LastModifiedOn = DateTime.Now;
		}
	}
}

