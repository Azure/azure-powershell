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