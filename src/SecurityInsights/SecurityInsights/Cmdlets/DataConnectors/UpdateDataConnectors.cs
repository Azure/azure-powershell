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
// ------------------------------------

using System.Management.Automation;
using Microsoft.Azure.Commands.SecurityInsights;
using Microsoft.Azure.Commands.SecurityInsights.Common;
using Microsoft.Azure.Commands.SecurityInsights.Models.DataConnectors;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.SecurityInsights;
using System;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.DataConnectors
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelDataConnector", DefaultParameterSetName = ParameterSetNames.DataConnectorId, SupportsShouldProcess = true), OutputType(typeof(PSSentinelDataConnector))]
    public class UpdateDataConnectors : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.DataConnectorId, Mandatory = true, HelpMessage = ParameterHelpMessages.ResourceGroupName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.DataConnectorId, Mandatory = true, HelpMessage = ParameterHelpMessages.WorkspaceName)]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.DataConnectorId, Mandatory = true, HelpMessage = ParameterHelpMessages.DataConnectorId)]
        [ValidateNotNullOrEmpty]
        public string DataConnectorId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSetNames.InputObject, HelpMessage = ParameterHelpMessages.InputObject)]
        [ValidateNotNull]
        public PSSentinelDataConnector InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSetNames.ResourceId, HelpMessage = ParameterHelpMessages.ResourceId)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Alerts)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string Alerts { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.AwsRoleArn)]
        [ValidateNotNullOrEmpty]
        public string AwsRoleArn { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Logs)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string Logs { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.DiscoveryLogs)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string DiscoveryLogs { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Exchange)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string Exchange { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.SharePoint)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string SharePoint { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Teams)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string Teams { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ParameterHelpMessages.Indicators)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string Indicators { get; set; }


        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = AzureIdUtilities.GetResourceGroup(this.InputObject.Id);
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(this.InputObject.Id);
                this.DataConnectorId = this.InputObject.Name;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = AzureIdUtilities.GetWorkspaceName(this.ResourceId);
                this.DataConnectorId = resourceIdentifier.ResourceName;
            }

            PSSentinelDataConnector dataConnector = null;
            try
            {
                dataConnector = this.SecurityInsightsClient.DataConnectors.Get(ResourceGroupName, WorkspaceName, DataConnectorId).ConvertToPSType();
            }
            catch
            {
                dataConnector = null;
            }

            if (dataConnector == null)
            {
                throw new Exception(string.Format("A Data Connector with DataConnectorId '{0}' in resource group '{1}' under workspace '{2}' does not exist. Please use New-AzSentinelDataConnector to create a Data Connector with these properties.", this.DataConnectorId, this.ResourceGroupName, this.WorkspaceName));
            }

            if(dataConnector.Kind == "AzureActiveDirectory") 
            {
                var convertedAADDataConnector = dataConnector as PSSentinelDataConnectorAAD;

                convertedAADDataConnector.Etag = convertedAADDataConnector.Etag;
                convertedAADDataConnector.TenantId = convertedAADDataConnector.TenantId;
                convertedAADDataConnector.DataTypes.Alerts.State = this.IsParameterBound(c => c.Alerts) ? this.Alerts : convertedAADDataConnector.DataTypes.Alerts.State;

                dataConnector = convertedAADDataConnector;
            };
            if (dataConnector.Kind == "AzureAdvancedThreatProtection")
            {
                var convertedAATPDataConnector = dataConnector as PSSentinelDataConnectorAATP;

                convertedAATPDataConnector.Etag = convertedAATPDataConnector.Etag;
                convertedAATPDataConnector.TenantId = convertedAATPDataConnector.TenantId;
                convertedAATPDataConnector.DataTypes.Alerts.State = this.IsParameterBound(c => c.Alerts) ? this.Alerts : convertedAATPDataConnector.DataTypes.Alerts.State;

                dataConnector = convertedAATPDataConnector;
            };
            if (dataConnector.Kind == "AzureSecurityCenter")
            {
                var convertedASCDataConnector = dataConnector as PSSentinelDataConnectorASC;

                convertedASCDataConnector.Etag = convertedASCDataConnector.Etag;
                convertedASCDataConnector.SubscriptionId = this.IsParameterBound(c => c.SubscriptionId) ? this.SubscriptionId : convertedASCDataConnector.SubscriptionId;
                convertedASCDataConnector.DataTypes.Alerts.State = this.IsParameterBound(c => c.Alerts) ? this.Alerts : convertedASCDataConnector.DataTypes.Alerts.State;

                dataConnector = convertedASCDataConnector;
            };
            if (dataConnector.Kind == "AmazonWebServicesCloudTrail")
            {
                var convertedAWSDataConnector = dataConnector as PSSentinelDataConnectorAWS;

                convertedAWSDataConnector.Etag = convertedAWSDataConnector.Etag;
                convertedAWSDataConnector.AwsRoleArn = this.IsParameterBound(c => c.AwsRoleArn) ? this.AwsRoleArn : convertedAWSDataConnector.AwsRoleArn;
                convertedAWSDataConnector.DataTypes.Logs.State = this.IsParameterBound(c => c.Logs) ? this.Logs : convertedAWSDataConnector.DataTypes.Logs.State;

                dataConnector = convertedAWSDataConnector;
            };
            if (dataConnector.Kind == "MicrosoftCloudAppSecurity")
            {
                var convertedMCASDataConnector = dataConnector as PSSentinelDataConnectorMCAS;

                convertedMCASDataConnector.Etag = convertedMCASDataConnector.Etag;
                convertedMCASDataConnector.TenantId = convertedMCASDataConnector.TenantId;
                convertedMCASDataConnector.DataTypes.Alerts.State = this.IsParameterBound(c => c.Alerts) ? this.Alerts : convertedMCASDataConnector.DataTypes.Alerts.State;
                convertedMCASDataConnector.DataTypes.DiscoveryLogs.State = this.IsParameterBound(c => c.DiscoveryLogs) ? this.DiscoveryLogs : convertedMCASDataConnector.DataTypes.DiscoveryLogs.State;

                dataConnector = convertedMCASDataConnector;
            };
            if (dataConnector.Kind == "MicrosoftDefenderAdvancedThreatProtection")
            {
                var convertedMDATPDataConnector = dataConnector as PSSentinelDataConnectorMDATP;

                convertedMDATPDataConnector.Etag = convertedMDATPDataConnector.Etag;
                convertedMDATPDataConnector.TenantId = convertedMDATPDataConnector.TenantId;
                convertedMDATPDataConnector.DataTypes.Alerts.State = this.IsParameterBound(c => c.Alerts) ? this.Alerts : convertedMDATPDataConnector.DataTypes.Alerts.State;

                dataConnector = convertedMDATPDataConnector;
            };
            if (dataConnector.Kind == "Office365")
            {
                var convertedO365DataConnector = dataConnector as PSSentinelDataConnectorOffice;

                convertedO365DataConnector.Etag = convertedO365DataConnector.Etag;
                convertedO365DataConnector.TenantId = convertedO365DataConnector.TenantId;
                convertedO365DataConnector.DataTypes.Exchange.State = this.IsParameterBound(c => c.Exchange) ? this.Exchange : convertedO365DataConnector.DataTypes.Exchange.State;
                convertedO365DataConnector.DataTypes.SharePoint.State = this.IsParameterBound(c => c.SharePoint) ? this.SharePoint : convertedO365DataConnector.DataTypes.SharePoint.State;
                convertedO365DataConnector.DataTypes.Teams.State = this.IsParameterBound(c => c.Teams) ? this.Teams : convertedO365DataConnector.DataTypes.Teams.State;

                dataConnector = convertedO365DataConnector;
            };
            if (dataConnector.Kind == "ThreatIntelligence")
            {
                var convertedTIDataConnector = dataConnector as PSSentinelDataConnectorTI;

                convertedTIDataConnector.Etag = convertedTIDataConnector.Etag;
                convertedTIDataConnector.TenantId = convertedTIDataConnector.TenantId;
                convertedTIDataConnector.DataTypes.Indicators.State = this.IsParameterBound(c => c.Indicators) ? this.Indicators : convertedTIDataConnector.DataTypes.Indicators.State;

                dataConnector = convertedTIDataConnector;
            };


            if (this.ShouldProcess(this.DataConnectorId, string.Format("Updating Data Connector '{0}' in resource group '{1}' under workspace '{2}'.", this.DataConnectorId, this.ResourceGroupName, this.WorkspaceName)))
            {
                var result = this.SecurityInsightsClient.DataConnectors.CreateOrUpdate(this.ResourceGroupName, this.WorkspaceName, this.DataConnectorId, dataConnector.CreatePSType()).ConvertToPSType();
                WriteObject(result);
            }
        }
    }
}