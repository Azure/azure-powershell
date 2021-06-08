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

using Newtonsoft.Json;

namespace Microsoft.Azure.PowerShell.Share.Survey
{
    internal class ModuleInfo
    {
        [JsonProperty(PropertyName = "name")]
        internal string Name { get; set; }

        [JsonProperty(PropertyName = "majorVersion")]
        internal int MajorVersion { get; set; }

        [JsonProperty(PropertyName = "activeDays")]
        internal int ActiveDays { get; set; }

        [JsonProperty(PropertyName = "firstActiveDate")]
        internal string FirstActiveDate { get; set; }

        [JsonProperty(PropertyName = "lastActiveDate")]
        internal string LastActiveDate { get; set; }

        [JsonProperty(PropertyName = "enabled")]
        internal bool Enabled { get; set; }

        internal ModuleInfo(ModuleInfo info)
        {
            Name = info.Name;
            MajorVersion = info.MajorVersion;
            ActiveDays = info.ActiveDays;
            FirstActiveDate = info.FirstActiveDate;
            LastActiveDate = info.LastActiveDate;
            Enabled = info.Enabled;
        }

        internal ModuleInfo() { }
    }
}
