using Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Cmdlet
{
	/// <summary>
	/// Cmdlet to create a new Azure Server Trust Group
	/// </summary>
	[Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServerTrustGroup"), OutputType(typeof(AzureSqlServerTrustGroupModel))]
	public class NewAzureSqlServerTrustGroup : AzureSqlServerTrustGroupCmdletBase
	{
		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 1,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 2,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 3,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public List<String> GroupMembers { get; set; }

		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = false,
			Position = 4,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public List<String> TrustScope { get; set; }

		protected override IEnumerable<AzureSqlServerTrustGroupModel> GetEntity()
		{
			List<AzureSqlServerTrustGroupModel> newEntity = new List<AzureSqlServerTrustGroupModel>();
			newEntity.Add(new AzureSqlServerTrustGroupModel()
			{
				ResourceGroupName = this.ResourceGroupName,
				Location = this.Location,
				Name = this.Name,
				TrustScope = this.TrustScope,
				GroupMembers = this.GroupMembers
			});

			return newEntity;
		}

		protected override IEnumerable<AzureSqlServerTrustGroupModel> PersistChanges(IEnumerable<AzureSqlServerTrustGroupModel> entity)
		{
			return new List<AzureSqlServerTrustGroupModel>()
			{
				ModelAdapter.CreateServerTrustGroup(entity.First())
			};
		}
	}
}
