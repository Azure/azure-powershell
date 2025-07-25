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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Net;
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Newtonsoft.Json.Linq;
using System;

namespace Microsoft.Azure.Commands.Network
{ 
    public abstract class ReachabilityAnalysisIntentBaseCmdlet : NetworkBaseCmdlet
    {
        public IReachabilityAnalysisIntentsOperations ReachabilityAnalysisIntentClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ReachabilityAnalysisIntents;
            }
        }

        public bool IsAnalysisIntentPresent(string resourceGroupName, string networkManagerName, string workspaceName, string analysisIntentName)
        {
            try
            {
                GetAnalysisIntent(resourceGroupName, networkManagerName, workspaceName, analysisIntentName);
            }
            catch (Microsoft.Azure.Management.Network.Models.CommonErrorResponseException exception)
            {
                // Use the concise error handling method
                HandleError(exception);
                return false;
            }

            return true;
        }

        // Helper method for concise error handling
        private void HandleError(Microsoft.Azure.Management.Network.Models.CommonErrorResponseException exception)
        {
            switch (exception.Response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    // Specific handling for Bad Request with detailed message
                    DisplayDetailedErrorMessage(exception);
                    break;

                case HttpStatusCode.NotFound:
                    WriteWarning("Error: Not Found - The specified resource could not be found.");
                    break;

                case HttpStatusCode.Forbidden:
                    WriteWarning("Error: Forbidden - You do not have permission to perform this operation.");
                    break;

                case HttpStatusCode.InternalServerError:
                    WriteWarning("Error: Internal Server Error - The server encountered an unexpected condition. Try again later.");
                    break;

                default:
                    WriteWarning($"Error: {exception.Response.StatusCode} - {exception.Message}");
                    break;
            }
        }

        // Method to display a detailed error message for BadRequest (400) responses
        private void DisplayDetailedErrorMessage(Microsoft.Azure.Management.Network.Models.CommonErrorResponseException exception)
        {
            string errorMessage = "Bad Request: An unknown error occurred.";

            // Check if the response content is available
            if (!string.IsNullOrEmpty(exception.Response.Content))
            {
                try
                {
                    // Parse the JSON response content to get the "message" field
                    var errorContent = JObject.Parse(exception.Response.Content);
                    errorMessage = errorContent["message"]?.ToString() ?? errorMessage;
                }
                catch
                {
                    // Fallback if parsing fails
                    WriteWarning($"Bad Request: Unable to parse error details. Raw response: {exception.Response.Content}");
                    return;  
                }
            }
            else
            {
                // If there is no content, default message
                errorMessage = "Bad Request: The request was invalid. Please check your parameters.";
            }

            // Display the error message to the user
            WriteWarning(errorMessage);
        }

        public PSReachabilityAnalysisIntent GetAnalysisIntent(string resourceGroupName, string networkManagerName, string workspaceName, string analysisIntentName)
        {
            var analysisIntent = this.ReachabilityAnalysisIntentClient.Get(resourceGroupName, networkManagerName, workspaceName, analysisIntentName);
            var psAnalysisIntent = ToPsReachabilityAnalysisIntent(analysisIntent);
            psAnalysisIntent.ResourceGroupName = resourceGroupName;
            psAnalysisIntent.NetworkManagerName = networkManagerName;
            psAnalysisIntent.VerifierWorkspaceName = workspaceName;
            psAnalysisIntent.Name = analysisIntentName;
            return psAnalysisIntent;
        }

        public PSReachabilityAnalysisIntent ToPsReachabilityAnalysisIntent(Management.Network.Models.ReachabilityAnalysisIntent analysisIntent)
        {
            var psReachabilityAnalysisIntent = NetworkResourceManagerProfile.Mapper.Map<PSReachabilityAnalysisIntent>(analysisIntent);
            return psReachabilityAnalysisIntent;
        }
    }
}