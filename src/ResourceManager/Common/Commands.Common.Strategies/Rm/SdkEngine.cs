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

using Microsoft.Azure.Commands.Common.Strategies.Rm.Config;
using System.Linq;
using System.Net;
using System.Security;

namespace Microsoft.Azure.Commands.Common.Strategies.Rm
{
    /// <summary>
    /// Engine for REST API calls using Azure SDK.
    /// </summary>
    sealed class SdkEngine : IEngine
    {        
        string _SubscriptionId { get; }

        public SdkEngine(string subscriptionId)
        {
            _SubscriptionId = subscriptionId;
        }

        public string GetId(IEntityConfig config)
            => new[] { ResourceId.Subscriptions, _SubscriptionId } 
                .Concat(config.GetIdFromSubscription()) 
                .IdToString();

        public string GetParameterValue<T>(Parameter<T> parameter)
        {
            var value = parameter.Value;
            if (value == null)
            {
                return null;
            }
            var secureValue = value as SecureString;
            return secureValue != null
                ? new NetworkCredential(string.Empty, secureValue).Password
                : value.ToString();
        }
    }
}
