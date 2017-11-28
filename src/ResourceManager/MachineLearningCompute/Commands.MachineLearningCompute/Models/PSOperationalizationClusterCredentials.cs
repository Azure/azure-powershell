using Microsoft.Azure.Management.MachineLearningCompute.Models;

namespace Microsoft.Azure.Commands.MachineLearningCompute.Models
{
    public class PSOperationalizationClusterCredentials : OperationalizationClusterCredentials
    {
        public PSOperationalizationClusterCredentials(OperationalizationClusterCredentials credentials)
        {
            this.StorageAccount = credentials.StorageAccount;
            this.ContainerRegistry = credentials.ContainerRegistry;
            this.ContainerService = credentials.ContainerService;
            this.AppInsights = credentials.AppInsights;
            this.ServiceAuthConfiguration = credentials.ServiceAuthConfiguration;
            this.SslConfiguration = credentials.SslConfiguration;
        }
    }
}
