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
        SupportsShouldProcess = true)]
    public class MoveSqlManagedInstanceDnsAlias : AzureSqlManagedInstanceDnsAliasCmdletBase
    {
        // Move by name of the target managed instance dns alias and by different ways for source managed instance dns alias.
        private const string MoveByNamesParameterSet = "MoveByNamesParameterSet";
        private const string MoveByNameAndSourceParentObjectParameterSet = "MoveByNameAndSourceParentObjectParameterSet";
        private const string MoveByNameAndSourceInputObjectParameterSet = "MoveByNameAndSourceInputObjectParameterSet";
        private const string MoveByNameAndSourceResourceIdParameterSet = "MoveByNameAndSourceResourceIdParameterSet";

        // Move by parent object of the target managed instance dns alias and by different ways for source managed instance dns alias.
        private const string MoveByParentObjectAndSourceNameParameterSet = "MoveByParentObjectAndSourceNameParameterSet";
        private const string MoveByParentObjectsParameterSet = "MoveByParentObjectsParameterSet";
        private const string MoveByParentObjectAndSourceInputObjectParameterSet = "MoveByParentObjectAndSourceInputObjectParameterSet";
        private const string MoveByParentObjectAndSourceResourceIdParameterSet = "MoveByParentObjectAndSourceResourceIdParameterSet";

        private const string ManagedInstanceDnsAliasResourceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/managedInstances/{2}/dnsAliases/{3}";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveByNamesParameterSet, Position = 0, HelpMessage = "Name of the target resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceParentObjectParameterSet, Position = 0, HelpMessage = "Name of the target resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceInputObjectParameterSet, Position = 0, HelpMessage = "Name of the target resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceResourceIdParameterSet, Position = 0, HelpMessage = "Name of the target resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveByNamesParameterSet, Position = 1, HelpMessage = "Name of the target managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceParentObjectParameterSet, Position = 1, HelpMessage = "Name of the target managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceInputObjectParameterSet, Position = 1, HelpMessage = "Name of the target managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByNameAndSourceResourceIdParameterSet, Position = 1, HelpMessage = "Name of the target managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByParentObjectAndSourceNameParameterSet, Position = 0, HelpMessage = "Input object of the target managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByParentObjectsParameterSet, Position = 0, HelpMessage = "Input object of the target managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByParentObjectAndSourceInputObjectParameterSet, Position = 0, HelpMessage = "Input object of the target managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = MoveByParentObjectAndSourceResourceIdParameterSet, Position = 0, HelpMessage = "Input object of the target managed instance.")]
        [ValidateNotNullOrEmpty]
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
        /// Gets or sets the name of target managed instance.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveByNamesParameterSet, Position = 3, HelpMessage = "Name of the source managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = MoveByParentObjectAndSourceNameParameterSet, Position = 2, HelpMessage = "Name of the source managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string SourceInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Sql Managed Instance DNS Alias
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = MoveByNamesParameterSet, Position = 4, HelpMessage = "Name of the source DNS alias.")]
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
                ConstructSourceResourceId(SourceResourceGroupName, SourceInstanceName, SourceName, ModelAdapter.Context.Subscription.Id);
            }
            return ModelAdapter.ListManagedInstanceDnsAliases(this.ResourceGroupName, this.InstanceName);
        }
 
        private void ConstructSourceResourceId(string sourceResourceGroupName, string sourceManagedInstanceName, string sourceDnsAliasName, string subscriptionId)
        {
            SourceResourceId = string.Format(
                    ManagedInstanceDnsAliasResourceIdTemplate,
                    subscriptionId,
                    sourceResourceGroupName,
                    sourceManagedInstanceName,
                    sourceDnsAliasName);
        }

        private void ConstructSourceResourceId(AzureSqlManagedInstanceModel sourceInstance, string sourceDnsAliasName, string subscriptionId)
        {
            SourceResourceId = string.Format(
                    ManagedInstanceDnsAliasResourceIdTemplate,
                    subscriptionId,
                    sourceInstance.ResourceGroupName,
                    sourceInstance.ManagedInstanceName,
                    sourceDnsAliasName);
        }

        private void ConstructSourceResourceId(AzureSqlManagedInstanceDnsAliasModel sourceDnsAlias)
        {
            SourceResourceId = sourceDnsAlias.Id;
            SourceName = sourceDnsAlias.DnsAliasName;
        }

        private void ParseParentObjectParameters()
        {
            ResourceGroupName = InstanceObject.ResourceGroupName;
            InstanceName = InstanceObject.ManagedInstanceName;
        }

        private string ExtractSubscriptionIdFromManagedInstanceResourceId(string instanceResourceId)
        {
            var resourceInfo = new ResourceIdentifier(instanceResourceId);
            return resourceInfo.Subscription;
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
                    ParseParentObjectParameters();
                    break;

                // Parameter sets with source name as input.
                case MoveByNamesParameterSet:
                    // At this point of the cmdlet, we still don't have initialized model adapter, so we cannot construct the resource ID of the alias
                    // because we lack subscription ID. Model adapter gets initialized in base.ExecuteCmdlet, so we will construct the resource ID in GetEntity.
                    break;
                case MoveByParentObjectAndSourceNameParameterSet:
                    {
                        ParseParentObjectParameters();
                        string subscriptionId = ExtractSubscriptionIdFromManagedInstanceResourceId(InstanceObject.Id);
                        ConstructSourceResourceId(SourceResourceGroupName, SourceInstanceName, SourceName, subscriptionId);
                        break;
                    }
                // Parameter sets with source parent object as input.
                case MoveByNameAndSourceParentObjectParameterSet:
                    {
                        string subscriptionId = ExtractSubscriptionIdFromManagedInstanceResourceId(SourceInstanceObject.Id);
                        ConstructSourceResourceId(SourceInstanceObject, SourceName, subscriptionId);
                        break;
                    }
                case MoveByParentObjectsParameterSet:
                    {
                        ParseParentObjectParameters();
                        string subscriptionId = ExtractSubscriptionIdFromManagedInstanceResourceId(InstanceObject.Id);
                        ConstructSourceResourceId(SourceInstanceObject, SourceName, subscriptionId);
                        break;
                    }

                // Parameter sets with source input object.
                case MoveByNameAndSourceInputObjectParameterSet:
                    ConstructSourceResourceId(SourceInputObject);
                    break;
                case MoveByParentObjectAndSourceInputObjectParameterSet:
                    ParseParentObjectParameters();
                    ConstructSourceResourceId(SourceInputObject);
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
