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

namespace Microsoft.Azure.Commands.Common.MSGraph.Version1_0
{
    using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications;
    using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Applications.Models;
    using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Groups;
    using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Groups.Models;
    using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users;
    using Microsoft.Azure.Commands.Common.MSGraph.Version1_0.Users.Models;
    using Microsoft.Rest.Azure.OData;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public static partial class MicrosoftGraphClientExtensions
    {

        private static string FormatFilterString<T>(ODataQuery<T> odataQuery)
        {
            return HttpUtility.UrlDecode(odataQuery.Filter);
        }

        public static IEnumerable<MicrosoftGraphServicePrincipal> FilterServicePrincipals(this IMicrosoftGraphClient client, MicrosoftObjectFilterOptions options)
        {
            List<MicrosoftGraphServicePrincipal> servicePrincipals = new List<MicrosoftGraphServicePrincipal>();
            MicrosoftGraphServicePrincipal servicePrincipal = null;

            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    servicePrincipal = client.ServicePrincipals.GetServicePrincipal(options.Id);
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (servicePrincipal != null)
                {
                    servicePrincipals.Add(servicePrincipal);
                }
            }
            else if (!string.IsNullOrEmpty(options.SPN))
            {
                try
                {
                    var odataQuery = new ODataQuery<MicrosoftGraphServicePrincipal>(s => s.ServicePrincipalNames.Contains(options.SPN));
                    servicePrincipal = client.ServicePrincipals.ListServicePrincipal(filter: FormatFilterString(odataQuery)).Value.FirstOrDefault();
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (servicePrincipal != null)
                {
                    servicePrincipals.Add(servicePrincipal);
                }
            }
            else
            {
                ODataQuery<MicrosoftGraphServicePrincipal> odataQuery = null;
                if (!string.IsNullOrEmpty(options.SearchString) && options.SearchString.EndsWith("*"))
                {
                    options.SearchString = options.SearchString.TrimEnd('*');
                    odataQuery = new ODataQuery<MicrosoftGraphServicePrincipal>(s => s.DisplayName.StartsWith(options.SearchString));
                }
                else
                {
                    odataQuery = new ODataQuery<MicrosoftGraphServicePrincipal>(s => s.DisplayName == options.SearchString);
                }

                return client.ServicePrincipals.ListServicePrincipal(filter: FormatFilterString(odataQuery)).Value;
            }

            return servicePrincipals;
        }

        public static IEnumerable<MicrosoftGraphServicePrincipal> FilterServicePrincipals(this IMicrosoftGraphClient client, ODataQuery<MicrosoftGraphServicePrincipal> odataQuery)
        {
            return client.ServicePrincipals.ListServicePrincipal(filter: FormatFilterString(odataQuery)).Value;
        }

        public static IEnumerable<MicrosoftGraphUser> FilterUsers(this IMicrosoftGraphClient client, MicrosoftObjectFilterOptions options)
        {
            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    MicrosoftGraphUser user = client.Users.GetUser(options.Id);
                    if (user != null)
                    {
                        return new List<MicrosoftGraphUser> { user };
                    }
                }
                catch {  /* The group does not exist, ignore the exception */ }
            }
            else if (!string.IsNullOrEmpty(options.UPN) || !string.IsNullOrEmpty(options.Mail))
            {
                IList<MicrosoftGraphUser> result = null;
                try
                {
                    string upnOrMail = options.UPN ?? options.Mail;
                    var odataQuery = new ODataQuery<MicrosoftGraphUser>();
                    if (!string.IsNullOrEmpty(options.UPN))
                    {
                        odataQuery.SetFilter(u => u.UserPrincipalName == upnOrMail);
                    }
                    else
                    {
                        odataQuery.SetFilter(u => u.Mail == upnOrMail);
                    }
                    result = client.Users.ListUser(filter: FormatFilterString(odataQuery)).Value;
                }
                catch {  /* The user does not exist, ignore the exception. */ }

                if (result != null)
                {
                    return result.Select(u => u);
                }
            }
            else
            {
                ODataQuery<MicrosoftGraphUser> odataQuery = null;
                if (!string.IsNullOrEmpty(options.SearchString) && options.SearchString.EndsWith("*"))
                {
                    options.SearchString = options.SearchString.TrimEnd('*');
                    odataQuery = new ODataQuery<MicrosoftGraphUser>(u => u.DisplayName.StartsWith(options.SearchString));
                }
                else
                {
                    odataQuery = new ODataQuery<MicrosoftGraphUser>(u => u.DisplayName == options.SearchString);
                }

                return client.Users.ListUser(filter: FormatFilterString(odataQuery)).Value;
            }

            return new List<MicrosoftGraphUser>();
        }

        public static IEnumerable<MicrosoftGraphUser> FilterUsers(this IMicrosoftGraphClient client, ODataQuery<MicrosoftGraphUser> odataQuery)
        {
            return client.Users.ListUser(filter: FormatFilterString(odataQuery)).Value;
        }

        public static IEnumerable<MicrosoftGraphGroup> FilterGroups(this IMicrosoftGraphClient client, MicrosoftObjectFilterOptions options)
        {
            if (!string.IsNullOrEmpty(options.Id))
            {
                try
                {
                    // use GetObjectsByObjectId to handle Redirects in the CSP scenario
                    MicrosoftGraphGroup group = client.Groups.GetGroup(options.Id);
                    if (group != null)
                    {
                        return new List<MicrosoftGraphGroup> { group };
                    }
                }
                catch {  /* The group does not exist, ignore the exception */ }
            }
            else
            {
                ODataQuery<MicrosoftGraphGroup> odataQuery = null;
                if (options.Mail != null)
                {
                    odataQuery = new ODataQuery<MicrosoftGraphGroup>(g => g.Mail == options.Mail);
                }
                else
                {
                    if (!string.IsNullOrEmpty(options.SearchString) && options.SearchString.EndsWith("*"))
                    {
                        options.SearchString = options.SearchString.TrimEnd('*');
                        odataQuery = new ODataQuery<MicrosoftGraphGroup>(g => g.DisplayName.StartsWith(options.SearchString));
                    }
                    else
                    {
                        odataQuery = new ODataQuery<MicrosoftGraphGroup>(g => g.DisplayName == options.SearchString);
                    }
                }

                return client.Groups.ListGroup(filter: FormatFilterString(odataQuery)).Value;
            }

            return new List<MicrosoftGraphGroup>();
        }

        public static IEnumerable<MicrosoftGraphGroup> FilterGroups(this IMicrosoftGraphClient client, ODataQuery<MicrosoftGraphGroup> odataQuery)
        {
            return client.Groups.ListGroup(filter: FormatFilterString(odataQuery)).Value;
        }
    }
}