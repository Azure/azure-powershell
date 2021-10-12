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

using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Management.DataFactory.Models;
using System.Text.Json;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSIntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint
    {
        private static JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = false };
        public string Category { get; set; }
        public string EndPoint { get; set; }

        public PSIntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint(IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint categoryEndpoint)
        {
            Category = categoryEndpoint.Category;
            EndPoint = JsonSerializer.Serialize(categoryEndpoint.Endpoints, options);
        }
    }
}
