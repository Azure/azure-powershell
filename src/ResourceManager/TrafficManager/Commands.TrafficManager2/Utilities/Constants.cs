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

namespace Microsoft.Azure.Commands.TrafficManager.Utilities
{
    public class Constants
    {
        public const string AzureEndpoint = "AzureEndpoints";
        public const string ExternalEndpoint = "ExternalEndpoints";
        public const string NestedEndpoint = "NestedEndpoints";

        public const string StatusEnabled = "Enabled";
        public const string StatusDisabled = "Disabled";

        public const string Performance = "Performance";
        public const string Weighted = "Weighted";
        public const string Priority = "Priority";

        public const string HTTP = "HTTP";
        public const string HTTPS = "HTTPS";

        public const string ProfileType = "Microsoft.Network/trafficManagerProfiles";
    }
}
