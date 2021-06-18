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

using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Creates a new AD application.
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ADApplication", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams), OutputType(typeof(PSADApplication))]
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ADApplication")]
    public class UpdateAzureADApplicationCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams, HelpMessage = "The application object id.")]
        [ValidateNotNullOrEmpty]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams, HelpMessage = "The application id.")]
        [ValidateNotNullOrEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.InputObjectWithUpdateParams, HelpMessage = "The application object.")]
        [ValidateNotNullOrEmpty]
        public PSADApplication InputObject { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.InputObjectWithUpdateParams,
            HelpMessage = "The display name for the application.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "The URL to the application's homepage.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "The URL to the application's homepage.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.InputObjectWithUpdateParams,
            HelpMessage = "The URL to the application's homepage.")]
        [ValidateNotNullOrEmpty]
        public string HomePage { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "The URIs that identify the application.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "The URIs that identify the application.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.InputObjectWithUpdateParams,
            HelpMessage = "The URIs that identify the application.")]
        [ValidateNotNullOrEmpty]
        [Alias("IdentifierUris")]
        public string[] IdentifierUri { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.InputObjectWithUpdateParams,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        [Alias("ReplyUrls")]
        public string[] ReplyUrl { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.InputObjectWithUpdateParams,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        public bool AvailableToOtherTenants { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.InputObject))
                {
                    ObjectId = InputObject.ObjectId;
                }
                else if (this.IsParameterBound(c => c.ApplicationId))
                {
                    ObjectId = ActiveDirectoryClient.GetAppObjectIdFromApplicationId(ApplicationId);
                }

                ApplicationUpdateParameters parameters = new ApplicationUpdateParameters
                {
                    DisplayName = DisplayName,
                    Homepage = HomePage,
                    IdentifierUris = (IdentifierUri == null) ? new string[] { } : IdentifierUri,
                    ReplyUrls = ReplyUrl,
                    AvailableToOtherTenants = this.IsParameterBound(c => c.AvailableToOtherTenants) ? AvailableToOtherTenants : (bool?)null
                };

                if (ShouldProcess(target: ObjectId, action: string.Format("Updating an application with object id '{0}'", ObjectId)))
                {
                    ActiveDirectoryClient.UpdateApplication(ObjectId, parameters);
                    WriteObject(ActiveDirectoryClient.GetApplication(ObjectId));
                }
            });
        }
    }
}
