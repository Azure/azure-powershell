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

using Hyak.Common;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightGatewaySettings", DefaultParameterSetName = SetByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(AzureHDInsightGatewaySettings))]
    public class SetAzureHDInsightGatewaySettingsCommand : HDInsightCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";

        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SetByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = SetByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster InputObject;

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets the login for the cluster's user.")]
        public PSCredential HttpCredential
        {
            get
            {
                return _credential == null ? null : new PSCredential(_credential.Username, _credential.Password.ConvertToSecureString());
            }
            set
            {
                _credential = new BasicAuthenticationCloudCredentials
                {
                    Username = value.UserName,
                    Password = value.Password.ConvertToString()
                };
            }
        }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Gets or sets list of Entra users for gateway access.")]
        public List<EntraUserInfo> RestAuthEntraUsers { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            bool isHttpCredentialBound = this.IsParameterBound(c => c.HttpCredential);
            bool isRestAuthEntraUsersBound = this.IsParameterBound(c => c.RestAuthEntraUsers);

            if (isHttpCredentialBound && isRestAuthEntraUsersBound)
            {
                throw new ParameterBindingException("Error: Cannot provide both HttpCredential and RestAuthEntraUsers parameters.");
            }

            if (!isHttpCredentialBound && !isRestAuthEntraUsersBound)
            {
                throw new ParameterBindingException("Error: Either HttpCredential or RestAuthEntraUsers parameter must be provided.");
            }

            var updateGatewaySettingsParameters = new UpdateGatewaySettingsParameters();
            if (isHttpCredentialBound)
            {
                updateGatewaySettingsParameters.IsCredentialEnabled = true;
                updateGatewaySettingsParameters.UserName = HttpCredential.UserName;
                updateGatewaySettingsParameters.Password = HttpCredential.Password.ConvertToString();
            }

            if (isRestAuthEntraUsersBound)
            {
                updateGatewaySettingsParameters.IsCredentialEnabled = false;
                updateGatewaySettingsParameters.RestAuthEntraUsers = RestAuthEntraUsers;
            }


            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                this.ClusterName = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ClusterName = this.InputObject.Name;
                this.ResourceGroupName = this.InputObject.ResourceGroup;
            }

            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            string action = isHttpCredentialBound ? "set gateway HTTP credential" : "set gateway Entra users";

            if (ShouldProcess(ClusterName, action))
            {
                HDInsightManagementClient.UpdateGatewayCredential(ResourceGroupName, ClusterName, updateGatewaySettingsParameters);
                WriteObject(new AzureHDInsightGatewaySettings(HDInsightManagementClient.GetGatewaySettings(ResourceGroupName, ClusterName)));
            }
        }
    }
}
