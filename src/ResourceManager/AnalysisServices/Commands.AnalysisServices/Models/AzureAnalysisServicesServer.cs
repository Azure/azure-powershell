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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Analysis;
using Microsoft.Azure.Management.Analysis.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace Microsoft.Azure.Commands.AnalysisServices.Models
{
    public class AzureAnalysisServicesServer
    {
        public List<string> AsAdministrators { get; set; }

        public string ProvisioningState { get; private set; }

        public string Id { get; private set; }

        public string Name { get; set; }

        public string Type { get; private set; }

        public string Location { get; set; }

        public string ServerFullName { get; private set; }

        public ServerSku Sku { get; set; }

        public System.Collections.Generic.IDictionary<string, string> Tag { get; set; }

        internal static AzureAnalysisServicesServer FromAnalysisServicesServer(AnalysisServicesServer server)
        {
            if (server == null)
            {
                return null;
            }

            return new AzureAnalysisServicesServer()
            {
                AsAdministrators = server.AsAdministrators == null
                    ? new List<string>()
                    : new List<string>(server.AsAdministrators.Members),
                Location = server.Location,
                Name = server.Name,
                Type = server.Type,
                ProvisioningState = server.ProvisioningState,
                Id = server.Id,
                ServerFullName = server.ServerFullName,
                Sku = server.Sku != null ? ServerSku.FromResourceSku(server.Sku) : new ServerSku(),
                Tag = server.Tags != null ? new Dictionary<string, string>(server.Tags) : new Dictionary<string, string>()
            };
        }

        internal static List<AzureAnalysisServicesServer> FromAnalysisServicesServerCollection(List<AnalysisServicesServer> list)
        {
            if (list == null)
            {
                return null;
            }

            var listAzureAnalysisServicesServer = new List<AzureAnalysisServicesServer>();
            list.ForEach(server => listAzureAnalysisServicesServer.Add(FromAnalysisServicesServer(server)));
            return listAzureAnalysisServicesServer;
        }
    }
}
