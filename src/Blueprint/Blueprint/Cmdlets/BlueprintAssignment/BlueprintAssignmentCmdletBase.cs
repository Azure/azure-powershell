using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Management.Blueprint.Models;
using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Authorization.Version2015_07_01.Models;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    public class BlueprintAssignmentCmdletBase : BlueprintCmdletBase
    {
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
        protected Assignment CreateAssignmentObject(string identityType, string userAssignedIdentity, string bpLocation, string blueprintId, PSLockMode? lockMode, Hashtable Parameters, Hashtable ResourceGroups, Hashtable SecureStringParameters)
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

            if (Parameters != null)
            {
                foreach (var key in Parameters.Keys)
                {
                    var value = new ParameterValue(Parameters[key], null);
                    localAssignment.Parameters.Add(key.ToString(), value);
                }
            }

            if (SecureStringParameters != null)
            {
                foreach (var key in SecureStringParameters.Keys)
                {
                    var kvp = SecureStringParameters[key] as Hashtable;
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

            if (ResourceGroups != null)
            {
                foreach (var key in ResourceGroups.Keys)
                {
                    var kvp = ResourceGroups[key] as Hashtable;
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
        protected void ThrowIfAssignmentExits(string scope, string name)
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
