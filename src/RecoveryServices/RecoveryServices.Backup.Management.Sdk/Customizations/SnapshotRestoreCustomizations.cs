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

// These partial-class members extend the generated models with SQL (MSSQL) Instance snapshot
// restore fields that the service supports but are not yet modeled in the generated stable
// (2026-10-01) bms.json. Keeping them in a hand-authored partial file means they survive an
// AutoRest regeneration of the Generated folder.
namespace Microsoft.Azure.Management.RecoveryServices.Backup.Models
{
    public partial class BmsrpQueryObject
    {
        /// <summary>
        /// Recovery mode filter (e.g. 'SnapshotAttachAndRecover') used to list the point-in-time log
        /// recovery points available on top of a SQL (MSSQL) Instance snapshot. Serialized as the
        /// OData query segment "recoveryMode" by the query builder (reflection on the property name).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveryMode")]
        public string RecoveryMode { get; set; }
    }

    public partial class TargetRestoreInfo
    {
        /// <summary>
        /// Target directory mapping used for SnapshotAttach restore (e.g. { "all": "C:/temp" }).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetDirectoryMapping")]
        public System.Collections.Generic.IDictionary<string, string> TargetDirectoryMapping { get; set; }
    }
}
