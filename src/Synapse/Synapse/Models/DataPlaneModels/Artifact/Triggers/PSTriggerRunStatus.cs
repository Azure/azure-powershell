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

using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public struct PSTriggerRunStatus
    {
        private readonly string _value;

        public static PSTriggerRunStatus Succeeded { get; } = new PSTriggerRunStatus("Succeeded");

        public static PSTriggerRunStatus Failed { get; } = new PSTriggerRunStatus("Failed");

        public static PSTriggerRunStatus Inprogress { get; } = new PSTriggerRunStatus("Inprogress");

        public PSTriggerRunStatus(string value)
        {
            _value = (value);
        }

        public static PSTriggerRunStatus Parse(TriggerRunStatus? status)
        {
            switch (status.ToString())
            {
                case "Succeeded": return Succeeded;
                case "Failed": return Failed;
                case "InProgress": return Inprogress;
                default: return new PSTriggerRunStatus(status.ToString());
            }
        }
    }
}

