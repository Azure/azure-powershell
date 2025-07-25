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


using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSInboundSecurityRulesProperty
    {
        public string Name { get; set; }
        public string Protocol { get; set; }
        public string SourceAddressPrefix { get; set; }
        public int? DestinationPortRange { get; set; }
        public List<string> DestinationPortRanges{ get; set; }
        public List<string> AppliesOn { get; set; }
    }
}