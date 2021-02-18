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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchSupportedImage"),OutputType(typeof(PSImageInformation))]
    public class GetBatchAccountSupportedImagesCommand : BatchObjectModelCmdletBase
    {
        private int maxCount = Constants.DefaultMaxCount;

        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Filter { get; set; }

        [Parameter]
        [ValidateNotNullOrEmpty]
        public int MaxCount
        {
            get { return this.maxCount; }
            set { this.maxCount = value; }
        }

        protected override void ExecuteCmdletImpl()
        {
            foreach (PSImageInformation nodeAgentSku in BatchClient.ListSupportedImages(this.BatchContext, this.Filter, this.MaxCount, this.AdditionalBehaviors))
            {
                WriteObject(nodeAgentSku);
            }
        }
    }
}
