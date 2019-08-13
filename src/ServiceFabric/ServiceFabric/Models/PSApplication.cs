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

using Microsoft.Azure.Management.ServiceFabric.Models;

namespace Microsoft.Azure.Commands.ServiceFabric.Models
{
    public class PSApplication : ApplicationResource
    {
        public PSApplication(ApplicationResource app)
            : base(
                  id: app.Id,
                  name: app.Name,
                  type: app.Type,
                  location: app.Location,
                  etag: app.Etag,
                  tags: app.Tags,
                  typeVersion: app.TypeVersion,
                  parameters: app.Parameters,
                  upgradePolicy: app.UpgradePolicy,
                  minimumNodes: app.MinimumNodes,
                  maximumNodes: app.MaximumNodes,
                  removeApplicationCapacity: app.RemoveApplicationCapacity,
                  metrics: app.Metrics,
                  provisioningState: app.ProvisioningState,
                  typeName: app.TypeName)
        {
        }
    }
}
