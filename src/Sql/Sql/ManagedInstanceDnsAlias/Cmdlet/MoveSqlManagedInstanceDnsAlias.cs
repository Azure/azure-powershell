using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model;
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
        DefaultParameterSetName = AcquireByNameAndSourceResourceIdParameterSet,
        SupportsShouldProcess = true)]
    public class MoveSqlManagedInstanceDnsAlias : AzureSqlManagedInstanceDnsAliasCmdletBase
    {
        // Acquire by name of the target managed instance dns alias and by different ways for source managed instance dns alias.
        private const string AcquireByNamesParameterSet = "AcquireByNamesParameterSet";
        private const string AcquireByNameAndSourceParentObjectParameterSet = "AcquireByNameAndSourceParentObjectParameterSet";
        private const string AcquireByNameAndSourceInputObjectParameterSet = "AcquireByNameAndSourceInputObjectParameterSet";
        private const string AcquireByNameAndSourceResourceIdParameterSet = "AcquireByNameAndSourceResourceIdParameterSet";

        // Acquire by parent object of the target managed instance dns alias and by different ways for source managed instance dns alias.
        private const string AcquireByParentObjectAndSourceNameParameterSet = "AcquireByParentObjectAndSourceNameParameterSet";
        private const string AcquireByParentObjectsParameterSet = "AcquireByParentObjectsParameterSet";
        private const string AcquireByParentObjectAndSourceInputObjectParameterSet = "AcquireByParentObjectAndSourceInputObjectParameterSet";
        private const string AcquireByParentObjectAndSourceResourceIdParameterSet = "AcquireByParentObjectAndSourceResourceIdParameterSet";

        private const string ManagedInstanceDnsAliasResourceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/managedInstances/{2}/dnsAliases/{3}";

        // <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNamesParameterSet, Position = 0, HelpMessage = "Name of the target resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNameAndSourceParentObjectParameterSet, Position = 0, HelpMessage = "Name of the target resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNameAndSourceInputObjectParameterSet, Position = 0, HelpMessage = "Name of the target resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNameAndSourceResourceIdParameterSet, Position = 0, HelpMessage = "Name of the target resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNamesParameterSet, Position = 1, HelpMessage = "Name of the target managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNameAndSourceParentObjectParameterSet, Position = 1, HelpMessage = "Name of the target managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNameAndSourceInputObjectParameterSet, Position = 1, HelpMessage = "Name of the target managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNameAndSourceResourceIdParameterSet, Position = 1, HelpMessage = "Name of the target managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AcquireByParentObjectAndSourceNameParameterSet, Position = 0, HelpMessage = "Input object of the target managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AcquireByParentObjectsParameterSet, Position = 0, HelpMessage = "Input object of the target managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AcquireByParentObjectAndSourceInputObjectParameterSet, Position = 0, HelpMessage = "Input object of the target managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AcquireByParentObjectAndSourceResourceIdParameterSet, Position = 0, HelpMessage = "Input object of the target managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        // <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNamesParameterSet, Position = 3, HelpMessage = "Name of the source resource group.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByParentObjectAndSourceNameParameterSet, Position = 2, HelpMessage = "Name of the source resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string SourceResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of target managed instance.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNamesParameterSet, Position = 4, HelpMessage = "Name of the source managed instance.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByParentObjectAndSourceNameParameterSet, Position = 3, HelpMessage = "Name of the source managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string SourceInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Sql Managed Instance DNS Alias
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNamesParameterSet, Position = 5, HelpMessage = "Name of the source DNS alias.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByParentObjectAndSourceNameParameterSet, Position = 4, HelpMessage = "Name of the source DNS alias.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByNameAndSourceParentObjectParameterSet, Position = 4, HelpMessage = "Name of the source DNS alias.")]
        [Parameter(Mandatory = true, ParameterSetName = AcquireByParentObjectsParameterSet, Position = 3, HelpMessage = "Name of the source DNS alias.")]
        [Alias("SourceDnsAliasName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string SourceName { get; set; }


        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AcquireByNameAndSourceParentObjectParameterSet, Position = 3, HelpMessage = "Input object of the source managed instance.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AcquireByParentObjectsParameterSet, Position = 2, HelpMessage = "Input object of the source managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel SourceInstanceObject { get; set; }

        /// <summary>
        /// Gets or sets the instance dns alias object.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = AcquireByNameAndSourceInputObjectParameterSet, Position = 3, HelpMessage = "Input object of the source managed instance DNS alias.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AcquireByParentObjectAndSourceInputObjectParameterSet, Position = 2, HelpMessage = "Input object of the source managed instance DNS alias.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceDnsAliasModel SourceInputObject { get; set; }

        /// <summary>
        /// Gets or sets the instance dns alias resource id
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AcquireByNameAndSourceResourceIdParameterSet, Position = 3, HelpMessage = "Resource ID of the source managed instance DNS alias.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = AcquireByParentObjectAndSourceResourceIdParameterSet, Position = 2, HelpMessage = "Resource ID of the source managed instance DNS alias.")]
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
            return ModelAdapter.ListManagedInstanceDnsAliases(this.ResourceGroupName, this.InstanceName);
        }
 
        private void ConstructSourceResourceId(string sourceResourceGroupName, string sourceManagedInstanceName, string sourceDnsAliasName)
        {
            SourceResourceId = string.Format(
                    ManagedInstanceDnsAliasResourceIdTemplate,
                    ModelAdapter.Context.Subscription.Id,
                    sourceResourceGroupName,
                    sourceManagedInstanceName,
                    sourceDnsAliasName);
        }

        private void ConstructSourceResourceId(AzureSqlManagedInstanceModel sourceInstance, string sourceDnsAliasName)
        {
            SourceResourceId = string.Format(
                    ManagedInstanceDnsAliasResourceIdTemplate,
                    ModelAdapter.Context.Subscription.Id,
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
            System.Diagnostics.Debugger.Launch();
            switch (ParameterSetName)
            {
                // Parameter sets with source resource id as input.
                case AcquireByNameAndSourceResourceIdParameterSet:
                    SourceName = SourceResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    break;
                case AcquireByParentObjectAndSourceResourceIdParameterSet:
                    SourceName = SourceResourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    ParseParentObjectParameters();
                    break;

                // Parameter sets with source name as input.
                case AcquireByNamesParameterSet:
                    ConstructSourceResourceId(SourceResourceGroupName, SourceInstanceName, SourceName);
                    break;
                case AcquireByParentObjectAndSourceNameParameterSet:
                    ParseParentObjectParameters();
                    ConstructSourceResourceId(SourceResourceGroupName, SourceInstanceName, SourceName);
                    break;

                // Parameter sets with source parent object as input.
                case AcquireByNameAndSourceParentObjectParameterSet:
                    ConstructSourceResourceId(SourceInstanceObject, SourceName);
                    break;
                case AcquireByParentObjectsParameterSet:
                    ParseParentObjectParameters();
                    ConstructSourceResourceId(SourceInstanceObject, SourceName);
                    break;

                // Parameter sets with source input object.
                case AcquireByNameAndSourceInputObjectParameterSet:
                    ConstructSourceResourceId(SourceInputObject);
                    break;
                case AcquireByParentObjectAndSourceInputObjectParameterSet:
                    ParseParentObjectParameters();
                    ConstructSourceResourceId(SourceInputObject);
                    break;
            }

            // messages describing behavior with -WhatIf and -Confirm flags
            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceDnsAliasDescription, ResourceGroupName, InstanceName, SourceName),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceDnsAliasWarning, ResourceGroupName, InstanceName, SourceName),
                Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }
    }
}
