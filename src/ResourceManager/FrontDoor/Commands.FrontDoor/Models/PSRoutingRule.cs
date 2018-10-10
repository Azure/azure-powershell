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

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.FrontDoor.Models
{    
    /// <summary>
        /// Represents the properties of an Azure Front Door object.
    /// </summary>
    public class PSRoutingRule: PSResource
    {
        public List<string> FrontendEndpointIds { get; set; }

        public List<PSProtocol> AcceptedProtocols { get; set; }

        public List<String> PatternsToMatch { get; set; }

        public PSForwardingProtocol? ForwardingProtocol { get; set; }

        public string CustomForwardingPath { get; set; }

        public PSQueryParameterStripDirective? QueryParameterStripDirective { get; set; }

        public PSEnabledState? DynamicCompression { get; set; }

        public List<PSHealthProbeSetting> HealthProbeSettings { get; set; }

        public string BackendPoolId { get; set; }
    
        public PSEnabledState? EnabledState { get; set; }

        public string ResourceState { get; set; }

        public bool EnableCaching { get; set; }
    }
}
