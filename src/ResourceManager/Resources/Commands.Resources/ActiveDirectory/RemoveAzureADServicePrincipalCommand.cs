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
using System;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Removes the service principal.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADServicePrincipal", SupportsShouldProcess = true), 
        OutputType(typeof(PSADServicePrincipal))]
    public class RemoveAzureADServicePrincipalCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId,
                  HelpMessage = "The service principal object id.")]
        [Alias("PrincipalId")]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }
        
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                PSADServicePrincipal servicePrincipal = null;

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(ProjectResources.RemovingServicePrincipal, ObjectId.ToString()),
                    ProjectResources.RemoveServicePrincipal,
                    ObjectId.ToString(),
                    () => servicePrincipal = ActiveDirectoryClient.RemoveServicePrincipal(ObjectId.ToString()));

                if (PassThru)
                {
                    WriteObject(servicePrincipal);
                }
            });
        }
    }
}