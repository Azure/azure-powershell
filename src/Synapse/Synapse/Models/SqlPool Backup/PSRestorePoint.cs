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

using Microsoft.Azure.Management.Synapse.Models;
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSRestorePoint : PSSynapseResource
    {
        public PSRestorePoint(RestorePoint restorePoint)
        {
            this.Location = restorePoint.Location;
            this.RestorePointType = restorePoint.RestorePointType;
            this.EarliestRestoreDate = restorePoint.EarliestRestoreDate;
            this.RestorePointCreationDate = restorePoint.RestorePointCreationDate;
            this.RestorePointLabel = restorePoint.RestorePointLabel;
            this.Id = restorePoint.Id;
            this.Name = restorePoint.Name;
            this.Type = restorePoint.Type;
        }

        public string Location { get; }

        public RestorePointType? RestorePointType { get; }
        
        public DateTime? EarliestRestoreDate { get; }

        public DateTime? RestorePointCreationDate { get; }

        public string RestorePointLabel { get; }

        public new string Id { get; set; }

        public new string Name { get; set; }

        public new string Type { get; set; }
    }
}
