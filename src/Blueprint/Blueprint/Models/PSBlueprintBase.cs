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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Blueprint.Models
{
    public class PSBlueprintBase : PSAzureResourceBase
    {
        public string Scope { get; set; }
        public string SubscriptionId { get; protected set; }
        public string ManagementGroupId { get; protected set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public PSBlueprintStatus Status { get; set; }
        public PSBlueprintTargetScope TargetScope { get; set; }
        public IDictionary<string, PSParameterDefinition> Parameters { get; set; }
        public IDictionary<string, PSResourceGroupDefinition> ResourceGroups { get; set; }
    }
}
