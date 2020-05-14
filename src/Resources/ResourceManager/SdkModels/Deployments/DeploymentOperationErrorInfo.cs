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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

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

        #region Public Methods

        public void ProcessError(DeploymentOperation operation)
        {
            ErrorResponse error = DeserializeDeploymentOperationError(operation.Properties?.StatusMessage?.ToString());

            if (error != null)
            {    
                ErrorMessages.Add(error);
            }
        }
        #endregion

        #region Static Methods 
        /// <summary>
        /// A special method to deserialize the statusMessage. This method will be retired with new
        /// Resources API version.
        /// </summary>
        /// <param name="statusMessage"></param>
        /// <returns></returns>
        public static ErrorResponse DeserializeDeploymentOperationError(string statusMessage)
        {
            if (statusMessage == null)
            {
                return null;
            }

            dynamic dynamicStatusMessage = DeserializeDeploymentOperationStatusMessage(statusMessage);
            ErrorResponse error = null;

            try
            {
                if (dynamicStatusMessage?.error != null )
                {
                    error = JsonConvert.DeserializeObject<ErrorResponse>(dynamicStatusMessage.error.ToString());
                }
                else if (dynamicStatusMessage != null)
                {
                    error = JsonConvert.DeserializeObject<ErrorResponse>(dynamicStatusMessage.ToString());
                }
            }
            catch 
            {
                 error = new ErrorResponse(null, statusMessage);
            }

            return error;
        }

        private static dynamic DeserializeDeploymentOperationStatusMessage(string statusMessage)
        {
            dynamic dynamicStatusMessage = null;

            try
            {
                dynamicStatusMessage = JsonConvert.DeserializeObject(statusMessage);
            }
            catch
            {
                // Sometimes statusMessage is not a valid JSON(it can be a string when it's the outer generic error message)
                // In that case, we'll ignore the error.
            }

            return dynamicStatusMessage;
        }
        #endregion
    }
}