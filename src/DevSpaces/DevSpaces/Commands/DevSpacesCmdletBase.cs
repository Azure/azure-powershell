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
using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.Aks.Generated.Version2017_08_31;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.DevSpaces;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Rest;
using CloudException = Microsoft.Rest.Azure.CloudException;

namespace Microsoft.Azure.Commands.DevSpaces.Commands
{
    public abstract class DevSpacesCmdletBase : AzureRMCmdlet
    {
        protected const string DevSpacesControllerNoun = "AzureRmDevSpacesController";
        protected const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        protected const string ListDevSpacesControllerParameterSet = "ListDevSpacesControllerParameterSet";
        protected const string DevSpacesControllerNameParameterSet = "DevSpacesControllerNameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";
        protected const string InputObjectParameterSet = "InputObjectParameterSet";

        private IDevSpacesManagementClient _client;
        private IResourceManagementClient _rmClient;
        private IContainerServiceClient _aksClient;

        protected IDevSpacesManagementClient Client => _client ?? (_client = BuildClient<DevSpacesManagementClient>());

        protected IContainerServiceClient ContainerClient => _aksClient ?? (_aksClient = BuildClient<ContainerServiceClient>());

        protected IResourceManagementClient RmClient =>
            _rmClient ?? (_rmClient = BuildClient<ResourceManagementClient>());


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
