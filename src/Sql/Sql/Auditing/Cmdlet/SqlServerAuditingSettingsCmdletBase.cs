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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Auditing.Services;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    public abstract class SqlServerAuditingSettingsCmdletBase : AzureSqlCmdletBase<ServerBlobAuditingSettingsModel, SqlAuditAdapter>
    {
        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = AuditingHelpMessages.ResourceGroupNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = AuditingHelpMessages.ResourceGroupNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = AuditingHelpMessages.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = AuditingHelpMessages.ServerNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = AuditingHelpMessages.ServerNameHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = AuditingHelpMessages.ServerNameHelpMessage)]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string ServerName { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = AuditingHelpMessages.ServerInputObjectHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = AuditingHelpMessages.ServerInputObjectHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = AuditingHelpMessages.ServerInputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public virtual AzureSqlServerModel InputObject { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.BlobStorageHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.BlobStorageByParentResourceParameterSetName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.BlobStorageHelpMessage)]
        public virtual SwitchParameter BlobStorage { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.EventHubHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.EventHubByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.EventHubHelpMessage)]
        public SwitchParameter EventHub { get; set; }

        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.LogAnalyticsHelpMessage)]
        [Parameter(
            ParameterSetName = DefinitionsCommon.LogAnalyticsByParentResourceParameterSetName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = AuditingHelpMessages.LogAnalyticsHelpMessage)]
        public SwitchParameter LogAnalytics { get; set; }

        protected override ServerBlobAuditingSettingsModel GetEntity()
        {
            ServerBlobAuditingSettingsModel model = null;
            if (ParameterSetName == DefinitionsCommon.BlobStorageParameterSetName ||
                ParameterSetName == DefinitionsCommon.StorageAccountSubscriptionIdParameterSetName ||
                ParameterSetName == DefinitionsCommon.BlobStorageByParentResourceParameterSetName ||
                ParameterSetName == DefinitionsCommon.StorageAccountSubscriptionIdByParentResourceParameterSetName)
            {
                if (BlobStorage.IsPresent == false)
                {
                    WriteWarning(DefinitionsCommon.AuditLogsDestinationWasNotSpecifiedWarning);
                }

                model = new ServerBlobAuditingSettingsModel();
            }
            else if (ParameterSetName == DefinitionsCommon.EventHubParameterSetName ||
                ParameterSetName == DefinitionsCommon.EventHubByParentResourceParameterSetName)
            {
                model = new ServerEventHubAuditingSettingsModel();
            }
            else if (ParameterSetName == DefinitionsCommon.LogAnalyticsParameterSetName ||
                ParameterSetName == DefinitionsCommon.LogAnalyticsByParentResourceParameterSetName)
            {
                model = new ServerLogAnalyticsAuditingSettingsModel();
            }

            if (InputObject == null)
            {
                model.ResourceGroupName = ResourceGroupName;
                model.ServerName = ServerName;
            }
            else
            {
                model.ResourceGroupName = InputObject.ResourceGroupName;
                model.ServerName = InputObject.ServerName;
            }

            ModelAdapter.GetAuditingSettings(model.ResourceGroupName, model.ServerName, model);
            return model;
        }

        /// <summary>
        /// Creation and initialization of the ModelAdapter object
        /// </summary>
        /// <param name="subscription">The AzureSubscription in which the current execution is performed</param>
        /// <returns>An initialized and ready to use ModelAdapter object</returns>
        protected override SqlAuditAdapter InitModelAdapter()
        {
            return new SqlAuditAdapter(DefaultProfile.DefaultContext);
        }
    }
}