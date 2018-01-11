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

using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Commands.Insights.Properties;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Insights.Autoscale
{
    /// <summary>
    /// Create or update an Autoscale setting
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmAutoscaleSetting", SupportsShouldProcess = true), OutputType(typeof(PSAddAutoscaleSettingOperationResponse))]
    public class AddAzureRmAutoscaleSettingCommand : ManagementCmdletBase
    {
        internal const string AddAzureRmAutoscaleSettingCreateParamGroup = "CreateAutoscaleSetting";
        internal const string AddAzureRmAutoscaleSettingUpdateParamGroup = "UpdateAutoscaleSetting";

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the InputObject parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingUpdateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The complete spec of an AutoscaleSetting")]
        [ValidateNotNullOrEmpty]
        [Alias("SettingSpec")]
        public PSAutoscaleSetting InputObject { get; set; }

        /// <summary>
        /// Gets or sets the Location parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingCreateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The location")]
        [LocationCompleter("Microsoft.Insights/autoscalesettings")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the rule name parameter of the cmdlet
        /// </summary>
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingCreateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The setting name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or set the resource group name
        /// </summary>
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingCreateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingUpdateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceGroup")]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the DisableSetting flag.
        /// <para>Using DisableSetting to make false the default, i.e. if the user does not include it in the call, the setting will be enabled.</para>
        /// </summary>
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingCreateParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The disable setting (status) flag")]
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingUpdateParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The disable setting (status) flag")]
        public SwitchParameter DisableSetting { get; set; }

        /// <summary>
        /// Gets or sets the AutoscaleProfiles
        /// </summary>
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingCreateParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of profiles")]
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingUpdateParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of profiles")]
        [ValidateNotNullOrEmpty]
        [Alias("AutoscaleProfiles")]
        public List<AutoscaleProfile> AutoscaleProfile { get; set; }

        /// <summary>
        /// Gets or sets the TargetResourceId parameter
        /// </summary>
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingCreateParamGroup, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id for the setting")]
        [ValidateNotNullOrEmpty]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Gets or sets the list of Notifications of the setting
        /// </summary>
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingCreateParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of notifications of the setting")]
        [Parameter(ParameterSetName = AddAzureRmAutoscaleSettingUpdateParamGroup, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The list of notifications of the setting")]
        [Alias("Notifications")]
        public List<AutoscaleNotification> Notification { get; set; }

        #endregion

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        protected override void ProcessRecordInternal()
        {
            this.WriteIdentifiedWarning(
                cmdletName: "Add-AzureRmAutoscaleSetting",
                topic: "Parameter name change", 
                message: "The parameter plural names for the parameters will be deprecated in a future breaking change release in favor of he singular versions of the same names.");
            if (ShouldProcess(
                target: string.Format("Create/update an autoscale setting: {0} from resource group: {1}", this.Name, this.ResourceGroupName),
                action: "Create/update an autoscale setting"))
            {
                AutoscaleSettingResource parameters = this.CreateAutoscaleSettingResource();

                // The result of this operation is operation (AutoscaleSettingResource) is being discarded for backwards compatibility
                var result = this.MonitorManagementClient.AutoscaleSettings.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName: this.ResourceGroupName, autoscaleSettingName: this.Name, parameters: parameters).Result;
                var response = new PSAddAutoscaleSettingOperationResponse()
                {
                    RequestId = result.RequestId,
                    StatusCode = result.Response != null ? result.Response.StatusCode : HttpStatusCode.OK,
                    SettingSpec = result.Body
                };

                WriteObject(response);
            }
        }

        private AutoscaleSettingResource CreateAutoscaleSettingResource()
        {
            bool enableSetting = !this.DisableSetting.IsPresent || !this.DisableSetting;

            if (this.InputObject != null)
            {

                // Receiving a single parameter with the whole spec for an autoscale setting
                var property = this.InputObject;

                if (property == null)
                {
                    throw new ArgumentException(ResourcesForAutoscaleCmdlets.PropertiresCannotBeNull);
                }

                this.Location = this.InputObject.Location;
                this.Name = this.InputObject.Name;

                // The semantics is if AutoscaleProfiles is given it will replace the existing Profiles
                this.AutoscaleProfile = this.AutoscaleProfile ?? property.Profiles.ToList();
                this.TargetResourceId = property.TargetResourceUri;

                enableSetting = !this.DisableSetting.IsPresent && property.Enabled.HasValue && property.Enabled.Value;

                // The semantics is if Notifications is given it will replace the existing ones
                this.Notification = this.Notification ?? (this.InputObject.Notifications != null ? this.InputObject.Notifications.ToList() : null);
            }

            return new AutoscaleSettingResource(
                profiles: this.AutoscaleProfile,
                location: this.Location,
                name: this.Name)
            {
                Enabled = enableSetting,
                TargetResourceUri = this.TargetResourceId,
                Notifications = this.Notification,
                Tags = this.InputObject != null ? new Dictionary<string, string>(this.InputObject.Tags) : new Dictionary<string, string>()
            };
        }
    }
}
