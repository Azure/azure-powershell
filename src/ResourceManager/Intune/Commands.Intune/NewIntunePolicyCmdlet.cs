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

namespace Commands.Intune
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Resources;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.WindowsAzure.Commands.Common;
    using Newtonsoft.Json.Linq;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;

    /// <summary>
    /// A cmdlet that creates a new azure resource.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmIntunePolicy", SupportsShouldProcess = true, DefaultParameterSetName = NewIntunePolicyCmdlet.TypeBasedParameterSet), OutputType(typeof(PSObject))]
    public sealed class NewIntunePolicyCmdlet : ResourceManipulationCmdletBase
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The policy kind.")]
        [ValidateNotNullOrEmpty]
        public PolicyTypeEnum Kind { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The friendlyName of the policy.")]
        [ValidateNotNullOrEmpty]
        public string FriendlyName { get; set; }

        /// <summary>
        /// The tenant level parameter set.
        /// </summary>
        internal const string TypeBasedParameterSet = "Create a policy.";

        /// <summary>
        /// Gets or sets the property object.
        /// </summary>
        [Alias("PropertyObject")]
        [Parameter(Mandatory = false, HelpMessage = "A hash table which represents resource properties.")]
        [ValidateNotNullOrEmpty]
        public PSObject Properties { get; set; }


        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            var resourceId = this.GetPolicyResourceId();
            this.ConfirmAction(
                this.Force,
                "Are you sure you want to create the following resource: "+ resourceId,
                "Creating the resource...",
                resourceId,
                () =>
                {
                    var apiVersion = "2015-01-08-alpha";
                    var resourceBody = this.GetResourceBody();

                    var operationResult = this.GetResourcesClient()
                        .PutResource(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            resource: resourceBody,
                            cancellationToken: this.CancellationToken.Value,
                            odataQuery: this.ODataQuery)
                        .Result;

                    var managementUri = this.GetResourcesClient()
                      .GetResourceManagementRequestUri(
                          resourceId: resourceId,
                          apiVersion: apiVersion,
                          odataQuery: this.ODataQuery);

                    var activity = string.Format("PUT {0}", managementUri.PathAndQuery);
                    var result = this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: true)
                        .WaitOnOperation(operationResult: operationResult);

                    this.TryConvertToResourceAndWriteObject(result);
                });
        }

        private string GetPolicyResourceId()
        {
            return string.Format(
                "/providers/Microsoft.Intune/locations/{0}/{1}/{2}",
                LocationHelper.GetLocation(this.GetResourcesClient(), this.CancellationToken.Value),
                PolicyTypeEnum.Android == this.Kind ? "androidPolicies" : "iosPolicies",
                Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Gets the resource body from the parameters.
        /// </summary>
        private JToken GetResourceBody()
        {
            return this.GetPolicyPutPayload(this.Kind).ToJToken();

        }

        /// <summary>
        /// Get the patch request payload for given policy type.
        /// </summary>
        private Dictionary<string, object> GetPolicyPutPayload(PolicyTypeEnum policyType, string apiVersion = "2015-01-08-alpha")
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("accessRecheckOfflineTimeout", "PT1H1M");
            properties.Add("accessRecheckOnlineTimeout", "PT1H1M");
            properties.Add("appSharingFromLevel", "allApps");
            properties.Add("appSharingToLevel", "allApps");
            properties.Add("authentication", "required");
            properties.Add("clipboardSharingLevel", "allApps");
            properties.Add("dataBackup", "allow");
            properties.Add("pinNumRetry", 6);
            properties.Add("deviceCompliance", "enable");
            properties.Add("fileSharingSaveAs", "allow");
            properties.Add("offlineWipeTimeout", "P1D");
            properties.Add("pin", "required");

            switch (policyType)
            {
                case PolicyTypeEnum.iOS:
                    {
                        properties.Add("description", "iosOneCreated");
                        properties.Add("friendlyName", this.FriendlyName);
                        properties.Add("touchId", "enable");

                        if (!apiVersion.StartsWith("2015-01-05"))
                        {
                            properties.Add("managedBrowser", "required");
                            properties.Add("fileEncryptionLevel", "deviceLocked");
                        }

                        break;
                    }
                case PolicyTypeEnum.Android:
                    {
                        properties.Add("description", "androidOneCreated");
                        properties.Add("friendlyName", this.FriendlyName);
                        properties.Add("screenCapture", "allow");

                        if (!apiVersion.StartsWith("2015-01-05"))
                        {
                            properties.Add("managedBrowser", "required");
                            properties.Add("fileEncryption", "notRequired");
                        }
                        break;
                    }
                default:
                    {
                        throw new Exception("Invalid PolicyType" + policyType);
                    }
            }

            Dictionary<string, object> entityObject = new Dictionary<string, object>();
            entityObject.Add("properties", properties);

            return entityObject;
        }
        
    }
    /// <summary>
    /// PolicyType
    /// </summary>
    public enum PolicyTypeEnum
    {
        iOS,
        Android
    }
}