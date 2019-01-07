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

namespace Microsoft.WindowsAzure.Commands.Sync.Download
{
    public class DownloaderParameters
    {
        public BlobUri BlobUri { get; set; }
        public string LocalFilePath { get; set; }
        public int ConnectionLimit { get; set; }
        public string StorageAccountKey { get; set; }
        public bool ValidateFreeDiskSpace { get; set; }
        public bool OverWrite { get; set; }
        public Action<ProgressRecord> ProgressDownloadStatus { get; set; }
        public Action<TimeSpan> ProgressDownloadComplete { get; set; }
    }
}