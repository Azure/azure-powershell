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

using Microsoft.Azure.Management.ContainerRegistry.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSRegistryUsage
    {
        public PSRegistryUsage(string name = default(string), long? limit = default(long?), long? currentValue = default(long?), string unit = default(string))
        {
            Name = name;
            Limit = limit;
            CurrentValue = currentValue;
            Unit = unit;
        }

        public PSRegistryUsage(RegistryUsage usage)
        {
            Name = usage.Name;
            Limit = usage.Limit;
            CurrentValue = usage.CurrentValue;
            Unit = usage.Unit;
        }

        public string Name { get; set; }

        public long? Limit { get; set; }

        public long? CurrentValue { get; set; }

        public string Unit { get; set; }
    }
}
