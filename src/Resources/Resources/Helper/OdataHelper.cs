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

using System;
using System.Net;
using System.Web;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    public static class OdataHelper
    {
        public static string GetFilterString<T>(Rest.Azure.OData.ODataQuery<T> odataQuery)
        {
            return HttpUtility.UrlDecode(odataQuery.Filter);
        }

        public static bool IsNotFoundException(this Common.MSGraph.Version1_0.DirectoryObjects.Models.OdataErrorException oe)
        {
            if (oe.Response != null && oe.Response.StatusCode == HttpStatusCode.NotFound &&
                oe.Body.Error != null && oe.Body.Error.Code != null && string.Equals(oe.Body.Error.Code, RequestResourceNotFound, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static bool IsAuthorizationDeniedException(this Common.MSGraph.Version1_0.DirectoryObjects.Models.OdataErrorException oe)
        {
            if (oe.Response != null && oe.Response.StatusCode == HttpStatusCode.Forbidden &&
                oe.Body.Error != null && oe.Body.Error.Code != null && string.Equals(oe.Body.Error.Code, AuthorizationDeniedException, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public const string RequestResourceNotFound = "Request_ResourceNotFound";
        public const string AuthorizationDeniedException = "Authorization_RequestDenied";
    }
}
