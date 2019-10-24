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
    internal static class BastionParameterSetNames
    {
        internal const string ByName = "ByName";
        internal const string ByResourceGroupName = "ByResourceGroupName";
        internal const string ByResourceId = "ByResourceId";
        internal const string ByBastionObject = "ByInputObject";
        internal const string ByIpResourceId = "ByPublicIpAddressId";
        internal const string ByIpObject = "ByPublicIpAddress";
        internal const string ByIpRGName = "ByPublicIpAddressRgName";
        internal const string ByIpName = "ByPublicIpAddressName";
        internal const string ByVNObject = "ByVirtualNetwork";
        internal const string ByVNResourceId = "ByVirtualNetworkId";
        internal const string ByVNName = "ByVirtualNetworkName";
        internal const string ByVNRGName = "ByVirtualNetworkRGName";
        internal const string ListBySubscription = "ListBySubscriptionId";
        internal const string ListByResourceGroup = "ListByResourceGroupName";
    }
}
