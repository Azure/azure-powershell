// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Utils;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSAzureBlobFileSystemConfiguration
    {
        internal Management.Batch.Models.AzureBlobFileSystemConfiguration toMgmtAzureBlobFileSystemConfiguration()
        {
            return new Management.Batch.Models.AzureBlobFileSystemConfiguration()
            {
                AccountName = this.AccountName,
                ContainerName = this.ContainerName,
                AccountKey = this.AccountKey,
                SasKey = this.SasKey,
                BlobfuseOptions = this.BlobfuseOptions,
                RelativeMountPath = this.RelativeMountPath,
                IdentityReference = this.IdentityReference?.toMgmtIdentityReference()
            };
        }

        internal static PSAzureBlobFileSystemConfiguration fromMgmtAzureBlobFileSystemConfiguration(Management.Batch.Models.AzureBlobFileSystemConfiguration fsConfig)
        {
            if (fsConfig == null)
            {
                return null;
            }
            if (fsConfig.IdentityReference != null)
            {
                return new PSAzureBlobFileSystemConfiguration(
                   accountName: fsConfig.AccountName,
                   containerName: fsConfig.ContainerName,
                   relativeMountPath: fsConfig.RelativeMountPath,
                   identityReference: (fsConfig.IdentityReference != null ? new PSComputeNodeIdentityReference(PSComputeNodeIdentityReference.fromMgmtIdentityReference(fsConfig.IdentityReference)) : null),
                   blobfuseOptions: fsConfig.BlobfuseOptions);

            }else if (fsConfig.SasKey != null)
            {
                return new PSAzureBlobFileSystemConfiguration(
                   accountName: fsConfig.AccountName,
                   containerName: fsConfig.ContainerName,
                   relativeMountPath: fsConfig.RelativeMountPath,
                   key: Microsoft.Azure.Batch.AzureStorageAuthenticationKey.FromSasKey(fsConfig.SasKey),
                   blobfuseOptions: fsConfig.BlobfuseOptions);
            }
            else if (fsConfig.AccountKey != null)
            {
                return new PSAzureBlobFileSystemConfiguration(
                   accountName: fsConfig.AccountName,
                   containerName: fsConfig.ContainerName,
                   relativeMountPath: fsConfig.RelativeMountPath,
                   key: Microsoft.Azure.Batch.AzureStorageAuthenticationKey.FromAccountKey(fsConfig.AccountKey),
                   blobfuseOptions: fsConfig.BlobfuseOptions);
            }

            return null;
        }
    }
}
