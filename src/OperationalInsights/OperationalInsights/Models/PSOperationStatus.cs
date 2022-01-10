// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSOperationStatus
    {
        public PSOperationStatus(Management.OperationalInsights.Models.OperationStatus opStatus)
        {
            Id = opStatus.Id;
            Name = opStatus.Name;
            Status = opStatus.Status;
            Error = opStatus.Error;
            EndTime = opStatus.EndTime;
            StartTime = opStatus.StartTime;
        }

        public string Id { set; get; }
        public string Name { set; get; }
        public string Status { set; get; }
        public ErrorResponse Error { set; get; }
        public string EndTime { set; get; }
        public string StartTime { set; get; }
    }
}
