using Microsoft.AzureStack.AzureConsistentStorage.Models;

namespace Microsoft.AzureStack.AzureConsistentStorage.Commands
{
    internal class QueueServiceResponse : ServiceResponseBase
    {
        public QueueServiceResponse(QueueServiceResponseResource resource)
            : base(resource, "QueueService")
        {
        }

        public QueueServiceSettings Settings { get; set; }
    }
}
