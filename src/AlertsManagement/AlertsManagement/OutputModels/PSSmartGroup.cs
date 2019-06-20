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
using Microsoft.Azure.Management.AlertsManagement.Models;

namespace Microsoft.Azure.Commands.AlertsManagement.OutputModels
{
    public class PSSmartGroup
    {
        public PSSmartGroup(SmartGroup smartGroup)
        {
            Id = smartGroup.Id;
            Name = smartGroup.Name;
            AlertsCount = smartGroup.AlertsCount;
            State = smartGroup.SmartGroupState;
            Severity = smartGroup.Severity;
            LastModifiedTime = smartGroup.LastModifiedDateTime;
            LastModifiedUserName = smartGroup.LastModifiedUserName;
        }

        public string Id { get; }

        public string Name { get; }

        public string State { get; }

        public string Severity { get; }

        public int? AlertsCount { get; }

        public DateTime? LastModifiedTime { get; }

        public string LastModifiedUserName { get; }
    }
}