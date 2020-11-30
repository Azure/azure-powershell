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
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.SecurityInsights.Cmdlets.DataConnectors
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SentinelDataConnector", DefaultParameterSetName = ParameterSetNames.AzureActiveDirectory, SupportsShouldProcess = true), OutputType(typeof(PSSentinelDataConnector))]
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
        public SwitchParameter AzureActiveDirectory { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AzureAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureAdvancedThreatProtection)]

        public SwitchParameter AzureAdvancedThreatProtection { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AzureSecurityCenter, Mandatory = true, HelpMessage = ParameterHelpMessages.AzureSecurityCenter)]
        public SwitchParameter AzureSecurityCenter { get; set; }
        
        [Parameter(ParameterSetName = ParameterSetNames.AmazonWebServicesCloudTrail, Mandatory = true, HelpMessage = ParameterHelpMessages.AmazonWebServicesCloudTrail)]
        public SwitchParameter AmazonWebServicesCloudTrail { get; set; }
        
        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftCloudAppSecurity, Mandatory = true, HelpMessage = ParameterHelpMessages.MicrosoftCloudAppSecurity)]
        public SwitchParameter MicrosoftCloudAppSecurity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.MicrosoftDefenderAdvancedThreatProtection, Mandatory = true, HelpMessage = ParameterHelpMessages.MicrosoftDefenderAdvancedThreatProtection)]
        public SwitchParameter MicrosoftDefenderAdvancedThreatProtection { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.Office365, Mandatory = true, HelpMessage = ParameterHelpMessages.Office365)]
        public SwitchParameter Office365 { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.ThreatIntelligence, Mandatory = true, HelpMessage = ParameterHelpMessages.ThreatIntelligence)]
        public SwitchParameter ThreatIntelligence { get; set; }

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

            var tenantId = AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id;

            if (ShouldProcess(name, VerbsCommon.New))
            {

                switch (ParameterSetName)
                {
                    case ParameterSetNames.AzureActiveDirectory:
                        DataConnectorDataTypeCommon aadcommon = new DataConnectorDataTypeCommon
                        { State = Alerts.ToLower()};
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
                        var outputaadconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, aadDataConnector);
                        WriteObject(outputaadconnector.ConvertToPSType(), enumerateCollection: false);
                        break;
                    case ParameterSetNames.AzureAdvancedThreatProtection:
                        DataConnectorDataTypeCommon aatpcommon = new DataConnectorDataTypeCommon
                        { State = Alerts.ToLower() };
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
                        var outputaatpconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, aatpDataConnector);
                        WriteObject(outputaatpconnector.ConvertToPSType(), enumerateCollection: false);
                        break;
                    case ParameterSetNames.AzureSecurityCenter:
                        DataConnectorDataTypeCommon asccommon = new DataConnectorDataTypeCommon
                        { State = Alerts.ToLower() };
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
                        var outputascconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, ascDataConnector);
                        WriteObject(outputascconnector.ConvertToPSType(), enumerateCollection: false);
                        break;
                    case ParameterSetNames.AmazonWebServicesCloudTrail:
                        AwsCloudTrailDataConnectorDataTypesLogs awscommon = new AwsCloudTrailDataConnectorDataTypesLogs
                        { State = Logs.ToLower() };
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
                        var outputawsconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, awsDataConnector);
                        WriteObject(outputawsconnector.ConvertToPSType(), enumerateCollection: false);
                        break;
                    case ParameterSetNames.MicrosoftCloudAppSecurity:
                        DataConnectorDataTypeCommon mcascommon = new DataConnectorDataTypeCommon
                        { State = Alerts.ToLower() };
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
                        var outputmcasconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, mcasDataConnector);
                        WriteObject(outputmcasconnector.ConvertToPSType(), enumerateCollection: false);
                        break;
                    case ParameterSetNames.MicrosoftDefenderAdvancedThreatProtection:
                        DataConnectorDataTypeCommon mdatpcommon = new DataConnectorDataTypeCommon
                        { State = Alerts.ToLower() };
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
                        var outputmdatpconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, mdatpDataConnector);
                        WriteObject(outputmdatpconnector.ConvertToPSType(), enumerateCollection: false);
                        break;
                    case ParameterSetNames.Office365:
                        OfficeDataConnectorDataTypesExchange officeExchange = new OfficeDataConnectorDataTypesExchange
                        { State = Exchange.ToLower() };
                        OfficeDataConnectorDataTypesSharePoint officeSharePoint = new OfficeDataConnectorDataTypesSharePoint
                        { State = SharePoint.ToLower() };
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
                        var outputofficeconnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, officeDataConnector);
                        WriteObject(outputofficeconnector.ConvertToPSType(), enumerateCollection: false);
                        break;
                    case ParameterSetNames.ThreatIntelligence:
                        TIDataConnectorDataTypesIndicators tiIndicators = new TIDataConnectorDataTypesIndicators
                        { State = Indicators.ToLower() }; 
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
                        var outputticonnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroupName, WorkspaceName, name, tiDataConnector);
                        WriteObject(outputticonnector.ConvertToPSType(), enumerateCollection: false);
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
        }
    }
}
