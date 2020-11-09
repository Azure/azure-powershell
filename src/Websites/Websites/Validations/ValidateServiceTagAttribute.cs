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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps.Validations
{
    public class ValidateServiceTagAttribute : ValidateArgumentsAttribute
    {
        private List<string> SupportedServiceTags = new List<string>() { 
            "ActionGroup", 
            "AzureCloud", 
            "AzureCognitiveSearch", 
            "AzureConnectors", 
            "AzureEventGrid", 
            "AzureFrontDoor.Backend", 
            "AzureMachineLearning",
            "AzureSignalR",
            "AzureTrafficManager",
            "LogicApps",
            "ServiceFabric"
        };

        protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
        {
            var ipAddressArgumentValue = arguments as string;

            if (ipAddressArgumentValue.Any(Char.IsWhiteSpace))
                throw new ValidationMetadataException("Service Tag cannot contain blank spaces.");

            var ipAddresses = ipAddressArgumentValue.Split(',');

            if (ipAddresses.Length > 8)
                throw new ValidationMetadataException("Only 8 service tags are allowed per rule");

            if (!ipAddresses.All(a => this.IsValidServiceTag(a)))
            {
                throw new ValidationMetadataException("One or more service tags are invalid.");
            }            
        }

        private bool IsValidServiceTag(string serviceTag)
        {
            // Currently a static list - will be updated once Service Tag team publishes an API to request the full list"
            return SupportedServiceTags.Contains(serviceTag, StringComparer.OrdinalIgnoreCase);
        }
    }
}
