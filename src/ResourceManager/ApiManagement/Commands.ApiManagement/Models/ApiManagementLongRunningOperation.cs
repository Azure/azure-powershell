//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.Models
{
    using Microsoft.Azure.Management.ApiManagement.Models;
    using System;

    public class ApiManagementLongRunningOperation
    {
        private ApiManagementLongRunningOperation()
        {
        }

        internal static ApiManagementLongRunningOperation CreateLongRunningOperation(
            string operationName,
            LongRunningOperationResponse longRunningResponse)
        {
            if (string.IsNullOrWhiteSpace(operationName))
            {
                throw new ArgumentNullException("operationName");
            }

            if (longRunningResponse == null)
            {
                throw new ArgumentNullException("longRunningResponse");
            }

            var result = new ApiManagementLongRunningOperation
            {
                OperationName = operationName,
                OperationLink = longRunningResponse.OperationStatusLink,
                RetryAfter = TimeSpan.FromSeconds(longRunningResponse.RetryAfter),
                Status = longRunningResponse.Status,
                Error = longRunningResponse.Error != null
                    ? longRunningResponse.Error.Message
                    : null
            };

            var apiServiceLongRunnigResponse = longRunningResponse as ApiServiceLongRunningOperationResponse;
            if (apiServiceLongRunnigResponse != null && apiServiceLongRunnigResponse.Value != null)
            {
                result.ApiManagement = new PsApiManagement(apiServiceLongRunnigResponse.Value);
            }

            return result;
        }

        public string OperationName { get; private set; }

        public OperationStatus Status { get; private set; }

        public TimeSpan? RetryAfter { get; private set; }

        public string OperationLink { get; private set; }

        public PsApiManagement ApiManagement { get; private set; }

        public string Error { get; private set; }
    }
}