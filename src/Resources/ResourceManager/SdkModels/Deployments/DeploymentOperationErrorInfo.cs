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

using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    /// <summary>
    /// This class processes failed deployment operations.
    /// </summary>
    public class DeploymentOperationErrorInfo
    {
        public const int MaxErrorsToShow = 3;

        public DeploymentOperationErrorInfo()
        {
            ErrorMessages = new List<ErrorResponse>();
        }

        public List<ErrorResponse> ErrorMessages { get; private set; }

        public void ProcessError(DeploymentOperation operation)
        {
            ErrorResponse error = operation.Properties?.StatusMessage?.Error;

            if (error != null)
            {    
                ErrorMessages.Add(error);
            }
        }
    }
}