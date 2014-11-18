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

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities
{
    /// <summary>
    /// Log.
    /// </summary>
    [DataContract]
    public class LogEntry
    {
        [DataMember(Name = "log_time")]
        public DateTime LogTime { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "type")]
        public LogEntryType Type { get; set; }

        [DataMember(Name = "details_url")]
        public Uri DetailsUrl { get; set; }

        public bool HasDetails { get; set; }

        public LogEntry()
        {
        }

        public LogEntry(DateTime logTime, string id, string message, LogEntryType type)
        {
            LogTime = logTime;
            Id = id;
            Message = message;
            Type = type;
        }
    }
}
