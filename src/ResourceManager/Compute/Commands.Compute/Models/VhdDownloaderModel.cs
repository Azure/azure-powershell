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

using Microsoft.WindowsAzure.Commands.Sync;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using System.IO;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class VhdDownloaderModel
    {
        public static VhdDownloadContext Download(DownloaderParameters downloadParameters, ComputeClientBaseCmdlet cmdlet)
        {
            Program.SyncOutput = new PSSyncOutputEvents(cmdlet);

            downloadParameters.ProgressDownloadComplete = Program.SyncOutput.ProgressDownloadComplete;
            downloadParameters.ProgressDownloadStatus = Program.SyncOutput.ProgressDownloadStatus;

            var downloader = new Downloader(downloadParameters);
            downloader.Download();

            return new VhdDownloadContext
            {
                LocalFilePath = new FileInfo(downloadParameters.LocalFilePath),
                Source = downloadParameters.BlobUri.Uri
            };
        }
    }
}
