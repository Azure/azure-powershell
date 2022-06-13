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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDnsAlias",
        DefaultParameterSetName = DeleteByNameParameterSet,
        SupportsShouldProcess = true)]
    public class RemoveAzureSqlManagedInstanceDnsAlias : AzureSqlManagedInstanceDnsAliasCmdletBase
    {
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByParentObjectParameterSet = "DeleteByParentObjectParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 1, HelpMessage = "Name of the managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        public string InstanceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByNameParameterSet, Position = 2, HelpMessage = "Name of the DNS alias.")]
        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, Position = 1, HelpMessage = "Name of the DNS alias.")]
        [ValidateNotNullOrEmpty]
        [Alias("DnsAliasName")]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DeleteByInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance DNS alias.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceDnsAliasModel InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DeleteByResourceIdParameterSet, Position = 0, HelpMessage = "Resource ID of the managed instance DNS alias.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> GetEntity()
        {
            return new List<AzureSqlManagedInstanceDnsAliasModel>(){
                ModelAdapter.GetManagedInstanceDnsAlias(ResourceGroupName, InstanceName, Name)
            };
        }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out.
        /// </summary>
        protected override bool WriteResult()
        {
            return PassThru.IsPresent;
        }

        protected override IEnumerable<AzureSqlManagedInstanceDnsAliasModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceDnsAliasModel> entity)
        {
            ModelAdapter.RemoveManagedInstanceDnsAlias(ResourceGroupName, InstanceName, Name);
            return entity;
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case DeleteByNameParameterSet:
                    // default case, we're getting RG, MI and DNS alias names directly from args
                    break;
                case DeleteByParentObjectParameterSet:
                    // we need to extract RG and MI name from the Instance object, DNS alias name is received directly from arg
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case DeleteByInputObjectParameterSet:
                    // we need to extract RG, MI and DNS alias name directly from the DNS alias object
                    ResourceGroupName = InputObject.ResourceGroupName;
                    InstanceName = InputObject.ManagedInstanceName;
                    Name = InputObject.DnsAliasName;
                    break;
                case DeleteByResourceIdParameterSet:
                    // we need to derive RG, MI and DNS alias from resource id
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
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceDnsAliasDescription, ResourceGroupName, InstanceName, Name),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceDnsAliasWarning, ResourceGroupName, InstanceName, Name),
                Properties.Resources.ShouldProcessCaption))
            {
                // message prompt requiring the customer to explicitly confirm the delete operation
                if (Force || ShouldContinue(string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlInstanceDnsAliasWarning, ResourceGroupName, InstanceName, Name), Properties.Resources.ShouldProcessCaption))
                {
                    base.ExecuteCmdlet();
                }
            }
        }
    }
}
