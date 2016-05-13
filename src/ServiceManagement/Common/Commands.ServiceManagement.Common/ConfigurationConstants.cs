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

using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class ConfigurationConstants
    {
        public const int MaxReceivedMessageSize = 100000000;

        public const int MaxStringContentLength = 67108864;

        public static Binding WebHttpBinding(int maxStringContentLength = 0)
        {
            var binding = new WebHttpBinding(WebHttpSecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            binding.ReaderQuotas.MaxStringContentLength =
                maxStringContentLength > 0 ?
                maxStringContentLength :
                MaxStringContentLength;

            // Increasing MaxReceivedMessageSize to allow big deployments
            binding.MaxReceivedMessageSize = MaxReceivedMessageSize;

            return binding;
        }
    }
}