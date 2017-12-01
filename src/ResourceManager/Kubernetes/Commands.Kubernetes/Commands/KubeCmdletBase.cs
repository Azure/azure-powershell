using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Rest;
using CloudException = Microsoft.Rest.Azure.CloudException;

namespace Microsoft.Azure.Commands.Kubernetes
{
public abstract class KubeCmdletBase : AzureRMCmdlet
    {
        private IContainerServiceClient _client;
        private IResourceManagementClient _rmClient;
        private IGraphRbacManagementClient _graphClient;

        protected const string KubeNounStr = "AzureRmKubernetes";

        protected IContainerServiceClient Client => _client ?? (_client = BuildClient<ContainerServiceClient>());

        protected IResourceManagementClient RmClient => _rmClient ?? ( _rmClient = BuildClient<ResourceManagementClient>());

        protected IGraphRbacManagementClient GraphClient =>
            _graphClient ?? (_graphClient = BuildClient<GraphRbacManagementClient>());

        /// <summary>
        /// Run Cmdlet with Error Handling (report error correctly)
        /// </summary>
        /// <param name="action"></param>
        protected void RunCmdLet(Action action)
        {
            try
            {
                action();
            }
            catch (CloudException ex)
            {
                throw new PSInvalidOperationException(ex.Body.Message, ex);
            }
        }

        private T BuildClient<T>() where T : ServiceClient<T>
        {
            return AzureSession.Instance.ClientFactory.CreateArmClient<T>(
                DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
        }
    }
}
