using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Kubernetes.Generated;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Kubernetes
{
public abstract class KubeCmdletBase : AzureRMCmdlet
    {
        private IContainerServiceClient client;

        protected const string KubeNounStr = "AzureRmKubernetes";

        public IContainerServiceClient Client
        {
            get
            {
                if (client == null)
                {
                    client = AzureSession.Instance.ClientFactory.CreateArmClient<ContainerServiceClient>(DefaultProfile.DefaultContext, AzureEnvironment.Endpoint.ResourceManager);
                }

                return client;
            }
        }

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
    }
}
