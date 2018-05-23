﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class PSExpressRouteCircuitConnection : PSChildResource
    {
        public string AddressPrefix { get; set; }
        public string AuthorizationKey { get; set; }
        public string CircuitConnectionStatus { get; set; }
        public string ProvisioningState { get; set; }
        public PSResourceId PeerExpressRouteCircuitPeering { get; set; }
        public PSResourceId ExpressRouteCircuitPeering { get; set; }
    }
}