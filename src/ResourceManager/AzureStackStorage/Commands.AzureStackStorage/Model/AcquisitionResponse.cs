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
using Microsoft.AzureStack.AzureConsistentStorage;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    internal class AcquisitionResponse : ResponseBase
    {
        public AcquisitionResponse(AcquisitionModel resource) : base(resource)
        {

        }

        public string FilePath { get; set; }

        public long MaximumBlobSize { get; set; }

        public AcquisitionStatus Status { get; set; }

        public Guid TenantSubscriptionId { get; set; }

        public string StorageAccountName { get; set; }

        public string Container { get; set; }

        public string Blob { get; set; }

        public string AcquisitionId { get; set; }

    }
}