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

namespace Microsoft.WindowsAzure.Commands.Storage.File
{
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage.File;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    public abstract class AzureStorageFileCmdletBase : StorageCloudCmdletBase<IStorageFileManagement>
    {
        [Parameter(
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Azure Storage Context Object")]
        public override AzureStorageContext Context { get; set; }

        protected FileRequestOptions RequestOptions
        {
            get
            {
                return (FileRequestOptions)this.GetRequestOptions(StorageServiceType.File);
            }
        }

        protected override IStorageFileManagement CreateChannel()
        {
            if (this.Channel == null || !this.ShareChannel)
            {
                this.Channel = new StorageFileManagement(
                    this.ParameterSetName == Constants.ShareNameParameterSetName ||
                    this.ParameterSetName == Constants.MatchingPrefixParameterSetName ||
                    this.ParameterSetName == Constants.SpecificParameterSetName ?
                        this.GetCmdletStorageContext() :
                        AzureStorageContext.EmptyContextInstance
                );
            }

            return this.Channel;
        }

        protected CloudFileShare BuildFileShareObjectFromName(string name)
        {
            NamingUtil.ValidateShareName(name, false);
            return this.Channel.GetShareReference(name);
        }

        protected bool ShareIsEmpty(CloudFileShare share)
        {
            try
            {
                FileContinuationToken fileToken = new FileContinuationToken();
                IEnumerator<IListFileItem> listedFiles = share.GetRootDirectoryReference().ListFilesAndDirectoriesSegmented(1, fileToken, RequestOptions, OperationContext).Results.GetEnumerator();
                if (listedFiles.MoveNext() && listedFiles.Current != null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
