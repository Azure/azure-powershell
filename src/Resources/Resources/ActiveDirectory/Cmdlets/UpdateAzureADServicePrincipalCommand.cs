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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Updates an existing service principal.
    /// </summary>
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ADServicePrincipal", DefaultParameterSetName = ParameterSet.SpObjectIdWithDisplayName, SupportsShouldProcess = true), OutputType(typeof(PSADServicePrincipal))]
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ADServicePrincipal")]

    public class UpdateAzureADServicePrincipalCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpObjectIdWithDisplayName, HelpMessage = "The servicePrincipal object id.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServicePrincipalObjectId")]
        public string ObjectId { get; set; }

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

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpObjectIdWithDisplayName, HelpMessage = "The display name for the service principal.")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithDisplayName, HelpMessage = "The display name for the service principal.")]
        [Parameter(Mandatory = false, ParameterSetName = ParameterSet.InputObjectWithDisplayName, HelpMessage = "The display name for the service principal.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The homepage for the service principal.")]
        public string Homepage { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The identifier URI(s) for the service principal.")]
        public string[] IdentifierUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The key credential(s) for the service principal.")]
        public KeyCredential[] KeyCredential { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The password credential(s) for the service principal.")]
        public PasswordCredential[] PasswordCredential { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                var sp = InputObject;
                if (sp == null)
                {
                    IEnumerable<PSADServicePrincipal> result = null;
                    if (this.IsParameterBound(c => c.ApplicationId))
                    {
                        var appId = ApplicationId.ToString();
                        Rest.Azure.OData.ODataQuery<ServicePrincipal> odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.AppId == appId);
                        result = ActiveDirectoryClient.FilterServicePrincipals(odataQuery);
                    }
                    else
                    {
                        ADObjectFilterOptions options = new ADObjectFilterOptions()
                        {
                            SPN = ServicePrincipalName,
                            Id = ObjectId
                        };

                        result = ActiveDirectoryClient.FilterServicePrincipals(options);
                    }

                    if (result == null)
                    {
                        throw new InvalidOperationException("ServicePrincipal does not exist.");
                    }

                    sp = result.FirstOrDefault();
                }

                // Get AppObjectId
                var applicationObjectId = GetObjectIdFromApplicationId(sp.ApplicationId.ToString());
                ApplicationUpdateParameters parameters = new ApplicationUpdateParameters()
                {
                    DisplayName = DisplayName,
                    Homepage = Homepage,
                    IdentifierUris = (IdentifierUri == null) ? new string[] { } : IdentifierUri,
                    KeyCredentials = KeyCredential,
                    PasswordCredentials = PasswordCredential
                };

                if (ShouldProcess(target: sp.Id, action: string.Format("Updating properties on application associated with a service principal with object id '{0}'", sp.Id)))
                {
                    ActiveDirectoryClient.UpdateApplication(applicationObjectId, parameters);
                    WriteObject(ActiveDirectoryClient.FilterServicePrincipals(new ADObjectFilterOptions() { Id = applicationObjectId }).FirstOrDefault());
                }
            });
        }

        private string GetObjectIdFromApplicationId(string applicationId)
        {
            var odataQueryFilter = new Rest.Azure.OData.ODataQuery<Application>(a => a.AppId == applicationId);
            var app = ActiveDirectoryClient.GetApplicationWithFilters(odataQueryFilter).SingleOrDefault();
            if (app == null)
            {
                throw new InvalidOperationException(String.Format("Application with AppId '{0}' does not exist.", applicationId));
            }
            return app.ObjectId;
        }
    }
}
