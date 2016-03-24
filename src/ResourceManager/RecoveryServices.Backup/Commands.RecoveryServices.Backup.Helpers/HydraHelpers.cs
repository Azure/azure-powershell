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
using System.Collections.Specialized;
using System.Web;
using CmdletModel = Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class HydraConstants
    {
        public const string SkipToken = "skipToken";
    }

    public class HydraHelpers
    {
        public static string GetHydraProviderType(CmdletModel.ContainerType containerType)
        {
            string providerType = string.Empty;

            switch (containerType)
            {
                case CmdletModel.ContainerType.AzureVM:
                    providerType = ProviderType.AzureIaasVM.ToString();
                    break;
                default:
                    break;
            }

            return providerType;
        }

        public static string GetHydraProviderType(CmdletModel.WorkloadType workloadType)
        {
            string providerType = string.Empty;

            switch (workloadType)
            {
                case CmdletModel.WorkloadType.AzureVM:
                    providerType = ProviderType.AzureIaasVM.ToString();
                    break;
                default:
                    break;
            }

            return providerType;
        }

        public static void GetSkipTokenFromNextLink(string nextLink, out string skipToken)
        {
            if (nextLink != null)
            {
                Uri uriObj = new Uri(nextLink);
                // This is sent by service and we don't expect this to be encoded.
                // TODO: Need to make sure during testing that this is in fact true.
                NameValueCollection queryParams = HttpUtility.ParseQueryString(uriObj.Query);
                if (queryParams.Get(HydraConstants.SkipToken) != null)
                {
                    skipToken = queryParams.Get(HydraConstants.SkipToken);
                }
                else
                {
                    skipToken = null;
                }
            }
            else
            {
                skipToken = null;
            }
        }

        public static string GetHydraContainerType(CmdletModel.ContainerType containerType)
        {
            string hydraContainerType = string.Empty;

            switch (containerType)
            {
                case CmdletModel.ContainerType.AzureVM:
                    hydraContainerType = ContainerType.IaasVMContainer.ToString();
                    break;
                default:
                    break;
            }

            return hydraContainerType;
        }

        public static string GetHydraWorkloadType(CmdletModel.WorkloadType workloadType)
        {
            string hydraWorkloadType = string.Empty;

            switch (workloadType)
            {
                case CmdletModel.WorkloadType.AzureVM:
                    hydraWorkloadType = WorkloadType.VM.ToString();
                    break;
                default:
                    break;
            }

            return hydraWorkloadType;
        }
    }
}
