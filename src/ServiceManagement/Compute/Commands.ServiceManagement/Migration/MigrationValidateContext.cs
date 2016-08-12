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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Network
{
    public static class MigrationValidateContextHelper
    {
        public static MigrationValidateContext ConvertToContext(
           OperationStatusResponse operationResponse, NetworkMigrationValidationResponse validationResponse)
        {
            if (operationResponse == null) return null;

            var result = new MigrationValidateContext
            {
                OperationId = operationResponse.Id,
                Result = operationResponse.Status.ToString()
            };

            if (validationResponse == null || validationResponse.ValidationMessages == null) return result;

            var errorCount = validationResponse.ValidationMessages.Count;

            if (errorCount > 0)
            {
                result.ValidationMessages = new ValidationMessage[errorCount];

                for (int i = 0; i < errorCount; i++)
                {
                    result.ValidationMessages[i] = new ValidationMessage
                    {
                        ResourceName = validationResponse.ValidationMessages[i].ResourceName,
                        ResourceType = validationResponse.ValidationMessages[i].ResourceType,
                        Category = validationResponse.ValidationMessages[i].Category,
                        Message = validationResponse.ValidationMessages[i].Message,
                        VirtualMachineName = validationResponse.ValidationMessages[i].VirtualMachineName
                    };
                }
                result.Result = "Validation failed.  Please see ValidationMessages for details";
            }

            return result;
        }
    }
}
