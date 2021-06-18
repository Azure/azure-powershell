// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Cdn.AfdHelpers;
using Microsoft.Azure.Commands.Cdn.AfdModels;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Cdn.AfdSecret
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorCdnSecret", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzFrontDoorCdnSecret : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdProfileName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceId, ParameterSetName = ResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.ResourceGroupName, ParameterSetName = FieldsParameterSet)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdSecretObject, ParameterSetName = ObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAfdSecret Secret { get; set; }

        [Parameter(Mandatory = true, HelpMessage = HelpMessageConstants.AfdSecretName, ParameterSetName = FieldsParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SecretName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = HelpMessageConstants.PassThruParameter)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case ObjectParameterSet:
                    this.ObjectParameterSetCmdlet();
                    break;

                case ResourceIdParameterSet:
                    this.ResourceIdParameterSetCmdlet();
                    break;
            }

            ConfirmAction(AfdResourceProcessMessage.AfdSecretDeleteMessage, this.SecretName, this.DeleteAfdSecret);
        }

        private void DeleteAfdSecret()
        {
            try
            {
                this.CdnManagementClient.Secrets.Delete(this.ResourceGroupName, this.ProfileName, this.SecretName);
            }
            catch (AfdErrorResponseException errorResponseException)
            {
                throw new PSArgumentException(errorResponseException.Response.Content);
            }

            if (this.PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }

        private void ObjectParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdSecretResourceId = new ResourceIdentifier(this.Secret.Id);

            this.ProfileName = parsedAfdSecretResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdSecretResourceId.ResourceGroupName;
            this.SecretName = parsedAfdSecretResourceId.ResourceName;
        }

        private void ResourceIdParameterSetCmdlet()
        {
            ResourceIdentifier parsedAfdSecretResourceId = new ResourceIdentifier(this.ResourceId);

            this.ProfileName = parsedAfdSecretResourceId.GetResourceName("profiles");
            this.ResourceGroupName = parsedAfdSecretResourceId.ResourceGroupName;
            this.SecretName = parsedAfdSecretResourceId.ResourceName;
        }
    }
}
