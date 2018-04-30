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

using Microsoft.Azure.Management.ContainerRegistry.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    public class PSContainerRegistryWebhook
    {
        public PSContainerRegistryWebhook(Webhook webhook)
        {
            Id = webhook?.Id;
            Name = webhook?.Name;
            Type = webhook?.Type;
            Tags = webhook?.Tags;
            Location = webhook?.Location;
            Status = webhook?.Status;
            Scope = webhook?.Scope;
            Actions = webhook?.Actions;
            ProvisioningState = webhook?.ProvisioningState;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Scope { get; set; }
        public IList<string> Actions { get; set; }
        public string ProvisioningState { get; set; }
        public CallbackConfig Config { get; set; }

    }
}
