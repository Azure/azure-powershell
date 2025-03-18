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
using Azure;

namespace Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel
{
    public class PSShareFileInfo
    {

        public ETag ETag { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public bool IsServerEncrypted { get; set; }
        public FileSmbProperties SmbProperties { get; set; }
        public FilePosixProperties PosixProperties { get; set; }

        public PSShareFileInfo(ShareFileInfo info)
        {
            this.ETag = info.ETag;
            this.LastModified = info.LastModified;
            this.IsServerEncrypted = info.IsServerEncrypted;
            this.SmbProperties = info.SmbProperties;
            this.PosixProperties = info.PosixProperties;
        }
    }
}
