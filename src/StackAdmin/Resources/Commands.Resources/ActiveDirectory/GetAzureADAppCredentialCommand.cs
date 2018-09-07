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

using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Gets AD application credentials.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmADAppCredential", DefaultParameterSetName = ParameterSet.ApplicationObjectId), OutputType(typeof(PSADCredential))]
    public class GetAzureADAppCredentialCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectId, HelpMessage = "The application object id.")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationId, HelpMessage = "The application id.")]
        [ValidateNotNullOrEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayName, HelpMessage = "The display name of the application.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObject, HelpMessage = "The application object.")]
        [ValidateNotNullOrEmpty]
        public PSADApplication ApplicationObject { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.ApplicationObject))
                {
                    ObjectId = ApplicationObject.ObjectId;
                }
                else if (this.IsParameterBound(c => c.ApplicationId))
                {
                    ObjectId = ActiveDirectoryClient.GetAppObjectIdFromApplicationId(ApplicationId);
                }
                else if (this.IsParameterBound(c => c.DisplayName))
                {
                    ObjectId = ActiveDirectoryClient.GetAppObjectIdFromDisplayName(DisplayName);
                }

                WriteObject(ActiveDirectoryClient.GetAppCredentials(ObjectId), enumerateCollection: true);
            });
        }
    }
}
