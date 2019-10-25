using System;
using System.IO;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Rest;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.custom
{
    public abstract class KubeCmdletBase : AzureRMCmdlet
    {
        private IAuthorizationManagementClient _authClient;
        private IGraphRbacManagementClient _graphClient;

        private IResourceManagementClient _rmClient;

        protected IResourceManagementClient RmClient =>
            _rmClient ?? (_rmClient = BuildClient<ResourceManagementClient>());

        protected IAuthorizationManagementClient AuthClient =>
            _authClient ?? (_authClient = BuildClient<AuthorizationManagementClient>());

        protected IGraphRbacManagementClient GraphClient =>
            _graphClient ?? (_graphClient = BuildClient<GraphRbacManagementClient>(
                endpoint: AzureEnvironment.Endpoint.Graph, postBuild: instance =>
                {
                    instance.TenantID = DefaultContext.Tenant.Id;
                    return instance;
                }));

        private string AzConfigDir => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            ".azure");

        protected string AcsSpFilePath => Path.Combine(AzConfigDir, "acsServicePrincipal.json");

        /// <summary>
        ///     Run Cmdlet with Error Handling (report error correctly)
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

        protected async Task RunCmdLetAsync(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch (CloudException ex)
            {
                throw new PSInvalidOperationException(ex.Body.Message, ex);
            }
        }

        protected async Task ConfirmActionAsync(bool force, string continueMessage, string processMessage,
            string target,
            Func<Task> func)
        {
            if (_qosEvent != null)
            {
                _qosEvent.PauseQoSTimer();
            }

            if (force || ShouldContinue(continueMessage, ""))
            {
                if (ShouldProcess(target, processMessage))
                {
                    if (_qosEvent != null)
                    {
                        _qosEvent.ResumeQosTimer();
                    }

                    await func();
                }
            }
        }

        private T BuildClient<T>(string endpoint = null, Func<T, T> postBuild = null) where T : ServiceClient<T>
        {
            var instance = AzureSession.Instance.ClientFactory.CreateArmClient<T>(
                DefaultProfile.DefaultContext, endpoint ?? AzureEnvironment.Endpoint.ResourceManager);
            return postBuild == null ? instance : postBuild(instance);
        }
    }
}