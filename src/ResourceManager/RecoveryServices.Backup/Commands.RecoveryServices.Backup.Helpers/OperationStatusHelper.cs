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
using HydraModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.HydraAdapter;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class OperationStatusHelper
    {
        public const double defaultOperationStatusRetryTimeInSec = 5.0;

        public static BackUpOperationStatusResponse TrackOperationStatus(BaseRecoveryServicesJobResponse jobResponse, HydraAdapter hydraAdapter)
        {
            var response = hydraAdapter.GetProtectedItemOperationStatusByURL(jobResponse.AzureAsyncOperation);
            while (response.OperationStatus.Status == HydraModel.OperationStatusValues.InProgress)
            {
                response = hydraAdapter.GetProtectedItemOperationStatusByURL(jobResponse.AzureAsyncOperation);
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(defaultOperationStatusRetryTimeInSec));
            }

            return response;
        }
    }
}
