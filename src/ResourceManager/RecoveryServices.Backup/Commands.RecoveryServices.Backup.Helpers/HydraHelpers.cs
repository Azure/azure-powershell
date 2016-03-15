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

using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Web;
using System.Collections.Specialized;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class HydraConstants
    {
        public const string SkipToken = "skipToken";
    }

    public class HydraHelpers
    {
        public static string GetHydraProviderType(ContainerType containerType)
        {
            string providerType = string.Empty;

            switch (containerType)
            {
                case ContainerType.AzureVM:
                    providerType = ProviderType.AzureIaasVM.ToString();
                    break;
                default:
                    break;
            }

            return providerType;
        }

        public static string GetHydraProviderType(WorkloadType workloadType)
        {
            string providerType = string.Empty;

            switch (workloadType)
            {
                case WorkloadType.AzureVM:
                    providerType = ProviderType.AzureIaasVM.ToString();
                    break;
                default:
                    break;
            }

            return providerType;
        }

        public static string GetDateTimeStringForService(DateTime date)
        {
            // our service expects date time to be serialized in the following format
            // we have to use english culture because our user might be running 
            // PS in another culture and our service can't understand it.
            DateTimeFormatInfo dateFormat = new CultureInfo("en-US").DateTimeFormat;
            return date.ToString("yyyy-MM-dd hh:mm:ss tt", dateFormat);
        }

        public static void GetSkipTokenFromNextLink(string url, out string nextLink)
        {
            Uri uriObj = new Uri(url);
            // This is sent by service and we don't expect this to be encoded.
            // TODO: Need to make sure during testing that this is in fact true.
            NameValueCollection queryParams = HttpUtility.ParseQueryString(uriObj.Query);
            if (queryParams.Get(HydraConstants.SkipToken) != null)
            {
                nextLink = queryParams.Get(HydraConstants.SkipToken);
            }
            else
            {
                nextLink = null;
            }
        }
    }
}
