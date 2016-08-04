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

using Microsoft.Azure.Commands.ActiveDirectory.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Creates a new AD application.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmADApplication", SupportsShouldProcess = true), OutputType(typeof(PSADApplication))]
    public class SetAzureADApplicationCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams, HelpMessage = "The application object id.")]
        [ValidateNotNullOrEmpty]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams, HelpMessage = "The application id.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "The display name for the application.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "The URL to the applicationâ€™s homepage.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "The URL to the applicationâ€™s homepage.")]
        [ValidateNotNullOrEmpty]
        public string HomePage { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "The URIs that identify the application.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "The URIs that identify the application.")]
        [ValidateNotNullOrEmpty]
        public string[] IdentifierUris { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "Specifies the URLs that user tokens are sent to for sign in, or the redirect URIs that OAuth 2.0 authorization codes and access tokens are sent to.")]
        public string[] ReplyUrls { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectIdWithUpdateParams,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdWithUpdateParams,
            HelpMessage = "True if the application is shared with other tenants; otherwise, false.")]
        public bool AvailableToOtherTenants { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (!string.IsNullOrEmpty(ApplicationId))
                {
                    ObjectId = ActiveDirectoryClient.GetObjectIdFromApplicationId(ApplicationId);
                }

                ApplicationUpdateParameters parameters = new ApplicationUpdateParameters
                {
                    DisplayName = DisplayName,
                    Homepage = HomePage,
                    IdentifierUris = IdentifierUris,
                    ReplyUrls = ReplyUrls,
                    AvailableToOtherTenants = AvailableToOtherTenants
                };

                if (ShouldProcess(target: ObjectId, action: string.Format("Updating an application with object id '{0}'", ObjectId)))
                {
                    ActiveDirectoryClient.UpdateApplication(ObjectId, parameters);
                }
            });
        }
    }
}