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

using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.WebApps.Models.WebApp
{
    public class PSAppServiceEnvironment
    {
        public PSAppServiceEnvironment(AppServiceEnvironmentResource other)
        {
            this.Location = other.Location;
            this.Name = other.Name;
            this.Kind = other.Kind;
            this.ProvisioningState = other.ProvisioningState;
            this.Status = other.Status;
            this.Id = other.Id;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ResourceGroupName { get; set; }
        public string Kind { get; set; }
        public ProvisioningState? ProvisioningState { get; set; }
        public HostingEnvironmentStatus? Status { get; set; }
        public bool? EnvironmentIsHealthy { get; set; }

    }
}
