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

using Microsoft.Azure.Storage.Shared.Protocol;
using XTable = Microsoft.Azure.Cosmos.Table;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Azure.Storage.File;
using System.Net;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel
{
    public class PSFileHandle
    {
        [Ps1Xml(Label = "HandleId", Target = ViewControl.Table, Position = 0)]
        public ulong? HandleId { get; set; }

        [Ps1Xml(Label = "Path", Target = ViewControl.Table, Position = 1)]
        public string Path { get; set; }

        [Ps1Xml(Label = "ClientIp", Target = ViewControl.Table, Position = 2)]
        public IPAddress ClientIp { get; set; }

        [Ps1Xml(Label = "ClientPort", Target = ViewControl.Table, Position = 3)]
        public int ClientPort { get; set; }

        [Ps1Xml(Label = "OpenTime", Target = ViewControl.Table, ScriptBlock = "$_.OpenTime.UtcDateTime.ToString(\"u\")", Position = 4)]
        public DateTimeOffset OpenTime { get; }

        [Ps1Xml(Label = "LastReconnectTime", Target = ViewControl.Table, ScriptBlock = "$_.LastReconnectTime.UtcDateTime.ToString(\"u\")", Position = 5)]
        public DateTimeOffset? LastReconnectTime { get; set; }

        [Ps1Xml(Label = "FileId", Target = ViewControl.Table, Position = 6)]
        public ulong FileId { get; set; }

        [Ps1Xml(Label = "ParentId", Target = ViewControl.Table, Position = 7)]
        public ulong ParentId { get; set; }

        [Ps1Xml(Label = "SessionId", Target = ViewControl.Table, Position = 8)]
        public ulong SessionId { get; set; }

        public PSFileHandle(FileHandle handle)
        {
            this.HandleId = handle.HandleId;
            this.Path = handle.Path;
            this.ClientIp = handle.ClientIp;
            this.ClientPort = handle.ClientPort;
            this.OpenTime = handle.OpenTime;
            this.LastReconnectTime = handle.LastReconnectTime;
            this.FileId = handle.FileId;
            this.ParentId = handle.ParentId;
            this.SessionId = handle.SessionId;
        }
    }
}
