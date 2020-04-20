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
    /// This class processes failed deployment operations and formats the resulting errors to be outputed
    /// at the end of a deployment.
    /// </summary>
    public class DeploymentOperationErrorInfo
    {
        private const int MaxErrorsToShow = 3;

        public DeploymentOperationErrorInfo()
        {
            ErrorMessages = new List<string>();
            RequestId = string.Empty;
        }

        public List<string> ErrorMessages { get; private set; }

        public string RequestId { get; private set; }

        #region Public Methods

        public void ProcessError(DeploymentOperation operation)
        {
            ErrorResponse error = DeserializeDeploymentOperationError(operation.Properties?.StatusMessage?.ToString());

            if (error != null)
            {
                var sb = new StringBuilder();

                sb.AppendLine().Append(GetErrorMessageWithDetails(error));

                // if there is target information let's add that to the error string
                if (operation.Properties.TargetResource?.ResourceType != null && operation.Properties.TargetResource?.ResourceName != null)
                {
                    sb.AppendLine().AppendFormat(ProjectResources.DeploymentOperationTargetInfoInErrror, operation.Properties.TargetResource.ResourceType,operation.Properties.TargetResource.ResourceName);                    
                }
                
                ErrorMessages.Add(sb.ToString());
            }            
        }

        public string GetErrorMessagesWithOperationId(string deploymentName = null)
        {
            if (ErrorMessages.Count == 0)
                return String.Empty;

            var sb = new StringBuilder();

            int maxErrors = ErrorMessages.Count > MaxErrorsToShow
               ? MaxErrorsToShow
               : ErrorMessages.Count;

            sb.AppendFormat(ProjectResources.DeploymentOperationOuterError, deploymentName, maxErrors, ErrorMessages.Count);
            sb.Append(string.Join(Environment.NewLine, ErrorMessages.Take(maxErrors)));
            sb.AppendLine().AppendFormat(ProjectResources.DeploymentOperationId, this.RequestId);
            
            return sb.ToString();
        }


        public void SetRequestIdFromResponseHeaders(HttpResponseMessage response)
        {
            RequestId = string.Empty;

            if (response?.Headers != null && response.Headers.TryGetValues("x-ms-request-id", out IEnumerable<string> requestIdValues))
            {
                RequestId = string.Join(";", requestIdValues);
            }
        }
        #endregion

        #region Static Methods
        public static string GetErrorMessageWithDetails(ErrorResponse error)
        {
            if (error == null) return null;

            if (error.Details == null)
            {
                return string.Format(ProjectResources.DeploymentOperationErrorMessageNoDetails, error.Code, error.Message);
            }

            string errorDetail = null;

            foreach (ErrorResponse detail in error.Details)
            {
                errorDetail += GetErrorMessageWithDetails(detail);
            }

            return string.Format(ProjectResources.DeploymentOperationErrorMessage, error.Code, error.Message, errorDetail);            
        }

        public static ErrorResponse DeserializeDeploymentOperationError(string statusMessage)
        {
            if (statusMessage == null)
            {
                return null;
            }

            ErrorResponse error = null;
            dynamic dynamicStatusMessage;

            try
            {
                dynamicStatusMessage = JsonConvert.DeserializeObject(statusMessage);
                error = JsonConvert.DeserializeObject<ErrorResponse>(dynamicStatusMessage?.error?.ToString());
            }
            catch
            {
                // We'll ignore the exception if we can't properly deserialize the JSON.
                // The reason for that can be 1- statusMessage is not a valid JSON(it can be a string when it's the outer generic error message)
                // which will result is DeserializeObject exception. 2- If error is not properly modeled as ErrorResponse.
            }

            return error;
        }
        #endregion
    }
}