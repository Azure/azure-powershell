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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.DirectoryObjects;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Groups;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Groups.Models;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users.Models;
using Microsoft.Rest.Azure;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    public class ActiveDirectoryClient
    {
        public IMicrosoftGraphClient GraphClient { get; private set; }

        /// <summary>
        /// Creates new ActiveDirectoryClient using WindowsAzureSubscription.
        /// </summary>
        /// <param name="context"></param>
        public ActiveDirectoryClient(IAzureContext context)
        {
            GraphClient = AzureSession.Instance.ClientFactory.CreateArmClient<MicrosoftGraphClient>(
                context, AzureEnvironment.ExtendedEndpoint.MicrosoftGraphUrl);
            (GraphClient as MicrosoftGraphClient).TenantID = context.Tenant.Id;
        }

        /// <summary>
        /// Gets a single directory object (user, service principal or group) according to filter.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public PSADObject GetADObject(ADObjectFilterOptions options)
        {
            PSADObject result = null;
            Debug.Assert(options != null);
            if (IsSet(options.Mail, options.UPN, options.Id))
            {
                result = FilterUsers(options).FirstOrDefault();
            }

            if (result == null && IsSet(options.SPN, options.Id))
            {
                result = FilterServicePrincipals(options).FirstOrDefault();
            }

            if (result == null && IsSet(options.Mail, options.Id))
            {
                result = FilterGroups(options).FirstOrDefault();
            }

            return result;
        }

        private static bool IsSet(params string[] strings)
        {
            return strings.Any(s => !string.IsNullOrEmpty(s));
        }

        private static string Normalize(string s)
        {
            return string.IsNullOrEmpty(s) ? null : s;
        }

        public IEnumerable<PSADServicePrincipal> FilterServicePrincipals(Rest.Azure.OData.ODataQuery<MicrosoftGraphServicePrincipal> odataQuery, int first = int.MaxValue, int skip = 0)
        {
            var response = GraphClient.ServicePrincipals.ListServicePrincipal(
                consistencyLevel: "eventual",
                filter: OdataHelper.GetFilterString(odataQuery)
            );
            return response.Value.Select(s => s.ToPSADServicePrincipal());
        }

        public IEnumerable<PSADServicePrincipal> FilterServicePrincipals(ADObjectFilterOptions options, int first = int.MaxValue, int skip = 0)
        {
            List<PSADServicePrincipal> servicePrincipals = new List<PSADServicePrincipal>();
            MicrosoftGraphServicePrincipal servicePrincipal = null;
            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    servicePrincipal = GraphClient.ServicePrincipals.GetServicePrincipal(options.Id);
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (servicePrincipal != null)
                {
                    servicePrincipals.Add(servicePrincipal.ToPSADServicePrincipal());
                }
            }
            else if (!string.IsNullOrEmpty(options.SPN))
            {
                try
                {
                    var odataQuery = new Rest.Azure.OData.ODataQuery<MicrosoftGraphServicePrincipal>(s => s.ServicePrincipalNames.Contains(options.SPN));
                    // todo: doesn't support paging
                    servicePrincipal = GraphClient.ServicePrincipals.ListServicePrincipal(filter: OdataHelper.GetFilterString(odataQuery)).Value.FirstOrDefault();
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (servicePrincipal != null)
                {
                    servicePrincipals.Add(servicePrincipal.ToPSADServicePrincipal());
                }
            }
            else
            {
                Rest.Azure.OData.ODataQuery<MicrosoftGraphServicePrincipal> odataQuery = null;
                if (!string.IsNullOrEmpty(options.SearchString) && options.SearchString.EndsWith("*"))
                {
                    options.SearchString = options.SearchString.TrimEnd('*');
                    odataQuery = new Rest.Azure.OData.ODataQuery<MicrosoftGraphServicePrincipal>(s => s.DisplayName != null && s.DisplayName.StartsWith(options.SearchString));
                }
                else
                {
                    odataQuery = new Rest.Azure.OData.ODataQuery<MicrosoftGraphServicePrincipal>(s => s.DisplayName == options.SearchString);
                }

                return FilterServicePrincipals(odataQuery, first, skip);
            }

            return servicePrincipals;
        }

        public IEnumerable<PSADUser> FilterUsers(ADObjectFilterOptions options, int first = int.MaxValue, int skip = 0)
        {
            if (!string.IsNullOrEmpty(options.Id))
            {
                MicrosoftGraphUser user = null;
                try
                {
                    user = GraphClient.Users.GetUser(Normalize(options.Id));
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (user != null)
                {
                    return new List<PSADUser> { user.ToPSADUser() };
                }
            }
            else if (!string.IsNullOrEmpty(options.UPN) || !string.IsNullOrEmpty(options.Mail))
            {
                IList<MicrosoftGraphUser> result = null;
                try
                {
                    string upnOrMail = Normalize(options.UPN) ?? Normalize(options.Mail);
                    var odataQuery = new Rest.Azure.OData.ODataQuery<MicrosoftGraphUser>();
                    if (!string.IsNullOrEmpty(options.UPN))
                    {
                        odataQuery.SetFilter(u => u.UserPrincipalName == upnOrMail);
                    }
                    else
                    {
                        odataQuery.SetFilter(u => u.Mail == upnOrMail);
                    }
                    result = GraphClient.Users.ListUser(
                        "eventual",
                        filter: OdataHelper.GetFilterString(odataQuery)
                    ).Value;
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (result != null)
                {
                    return result.Select(u => u.ToPSADUser());
                }
            }
            else
            {
                Rest.Azure.OData.ODataQuery<MicrosoftGraphUser> odataQuery = null;
                if (!string.IsNullOrEmpty(options.SearchString) && options.SearchString.EndsWith("*"))
                {
                    options.SearchString = options.SearchString.TrimEnd('*');
                    odataQuery = new Rest.Azure.OData.ODataQuery<MicrosoftGraphUser>(u => u.DisplayName != null && u.DisplayName.StartsWith(options.SearchString));
                }
                else
                {
                    odataQuery = new Rest.Azure.OData.ODataQuery<MicrosoftGraphUser>(u => u.DisplayName == options.SearchString);
                }

                return GraphClient.Users.ListUser(
                    consistencyLevel: "eventual",
                    filter: OdataHelper.GetFilterString(odataQuery)
                ).Value.Select(u => u.ToPSADUser());
            }

            return new List<PSADUser>();
        }

        /// <summary>
        /// Get object by ObjectId
        /// </summary>
        public PSADObject GetObjectByObjectId(string objectId)
        {
            return GraphClient.DirectoryObjects.GetDirectoryObject(objectId)?.ToPSADObject();
        }

        /// <summary>
        /// The graph getobjectsbyObjectId API supports 1000 objectIds per call.
        /// Due to this we are batching objectIds by chunk size of 1000 per APi call if it exceeds 1000
        /// </summary>
        public List<PSADObject> GetObjectsByObjectIds(List<string> objectIds)
        {
            // todo: do we want to use 1000 as batch count in msgraph API?
            List<PSADObject> result = new List<PSADObject>();
            IList<Common.MSGraph.Version1_0.DirectoryObjects.Models.MicrosoftGraphDirectoryObject> adObjects;
            int objectIdBatchCount;
            const int batchCount = 1000;
            for (int i = 0; i < objectIds.Count; i += batchCount)
            {
                if ((i + batchCount) > objectIds.Count)
                {
                    objectIdBatchCount = objectIds.Count - i;
                }
                else
                {
                    objectIdBatchCount = batchCount;
                }
                List<string> objectIdBatch = objectIds.GetRange(i, objectIdBatchCount);
                try
                {
                    adObjects = GraphClient.DirectoryObjects.GetByIds(
                        new Common.MSGraph.Version1_0.DirectoryObjects.Models.Body()
                        {
                            Ids = objectIdBatch
                        }).Value;
                    result.AddRange(adObjects.Select(o => o.ToPSADObject()));
                }
                catch (Common.MSGraph.Version1_0.DirectoryObjects.Models.OdataErrorException)
                {
                    // Swallow OdataErroException
                }
            }
            return result;
        }

        public IEnumerable<PSADGroup> FilterGroups(ADObjectFilterOptions options, int first = int.MaxValue, int skip = 0)
        {
            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    // use GetObjectsByObjectId to handle Redirects in the CSP scenario
                    PSADGroup group = GetObjectByObjectId(options.Id) as PSADGroup;
                    if (group != null)
                    {
                        return new List<PSADGroup> { group };
                    }
                }
                catch {  /* The group does not exist, ignore the exception */ }

                return new List<PSADGroup>();
            }
            else if (options.Mail != null)
            {
                Rest.Azure.OData.ODataQuery<MicrosoftGraphGroup> odataQuery = new Rest.Azure.OData.ODataQuery<MicrosoftGraphGroup>(g => g.Mail == options.Mail);
                return GraphClient.Groups.ListGroup(filter: OdataHelper.GetFilterString(odataQuery)).Value.Select(g => g.ToPSADGroup());
            }
            else
            {
                Rest.Azure.OData.ODataQuery<MicrosoftGraphGroup> odataQuery = null;
                if (!string.IsNullOrEmpty(options.SearchString) && options.SearchString.EndsWith("*"))
                {
                    options.SearchString = options.SearchString.TrimEnd('*');
                    odataQuery = new Rest.Azure.OData.ODataQuery<MicrosoftGraphGroup>(g => g.DisplayName.StartsWith(options.SearchString));
                }
                else
                {
                    odataQuery = new Rest.Azure.OData.ODataQuery<MicrosoftGraphGroup>(g => g.DisplayName == options.SearchString);
                }

                return GraphClient.Groups.ListGroup(filter: OdataHelper.GetFilterString(odataQuery)).Value.Select(g => g.ToPSADGroup());
            }
        }

        public string GetObjectId(ADObjectFilterOptions options)
        {
            if (options != null && options.Id != null)
            {
                return options.Id;
            }
            else
            {
                PSADObject adObj = GetADObject(options);

                if (adObj == null)
                {
                    throw new KeyNotFoundException("The provided information does not map to an AD object id.");
                }

                return adObj.Id;
            }
        }
    }
}