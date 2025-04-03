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

namespace Microsoft.Azure.Commands.Network
{
    public abstract class VerifierWorkspaceBaseCmdlet : NetworkBaseCmdlet
    {
        public IVerifierWorkspacesOperations VerifierWorkspaceClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.VerifierWorkspaces;
            }
        }

        public bool IsVerifierWorkspacePresent(string resourceGroupName, string networkManagerName, string workspaceName)
        {
            try
            {
                GetVerifierWorkspace(resourceGroupName, networkManagerName, workspaceName);
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


        public PSVerifierWorkspace GetVerifierWorkspace(string resourceGroupName, string networkManagerName, string workspaceName)
        {
            var verifierWorkspace = this.VerifierWorkspaceClient.Get(resourceGroupName, networkManagerName, workspaceName);
            var psVerifierWorkspace = ToPsVerifierWorkspace(verifierWorkspace);
            psVerifierWorkspace.Tags = verifierWorkspace.Tags;
            psVerifierWorkspace.ResourceGroupName = resourceGroupName;
            psVerifierWorkspace.NetworkManagerName = networkManagerName;
            return psVerifierWorkspace;
        }

        public PSVerifierWorkspace ToPsVerifierWorkspace(Management.Network.Models.VerifierWorkspace verifierWorkspace)
        {
            var psVerifierWorkspace = NetworkResourceManagerProfile.Mapper.Map<PSVerifierWorkspace>(verifierWorkspace);
            return psVerifierWorkspace;
        }
    }
}