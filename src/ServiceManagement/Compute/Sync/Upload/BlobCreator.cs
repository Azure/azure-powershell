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

using Microsoft.WindowsAzure.Commands.Sync.Download;
using System.IO;

namespace Microsoft.WindowsAzure.Commands.Sync.Upload
{
    public class BlobCreator : BlobCreatorBase
    {
        public BlobCreator(FileInfo localVhd, BlobUri destination, ICloudPageBlobObjectFactory blobObjectFactory, bool overWrite) :
            base(localVhd, destination, blobObjectFactory, overWrite)
        {
        }

        protected override void CreateRemoteBlobAndPopulateContext(UploadContext context)
        {
            CreateRemoteBlob();
            PopulateContextWithUploadableRanges(localVhd, context, false);
            PopulateContextWithDataToUpload(localVhd, context);
        }

        private void CreateRemoteBlob()
        {
            Program.SyncOutput.MessageCreatingNewPageBlob(OperationMetaData.FileMetaData.VhdSize);

            destinationBlob.Create(OperationMetaData.FileMetaData.VhdSize);

            using (var bdms = new BlobMetaDataScope(destinationBlob))
            {
                bdms.Current.SetUploadMetaData(OperationMetaData);
                bdms.Complete();
            }
        }
    }
}