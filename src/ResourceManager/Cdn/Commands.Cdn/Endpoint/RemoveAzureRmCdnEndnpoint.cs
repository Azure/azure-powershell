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

using System;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Models.Endpoint;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;

namespace Microsoft.Azure.Commands.Cdn.Endpoint
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmCdnEndpoint", ConfirmImpact = ConfirmImpact.High, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureCdnEndpoint : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Azure Cdn endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Azure Cdn profile name.")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group of the Azure Cdn Profile")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The endpoint.")]
        [ValidateNotNull]
        public PSEndpoint CdnEndpoint { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Return object if specified.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ObjectParameterSet)
            {
                ResourceGroupName = CdnEndpoint.ResourceGroupName;
                ProfileName = CdnEndpoint.ProfileName;
                EndpointName = CdnEndpoint.Name;
            }

            try
            {
                CdnManagementClient.Endpoints.Get(EndpointName, ProfileName, ResourceGroupName);
            }
            catch (AggregateException exception)
            {
                var errorResponseException = exception.InnerException as ErrorResponseException;
                if (errorResponseException == null)
                {
                    throw;
                }

                if (errorResponseException.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    throw new PSArgumentException(string.Format(
                        Resources.Error_DeleteNonExistingEndpoint,
                        EndpointName,
                        ProfileName,
                        ResourceGroupName));
                }
            }

            if(!ShouldProcess(string.Format(Resources.Confirm_RemoveEndpoint, EndpointName, ProfileName, ResourceGroupName)))
            {
                return;
            }

            CdnManagementClient.Endpoints.DeleteIfExists(EndpointName, ProfileName, ResourceGroupName);

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}
