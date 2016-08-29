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

using Microsoft.Azure.Management.ApiManagement.SmapiModels;
using System;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models
{
    public class TenantConfigurationLongRunningOperation
    {
        public string OperationName { get; private set; }

        public OperationStatus Status { get; private set; }

        public TimeSpan? RetryAfter { get; private set; }

        public string OperationLink { get; set; }

        public PsApiManagementOperationResult OperationResult { get; private set; }

        internal static TenantConfigurationLongRunningOperation CreateLongRunningOperation(
            string operationName,
            TenantLongRunningOperationResponse longRunningResponse)
        {
            if (string.IsNullOrWhiteSpace(operationName))
            {
                throw new ArgumentNullException("operationName");
            }

            if (longRunningResponse == null)
            {
                throw new ArgumentNullException("longRunningResponse");
            }

            var result = new TenantConfigurationLongRunningOperation
            {
                OperationName = operationName,
                OperationLink = longRunningResponse.OperationStatusLink ?? string.Empty,
                RetryAfter = TimeSpan.FromSeconds(longRunningResponse.RetryAfter)
            };

            var tenantConfigurationLongRunningResponse = longRunningResponse as TenantConfigurationLongRunningOperationResponse;
            if (tenantConfigurationLongRunningResponse != null && tenantConfigurationLongRunningResponse.OperationResult != null)
            {
                result.OperationResult = new PsApiManagementOperationResult(tenantConfigurationLongRunningResponse.OperationResult);
            }

            return result;
        }
    }
}