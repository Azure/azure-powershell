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
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    [DataContract]
    sealed class ScaleOutServerDatabaseSyncResult
    {
        [DataMember]
        public string OperationId { get; set; }

        [DataMember(Name = "database")]
        public string Database { get; set; }

        [DataMember(Name = "UpdatedAt")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "StartedAt")]
        public DateTime StartedAt { get; set; }

        [DataMember(Name = "syncstate")]
        public DatabaseSyncState SyncState { get; set; }

        [DataMember(Name = "details")]
        public string Details { get; set; }
    }
}
