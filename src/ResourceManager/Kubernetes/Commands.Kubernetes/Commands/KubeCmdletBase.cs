using System;
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Rest;
using CloudException = Microsoft.Rest.Azure.CloudException;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Graph.RBAC.Version1_6;

namespace Microsoft.Azure.Commands.Kubernetes
{
    public abstract class KubeCmdletBase : AzureRMCmdlet
    {
        private IContainerServiceClient _client;
        private IResourceManagementClient _rmClient;
        private IAuthorizationManagementClient _authClient;
        private IGraphRbacManagementClient _graphClient;

        protected const string KubeNounStr = "AzureRmKubernetes";

        protected IContainerServiceClient Client => _client ?? (_client = BuildClient<ContainerServiceClient>());

        protected IResourceManagementClient RmClient =>
            _rmClient ?? (_rmClient = BuildClient<ResourceManagementClient>());

        protected IAuthorizationManagementClient AuthClient =>
            _authClient ?? (_authClient = BuildClient<AuthorizationManagementClient>());

        protected IGraphRbacManagementClient GraphClient =>
            _graphClient ?? (_graphClient = BuildClient<GraphRbacManagementClient>(endpoint: AzureEnvironment.Endpoint.Graph, postBuild: instance =>
            {
                instance.TenantID = DefaultContext.Tenant.Id;
                return instance;
            }));

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

        private T BuildClient<T>(string endpoint = null, Func<T, T> postBuild = null) where T : ServiceClient<T>
        {
            var instance = AzureSession.Instance.ClientFactory.CreateArmClient<T>(
                DefaultProfile.DefaultContext, endpoint ?? AzureEnvironment.Endpoint.ResourceManager);
            return postBuild == null ? instance : postBuild(instance);
        }

        private string AzConfigDir => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".azure");

        protected string AcsSpFilePath => Path.Combine(AzConfigDir, "acsServicePrincipal.json");
    }
}