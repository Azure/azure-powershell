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
using System;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.DataConnectors
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelDataConnector", DefaultParameterSetName = ParameterSetNames.DataConnectorId), OutputType(typeof(PSSentinelDataConnector))]
    public class NewDataConnectors : SecurityInsightsCmdletBase
    {
        [Parameter(ParameterSetName = ParameterSetNames.AzureActiveDirectory, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureActiveDirectory)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureAdvancedThreatProtection)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureSecurityCenter, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureSecurityCenter)]
        [Parameter(ParameterSetName = ParameterSetNames.AmazonWebServicesCloudTrail, Mandatory = true, HelpMessage = ParameterHelpMessages.AmazonWebServicesCloudTrail)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftCloudAppSecurity, Mandatory = true, HelpMessage = ParameterHelpMessages.MicrosoftCloudAppSecurity)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftDefenderAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.MicrosoftDefenderAdvancedThreatProtection)]
        [Parameter(ParameterSetName = ParameterSetNames.Office365, Mandatory = true, HelpMessage = ParameterHelpMessages.Office365)]
        [Parameter(ParameterSetName = ParameterSetNames.ThreatIntelligence, Mandatory = true, HelpMessage = ParameterHelpMessages.ThreatIntelligence)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty] 
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AzureActiveDirectory, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureActiveDirectory)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureAdvancedThreatProtection)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureSecurityCenter, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureSecurityCenter)]
        [Parameter(ParameterSetName = ParameterSetNames.AmazonWebServicesCloudTrail, Mandatory = true, HelpMessage = ParameterHelpMessages.AmazonWebServicesCloudTrail)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftCloudAppSecurity, Mandatory = true, HelpMessage = ParameterHelpMessages.MicrosoftCloudAppSecurity)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftDefenderAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.MicrosoftDefenderAdvancedThreatProtection)]
        [Parameter(ParameterSetName = ParameterSetNames.Office365, Mandatory = true, HelpMessage = ParameterHelpMessages.Office365)]
        [Parameter(ParameterSetName = ParameterSetNames.ThreatIntelligence, Mandatory = true, HelpMessage = ParameterHelpMessages.ThreatIntelligence)]
        [ValidateNotNullOrEmpty] 
        public string WorkspaceName { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AzureActiveDirectory, Mandatory = false, HelpMessage = ParameterHelpMessages.AzureActiveDirectory)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureAdvancedThreatProtection, Mandatory = false, HelpMessage = ParameterHelpMessages.AzureAdvancedThreatProtection)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureSecurityCenter, Mandatory = false, HelpMessage = ParameterHelpMessages.AzureSecurityCenter)]
        [Parameter(ParameterSetName = ParameterSetNames.AmazonWebServicesCloudTrail, Mandatory = false, HelpMessage = ParameterHelpMessages.AmazonWebServicesCloudTrail)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftCloudAppSecurity, Mandatory = false, HelpMessage = ParameterHelpMessages.MicrosoftCloudAppSecurity)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftDefenderAdvancedThreatProtection, Mandatory = false, HelpMessage = ParameterHelpMessages.MicrosoftDefenderAdvancedThreatProtection)]
        [Parameter(ParameterSetName = ParameterSetNames.Office365, Mandatory = false, HelpMessage = ParameterHelpMessages.Office365)]
        [Parameter(ParameterSetName = ParameterSetNames.ThreatIntelligence, Mandatory = false, HelpMessage = ParameterHelpMessages.ThreatIntelligence)]
        public string DataConnectorId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AzureActiveDirectory, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureActiveDirectory)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureAdvancedThreatProtection)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureSecurityCenter, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureSecurityCenter)]
        [Parameter(ParameterSetName = ParameterSetNames.AmazonWebServicesCloudTrail, Mandatory = true, HelpMessage = ParameterHelpMessages.AmazonWebServicesCloudTrail)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftCloudAppSecurity, Mandatory = true, HelpMessage = ParameterHelpMessages.MicrosoftCloudAppSecurity)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftDefenderAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.MicrosoftDefenderAdvancedThreatProtection)]
        [Parameter(ParameterSetName = ParameterSetNames.Office365, Mandatory = true, HelpMessage = ParameterHelpMessages.Office365)]
        [Parameter(ParameterSetName = ParameterSetNames.ThreatIntelligence, Mandatory = true, HelpMessage = ParameterHelpMessages.ThreatIntelligence)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("AzureActiveDirectory", "AzureAdvancedThreatProtection", "AzureSecurityCenter", "AmazonWebServicesCloudTrail", "MicrosoftCloudAppSecurity", "MicrosoftDefenderAdvancedThreatProtection", "Office365", "ThreatIntelligence")]
        public string Kind { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AzureActiveDirectory, Mandatory = true, HelpMessage = ParameterHelpMessages.Alerts)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.Alerts)]
        [Parameter(ParameterSetName = ParameterSetNames.AzureSecurityCenter, Mandatory = true, HelpMessage = ParameterHelpMessages.Alerts)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftCloudAppSecurity, Mandatory = true, HelpMessage = ParameterHelpMessages.Alerts)]
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftDefenderAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.Alerts)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string Alerts { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AzureSecurityCenter, Mandatory = true, HelpMessage = ParameterHelpMessages.SubscriptionId)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AmazonWebServicesCloudTrail, Mandatory = true, HelpMessage = ParameterHelpMessages.AwsRoleArn)]
        [ValidateNotNullOrEmpty]
        public string AwsRoleArn { get; set; }
        
        [Parameter(ParameterSetName = ParameterSetNames.AmazonWebServicesCloudTrail, Mandatory = true, HelpMessage = ParameterHelpMessages.Logs)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string Logs { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftCloudAppSecurity, Mandatory = true, HelpMessage = ParameterHelpMessages.DiscoveryLogs)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string DiscoveryLogs { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.Office365, Mandatory = true, HelpMessage = ParameterHelpMessages.Exchange)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string Exchange { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.Office365, Mandatory = true, HelpMessage = ParameterHelpMessages.SharePoint)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string SharePoint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ThreatIntelligence, Mandatory = true, HelpMessage = ParameterHelpMessages.Indicators)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("Enabled", "Disabled")]
        public string Indicators { get; set; }

        public override void ExecuteCmdlet()
        {
            if (DataConnectorId == null)
            {
                DataConnectorId = Guid.NewGuid().ToString();
            }

            var name = DataConnectorId;

            var tenantId = AzureSubscription.Property.HomeTenant;

            if (ShouldProcess(name, VerbsCommon.New))
            {

                switch (ParameterSetName)
                {
                    case ParameterSetNames.AzureActiveDirectory:
                        DataConnectorDataTypeCommon aadcommon = new DataConnectorDataTypeCommon
                        { State = Alerts};
                        AlertsDataTypeOfDataConnector aadalerts = new AlertsDataTypeOfDataConnector
                        { 
                            Alerts = aadcommon
                        };
                        AADDataConnector aadDataTypes = new AADDataConnector
                        {
                            DataTypes = aadalerts,
                            TenantId = tenantId
                        };
                        DataConnector aadDataConnector = aadDataTypes; 
                        var outputaadconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, name, aadDataConnector).GetAwaiter().GetResult().Body;
                        WriteObject(outputaadconnector, enumerateCollection: false);
                        break;
                    case ParameterSetNames.AzureAdvancedThreatProtection:
                        DataConnectorDataTypeCommon aatpcommon = new DataConnectorDataTypeCommon
                        { State = Alerts };
                        AlertsDataTypeOfDataConnector aatpalerts = new AlertsDataTypeOfDataConnector
                        {
                            Alerts = aatpcommon
                        };
                        AATPDataConnector aatpDataTypes = new AATPDataConnector
                        {
                            DataTypes = aatpalerts,
                            TenantId = tenantId
                        };
                        DataConnector aatpDataConnector = aatpDataTypes;
                        var outputaatpconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, name, aatpDataConnector).GetAwaiter().GetResult().Body;
                        WriteObject(outputaatpconnector, enumerateCollection: false);
                        break;
                    case ParameterSetNames.AzureSecurityCenter:
                        DataConnectorDataTypeCommon asccommon = new DataConnectorDataTypeCommon
                        { State = Alerts };
                        AlertsDataTypeOfDataConnector ascalerts = new AlertsDataTypeOfDataConnector
                        {
                            Alerts = asccommon
                            
                        };
                        ASCDataConnector ascDataTypes = new ASCDataConnector
                        {
                            DataTypes = ascalerts,
                            SubscriptionId = SubscriptionId
                            
                        };
                        DataConnector ascDataConnector = ascDataTypes;
                        var outputascconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, name, ascDataConnector).GetAwaiter().GetResult().Body;
                        WriteObject(outputascconnector, enumerateCollection: false);
                        break;
                    case ParameterSetNames.AmazonWebServicesCloudTrail:
                        AwsCloudTrailDataConnectorDataTypesLogs awscommon = new AwsCloudTrailDataConnectorDataTypesLogs
                        { State = Logs };
                         AwsCloudTrailDataConnectorDataTypes awslogs = new AwsCloudTrailDataConnectorDataTypes
                        {
                            Logs = awscommon
                        };
                        AwsCloudTrailDataConnector awsDataTypes = new AwsCloudTrailDataConnector
                        {
                            DataTypes = awslogs,
                            AwsRoleArn = AwsRoleArn

                        };
                        DataConnector awsDataConnector = awsDataTypes;
                        var outputawsconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, name, awsDataConnector).GetAwaiter().GetResult().Body;
                        WriteObject(outputawsconnector, enumerateCollection: false);
                        break;
                    case ParameterSetNames.MicrosoftCloudAppSecurity:
                        DataConnectorDataTypeCommon mcascommon = new DataConnectorDataTypeCommon
                        { State = Alerts };
                        DataConnectorDataTypeCommon mcasdiscovery = new DataConnectorDataTypeCommon
                        { State = DiscoveryLogs };
                        MCASDataConnectorDataTypes mcasDataTypes = new MCASDataConnectorDataTypes
                        {
                            Alerts = mcascommon,
                            DiscoveryLogs = mcasdiscovery
                        };
                        MCASDataConnector mcasConnector = new MCASDataConnector
                        {
                            DataTypes = mcasDataTypes,
                            TenantId = tenantId
                        };
                        DataConnector mcasDataConnector = mcasConnector;
                        var outputmcasconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, name, mcasDataConnector).GetAwaiter().GetResult().Body;
                        WriteObject(outputmcasconnector, enumerateCollection: false);
                        break;
                    case ParameterSetNames.MicrosoftDefenderAdvancedThreatProtection:
                        DataConnectorDataTypeCommon mdatpcommon = new DataConnectorDataTypeCommon
                        { State = Alerts };
                        AlertsDataTypeOfDataConnector mdatpalerts = new AlertsDataTypeOfDataConnector
                        {
                            Alerts = mdatpcommon
                        };
                        MDATPDataConnector mdatpDataTypes = new MDATPDataConnector
                        {
                            DataTypes = mdatpalerts,
                            TenantId = tenantId
                        };
                        DataConnector mdatpDataConnector = mdatpDataTypes;
                        var outputmdatpconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, name, mdatpDataConnector).GetAwaiter().GetResult().Body;
                        WriteObject(outputmdatpconnector, enumerateCollection: false);
                        break;
                    case ParameterSetNames.Office365:
                        OfficeDataConnectorDataTypesExchange officeExchange = new OfficeDataConnectorDataTypesExchange
                        { State = Exchange };
                        OfficeDataConnectorDataTypesSharePoint officeSharePoint = new OfficeDataConnectorDataTypesSharePoint
                        { State = SharePoint };
                        OfficeDataConnectorDataTypes officeDataTypes = new OfficeDataConnectorDataTypes
                        {
                            Exchange = officeExchange,
                            SharePoint = officeSharePoint
                        };
                        OfficeDataConnector officeConnector = new OfficeDataConnector
                        {
                            DataTypes = officeDataTypes,
                            TenantId = tenantId
                        };
                        DataConnector officeDataConnector = officeConnector;
                        var outputofficeconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, name, officeDataConnector).GetAwaiter().GetResult().Body;
                        WriteObject(outputofficeconnector, enumerateCollection: false);
                        break;
                    case ParameterSetNames.ThreatIntelligence:
                        TIDataConnectorDataTypesIndicators tiIndicators = new TIDataConnectorDataTypesIndicators
                        { State = Indicators };
                        TIDataConnectorDataTypes tiDataTypes = new TIDataConnectorDataTypes
                        {
                            Indicators = tiIndicators
                        };
                        TIDataConnector tiConnector = new TIDataConnector
                        { 
                            DataTypes = tiDataTypes,
                            TenantId = tenantId
                        };
                        DataConnector tiDataConnector = tiConnector;
                        var outputticonnector = SecurityInsightsClient.DataConnectors.CreateOrUpdateWithHttpMessagesAsync(ResourceGroupName, WorkspaceName, name, tiDataConnector).GetAwaiter().GetResult().Body;
                        WriteObject(outputticonnector, enumerateCollection: false);
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
        }
    }
}
