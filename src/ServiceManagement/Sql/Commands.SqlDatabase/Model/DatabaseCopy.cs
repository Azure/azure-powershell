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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Model
{
    public class DatabaseCopy
    {
        public Guid EntityId { get; set; }

        public string SourceServerName { get; set; }

        public string SourceDatabaseName { get; set; }

        public string DestinationServerName { get; set; }

        public string DestinationDatabaseName { get; set; }

        public bool IsContinuous { get; set; }

        public byte ReplicationState { get; set; }

        public string ReplicationStateDescription { get; set; }

        public int LocalDatabaseId { get; set; }

        public bool IsLocalDatabaseReplicationTarget { get; set; }

        public bool IsInterlinkConnected { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public float PercentComplete { get; set; }

        public bool IsOfflineSecondary { get; set; }

        public bool IsTerminationAllowed { get; set; }
    }
}
