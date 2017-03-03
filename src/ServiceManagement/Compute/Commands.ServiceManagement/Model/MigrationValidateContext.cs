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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Management.Compute.Models;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Microsoft.WindowsAzure.Management.Storage.Models;

    public class MigrationValidateContext
    {
        public ValidationMessage [] ValidationMessages { get; set; }
        public string OperationId { get; set; }
        public string Result { get; set; }
    }

    public class ValidationMessage
    {
        public string ResourceType { get; set; }
        public string ResourceName { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
        public string VirtualMachineName { get; set; }
    }

    public class MigrationValidateContextHelper
    {
        public static MigrationValidateContext ConvertToContext(OperationStatusResponse operationResponse,
            XrpMigrationValidateDeploymentResponse validationResponse)
        {
            if (operationResponse == null) return null;

            var result = new MigrationValidateContext();
            bool errorOccurred = false;
            bool warningOccurred = false;

            if (validationResponse == null || validationResponse.ValidateDeploymentMessages == null)
            {
                return getResult(result, operationResponse, noMessage: true);
            };

            int messageCount = validationResponse.ValidateDeploymentMessages.Count;

            for (int i = 0; i < messageCount; i++)
            {
                var validateMessage = validationResponse.ValidateDeploymentMessages[i];

                result.ValidationMessages[i] = new ValidationMessage
                {
                    ResourceName = validateMessage.ResourceName,
                    ResourceType = validateMessage.ResourceType,
                    Category = validateMessage.Category,
                    Message = validateMessage.Message,
                    VirtualMachineName = validateMessage.VirtualMachineName
                };

                setFlag(validateMessage.Category, ref errorOccurred, ref warningOccurred);
            }

            return getResult(result, operationResponse, errorOccurred, warningOccurred); ;
        }

        public static MigrationValidateContext ConvertToContext(OperationStatusResponse operationResponse,
            NetworkMigrationValidationResponse validationResponse)
        {
            if (operationResponse == null) return null;

            var result = new MigrationValidateContext();
            bool errorOccurred = false;
            bool warningOccurred = false;

            if (validationResponse == null || validationResponse.ValidationMessages == null)
            {
                return getResult(result, operationResponse, noMessage: true);
            };

            int messageCount = validationResponse.ValidationMessages.Count;

            for (int i = 0; i < messageCount; i++)
            {
                var validateMessage = validationResponse.ValidationMessages[i];

                result.ValidationMessages[i] = new ValidationMessage
                {
                    ResourceName = validateMessage.ResourceName,
                    ResourceType = validateMessage.ResourceType,
                    Category = validateMessage.Category,
                    Message = validateMessage.Message,
                    VirtualMachineName = validateMessage.VirtualMachineName
                };

                setFlag(validateMessage.Category, ref errorOccurred, ref warningOccurred);
            }

            return getResult(result, operationResponse, errorOccurred, warningOccurred); ;
        }

        public static MigrationValidateContext ConvertToContext(OperationStatusResponse operationResponse,
            XrpMigrationValidateStorageResponse validationResponse)
        {
            if (operationResponse == null) return null;

            var result = new MigrationValidateContext();
            bool errorOccurred = false;
            bool warningOccurred = false;

            if (validationResponse == null || validationResponse.ValidateStorageMessages == null)
            {
                return getResult(result, operationResponse, noMessage:true);
            };

            int messageCount = validationResponse.ValidateStorageMessages.Count;

            for (int i = 0; i < messageCount; i++)
            {
                var validateMessage = validationResponse.ValidateStorageMessages[i];

                result.ValidationMessages[i] = new ValidationMessage
                {
                    ResourceName = validateMessage.ResourceName,
                    ResourceType = validateMessage.ResourceType,
                    Category = validateMessage.Category,
                    Message = validateMessage.Message,
                    VirtualMachineName = validateMessage.VirtualMachineName
                };

                setFlag(validateMessage.Category, ref errorOccurred, ref warningOccurred);
            }

            return getResult(result, operationResponse, errorOccurred, warningOccurred);
        }

        private static MigrationValidateContext getResult(MigrationValidateContext result, OperationStatusResponse operationResponse,
            bool errorOccurred = false, bool warningOccurred = false, bool noMessage = false)
        {
            result.OperationId = operationResponse.Id;
            result.Result = operationResponse.Status.ToString();

            if (noMessage)
            {
                result.Result = "There are no ValidationMessages.";
            }
            else if (errorOccurred)
            {
                result.Result = "Validation Failed. Please see ValidationMessages object for additional details.";
            }
            else if (warningOccurred)
            {
                result.Result = "Validation Passed with warnings. Please see ValidationMessages object for a list of resources that will be migrated and additional detail on the warnings.";
            }
            else
            {
                result.Result = "Validation Passed. Please see ValidationMessages object for a list of resources that will be migrated.";
            }
            return result;
        }

        private static void setFlag(string category, ref bool errorOccurred, ref bool warningOccurred)
        {
            if (category.Equals("Error", System.StringComparison.InvariantCultureIgnoreCase))
            {
                errorOccurred = true;
            }
            else if (category.Equals("Warning", System.StringComparison.InvariantCultureIgnoreCase))
            {
                warningOccurred = true;
            }
        }
    }
}
