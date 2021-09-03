//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.


namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.Properties;
    using ResourceManager.Common.ArgumentCompleters;
    using System.Globalization;
    using System.Management.Automation;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagement", SupportsShouldProcess = true)]
    [OutputType(typeof(bool), ParameterSetName = new[] { InDeletedParameterSetName, ResourceGroupParameterSetName })]
    public class RemoveAzureApiManagement : AzureApiManagementCmdletBase
    {
        internal const string InDeletedParameterSetName = "InDeleted";
        internal const string ResourceGroupParameterSetName = "DeleteByResourceGroup";

        [Parameter(
            ParameterSetName = ResourceGroupParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management service exists.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = ResourceGroupParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of API Management service.")]
        [Parameter(
            ParameterSetName = InDeletedParameterSetName,
            Mandatory = true,
            HelpMessage = "Name of API Management service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = InDeletedParameterSetName,
            Mandatory = true,
            HelpMessage = "Flag only meant to be used for Deleted ApiManagement Service")]
        public bool InRemovedState { get; set; }

        [Parameter(
            ParameterSetName = InDeletedParameterSetName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Location where want to Get API Management.")]
        [LocationCompleter("Microsoft.ApiManagement/service")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            var actionDescription = string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.RemoveAzureApiManagementDescription,
                    Name);

            var actionWarning = string.Format(
                CultureInfo.CurrentCulture,
                Resources.RemoveAzureApiManagementWarning,
                Name);

            // Do nothing if force is not specified and user cancelled the operation
            if (!ShouldProcess(
                    actionDescription,
                    actionWarning,
                    Resources.ShouldProcessCaption))
            {
                return;
            }

            if (ParameterSetName.Equals(InDeletedParameterSetName) && InRemovedState)
            {
                ExecuteCmdLetWrap(
                    () => Client.PurgeApiManagement(Name, Location),
                    PassThru.IsPresent);
            }
            else
            {
                ExecuteCmdLetWrap(
                    () => Client.DeleteApiManagement(ResourceGroupName, Name),
                    PassThru.IsPresent);
            }
        }
    }
}
