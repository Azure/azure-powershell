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

namespace Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider
{
    internal class PrivateLinkProviderFactory
    {
        private const string NETWORKING_TYPE = "microsoft.network/privatelinkservices";
        
        public static IPrivateLinkProvider CreatePrivateLinkProvder(NetworkBaseCmdlet cmdlet, string subscription, string privateLinkResourceType)
        {
            IPrivateLinkProvider provider = null;

            if(privateLinkResourceType == null)
            {
                return new NetworkingProvider(cmdlet);
            }

            if(GenericProvider.SupportsPrivateLinkFeature(privateLinkResourceType))
            {
                return new GenericProvider(cmdlet, subscription, privateLinkResourceType);
            }

            switch (privateLinkResourceType.ToLower())
            {
                case NETWORKING_TYPE:
                default:
                    provider = new NetworkingProvider(cmdlet);
                    break;
            }
            return provider;
        }

        public IPrivateLinkProvider CreatePrivateLinkProvder(NetworkBaseCmdlet cmdlet)
        {
            return CreatePrivateLinkProvder(cmdlet, null, null);
        }
    }
}
