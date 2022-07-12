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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Cmdlet
{
    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDnsAlias",
        DefaultParameterSetName = CreateByNameParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceDnsAliasModel))]
    public class NewAzureSqlManagedInstanceDnsAlias: AzureSqlManagedInstanceDnsAliasCmdletBase
    {
        private const string CreateByNameParameterSet = "CreateByNameParameterSet";
        private const string CreateByParentObjectParameterSet = "CreateByParentObjectParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 1, HelpMessage = "Name of the managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the dns alias name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByNameParameterSet, Position = 2, HelpMessage = "Name of the DNS alias.")]
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, Position = 2, HelpMessage = "Name of the DNS alias.")]
        [ValidateNotNullOrEmpty]
        [Alias("DnsAliasName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the instance object.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = CreateByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets whether or not to create dns record.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Create DNS record.")]
        public SwitchParameter CreateDnsRecord { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Check to see if the instance already exists in this resource group.
        /// </summary>
        /// <returns>Null if the instance doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetManagedInstanceDnsAlias(this.ResourceGroupName, this.InstanceName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no instance with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The instance already exists
            throw new PSArgumentException(
                string.Format(Properties.Resources.ManagedInstanceDnsAliasExists, this.Name),
                "Name");
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case CreateByNameParameterSet:
                    // default case, we're getting RG, MI and DNS alias names directly from args
                    break;
                case CreateByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, DNS alias name received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                default:
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.CreateAzureSqlInstanceDnsAliasDescription, ResourceGroupName, InstanceName, Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.CreateAzureSqlInstanceDnsAliasWarning, ResourceGroupName, InstanceName, Name),
                Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }

        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceDnsAliasModel> model)
        {
            List<AzureSqlManagedInstanceDnsAliasModel> newEntity = new List<AzureSqlManagedInstanceDnsAliasModel>
            {
                new AzureSqlManagedInstanceDnsAliasModel()
                {
                    ResourceGroupName = ResourceGroupName,
                    ManagedInstanceName = InstanceName,
                    DnsAliasName = Name
                }
            };
            return newEntity;
        }

        /// <summary>
        /// Create the new DNS alias.
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceDnsAliasModel> entity)
        {
            return new List<AzureSqlManagedInstanceDnsAliasModel>() {
                ModelAdapter.UpsertManagedInstanceDnsAlias(entity.First(), CreateDnsRecord)
            };
        }
    }
}
