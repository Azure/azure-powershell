using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.SignalR.Generated;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.SignalR
{
    public abstract class SignalRCmdletBase : AzureRMCmdlet
    {
        protected const string SignalRNoun = "AzureRmSignalR";
        protected const string SignalRKeyNoun = "AzureRmSignalRKey";
        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string ListSignalRServiceParameterSet = "ListSignalRServiceParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        private ISignalRManagementClient _client;

        protected ISignalRManagementClient Client => _client ?? (_client = BuildClient<SignalRManagementClient>());

        /// <summary>
        /// Run Cmdlet with Error Handling (report error correctly)
        /// </summary>
        /// <param name="action">The actual Cmdlet action to be wrapped.</param>
        protected void RunCmdlet(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Rest.Azure.CloudException ex)
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
    }
}
