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
using System.Net;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using Azure.Storage.Files.Shares.Models;

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

        [Ps1Xml(Label = "ClientName", Target = ViewControl.Table, Position = 9)]
        public string ClientName { get; set; }

        public PSFileHandle(ShareFileHandle handle)
        {
            if (!String.IsNullOrEmpty(handle.HandleId))
            {
                this.HandleId = Convert.ToUInt64(handle.HandleId);
            }
            this.Path = handle.Path;
            this.ClientName = handle.ClientName;
            if (!String.IsNullOrEmpty(handle.ClientIp))
            {
                string[] clientIPs = handle.ClientIp.Split(new char[] { ':'}, StringSplitOptions.RemoveEmptyEntries);
                if (clientIPs.Length >= 1)
                {
                    this.ClientIp = IPAddress.Parse(clientIPs[0]);
                }
                if (clientIPs.Length >= 2 && !String.IsNullOrEmpty(clientIPs[1]))
                {
                    this.ClientPort = Convert.ToInt32(clientIPs[1]);
                }
            }
            if (handle.OpenedOn != null)
            {
                this.OpenTime = handle.OpenedOn.Value;
            }
            this.LastReconnectTime = handle.LastReconnectedOn;
            if (!String.IsNullOrEmpty(handle.FileId))
            {
                this.FileId = Convert.ToUInt64(handle.FileId);
            }
            if (!String.IsNullOrEmpty(handle.ParentId))
            {
                this.ParentId = Convert.ToUInt64(handle.ParentId);
            }
            if (!String.IsNullOrEmpty(handle.SessionId))
            {
                this.SessionId = Convert.ToUInt64(handle.SessionId);
            }
        }
    }
}
