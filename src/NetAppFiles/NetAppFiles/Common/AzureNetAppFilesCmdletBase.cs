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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.NetAppFiles.Common
{
    /// <summary>
    /// Base class of Azure NetApp Files Cmdlet.
    /// </summary>
    public class AzureNetAppFilesCmdletBase : AzureRMCmdlet
    { 
        private INetAppManagementClient _netAppFilesManagementClient;

        protected const string ResourceIdParameterSet = "ByResourceIdParameterSet";
        protected const string ObjectParameterSet = "ByObjectParameterSet";
        protected const string ParentObjectParameterSet = "ByParentObjectParameterSet";
        protected const string FieldsParameterSet = "ByFieldsParameterSet";
        public const string PreviewMessage = "The cmdlet  is in preview.";

        /// <summary>
        /// Gets or sets the Azure NetApp Files management client.
        /// </summary>
        public INetAppManagementClient AzureNetAppFilesManagementClient
        {
            get =>
                _netAppFilesManagementClient ??
                (_netAppFilesManagementClient =
                    AzureSession.Instance.ClientFactory.CreateArmClient<NetAppManagementClient>(DefaultProfile.DefaultContext,
                        AzureEnvironment.Endpoint.ResourceManager));
            set { _netAppFilesManagementClient = value; }
        }
    }
}
