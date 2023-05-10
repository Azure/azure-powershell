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
using Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Cmdlet
{
    [Cmdlet(VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDtc",
        DefaultParameterSetName = SetByNameParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceDtcModel))]
    public class SetAzureSqlManagedInstanceDtc: ManagedInstanceDtcCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentObjectParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        /// <summary>
        /// Sets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet, Position = 0, HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Sets or sets the name of tarSet managed instance.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByNameParameterSet, Position = 1, HelpMessage = "Name of the managed instance.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Sets or sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }

        /// <summary>
        /// Sets or sets the instance DTC resource id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByInputObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance DTC.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceDtcModel InputObject { get; set; }

        /// <summary>
        /// Sets or sets the instance DTC resource id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = SetByResourceIdParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Resource ID of the managed instance DTC.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not the DTC is enabled.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SetByNameParameterSet, Position = 2, HelpMessage = "DTC enabled status.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByParentObjectParameterSet, Position = 1, HelpMessage = "DTC enabled status.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, HelpMessage = "DTC enabled status.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByResourceIdParameterSet, Position = 1, HelpMessage = "DTC enabled status.")]
        public bool? DtcEnabled { get; set; }

        /// <summary>
        /// Gets or sets the external DNS suffix search list.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SetByNameParameterSet, Position = 3, HelpMessage = "External DNS suffix search list.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByParentObjectParameterSet, Position = 2, HelpMessage = "External DNS suffix search list.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, HelpMessage = "External DNS suffix search list.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByResourceIdParameterSet, Position = 2, HelpMessage = "External DNS suffix search list.")]
        public List<string> ExternalDnsSuffixSearchList { get; set; }

        /// <summary>
        /// Gets or sets allow XA Transactions to managed instance DTC.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SetByNameParameterSet, HelpMessage = "XA transactions enabled status.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByParentObjectParameterSet, Position = 3, HelpMessage = "XA transactions enabled status.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, HelpMessage = "XA transactions enabled status.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByResourceIdParameterSet, Position = 3, HelpMessage = "XA transactions enabled status.")]
        public bool? XaTransactionsEnabled { get; set; }

        /// <summary>
        /// Gets or sets allow SNA LU 6.2 Transactions to managed instance DTC.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SetByNameParameterSet, HelpMessage = "SNA LU 6.2 transactions enabled status.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByParentObjectParameterSet, HelpMessage = "SNA LU 6.2 transactions enabled status.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, HelpMessage = "SNA LU 6.2 transactions enabled status.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByResourceIdParameterSet, Position = 3, HelpMessage = "SNA LU 6.2 transactions enabled status.")]
        public bool? SnaLu6point2TransactionsEnabled { get; set; }

        /// <summary>
        /// Gets or sets default timeout for XA Transactions (in seconds).
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SetByNameParameterSet, HelpMessage = "XA transactions default timeout.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByParentObjectParameterSet, HelpMessage = "XA transactions default timeout.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, HelpMessage = "XA transactions default timeout.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByResourceIdParameterSet, Position = 3, HelpMessage = "XA transactions default timeout.")]
        public int? XaTransactionsDefaultTimeout { get; set; }

        /// <summary>
        /// Gets or sets maximum timeout for XA Transactions (in seconds).
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SetByNameParameterSet, HelpMessage = "XA transactions maximum timeout.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByParentObjectParameterSet, HelpMessage = "XA transactions maximum timeout.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, HelpMessage = "XA transactions maximum timeout.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByResourceIdParameterSet, Position = 3, HelpMessage = "XA transactions maximum timeout.")]
        public int? XaTransactionsMaximumTimeout { get; set; }

        /// <summary>
        /// Gets or sets allow Inbound traffic to managed instance DTC.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SetByNameParameterSet, HelpMessage = "Enable inbound traffic.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByParentObjectParameterSet, HelpMessage = "Enable inbound traffic.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, HelpMessage = "Enable inbound traffic.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByResourceIdParameterSet, Position = 3, HelpMessage = "Enable inbound traffic.")]
        public bool? AllowInboundEnabled { get; set; }

        /// <summary>
        /// Gets or sets allow Outbound traffic of managed instance DTC.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SetByNameParameterSet, HelpMessage = "Enable outbound traffic.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByParentObjectParameterSet, HelpMessage = "Enable outbound traffic.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, HelpMessage = "Enable outbound traffic.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByResourceIdParameterSet, Position = 3, HelpMessage = "Enable outbound traffic.")]
        public bool? AllowOutboundEnabled { get; set; }

        /// <summary>
        /// Gets or sets authentication type of managed instance DTC.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = SetByNameParameterSet, HelpMessage = "Authentication type.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByParentObjectParameterSet, HelpMessage = "Authentication type.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet, HelpMessage = "Authentication type.")]
        [Parameter(Mandatory = false, ParameterSetName = SetByResourceIdParameterSet, Position = 3, HelpMessage = "Authentication type.")]
        public string Authentication { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of confirmation
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Skip confirmation message for performing the action.")]
        public SwitchParameter Force { get; set; }

        protected override AzureSqlManagedInstanceDtcModel GetEntity()
        {
            return ModelAdapter.GetManagedInstanceDtc(ResourceGroupName, InstanceName);
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case SetByNameParameterSet:
                    // Default case, we're getting RG and MI names directly from args.
                    break;
                case SetByParentObjectParameterSet:
                    // We need to extract RG and MI names from the Instance object.
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case SetByInputObjectParameterSet:
                    ResourceGroupName = InputObject.ResourceGroupName;
                    InstanceName = InputObject.ManagedInstanceName;
                    break;
                case SetByResourceIdParameterSet:
                    // We need to derive RG and MI names from resource id.
                    var resourceInfo = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = resourceInfo.ResourceGroupName;
                    InstanceName = resourceInfo.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                    break;
                default:
                    break;
            }

            if (ShouldProcess(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceDtcDescription, InstanceName, ResourceGroupName),
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceDtcWarning, InstanceName, ResourceGroupName),
                Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }

        protected override AzureSqlManagedInstanceDtcModel ApplyUserInputToModel(AzureSqlManagedInstanceDtcModel model)
        {
            if (!ParameterSetName.Equals(SetByInputObjectParameterSet))
            {
                model.DtcEnabled = this.IsParameterBound(c => c.DtcEnabled) ? DtcEnabled : model.DtcEnabled;
                model.ExternalDnsSuffixSearchList = this.IsParameterBound(c => c.ExternalDnsSuffixSearchList) ? ExternalDnsSuffixSearchList : model.ExternalDnsSuffixSearchList;
                model.SecuritySettings.XaTransactionsEnabled = this.IsParameterBound(c => c.XaTransactionsEnabled) ? XaTransactionsEnabled : model.SecuritySettings.XaTransactionsEnabled;
                model.SecuritySettings.SnaLu6point2TransactionsEnabled = this.IsParameterBound(c => c.SnaLu6point2TransactionsEnabled) ? SnaLu6point2TransactionsEnabled : model.SecuritySettings.SnaLu6point2TransactionsEnabled;
                model.SecuritySettings.XaTransactionsDefaultTimeout = this.IsParameterBound(c => c.XaTransactionsDefaultTimeout) ? XaTransactionsDefaultTimeout : model.SecuritySettings.XaTransactionsDefaultTimeout;
                model.SecuritySettings.XaTransactionsMaximumTimeout = this.IsParameterBound(c => c.XaTransactionsMaximumTimeout) ? XaTransactionsMaximumTimeout : model.SecuritySettings.XaTransactionsMaximumTimeout;
                model.SecuritySettings.TransactionManagerCommunicationSettings.AllowOutboundEnabled = this.IsParameterBound(c => c.AllowOutboundEnabled) ? AllowOutboundEnabled : model.SecuritySettings.TransactionManagerCommunicationSettings.AllowOutboundEnabled;
                model.SecuritySettings.TransactionManagerCommunicationSettings.AllowInboundEnabled = this.IsParameterBound(c => c.AllowInboundEnabled) ? AllowInboundEnabled : model.SecuritySettings.TransactionManagerCommunicationSettings.AllowInboundEnabled;
                model.SecuritySettings.TransactionManagerCommunicationSettings.Authentication = this.IsParameterBound(c => c.Authentication) ? Authentication : model.SecuritySettings.TransactionManagerCommunicationSettings.Authentication;
            } else
            {
                model.DtcEnabled = this.IsParameterBound(c => c.DtcEnabled) ? DtcEnabled : InputObject.DtcEnabled;
                model.ExternalDnsSuffixSearchList = this.IsParameterBound(c => c.ExternalDnsSuffixSearchList) ? ExternalDnsSuffixSearchList : InputObject.ExternalDnsSuffixSearchList;
                model.SecuritySettings.XaTransactionsEnabled = this.IsParameterBound(c => c.XaTransactionsEnabled) ? XaTransactionsEnabled : InputObject.SecuritySettings.XaTransactionsEnabled;
                model.SecuritySettings.SnaLu6point2TransactionsEnabled = this.IsParameterBound(c => c.SnaLu6point2TransactionsEnabled) ? SnaLu6point2TransactionsEnabled : InputObject.SecuritySettings.SnaLu6point2TransactionsEnabled;
                model.SecuritySettings.XaTransactionsDefaultTimeout = this.IsParameterBound(c => c.XaTransactionsDefaultTimeout) ? XaTransactionsDefaultTimeout : InputObject.SecuritySettings.XaTransactionsDefaultTimeout;
                model.SecuritySettings.XaTransactionsMaximumTimeout = this.IsParameterBound(c => c.XaTransactionsMaximumTimeout) ? XaTransactionsMaximumTimeout : InputObject.SecuritySettings.XaTransactionsMaximumTimeout;
                model.SecuritySettings.TransactionManagerCommunicationSettings.AllowOutboundEnabled = this.IsParameterBound(c => c.AllowOutboundEnabled) ? AllowOutboundEnabled : InputObject.SecuritySettings.TransactionManagerCommunicationSettings.AllowOutboundEnabled;
                model.SecuritySettings.TransactionManagerCommunicationSettings.AllowInboundEnabled = this.IsParameterBound(c => c.AllowInboundEnabled) ? AllowInboundEnabled : InputObject.SecuritySettings.TransactionManagerCommunicationSettings.AllowInboundEnabled;
                model.SecuritySettings.TransactionManagerCommunicationSettings.Authentication = this.IsParameterBound(c => c.Authentication) ? Authentication : InputObject.SecuritySettings.TransactionManagerCommunicationSettings.Authentication;
            }
            return base.ApplyUserInputToModel(model);
        }

        protected override AzureSqlManagedInstanceDtcModel PersistChanges(AzureSqlManagedInstanceDtcModel entity)
        {
            return ModelAdapter.SetManagedInstanceDtc(ResourceGroupName, InstanceName, entity);
        }
    }
}
