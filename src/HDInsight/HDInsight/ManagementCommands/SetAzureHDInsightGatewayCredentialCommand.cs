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
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightGatewayCredential", DefaultParameterSetName = SetByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(AzureHDInsightGatewaySettings))]
    public class SetAzureHDInsightGatewayCredentialCommand : HDInsightCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";

        #region Input Parameter Definitions

        [Alias("ClusterName")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get { return _clusterName; }
            set { _clusterName = value; }
        }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = SetByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster InputObject;

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SetByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId;

        [Parameter(
            Position = 1,
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
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            HelpMessage = "Gets or sets the Entra user data. Accepts a JSON array of user objects with 'ObjectId', 'DisplayName', and 'Upn' fields, or one or more ObjectIds/UPNs separated by ';' or ','. Whitespace around entries is ignored.")]
        public string EntraUserData { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            bool isHttpCredentialBound = this.HttpCredential != null;
            bool isRestAuthEntraUsersBound = this.EntraUserData != null;
            List<EntraUserInfo> RestAuthEntraUsers = ClusterConfigurationUtils.GetHDInsightGatewayEntraUser(EntraUserData);
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
            }else if (isRestAuthEntraUsersBound)
            {
                updateGatewaySettingsParameters.IsCredentialEnabled = false;
                updateGatewaySettingsParameters.RestAuthEntraUsers = RestAuthEntraUsers;
            }


            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                this.Name = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.Name = this.InputObject.Name;
                this.ResourceGroupName = this.InputObject.ResourceGroup;
            }

            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(Name);
            }

            string action = isHttpCredentialBound ? "set gateway HTTP credential" : "set gateway Entra users";

            if (ShouldProcess(Name, action))
            {
                HDInsightManagementClient.UpdateGatewayCredential(ResourceGroupName, Name, updateGatewaySettingsParameters);
                WriteObject(new AzureHDInsightGatewaySettings(HDInsightManagementClient.GetGatewaySettings(ResourceGroupName, Name)));
            }
        }
    }
}
