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
using System;
using System.Linq;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Updates an exisitng service principal.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmADServicePrincipal", DefaultParameterSetName = ParameterSet.SpObjectIdWithDisplayName, SupportsShouldProcess = true)]

    public class SetAzureADServicePrincipalCommand: ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpObjectIdWithDisplayName, HelpMessage = "The servicePrincipal object id.")]
        [ValidateNotNullOrEmpty]
        [Alias("ServicePrincipalObjectId")]
        public string ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithDisplayName, HelpMessage = "The servicePrincipal name.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SpObjectIdWithDisplayName, HelpMessage = "The display name for the application.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPNWithDisplayName, HelpMessage = "The display name for the application.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        public override void ExecuteCmdlet()
        {
            ADObjectFilterOptions options = new ADObjectFilterOptions
            {
                SPN = ServicePrincipalName,
                Id = ObjectId
            };

            ExecutionBlock(() =>
            {
                // At max 1 SP can be returned with SPN and Id options
                var sp = ActiveDirectoryClient.FilterServicePrincipals(options).FirstOrDefault();

                if (sp == null)
                {
                    throw new InvalidOperationException("ServicePrincipal does not exist.");
                }

                // Get AppObjectId
                string applicationObjectId = ActiveDirectoryClient.GetObjectIdFromApplicationId(sp.ApplicationId.ToString());

                if (!string.IsNullOrEmpty(DisplayName))
                {
                    ApplicationUpdateParameters parameters = new ApplicationUpdateParameters()
                    {
                        DisplayName = DisplayName
                    };

                    if (ShouldProcess(target: sp.Id.ToString(), action: string.Format("Updating properties on application associated with a service principal with object id '{0}'", sp.Id)))
                    {
                        ActiveDirectoryClient.UpdateApplication(applicationObjectId, parameters);
                    }
                }
            });
        }
    }
}
