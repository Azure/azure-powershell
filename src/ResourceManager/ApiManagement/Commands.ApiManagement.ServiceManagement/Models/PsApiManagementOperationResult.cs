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
    public class PsApiManagementOperationResult
    {
        public string Id { get; set; }

        public string ResultInfo { get; set; }

        public TenantConfigurationState State { get; set; }

        public DateTime Started { get; set; }

        public DateTime Updated { get; set; }

        public ErrorBody Error { get; set; }

        public PsApiManagementOperationResult()
        {

        }

        public PsApiManagementOperationResult(OperationResultContract operationResult)
            : this()
        {
            if (operationResult == null)
            {
                throw new ArgumentNullException("operationResult");
            }

            Id = operationResult.IdPath;
            Error = operationResult.Error != null ? new ErrorBody(operationResult.Error) : null;
            ResultInfo = operationResult.ResultInfo;
            Started = operationResult.Started;
            Updated = operationResult.Updated;
            State = ToTenantConfigurationState(operationResult.Status);
        }

        internal TenantConfigurationState ToTenantConfigurationState(AsyncOperationState state)
        {
            TenantConfigurationState tenantState;
            switch (state)
            {
                case AsyncOperationState.Started:
                    tenantState = TenantConfigurationState.Started;
                    break;
                case AsyncOperationState.InProgress:
                    tenantState = TenantConfigurationState.InProgress;
                    break;
                case AsyncOperationState.Succeeded:
                    tenantState = TenantConfigurationState.Succeeded;
                    break;
                case AsyncOperationState.Failed:
                    tenantState = TenantConfigurationState.Failed;
                    break;
                default: throw new NotSupportedException("Invalid State :" + state);
            }

            return tenantState;
        }
    }
}