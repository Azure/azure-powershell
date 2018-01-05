﻿// ----------------------------------------------------------------------------------
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

using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Common.Strategies.Templates
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-authoring-templates
    /// </summary>
    public class Template
    {
        [JsonProperty("$schema")]
        public string Schema { get; set; }
            = "http://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#";

        public string contentVersion { get; set; }

        public Resource[] resources { get; set; }
    }
}
