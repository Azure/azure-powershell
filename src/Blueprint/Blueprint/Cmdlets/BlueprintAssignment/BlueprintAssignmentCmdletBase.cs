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

using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Authorization.Version2015_07_01.Models;
using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using static Microsoft.Azure.Commands.Blueprint.Common.BlueprintConstants;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    public class BlueprintAssignmentCmdletBase : BlueprintCmdletBase
    {
        #region Parameters
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignmentByFile, Mandatory = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.BlueprintAssignmentName)]
        [ValidatePattern("^[0-9a-zA-Z_-]*$", Options = RegexOptions.Compiled | RegexOptions.CultureInvariant)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignmentByFile, Mandatory = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = true, ValueFromPipeline = true, HelpMessage = ParameterHelpMessages.BlueprintObject)]
        [ValidateNotNull]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignmentByFile, Mandatory = false, HelpMessage = ParameterHelpMessages.SubscriptionIdToAssign)]
        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.SubscriptionIdToAssign)]
        [ValidateNotNullOrEmpty]
        public string[] SubscriptionId { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Location)]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Resources/resourceGroups")]
        public string Location { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, HelpMessage = ParameterHelpMessages.SystemAssignedIdentity)]
        public SwitchParameter SystemAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, HelpMessage = ParameterHelpMessages.UserAssignedIdentity)]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, HelpMessage = ParameterHelpMessages.LockFlag)]
        public PSLockMode? Lock { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, HelpMessage = ParameterHelpMessages.SecureString)]
        [ValidateNotNullOrEmpty]
        public Hashtable SecureStringParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public Hashtable ResourceGroupParameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignment, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = ParameterHelpMessages.Parameters)]
        [ValidateNotNull]
        public Hashtable Parameter { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.CreateBlueprintAssignmentByFile, Mandatory = false, HelpMessage = ParameterHelpMessages.SecureString)]
        [ValidateNotNullOrEmpty]
        public string AssignmentFile { get; set; }

        #endregion Parameters

        /// <summary>
        /// Creates an assignment object to be submitted
        /// </summary>
        /// <param name="identityType"></param>
        /// <param name="bpLocation"></param>
        /// <param name="blueprintId"></param>
        /// <param name="lockMode"></param>
        /// <param name="Parameters"></param>
        /// <param name="ResourceGroups"></param>
        /// <returns></returns>
        protected Assignment CreateAssignmentObject(string identityType, string userAssignedIdentity, string bpLocation, string blueprintId, PSLockMode? lockMode, Hashtable parameters, Hashtable resourceGroups, Hashtable secureStringParameters)
        {
            Dictionary<string, UserAssignedIdentity> userAssignedIdentities = null;

            if (userAssignedIdentity != null)
            {
                userAssignedIdentities = new Dictionary<string, UserAssignedIdentity>()
                {
                    { userAssignedIdentity, new UserAssignedIdentity() }
                };
            }

            var localAssignment = new Assignment
            {
                Identity = new ManagedServiceIdentity { Type = identityType, UserAssignedIdentities = userAssignedIdentities },
                Location = bpLocation,
                BlueprintId = blueprintId,
                Locks = new AssignmentLockSettings { Mode = lockMode == null ? PSLockMode.None.ToString() : lockMode.ToString() },
                Parameters = new Dictionary<string, ParameterValueBase>(),
                ResourceGroups = new Dictionary<string, ResourceGroupValue>()
            };

            if (parameters != null)
            {
                foreach (var key in parameters.Keys)
                {
                    var value = new ParameterValue(parameters[key], null);
                    localAssignment.Parameters.Add(key.ToString(), value);
                }
            }

            if (secureStringParameters != null)
            {
                foreach (var key in secureStringParameters.Keys)
                {
                    var kvp = secureStringParameters[key] as Hashtable;
                    string keyVaultId = null;
                    string secretName = null;
                    string secretVersion = null;

                    foreach (var k in kvp.Keys)
                    {
                        var paramKey = k.ToString();

                        if (string.Equals(paramKey, "keyVaultId", StringComparison.InvariantCultureIgnoreCase))
                        {
                            keyVaultId = kvp[k].ToString();
                        }
                        else if (string.Equals(paramKey, "secretName", StringComparison.InvariantCultureIgnoreCase))
                        {
                            secretName = kvp[k].ToString();
                        }
                        else if (string.Equals(paramKey, "secretVersion", StringComparison.InvariantCultureIgnoreCase))
                        {
                            secretVersion = kvp[k].ToString();
                        }
                    }

                    var secretValue = new SecretReferenceParameterValue(new SecretValueReference(new KeyVaultReference(keyVaultId), secretName, secretVersion));
                    localAssignment.Parameters.Add(key.ToString(), secretValue);
                }
            }

            if (resourceGroups != null)
            {
                foreach (var key in resourceGroups.Keys)
                {
                    var kvp = resourceGroups[key] as Hashtable;
                    string name = null;
                    string location = null;

                    foreach (var k in kvp.Keys)
                    {
                        var rgKey = k.ToString();

                        if (string.Equals(rgKey, "name", StringComparison.InvariantCultureIgnoreCase))
                        {
                            name = kvp[k].ToString();
                        }

                        if (string.Equals(rgKey, "location", StringComparison.InvariantCultureIgnoreCase))
                        {
                            location = kvp[k].ToString();
                        }
                    }

                    var rgv = new ResourceGroupValue(name, location);
                    localAssignment.ResourceGroups.Add(key.ToString(), rgv);
                }
            }

            return localAssignment;
        }

        /// <summary>
        /// Get Blueprint SPN object Id for this tenant
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="assignmentName"></param>
        /// <returns>"spnObjectId"</returns>
        protected string GetBlueprintSpn(string scope, string assignmentName)
        {
            var response = BlueprintClient.GetBlueprintSpnObjectId(scope, assignmentName);

            if (response == null)
            {
                throw new KeyNotFoundException(Resources.BlueprintSpnObjectIdNotFound);
            }

            return response.ObjectId;
        }

        /// <summary>
        /// Assign owner role to Blueprint RP (so that we can do deployments)
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="spnObjectId"></param>
        protected void AssignOwnerPermission(string subscriptionId, string spnObjectId)
        {
            string scope = string.Format(BlueprintConstants.SubscriptionScope, subscriptionId);

            var filter = new Rest.Azure.OData.ODataQuery<RoleAssignmentFilter>();
            filter.SetFilter(a => a.AssignedTo(spnObjectId));

            var roleAssignmentList = AuthorizationManagementClient.RoleAssignments.ListForScopeAsync(scope, filter).GetAwaiter().GetResult();

            var roleAssignment = roleAssignmentList?
                .Where(ra => ra.Id.EndsWith(BlueprintConstants.OwnerRoleDefinitionId))
                .FirstOrDefault();

            if (roleAssignment != null) return;

            var roleAssignmentParams = new RoleAssignmentProperties(
                roleDefinitionId: BlueprintConstants.OwnerRoleDefinitionId, principalId: spnObjectId);

            try
            {
                AuthorizationManagementClient.RoleAssignments.CreateAsync(scope: scope,
                    roleAssignmentName: Guid.NewGuid().ToString(),
                    parameters: new RoleAssignmentCreateParameters(roleAssignmentParams))
                    .GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                // ignore if it already exists
                if (ex is CloudException cex && cex.Response.StatusCode != HttpStatusCode.Conflict)
                {
                    throw;
                }
            }
        }
        protected void ThrowIfAssignmentExists(string scope, string name)
        {
            PSBlueprintAssignment assignment = null;

            try
            {
                assignment = BlueprintClient.GetBlueprintAssignment(scope, name);
            }
            catch (Exception ex)
            {
                if (ex is CloudException cex && cex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // if exception is for a reason other than .NotFound, pass it to the caller.
                    throw;
                }
            }

            if (assignment != null)
            {
                throw new Exception(string.Format(Resources.AssignmentExists, name, scope));
            }
        }

        protected void ThrowIfAssignmentNotExist(string scope, string name)
        {
            PSBlueprintAssignment assignment = null;

            try
            {
                assignment = BlueprintClient.GetBlueprintAssignment(scope, name);
            }
            catch (Exception ex)
            {
                if (ex is CloudException cex && cex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // if exception is for a reason other than .NotFound, pass it to the caller.
                    throw;
                }
            }

            if (assignment == null)
            {
                throw new Exception(string.Format(Resources.AssignmentNotExist, name, scope));
            }
        }
    }
}
