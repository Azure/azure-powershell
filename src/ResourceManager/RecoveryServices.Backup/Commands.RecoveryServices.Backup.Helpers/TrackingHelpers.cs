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

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers
{
    public class TrackingHelpers
    {
        /// <summary>
        /// Defines the time (in seconds) to sleep in between calls while tracking operations
        /// </summary>
        private const int _defaultSleepForOperationTracking = 5;

        /// <summary>
        /// Block to track the operation to completion.
        /// Waits till the status of the operation becomes something other than InProgress.
        /// </summary>
        /// <param name="statusUrlLink"></param>
        /// <param name="serviceClientMethod"></param>
        /// <returns></returns>
        public static BackUpOperationStatusResponse WaitForOperationCompletionUsingStatusLink(
            string statusUrlLink,
            Func<string, BackUpOperationStatusResponse> serviceClientMethod)
        {
            // using this directly because it doesn't matter which function we use.
            // return type is same and currently we are using it in only two places.
            // protected item and policy.
            BackUpOperationStatusResponse response = serviceClientMethod(statusUrlLink);

            while (
                response != null &&
                response.OperationStatus != null &&
                response.OperationStatus.Status == OperationStatusValues.InProgress.ToString())
            {
                Logger.Instance.WriteDebug(
                    "Tracking operation completion using status link: " + statusUrlLink);
                TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);
                response = serviceClientMethod(statusUrlLink);
            }

            return response;
        }
    }
}
