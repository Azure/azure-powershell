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
using Microsoft.Azure.Management.Analysis.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.AnalysisServices.Models
{
    public class PsAzureAnalysisServicesFirewallRule
    {
        public string FirewallRuleName { get; set; }

        public string RangeStart { get; set; }

        public string RangeEnd { get; set; }

        public PsAzureAnalysisServicesFirewallRule(string firewallRuleName, string rangeStart, string rangeEnd)
        {
            FirewallRuleName = firewallRuleName;
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }
    }
}
