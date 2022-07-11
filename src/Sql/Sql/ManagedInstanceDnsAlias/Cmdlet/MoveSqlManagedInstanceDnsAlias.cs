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
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Cmdlet
{
    [Cmdlet(VerbsCommon.Move,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDnsAlias",
        DefaultParameterSetName = MoveByNameAndSourceResourceIdParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceDnsAliasModel))]
    public class MoveSqlManagedInstanceDnsAlias : AzureSqlManagedInstanceDnsAliasCmdletBase
    {
        // Move by name of the destination managed instance dns alias and by different ways for source managed instance dns alias.
        private const string MoveByNamesParameterSet = "MoveByNamesParameterSet";
        private const string MoveByNameAndSourceParentObjectParameterSet = "MoveByNameAndSourceParentObjectParameterSet";
        private const string MoveByNameAndSourceInputObjectParameterSet = "MoveByNameAndSourceInputObjectParameterSet";
        private const string MoveByNameAndSourceResourceIdParameterSet = "MoveByNameAndSourceResourceIdParameterSet";

        // Move by parent object of the destination managed instance dns alias and by different ways for source managed instance dns alias.
        private const string MoveByParentObjectAndSourceNameParameterSet = "MoveByParentObjectAndSourceNameParameterSet";
        private const string MoveByParentObjectsParameterSet = "MoveByParentObjectsParameterSet";
        private const string MoveByParentObjectAndSourceInputObjectParameterSet = "MoveByParentObjectAndSourceInputObjectParameterSet";
        private const string MoveByParentObjectAndSourceResourceIdParameterSet = "MoveByParentObjectAndSourceResourceIdParameterSet";

        private const string ManagedInstanceDnsAliasResourceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/managedInstances/{2}/dnsAliases/{3}";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveByNamesParameterSet, Position = 0, HelpMessage = "Name of the destination resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceParentObjectParameterSet, Position = 0, HelpMessage = "Name of the destination resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceInputObjectParameterSet, Position = 0, HelpMessage = "Name of the destination resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceResourceIdParameterSet, Position = 0, HelpMessage = "Name of the destination resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias("DestResourceGroupName")]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of destination managed instance.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveByNamesParameterSet, Position = 1, HelpMessage = "Name of the destination managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceParentObjectParameterSet, Position = 1, HelpMessage = "Name of the destination managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceInputObjectParameterSet, Position = 1, HelpMessage = "Name of the destination managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceResourceIdParameterSet, Position = 1, HelpMessage = "Name of the destination managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("DestInstanceName")]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByParentObjectAndSourceNameParameterSet, Position = 0, HelpMessage = "Input object of the destination managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByParentObjectsParameterSet, Position = 0, HelpMessage = "Input object of the destination managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByParentObjectAndSourceInputObjectParameterSet, Position = 0, HelpMessage = "Input object of the destination managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByParentObjectAndSourceResourceIdParameterSet, Position = 0, HelpMessage = "Input object of the destination managed instance.")]
        [ValidateNotNullOrEmpty]
        [Alias("DestInstanceObject")]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveByNamesParameterSet, Position = 2, HelpMessage = "Name of the source resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByParentObjectAndSourceNameParameterSet, Position = 1, HelpMessage = "Name of the source resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string SourceResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of destination managed instance.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveByNamesParameterSet, Position = 3, HelpMessage = "Name of the source managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByParentObjectAndSourceNameParameterSet, Position = 2, HelpMessage = "Name of the source managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string SourceInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Sql Managed Instance DNS Alias
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveByNamesParameterSet, HelpMessage = "Name of the source DNS alias.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByParentObjectAndSourceNameParameterSet, Position = 3, HelpMessage = "Name of the source DNS alias.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceParentObjectParameterSet, Position = 3, HelpMessage = "Name of the source DNS alias.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByParentObjectsParameterSet, Position = 2, HelpMessage = "Name of the source DNS alias.")]
        [Alias("SourceDnsAliasName")]
        [ValidateNotNullOrEmpty]
        public string SourceName { get; set; }


        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByNameAndSourceParentObjectParameterSet, Position = 2, HelpMessage = "Input object of the source managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MoveByParentObjectsParameterSet, Position = 1, HelpMessage = "Input object of the source managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel SourceInstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the instance dns alias object.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByNameAndSourceInputObjectParameterSet, Position = 2, HelpMessage = "Input object of the source managed instance DNS alias.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MoveByParentObjectAndSourceInputObjectParameterSet, Position = 1, HelpMessage = "Input object of the source managed instance DNS alias.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceDnsAliasModel SourceInputObject { get; set; }

        /// <summary>
        /// Gets or sets the instance dns alias resource id
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByNameAndSourceResourceIdParameterSet, Position = 2, HelpMessage = "Resource ID of the source managed instance DNS alias.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = MoveByParentObjectAndSourceResourceIdParameterSet, Position = 1, HelpMessage = "Resource ID of the source managed instance DNS alias.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public string SourceResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> GetEntity()
        {
            // Since we didn't construct source DNS alias resource Id, for this parameter set, in the ExecuteCmdlet method,
            // we can do it now, since ModelAdapter is initialized at this point (it was initialized after entering the base.ExecuteCmdlet method).
            if(ParameterSetName == MoveByNamesParameterSet)
            {
                string sourceResourceId = ConstructSourceDnsAliasResourceId(SourceResourceGroupName, SourceInstanceName, SourceName, ModelAdapter.Context.Subscription.Id);
                SourceResourceId = sourceResourceId;
            }
            return ModelAdapter.ListManagedInstanceDnsAliases(this.ResourceGroupName, this.InstanceName);
        }
 
        private string ConstructSourceDnsAliasResourceId(string sourceResourceGroupName, string sourceManagedInstanceName, string sourceDnsAliasName, string subscriptionId)
        {
            return string.Format(
                    ManagedInstanceDnsAliasResourceIdTemplate,
                    subscriptionId,
                    sourceResourceGroupName,
                    sourceManagedInstanceName,
                    sourceDnsAliasName);
        }

        private string ConstructSourceDnsAliasResourceId(AzureSqlManagedInstanceModel sourceInstance, string sourceDnsAliasName, string subscriptionId)
        {
            return string.Format(
                    ManagedInstanceDnsAliasResourceIdTemplate,
                    subscriptionId,
                    sourceInstance.ResourceGroupName,
                    sourceInstance.ManagedInstanceName,
                    sourceDnsAliasName);
        }

        /// <summary>
        /// Apply user input to model - nothing to do
        /// </summary>
        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceDnsAliasModel> model)
        {
            return model;
        }

        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceDnsAliasModel> entity)
        {
            return new List<AzureSqlManagedInstanceDnsAliasModel>() {
                ModelAdapter.AcquireManagedInstanceDnsAlias(ResourceGroupName, InstanceName, SourceName, new ManagedServerDnsAliasAcquisition(SourceResourceId))
            };
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                // Parameter sets with source resource id as input.
                case MoveByNameAndSourceResourceIdParameterSet:
                    SourceName = SourceResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    break;
                case MoveByParentObjectAndSourceResourceIdParameterSet:
                    SourceName = SourceResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;

                // Parameter sets with source name as input.
                case MoveByNamesParameterSet:
                    // At this point of the cmdlet, we still don't have initialized model adapter, so we cannot construct the resource ID of the alias
                    // because we lack subscription ID. Model adapter gets initialized in base.ExecuteCmdlet, so we will construct the resource ID in GetEntity.
                    break;
                case MoveByParentObjectAndSourceNameParameterSet:
                    {
                        ResourceGroupName = InstanceObject.ResourceGroupName;
                        InstanceName = InstanceObject.ManagedInstanceName;
                        var resourceInfo = new ResourceIdentifier(InstanceObject.Id);
                        string subscriptionId = resourceInfo.Subscription;
                        string sourceResourceId = ConstructSourceDnsAliasResourceId(SourceResourceGroupName, SourceInstanceName, SourceName, subscriptionId);
                        SourceResourceId = sourceResourceId;
                        break;
                    }
                // Parameter sets with source parent object as input.
                case MoveByNameAndSourceParentObjectParameterSet:
                    {
                        var resourceInfo = new ResourceIdentifier(SourceInstanceObject.Id);
                        string subscriptionId = resourceInfo.Subscription;
                        string sourceResourceId = ConstructSourceDnsAliasResourceId(SourceInstanceObject, SourceName, subscriptionId);
                        SourceResourceId = sourceResourceId;
                        break;
                    }
                case MoveByParentObjectsParameterSet:
                    {
                        ResourceGroupName = InstanceObject.ResourceGroupName;
                        InstanceName = InstanceObject.ManagedInstanceName;
                        var resourceInfo = new ResourceIdentifier(InstanceObject.Id);
                        string subscriptionId = resourceInfo.Subscription;
                        string sourceResourceId = ConstructSourceDnsAliasResourceId(SourceInstanceObject, SourceName, subscriptionId);
                        SourceResourceId = sourceResourceId;
                        break;
                    }

                // Parameter sets with source input object.
                case MoveByNameAndSourceInputObjectParameterSet:
                    SourceResourceId = SourceInputObject.Id;
                    SourceName = SourceInputObject.DnsAliasName;
                    break;
                case MoveByParentObjectAndSourceInputObjectParameterSet:
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    SourceResourceId = SourceInputObject.Id;
                    SourceName = SourceInputObject.DnsAliasName;
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.MoveAzureSqlInstanceDnsAliasDescription, SourceName, SourceInstanceName, SourceResourceGroupName, InstanceName, ResourceGroupName),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.MoveAzureSqlInstanceDnsAliasWarning, SourceName, SourceInstanceName, SourceResourceGroupName, InstanceName, ResourceGroupName),
                Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }
    }
}
