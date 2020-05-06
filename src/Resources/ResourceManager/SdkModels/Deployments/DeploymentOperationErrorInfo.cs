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
    /// This class processes failed deployment operations and formats the resulting errors to be outputed
    /// at the end of a deployment.
    /// </summary>
    public class DeploymentOperationErrorInfo
    {
        private const int MaxErrorsToShow = 3;
        private const char Whitespace = ' ';

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

                sb.Append(GetErrorMessageWithDetails(error));

                // if there is target information let's add that to the error string. We need to do this here since this information is per operation and comes separately from statusMessage.
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

            // Add outer message showing the total number of errors.
            sb.AppendFormat(ProjectResources.DeploymentOperationOuterError, deploymentName, maxErrors, ErrorMessages.Count);

            // Add each error status message
            ErrorMessages
                .Take(maxErrors).ToList()
                .ForEach(m => sb.AppendLine().AppendFormat(ProjectResources.DeploymentOperationStatusMessage, m).AppendLine());

            // Add correlationId
            sb.AppendLine().AppendFormat(ProjectResources.DeploymentCorrelationId, this.RequestId);
            
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
        public static string GetErrorMessageWithDetails(ErrorResponse error, int level = 0)
        {
            if (error == null) return null;

            if (error.Details == null)
            {
                return string.Format(ProjectResources.DeploymentOperationErrorMessageNoDetails, error.Message, error.Code);
            }

            string errorDetail = null;

            foreach (ErrorResponse detail in error.Details)
            {
                errorDetail += System.Environment.NewLine + GetIndentation(level) + GetErrorMessageWithDetails(detail, level + 1);
            }

            return string.Format(ProjectResources.DeploymentOperationErrorMessage, error.Message, error.Code, errorDetail);            
        }

        private static string GetIndentation(int l)
        {
            return new StringBuilder().Append(Whitespace, l*2).Append(" - ").ToString();    
        }

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
                error = JsonConvert.DeserializeObject<ErrorResponse>(dynamicStatusMessage?.error.ToString());
            }
            catch (ArgumentException)
            {
                // Ignore if dynamicStatusMessage throws ArgumentException. It'll be due to statusMessage not being valid JSON.
            }
            catch (Exception ex)
            {
                throw new Exception("Deployment operation failed, but we were unable to get additional error information. " + ex.Message + ex.StackTrace);
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
                // In that case, we'll ignore the outer error which is an error message with no valuable information.
            }

            return dynamicStatusMessage;
        }
        #endregion
    }
}