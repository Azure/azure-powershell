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
using Microsoft.WindowsAzure.Commands.Sync.Upload;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class VhdUploaderModel
    {
        public static VhdUploadContext Upload(UploadParameters uploadParameters)
        {
            Program.SyncOutput = new PSSyncOutputEvents(uploadParameters.Cmdlet);

            BlobCreatorBase blobCreator;
            if (uploadParameters.BaseImageUri != null)
            {
                blobCreator = new PatchingBlobCreator(uploadParameters.LocalFilePath, uploadParameters.DestinationUri, uploadParameters.BaseImageUri, uploadParameters.BlobObjectFactory, uploadParameters.OverWrite);
            }
            else
            {
                blobCreator = new BlobCreator(uploadParameters.LocalFilePath, uploadParameters.DestinationUri, uploadParameters.BlobObjectFactory, uploadParameters.OverWrite);
            }

            using (var uploadContext = blobCreator.Create())
            {
                var synchronizer = new BlobSynchronizer(uploadContext, uploadParameters.NumberOfUploaderThreads);
                if (synchronizer.Synchronize())
                {
                    return new VhdUploadContext {LocalFilePath = uploadParameters.LocalFilePath, DestinationUri = uploadParameters.DestinationUri.Uri};
                }
                return null;
            }
        }
    }
}