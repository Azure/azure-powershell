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
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Internal.Subscriptions;
using System;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Management.Blueprint.Models;
using System.Collections.Generic;
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
    public class BlueprintCmdletBase : AzureRMCmdlet
    {
        #region Properties
        /// <summary>
        /// The blueprint client.
        /// </summary>
        private IBlueprintClient blueprintClient;
        public IBlueprintClient BlueprintClient
        {
            get
            {
                return blueprintClient = blueprintClient ?? new BlueprintClient(DefaultProfile.DefaultContext);
            }
            set => blueprintClient = value;
        }

        /// <summary>
        /// Blueprint client with delegating handler. The delegating handler is needed to get blueprint versions info.
        /// </summary>
        private IBlueprintClient blueprintClientWithVersion;
        public IBlueprintClient BlueprintClientWithVersion
        {
            get
            {
                return blueprintClientWithVersion = blueprintClientWithVersion ?? new BlueprintClient(DefaultProfile.DefaultContext, new ApiExpandHandler());
            }
            set => blueprintClientWithVersion = value;
        }

        /// <summary>
        /// Service client credentials client to hold credentials
        /// </summary>
        private ServiceClientCredentials clientCredentials;
        public ServiceClientCredentials ClientCredentials
        {
            get
            {
                return clientCredentials = clientCredentials ?? AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(DefaultProfile.DefaultContext,
                                               AzureEnvironment.Endpoint.ResourceManager);

            }
            set => clientCredentials = value;
        }

        /// <summary>
        /// Authorization client
        /// </summary>
        private IAuthorizationManagementClient authorizationManagementClient;

        public IAuthorizationManagementClient AuthorizationManagementClient
        {
            get
            {
                return authorizationManagementClient = authorizationManagementClient ?? AzureSession.Instance.ClientFactory.CreateArmClient<AuthorizationManagementClient>(DefaultProfile.DefaultContext, 
                                                           AzureEnvironment.Endpoint.ResourceManager);
            }
            set => authorizationManagementClient = value;
        }

        /// <summary>
        /// ARM client
        /// </summary>
        private IResourceManagementClient resourceManagerClient;
        public IResourceManagementClient ResourceManagerClient
        { 
            get
            {
                return resourceManagerClient = resourceManagerClient ?? new ResourceManagementClient(
                                                   DefaultProfile.DefaultContext.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                                                   ClientCredentials);
            }
            set => resourceManagerClient = value;
        }

        #endregion Properties

        #region Cmdlet Overrides
        protected override void WriteExceptionError(Exception ex)
        {
            var aggEx = ex as AggregateException;

            if (aggEx != null && aggEx.InnerExceptions != null)
            {
                foreach (var e in aggEx.Flatten().InnerExceptions)
                {
                    WriteExceptionError(e);
                }
                return;
            }

            base.WriteExceptionError(ex);
        }
        #endregion Cmdlet Overrides

        #region Protected Methods

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
        /// Register Blueprint RP with a subscription.
        /// </summary>
        /// <param name="subscriptionId"> SubscriptionId passed from the cmdlet</param>
        protected void RegisterBlueprintRp(string subscriptionId)
        {
            ResourceManagerClient.SubscriptionId = subscriptionId;
            var response = ResourceManagerClient.Providers.Register(BlueprintConstants.BlueprintProviderNamespace);

            if (response == null)
            {
                throw new KeyNotFoundException(string.Format(Resources.ResourceProviderRegistrationFailed, BlueprintConstants.BlueprintProviderNamespace));
            }
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

        /// <summary>
        /// Get management group ancestors for a given subscription
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        protected List<string> GetManagementGroupAncestorsForSubscription(string subscriptionId)
        {
            List<string> managementGroupAncestors = new List<string>();

            if (subscriptionId != null)
            {
                string result = GetManagementGroupAncestorsAsync(subscriptionId).GetAwaiter().GetResult();
                var resultJObjects = JObject.Parse(result);
                var managementGroupAncestorsObjects = resultJObjects["managementGroupAncestors"].Children().ToList();

                foreach (var mgObject in managementGroupAncestorsObjects)
                {
                    managementGroupAncestors.Add(mgObject.ToString());
                }
            }
            return managementGroupAncestors;
        }

        /// <summary>
        /// Task for get management group ancestors
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        private async Task<string> GetManagementGroupAncestorsAsync(string subscriptionId)
        {
            var url = string.Format(BlueprintConstants.MgAncestorsRequestUrlTemplate, subscriptionId);
            var httpRequest = new HttpRequestMessage();
            httpRequest.Method = new HttpMethod("GET");
            httpRequest.RequestUri = new Uri(url);

            HttpResponseMessage httpResponse = null;
            string responseContent = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    await ClientCredentials.ProcessHttpRequestAsync(httpRequest, new CancellationToken(false)).ConfigureAwait(false);
                    httpResponse = await client.SendAsync(httpRequest, new CancellationToken(false));

                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    // If we can't find the given subscription in the tenant, show error message.
                    if (statusCode == HttpStatusCode.NotFound)
                    {
                        CloudException cex = new CloudException(string.Format("Subscription Id '{0}' could not be found in current tenant.", subscriptionId));
                        throw cex;
                    }

                    responseContent = httpResponse.EnsureSuccessStatusCode().Content.ReadAsStringAsync().Result;
                }
                return responseContent;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        protected string FormatManagementGroupAncestorScope(string mg) => string.Format(BlueprintConstants.ManagementGroupScope, mg);

        #endregion Protected Methods
    }
}
