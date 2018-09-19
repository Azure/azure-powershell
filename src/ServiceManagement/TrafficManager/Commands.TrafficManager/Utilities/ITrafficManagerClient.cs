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

using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.TrafficManager.Models;
using Microsoft.WindowsAzure.Management.TrafficManager;
using Microsoft.WindowsAzure.Management.TrafficManager.Models;

namespace Microsoft.WindowsAzure.Commands.TrafficManager.Utilities
{
    public interface ITrafficManagerClient
    {
        TrafficManagerManagementClient Client { get; }

        ProfileWithDefinition NewAzureTrafficManagerProfile(
            string profileName,
            string domainName,
            string loadBalancingMethod,
            int monitorPort,
            string monitorProtocol,
            string monitorRelativePath,
            int ttl);

        ProfileWithDefinition AssignDefinitionToProfile(string profileName, DefinitionCreateParameters definitionParameter);
        void RemoveTrafficManagerProfile(string profileName);
        ProfileWithDefinition GetTrafficManagerProfileWithDefinition(string profileName);

        DefinitionCreateParameters InstantiateTrafficManagerDefinition(
            string loadBalancingMethod,
            int monitorPort,
            string monitorProtocol,
            string monitorRelativePath,
            int ttl,
            IList<TrafficManagerEndpoint> endpoints);

        DefinitionCreateParameters InstantiateTrafficManagerDefinition(Definition definition);

        void UpdateProfileStatus(string profileName, ProfileDefinitionStatus targetStatus);
        ProfileDefinitionStatus GetStatus(string profileName);
        void CreateTrafficManagerProfile(string profileName, string domainName);
        void CreateTrafficManagerDefinition(string profileName, DefinitionCreateParameters parameters);
        ProfileGetResponse GetProfile(string profileName);
        DefinitionGetResponse GetDefinition(string profileName);
        IEnumerable<SimpleProfile> ListProfiles();
        bool TestDomainAvailability(string domainName);
    }
}