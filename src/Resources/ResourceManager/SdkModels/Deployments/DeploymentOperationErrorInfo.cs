using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    internal class DeploymentOperationErrorInfo
    {
        public DeploymentOperationErrorInfo()
        {
            ErrorMessages = new List<string>();
        }

        public List<string> ErrorMessages { get; set; }

        public List<Provider> RequiredProviders { get; set; }

        public void ProcessError(DeploymentOperation operation)
        {
            if (operation.Properties.StatusMessage != null)
            {
               ErrorResponse error = DeserializeError(operation.Properties.StatusMessage.ToString());

                if (error != null)
                {
                    string outerError = "";
                    // if there is target information let's add that to the error record
                    if (operation.Properties.TargetResource.ResourceType != null && operation.Properties.TargetResource.ResourceName != null)
                    {
                        outerError = $"Resource {operation.Properties.TargetResource.ResourceType} with name '{operation.Properties.TargetResource.ResourceName}' failed to deploy.";
                    }

                    ErrorMessages.Add($"{outerError} Code: {error.Code}. Message: {error.Message}");

                    if (error.Details != null)
                    {
                        foreach (var detail in error.Details)
                        {
                            ErrorMessages.Add($"InnerError: Code: {error.Code}. Message: {error.Message}");
                        }
                    }
                }
            }
        }

        private ErrorResponse DeserializeError(string statusMessage)
        {
            if (statusMessage == null) return null;

            ErrorResponse errorObj = null;
            dynamic statusMessageObj;

            try
            {
                statusMessageObj = JsonConvert.DeserializeObject(statusMessage);

                if (statusMessageObj.error != null)
                {
                    var temp = statusMessageObj.error.ToString();
                    errorObj = JsonConvert.DeserializeObject<ErrorResponse>(statusMessageObj.error.ToString());
                }
            }
            catch
            {
                // There could be two known reasons why we got here:
                // 1- statusMessage is not always a valid JSON(it can sometimes be a string when it's the outer generic error message) which can result is DeserializeObject exception.
                // 2- if error is not properly modeled as ErrorResponse
                // We'll ignore all.
            }

            return errorObj;
        }
    }
}
