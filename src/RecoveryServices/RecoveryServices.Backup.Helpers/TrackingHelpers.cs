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
using System.Threading;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using RestAzureNS = Microsoft.Rest.Azure;
using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using SystemNet = System.Net;

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
        /// <param name="response">Response of the operation returned by the service.</param>
        /// <param name="getOpStatus">Delegate method to fetch the operation status of the operation.</param>
        /// <returns>Status of the operation once it completes.</returns>
        public static T GetOperationStatus<T>(RestAzureNS.AzureOperationResponse response,
            Func<string, RestAzureNS.AzureOperationResponse<T>> getOpStatus)
            where T : ServiceClientModel.OperationStatus
        {
            var operationId = response.Response.Headers.GetAzureAsyncOperationId();

            var opStatusResponse = getOpStatus(operationId);

            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            while (opStatusResponse.Body.Status ==
                ServiceClientModel.OperationStatusValues.InProgress)
            {
                if (!TestMockSupport.RunningMocked)
                {
                    TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);                    
                }
                if (String.Compare(testMode, "Record", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Thread.Sleep(5000);
                }

                opStatusResponse = getOpStatus(operationId);
            }

            opStatusResponse = getOpStatus(operationId);

            return opStatusResponse.Body;
        }

        /// <summary>
        /// Block to track the operation to completion.
        /// Waits till the status of the operation becomes something other than InProgress.
        /// </summary>
        /// <param name="response">Response of the operation returned by the service.</param>
        /// <param name="getOpStatus">Delegate method to fetch the operation status of the operation.</param>
        /// <returns>Operation status of the operation once it completes.</returns>
        public static T GetOperationStatus<T, S>(RestAzureNS.AzureOperationResponse<S> response,
            Func<string, RestAzureNS.AzureOperationResponse<T>> getOpStatus)
            where T : ServiceClientModel.OperationStatus
        {
            var operationId = response.Response.Headers.GetAzureAsyncOperationId();

            var opStatusResponse = getOpStatus(operationId);

            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            while (opStatusResponse.Body.Status ==
                ServiceClientModel.OperationStatusValues.InProgress)
            {
                if (!TestMockSupport.RunningMocked)
                {
                    TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);
                }
                if (String.Compare(testMode, "Record", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Thread.Sleep(5000);
                }
                opStatusResponse = getOpStatus(operationId);
            }

            opStatusResponse = getOpStatus(operationId);

            return opStatusResponse.Body;
        }

        /// <summary>
        /// Block to track the operation to completion.
        /// Waits till the HTTP status code of the operation becomes something other than Accepted.
        /// </summary>
        /// <param name="response">Response of the operation returned by the service.</param>
        /// <param name="getOpStatus">Delegate method to fetch the operation status of the operation.</param>
        /// <returns>Result of the operation once it completes.</returns>
        public static RestAzureNS.AzureOperationResponse GetOperationResult(
            RestAzureNS.AzureOperationResponse response,
            Func<string, RestAzureNS.AzureOperationResponse> getOpStatus)
        {
            var operationId = response.Response.Headers.GetOperationResultId();

            var opStatusResponse = getOpStatus(operationId);

            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            while (opStatusResponse.Response.StatusCode == SystemNet.HttpStatusCode.Accepted)
            {
                if (!TestMockSupport.RunningMocked)
                {
                    TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);
                }
                if (String.Compare(testMode, "Record", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Thread.Sleep(5000);
                }

                opStatusResponse = getOpStatus(operationId);
            }

            opStatusResponse = getOpStatus(operationId);

            return opStatusResponse;
        }

        /// <summary>
        /// Block to track the operation to completion.
        /// Waits till the status of the data-move operation is InProgress.
        /// </summary>
        /// <param name="response">Response of the operation returned by the service.</param>
        /// <param name="getOpStatus">Delegate method to fetch the operation status of the operation.</param>
        /// <returns>Result of the operation once it completes.</returns>
        public static RestAzureNS.AzureOperationResponse<T> GetOperationStatusDataMove<T>(
            RestAzureNS.AzureOperationResponse response,
            Func<string, RestAzureNS.AzureOperationResponse<T>> getOpStatus)
            where T: ServiceClientModel.OperationStatus
        {
            var operationId = response.Response.Headers.GetOperationResultId();
            var opStatusResponse = getOpStatus(operationId);

            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            while (opStatusResponse.Body.Status == "InProgress")
            {
                if (!TestMockSupport.RunningMocked)
                {
                    TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);                    
                }
                if (String.Compare(testMode, "Record", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Thread.Sleep(5000);
                }

                opStatusResponse = getOpStatus(operationId);
            }
            opStatusResponse = getOpStatus(operationId);
            
            return opStatusResponse;
        }

        /// <summary>
        /// Block to track the operation to completion.
        /// Waits till the HTTP status code of the operation becomes something other than Accepted.
        /// </summary>
        /// <param name="response">Response of the operation returned by the service.</param>
        /// <param name="getOpStatus">Delegate method to fetch the operation status of the operation.</param>
        /// <returns>Result of the operation once it completes.</returns>
        public static RestAzureNS.AzureOperationResponse<T> GetOperationResult<T>(
            RestAzureNS.AzureOperationResponse response,
            Func<string, RestAzureNS.AzureOperationResponse<T>> getOpStatus)
            where T: ServiceClientModel.ProtectionContainerResource
        {
            var operationId = response.Response.Headers.GetOperationResultId();
            var opStatusResponse = getOpStatus(operationId);

            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            while (opStatusResponse.Response.StatusCode == SystemNet.HttpStatusCode.Accepted)
            {
                if (!TestMockSupport.RunningMocked)
                {
                    TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);                    
                }
                if (String.Compare(testMode, "Record", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Thread.Sleep(5000);
                }

                opStatusResponse = getOpStatus(operationId);
            }
            opStatusResponse = getOpStatus(operationId);
            return opStatusResponse;
        }

        /// <summary>
        /// This method is used to fetch the prepare data move CorrelationId.
        /// </summary>
        /// <param name="response">Response of the operation returned by the service.</param>
        /// <param name="getCorrelationId">Delegate method to fetch the correlation id of the operation.</param>
        /// <returns>Result of the operation once it completes.</returns>
        public static PrepareDataMoveResponse GetCorrelationId(
            RestAzureNS.AzureOperationResponse response,
            Func<string, PrepareDataMoveResponse> getCorrelationId)            
        {
            var operationId = response.Response.Headers.GetAzureAsyncOperationId(); 
            var opStatusResponse = getCorrelationId(operationId);
            return opStatusResponse;
        }

        /// <summary>
        /// Block to track the operation to completion.
        /// Waits till the HTTP status code of the operation becomes something other than Accepted.
        /// </summary>
        /// <param name="response">Response of the operation returned by the service.</param>
        /// <param name="getOpStatus">Delegate method to fetch the operation status of the operation.</param>
        /// <returns>Result of the operation once it completes.</returns>
        public static RestAzureNS.AzureOperationResponse<T> GetOperationResult<T>(
            RestAzureNS.AzureOperationResponse<T> response,
            Func<string, RestAzureNS.AzureOperationResponse<T>> getOpStatus)
            where T: ServiceClientModel.ProtectionContainerResource
        {
            var operationId = response.Response.Headers.GetOperationResultId();

            var opStatusResponse = getOpStatus(operationId);
            
            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");
            while (opStatusResponse.Response.StatusCode == SystemNet.HttpStatusCode.Accepted)
            {
                if (!TestMockSupport.RunningMocked)
                {
                    TestMockSupport.Delay(_defaultSleepForOperationTracking * 1000);                    
                }
                if (String.Compare(testMode, "Record", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Thread.Sleep(5000);
                }

                opStatusResponse = getOpStatus(operationId);
            }

            opStatusResponse = getOpStatus(operationId);

            return opStatusResponse;
        }

        /// <summary>
        /// Retries request to URL for specified no. of tries in case of failure
        /// </summary>
        /// <param name="url"></param>
        /// <param name="retryCount"></param>
        /// <returns></returns>
        public static SystemNet.HttpWebResponse RetryHttpWebRequest(string url, int retryCount)
        {
            SystemNet.HttpWebRequest webRequest = (SystemNet.HttpWebRequest)SystemNet.WebRequest.Create(url);
            SystemNet.HttpWebResponse webResponse = (SystemNet.HttpWebResponse)webRequest.GetResponse();

            if ((SystemNet.HttpStatusCode.OK != webResponse.StatusCode) && (retryCount > 0))
            {
                return RetryHttpWebRequest(url, retryCount - 1);
            }
            else
            {
                return webResponse;
            }
        }
    }
}
