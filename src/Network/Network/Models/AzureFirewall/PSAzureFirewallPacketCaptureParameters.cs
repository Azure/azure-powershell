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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Rest;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSAzureFirewallPacketCaptureParameters
    {

        public uint DurationInSeconds { get; set; }

        public uint NumberOfPacketsToCapture { get; set; }

        public string SasUrl { get; set; }

        public string FileName { get; set; }

        public string Protocol { get; set; }

        public List<PSAzureFirewallPacketCaptureFlags> Flags { get; set; }

        public List<PSAzureFirewallPacketCaptureRule> Filters { get; set; }

        public string Operation {  get; set; }

        [JsonIgnore]
        public string FlagsText
        {
            get { return JsonConvert.SerializeObject(Flags, Formatting.Indented); }
        }

        [JsonIgnore]
        public string FiltersText
        {
            get { return JsonConvert.SerializeObject(Filters, Formatting.Indented); }
        }

        public void AddFilter(PSAzureFirewallPacketCaptureRule rule)
        {
            // Validate
            if (this.Filters == null)
            {
                this.Filters = new List<PSAzureFirewallPacketCaptureRule>();
            }

            this.Filters.Add(rule);
        }
    }
}
