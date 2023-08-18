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

using Microsoft.Azure.Commands.Maintenance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.Maintenance
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ConfigurationAssignment", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSConfigurationAssignment))]
    public partial class NewAzureRmConfigurationAssignment : MaintenanceAutomationBaseCmdlet
    {
        const string GlobalLocation = "global";
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.ConfigurationAssignmentName, VerbsCommon.New))
                {
                    ConfigurationAssignment result = null;
                    string resourceGroupName = this.ResourceGroupName;
                    string providerName = this.ProviderName;
                    string resourceParentType = this.ResourceParentType;
                    string resourceParentName = this.ResourceParentName;
                    string resourceType = this.ResourceType;
                    string resourceName = this.ResourceName;
                    string configurationAssignmentName = this.ConfigurationAssignmentName;

                    if (IsSubcriptionAssignment(this.ResourceGroupName, this.ProviderName, this.ResourceParentType, this.ResourceName))
                    {
                        var configurationAssignment = new ConfigurationAssignment();
                        configurationAssignment.ResourceId = $"/subscriptions/{this.MaintenanceClient.MaintenanceManagementClient.SubscriptionId}";
                        configurationAssignment.Location = GlobalLocation;
                        configurationAssignment.MaintenanceConfigurationId = this.MaintenanceConfigurationId;
                        PrepapreDynamicScopeFilter(configurationAssignment);
                        result = ConfigurationAssignmentsForSubscriptionsClient.CreateOrUpdate(this.ConfigurationAssignmentName, configurationAssignment);
                    }   
                    else if(IsResourceGroupAssignment(this.ResourceGroupName, this.ProviderName, this.ResourceParentType, this.ResourceName))
                    {
                        var configurationAssignment = new ConfigurationAssignment();
                        configurationAssignment.ResourceId = $"/subscriptions/{this.MaintenanceClient.MaintenanceManagementClient.SubscriptionId}/resourcegroups/{this.ResourceGroupName}";
                        configurationAssignment.Location = this.Location;
                        configurationAssignment.MaintenanceConfigurationId = this.MaintenanceConfigurationId;
                        PrepapreDynamicScopeFilter(configurationAssignment);
                        result = ConfigurationAssignmentsForResourceGroupClient.CreateOrUpdate(this.ResourceGroupName, this.ConfigurationAssignmentName, configurationAssignment);
                    }
                    else
                    {
                        var configurationAssignment = new ConfigurationAssignment();
                        configurationAssignment.ResourceId = this.ResourceId;

                        configurationAssignment.Location = this.Location;
                        configurationAssignment.MaintenanceConfigurationId = this.MaintenanceConfigurationId;

                        result = (!string.IsNullOrEmpty(resourceParentType) && !string.IsNullOrEmpty(resourceParentName)) ?
                            ConfigurationAssignmentsClient.CreateOrUpdateParent(resourceGroupName, providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, configurationAssignment) :
                            ConfigurationAssignmentsClient.CreateOrUpdate(resourceGroupName, providerName, resourceType, resourceName, configurationAssignmentName, configurationAssignment);

                    }

                    var psObject = new PSConfigurationAssignment();
                    MaintenanceAutomationAutoMapperProfile.Mapper.Map<ConfigurationAssignment, PSConfigurationAssignment>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }

        private void PrepapreDynamicScopeFilter(ConfigurationAssignment configurationAssignment)
        {
            configurationAssignment.Filter = new ConfigurationAssignmentFilterProperties();
            configurationAssignment.Filter.ResourceGroups = this.FilterResourceGroup == null ? null : this.FilterResourceGroup.ToList();
            configurationAssignment.Filter.ResourceTypes = this.FilterResourceType== null ? null : this.FilterResourceType.ToList();
            configurationAssignment.Filter.OsTypes = this.FilterOsType == null ? null : this.FilterOsType.ToList();
            configurationAssignment.Filter.Locations = this.FilterLocation == null ? null : this.FilterLocation.ToList();

            if (!string.IsNullOrEmpty(this.FilterTag) || !string.IsNullOrEmpty(this.FilterOperator))
            {
                configurationAssignment.Filter.TagSettings = new TagSettingsProperties();
            }

            if (!string.IsNullOrEmpty(this.FilterTag))
            {
                configurationAssignment.Filter.TagSettings.Tags = JsonConvert.DeserializeObject<IDictionary<string, IList<string>>>(this.FilterTag);
            }

            if (Enum.TryParse<TagOperators>(this.FilterOperator, true, out var filterOperator))
            {
                configurationAssignment.Filter.TagSettings.FilterOperator = filterOperator;
            }
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 0,
            Mandatory = false,
            HelpMessage = "The resource Group Name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = false,
            HelpMessage = "The resource provider Name.",
            ValueFromPipelineByPropertyName = true)]
        public string ProviderName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = false,
            HelpMessage = "The parent resource type.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceParentType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = false,
            HelpMessage = "The parent resource name.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceParentName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = false,
            HelpMessage = "The resource type.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = false,
            HelpMessage = "The resource name.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = true,
            HelpMessage = "The configuration assignment name, should match the MaintenanceConfigurationName.",
            ValueFromPipelineByPropertyName = true)]
        public string ConfigurationAssignmentName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "The configuration assignment name, should match the MaintenanceConfigurationName.",
            Mandatory = false)]
        public string ResourceId { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "The location without spaces for the resource.",
            Mandatory = false)]
        public string Location { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "The fully qualified MaintenanceConfiguration.",
            Mandatory = true)]
        public string MaintenanceConfigurationId { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "Allowed resource types for dynamic scope.",
            Mandatory = false)]
        public string[] FilterResourceType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "Allowed locations for dynamic scope.",
            Mandatory = false)]
        public string[] FilterLocation { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "Allowed resource types for dynamic scope.",
            Mandatory = false)]
        public string FilterTag { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "Tag filter operator for dynamic scope.",
            Mandatory = false)]
        public string FilterOperator { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "Operating system type for dynamic scope.",
            Mandatory = false)]
        public string[] FilterOsType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            HelpMessage = "Operating system type for dynamic scope.",
            Mandatory = false)]
        public string[] FilterResourceGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
    }
}
