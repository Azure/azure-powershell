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

using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;

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
        public static T GetOperationStatus<T>(Microsoft.Rest.Azure.AzureOperationResponse response,
            Func<string, AzureOperationResponse<T>> getOpStatus)
            where T : ServiceClientModel.OperationStatus
        {
            var operationId = response.Response.Headers.GetAzureAsyncOperationId();

            var opStatusResponse = getOpStatus(operationId);

            while (opStatusResponse.Body.Status == ServiceClientModel.OperationStatusValues.InProgress)
            {
                TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);

                opStatusResponse = getOpStatus(operationId);
            }

            opStatusResponse = getOpStatus(operationId);

            return opStatusResponse.Body;
        }

        /// <summary>
        /// Block to track the operation to completion.
        /// Waits till the status of the operation becomes something other than InProgress.
        /// </summary>
        /// <param name="statusUrlLink"></param>
        /// <param name="serviceClientMethod"></param>
        /// <returns></returns>
        public static T GetOperationStatus<T, S>(Microsoft.Rest.Azure.AzureOperationResponse<S> response,
            Func<string, AzureOperationResponse<T>> getOpStatus)
            where T : ServiceClientModel.OperationStatus
        {
            var operationId = response.Response.Headers.GetAzureAsyncOperationId();

            var opStatusResponse = getOpStatus(operationId);

            while (opStatusResponse.Body.Status == ServiceClientModel.OperationStatusValues.InProgress)
            {
                TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);

                opStatusResponse = getOpStatus(operationId);
            }

            opStatusResponse = getOpStatus(operationId);

            return opStatusResponse.Body;
        }

        public static Microsoft.Rest.Azure.AzureOperationResponse GetOperationResult(Microsoft.Rest.Azure.AzureOperationResponse response,
            Func<string, Microsoft.Rest.Azure.AzureOperationResponse> getOpStatus)
        {
            var operationId = response.Response.Headers.GetOperationResultId();

            var opStatusResponse = getOpStatus(operationId);

            while (opStatusResponse.Response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);

                opStatusResponse = getOpStatus(operationId);
            }

            opStatusResponse = getOpStatus(operationId);

            return opStatusResponse;
        }
    }
}
