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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Cmdlet
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDnsAlias",
        DefaultParameterSetName = SetByNameParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceDnsAliasModel))]
    public class SetAzureSqlManagedInstanceDnsAlias : AzureSqlManagedInstanceDnsAliasCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentObjectParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet, Position = 1, HelpMessage = "Name of the managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Sql Managed Instance DNS Alias
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet, Position = 2, HelpMessage = "Name of the managed instance DNS alias.")]
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the managed instance DNS alias.")]
        [ValidateNotNullOrEmpty]
        [Alias("DnsAliasName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the instance object.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance DNS alias.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceDnsAliasModel InputObject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = SetByResourceIdParameterSet, Position = 0, HelpMessage = "Resource ID of the managed instance DNS alias.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to create dns record.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Parameter which indicates whether the DNS alias should have a DNS record.")]
        public SwitchParameter HasDnsRecord { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> GetEntity()
        {
            return new List<AzureSqlManagedInstanceDnsAliasModel>() { ModelAdapter.GetManagedInstanceDnsAlias(this.ResourceGroupName, this.InstanceName, this.Name) };
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

        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceDnsAliasModel> entity)
        {
            return new List<AzureSqlManagedInstanceDnsAliasModel>() {
                ModelAdapter.UpsertManagedInstanceDnsAlias(entity.First(), HasDnsRecord)
            };
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case SetByNameParameterSet:
                    // default case, we're getting RG, MI and DNS alias names directly from args
                    break;
                case SetByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, DNS alias name received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case SetByInputObjectParameterSet:
                    ResourceGroupName = InputObject.ResourceGroupName;
                    InstanceName = InputObject.ManagedInstanceName;
                    Name = InputObject.DnsAliasName;
                    break;
                case SetByResourceIdParameterSet:
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    Name = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceDnsAliasDescription, ResourceGroupName, InstanceName, Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceDnsAliasWarning, ResourceGroupName, InstanceName, Name),
                Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }
    }
}
