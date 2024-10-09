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

namespace Microsoft.Azure.Commands.Network.Bastion
{
    internal class Constants
    {
        // Bastion
        internal const string BastionResourceName = "Bastion";
        internal const string BastionResourceType = "Microsoft.Network/bastionHosts";
        internal const string BastionSubnetName = "AzureBastionSubnet";
        internal const string BastionIpConfigurationName = "IpConf";

        // Scale Units
        internal const int MinimumScaleUnits = 2;
        internal const int MaximumScaleUnits = 50;

        // Shareable Link
        internal const string ShareableLink = "ShareableLink";
    }
}
