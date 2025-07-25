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

using Microsoft.Azure.Commands.Management.Search.Models;
using Microsoft.Azure.Management.Search.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    public abstract class PrivateEndpointConnectionBaseCmdlet : SearchServiceBaseCmdlet
    {
        protected const string PrivateEndpointConnectionNameHelpMessage = "Azure Cognitive Search Service private endpoint connection name";
        protected const string PrivateEndpointConnectionStatusHelpMessage = "Private link service connection status";
        protected const string PrivateEndpointConnectionResourceIdHelpMessage = "Private link service resource id";
        protected const string PrivateEndpointConnectionDescriptionHelpMessage = "Private endpoint connection description";
        protected const string PrivateEndpointInputObjectHelpMessage = "Private endpoint connection input object";

        protected void WritePrivateEndpointConnection(PrivateEndpointConnection privateEndpointConnection)
        {
            if (privateEndpointConnection != null)
            {
                WriteObject((PSPrivateEndpointConnection)privateEndpointConnection);
            }
        }

        protected void WritePrivateEndpointConnectionList(IEnumerable<PrivateEndpointConnection> privateEndpointConnections)
        {
            var output = new List<PSPrivateEndpointConnection>();
            if (privateEndpointConnections != null)
            {
                output = privateEndpointConnections.Select(pe => (PSPrivateEndpointConnection)pe).ToList();
            }

            WriteObject(output, true);
        }
    }
}