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
using System.Linq;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Updates an exisitng service principal.
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureRmADServicePrincipal", DefaultParameterSetName = ParameterSet.SpObjectIdWithDisplayName, SupportsShouldProcess = true), OutputType(typeof(PSADServicePrincipal))]
    [Alias("Set-AzureRmADServicePrincipal")]

    public class UpdateAzureADServicePrincipalCommand: ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpObjectIdWithDisplayName, HelpMessage = "The servicePrincipal object id.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServicePrincipalObjectId")]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpApplicationIdWithDisplayName, HelpMessage = "The service principal application id.")]
        [ValidateNotNullOrEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithDisplayName, HelpMessage = "The servicePrincipal name.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.InputObjectWithDisplayName, HelpMessage = "The service principal object.")]
        [ValidateNotNullOrEmpty]
        public PSADServicePrincipal InputObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpObjectIdWithDisplayName, HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithDisplayName, HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ParameterSetName = ParameterSet.InputObjectWithDisplayName, HelpMessage = "The display name for the application")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.InputObject))
                {
                    ServicePrincipalName = InputObject.ServicePrincipalNames?.FirstOrDefault();
                    ObjectId = InputObject.Id;
                }

                Rest.Azure.OData.ODataQuery<ServicePrincipal> odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>();
                if (this.IsParameterBound(c => c.ObjectId))
                {
                    var objectId = ObjectId.ToString();
                    odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.ObjectId == objectId);
                }
                else if (this.IsParameterBound(c => c.ApplicationId))
                {
                    var appId = ApplicationId.ToString();
                    odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.AppId == appId);
                }
                else if (this.IsParameterBound(c => c.ServicePrincipalName))
                {
                    odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.ServicePrincipalNames.Contains(ServicePrincipalName));
                }

                var sp = InputObject;
                if (sp == null)
                {
                    // At max 1 SP can be returned with SPN and Id options
                    sp = ActiveDirectoryClient.FilterServicePrincipals(odataQuery).FirstOrDefault();

                    if (sp == null)
                    {
                        throw new InvalidOperationException("ServicePrincipal does not exist.");
                    }
                }

                // Get AppObjectId
                var applicationObjectId = ActiveDirectoryClient.GetObjectIdFromApplicationId(sp.ApplicationId);
                ApplicationUpdateParameters parameters = new ApplicationUpdateParameters()
                {
                    DisplayName = DisplayName
                };

                if (ShouldProcess(target: sp.Id.ToString(), action: string.Format("Updating properties on application associated with a service principal with object id '{0}'", sp.Id)))
                {
                    ActiveDirectoryClient.UpdateApplication(applicationObjectId, parameters);
                    WriteObject(ActiveDirectoryClient.FilterServicePrincipals(odataQuery).FirstOrDefault());
                }
            });
        }
    }
}
