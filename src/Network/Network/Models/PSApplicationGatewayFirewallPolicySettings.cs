//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.Models
{
    public partial class PSApplicationGatewayFirewallPolicySettings
    {
        [Ps1Xml(Target = ViewControl.Table)]
        public string State { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string Mode { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool? RequestBodyEnforcement { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int? RequestBodyInspectLimitInKB { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool RequestBodyCheck { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int MaxRequestBodySizeInKb { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public bool? FileUploadEnforcement { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int FileUploadLimitInMb { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public string CustomBlockResponseBody { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int? CustomBlockResponseStatusCode { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public PSApplicationGatewayFirewallPolicyLogScrubbingConfiguration LogScrubbing { get; set; }

        [Ps1Xml(Target = ViewControl.Table)]
        public int? JSChallengeCookieExpirationInMins { get; set; }
    }
}
