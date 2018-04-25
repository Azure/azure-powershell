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
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Removes the service principal.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmADServicePrincipal", SupportsShouldProcess = true, DefaultParameterSetName = ParameterSet.ObjectId),
        OutputType(typeof(PSADServicePrincipal))]
    public class RemoveAzureADServicePrincipalCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId, HelpMessage = "The service principal object id.")]
        [ValidateNotNullOrEmpty]
        [Alias("PrincipalId", "Id")]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationId, HelpMessage = "The service principal application id.")]
        [ValidateNotNullOrEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPN, HelpMessage = "The service principal name.")]
        [Alias("SPN")]
        [ValidateNotNullOrEmpty]
        public string ServicePrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayName, HelpMessage = "The display name of the service principal.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.InputObject, HelpMessage = "The service principal object.")]
        [ValidateNotNullOrEmpty]
        public PSADServicePrincipal InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObject, HelpMessage = "The application object whose service principal is being removed.")]
        [ValidateNotNullOrEmpty]
        public PSADApplication ApplicationObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                PSADServicePrincipal servicePrincipal = null;
                if (this.IsParameterBound(c => c.InputObject))
                {
                    ObjectId = InputObject.Id;
                }

                if (!this.IsParameterBound(c => c.ObjectId) && ObjectId != Guid.Empty)
                {
                    IEnumerable<PSADServicePrincipal> result = null;
                    if (this.IsParameterBound(c => c.ApplicationId) || this.IsParameterBound(c => c.ApplicationObject))
                    {
                        var appId = ApplicationObject == null ? ApplicationId.ToString() : ApplicationObject.ApplicationId.ToString();
                        Rest.Azure.OData.ODataQuery<ServicePrincipal> odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.AppId == appId);
                        result = ActiveDirectoryClient.FilterServicePrincipals(odataQuery);
                    }
                    else if (this.IsParameterBound(c => c.ServicePrincipalName) || this.IsParameterBound(c => c.DisplayName))
                    {
                        ADObjectFilterOptions options = new ADObjectFilterOptions()
                        {
                            SPN = ServicePrincipalName,
                            SearchString = DisplayName
                        };

                        result = ActiveDirectoryClient.FilterServicePrincipals(options);
                    }

                    if (result == null)
                    {
                        throw new ArgumentException(string.Format("Could not find a service principal with the name {0}.", ServicePrincipalName));
                    }

                    ObjectId = result.Select(s => s.Id).FirstOrDefault();
                }


                ConfirmAction(
                    Force.IsPresent,
                    string.Format(ProjectResources.RemovingServicePrincipal, ObjectId),
                    ProjectResources.RemoveServicePrincipal,
                    ObjectId.ToString(),
                    () => servicePrincipal = ActiveDirectoryClient.RemoveServicePrincipal(ObjectId));

                if (PassThru)
                {
                    WriteObject(servicePrincipal);
                }
            });
        }
    }
}