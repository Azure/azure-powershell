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

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Cdn.Models.Endpoint
{
    public class PSDeliveryRuleUrlRedirectAction: PSDeliveryRuleAction
    {
        public string RedirectType { get; set; }

        public string DestinationProtocol { get; set; }

        public string CustomPath { get; set; }

        public string CustomHostname { get; set; }

        public string CustomQueryString { get; set; }

        public string CustomFragment { get; set; }
    }
}
