// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.FailoverGroup.Model;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Database Failover Group
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseFailoverGroup",ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(AzureSqlFailoverGroupModel))]
    public class SetAzureSqlFailoverGroup : AzureSqlFailoverGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the primary Azure SQL Database Server of the Failover Group.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Database Failover Group
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string FailoverGroupName { get; set; }

        /// <summary>
        /// Gets or sets the failover policy without data loss for the Sql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The failover policy of the Azure SQL Database Failover Group.")]
        [ValidateNotNullOrEmpty]
        [PSDefaultValue(Help = "Manual", Value = FailoverPolicy.Manual)]
        public FailoverPolicy FailoverPolicy { get; set; }

        /// <summary>
        /// Gets or sets the grace period with data loss for the Sql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Interval before automatic failover is initiated if an outage occurs on the primary server and failover cannot be completed without data loss.")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(0, int.MaxValue)]
        [PSDefaultValue(Help = "1")]
        public int GracePeriodWithDataLossHours { get; set; }

        /// <summary>
        /// Gets or sets the failover policy for read only endpoint of the Sql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Whether outages on the secondary server should trigger automatic failover of the read-only endpoint. This feature is not yet supported.")]
        [ValidateNotNullOrEmpty]
        public AllowReadOnlyFailoverToPrimary AllowReadOnlyFailoverToPrimary { get; set; }

        /// <summary>
        /// Gets or sets the list of partner servers of the Sql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The list of partner servers in the failover group (empty list for 0 servers).")]
        [ValidateNotNull]
        public List<string> PartnerServerList { get; set; }

        /// <summary>
        /// Gets or sets the read only endpoint target server of the Sql Azure Failover Group.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the target server for the read only endpoint.")]
        [ValidateNotNull]
        public string ReadOnlyEndpointTargetServer { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> GetEntity()
        {
            bool useV2Get = MyInvocation.BoundParameters.ContainsKey("PartnerServerList");
            AzureSqlFailoverGroupModel model = ModelAdapter.GetFailoverGroup(this.ResourceGroupName, this.ServerName, this.FailoverGroupName);

            // For cases when existing failover group is multi-secondary, but no multi-secondary properties change in the Set invocation.
            if (model.PartnerServers != null && model.PartnerServers.Any() && model.PartnerServers.Count > 1)
            {
                useV2Get = true;
                model = ModelAdapter.GetFailoverGroup(this.ResourceGroupName, this.ServerName, this.FailoverGroupName);
            }
            return new List<AzureSqlFailoverGroupModel>() { model };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlFailoverGroupModel> model)
        {
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            List<AzureSqlFailoverGroupModel> newEntity = new List<AzureSqlFailoverGroupModel>();
            AzureSqlFailoverGroupModel newModel = model.First();
            bool isMultiSecondary = (newModel.PartnerServers != null && newModel.PartnerServers.Count > 1) || MyInvocation.BoundParameters.ContainsKey("PartnerServerList");

            FailoverPolicy effectivePolicy = FailoverPolicy;
            if (!MyInvocation.BoundParameters.ContainsKey("FailoverPolicy"))
            {
                // If none was provided, use the existing policy.
                Enum.TryParse(newModel.ReadWriteFailoverPolicy, out effectivePolicy);
            }

            newModel.ReadWriteFailoverPolicy = effectivePolicy.ToString();
            newModel.FailoverWithDataLossGracePeriodHours = ComputeEffectiveGracePeriod(effectivePolicy, originalGracePeriod: newModel.FailoverWithDataLossGracePeriodHours);
            newModel.ReadOnlyFailoverPolicy = MyInvocation.BoundParameters.ContainsKey("AllowReadOnlyFailoverToPrimary") ? AllowReadOnlyFailoverToPrimary.ToString() : newModel.ReadOnlyFailoverPolicy;
            if (MyInvocation.BoundParameters.ContainsKey("PartnerServerList"))
            {
                List<FailoverGroupPartnerServer> serversToAdd = new List<FailoverGroupPartnerServer>();
                foreach (string serverName in PartnerServerList)
                {
                    serversToAdd.Add(new FailoverGroupPartnerServer()
                    {
                        Id = serverName,
                        ReplicationRole = Management.Sql.LegacySdk.Models.ReplicationRole.Secondary
                    });
                }
                newModel.PartnerServers = serversToAdd;
            }

            if (isMultiSecondary)
            {
                newModel.FailoverGroupReadWriteEndpointV2 = new FailoverGroupReadWriteEndpoint(newModel.ReadWriteFailoverPolicy, newModel.FailoverWithDataLossGracePeriodHours);
            }

            if (MyInvocation.BoundParameters.ContainsKey("ReadOnlyEndpointTargetServer"))
            {
                newModel.FailoverGroupReadOnlyEndpointV2 = new FailoverGroupReadOnlyEndpoint(newModel.ReadOnlyFailoverPolicy, ReadOnlyEndpointTargetServer);
            }
            newEntity.Add(newModel);

            return newEntity;
        }

        /// <summary>
        /// Update the Failover Group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> PersistChanges(IEnumerable<AzureSqlFailoverGroupModel> entity)
        {
            AzureSqlFailoverGroupModel model = entity.First();
            bool useV2 = (model.PartnerServers != null && model.PartnerServers.Count > 1) || (MyInvocation.BoundParameters.ContainsKey("PartnerServerList"));
            return new List<AzureSqlFailoverGroupModel>() {
                ModelAdapter.PatchUpdateFailoverGroup(entity.First(), useV2)
            };
        }
    }
}
