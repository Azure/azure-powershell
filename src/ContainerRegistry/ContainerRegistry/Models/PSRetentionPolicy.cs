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

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSRetentionPolicy
    {
        public PSRetentionPolicy(int? days = default(int?), System.DateTime? lastUpdatedTime = default(System.DateTime?), string status = default(string))
        {
            Days = days;
            LastUpdatedTime = lastUpdatedTime;
            Status = status;
        }

        public int? Days { get; set; }

        public System.DateTime? LastUpdatedTime { get; private set; }

        public string Status { get; set; }
    }
}
