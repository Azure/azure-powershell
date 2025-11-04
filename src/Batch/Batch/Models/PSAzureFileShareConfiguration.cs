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
    public partial class PSAzureFileShareConfiguration
    {
        internal AzureFileShareConfiguration toMgmtAzureFileShareConfiguration()
        {
            return new AzureFileShareConfiguration(
                accountName: this.AccountName,
                azureFileUrl: this.AzureFileUrl,
                accountKey: this.AccountKey,
                relativeMountPath: this.RelativeMountPath,
                mountOptions: this.MountOptions);
        }

        internal static PSAzureFileShareConfiguration fromMgmtAzureFileShareConfiguration(AzureFileShareConfiguration afs)
        {
            if (afs == null)
            {
                return null;
            }
            return new PSAzureFileShareConfiguration(
            
                accountName: afs.AccountName,
                azureFileUrl: afs.AzureFileUrl,
                accountKey: afs.AccountKey,
                relativeMountPath: afs.RelativeMountPath,
                mountOptions: afs.MountOptions
            );
        }
    }
}
