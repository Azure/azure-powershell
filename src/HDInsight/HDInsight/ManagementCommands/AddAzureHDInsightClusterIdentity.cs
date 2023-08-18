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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight.ManagementCommands
{
    [CmdletOutputBreakingChangeWithVersion(typeof(AzureHDInsightConfig), Constants.deprecateByAzVersion, Constants.deprecateByVersion, 
        DeprecatedOutputProperties = new string[] {"Dictionary<ClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions"}, 
        NewOutputProperties = new string[] {"Dictionary<RuntimeScriptActionClusterNodeType, List<AzureHDInsightScriptAction>> ScriptActions"})]
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightClusterIdentity",DefaultParameterSetName = CertificateFilePathSet),OutputType(typeof(AzureHDInsightConfig))]
    public class AddAzureHDInsightClusterIdentity : HDInsightCmdletBase
    {
        private const string CertificateFilePathSet = "CertificateFilePath";
        private const string CertificateFileContentsSet = "CertificateFileContents";

        #region Input Parameter Definitions

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster")]
        public AzureHDInsightConfig Config { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Service Principal Object Id for accessing Azure Data Lake.")]
        public Guid ObjectId { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The Service Principal certificate file path for accessing Azure Data Lake.",
            ParameterSetName = CertificateFilePathSet)]
        public string CertificateFilePath { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The Service Principal certificate file contents for accessing Azure Data Lake.",
            ParameterSetName = CertificateFileContentsSet)]
        public byte[] CertificateFileContents { get; set; }

        [Parameter(Position = 3,
            Mandatory = true,
            HelpMessage = "The Service Principal certificate password for accessing Azure Data Lake.")]
        public string CertificatePassword { get; set; }

        [Parameter(Position = 4,
            Mandatory = false,
            HelpMessage = "The Service Principal AAD Tenant Id for accessing Azure Data Lake.")]
        public Guid AadTenantId { get; set; }

        [Parameter(Position = 5,
            Mandatory = false,
            HelpMessage = "The Service Principal Application Id for accessing Azure Data Lake.")]
        public Guid ApplicationId { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case CertificateFilePathSet:
                    {
                        Config.CertificateFilePath = CertificateFilePath;
                    }
                    break;
                case CertificateFileContentsSet:
                    {
                        Config.CertificateFileContents = CertificateFileContents;
                    }
                    break;
                default:
                    throw new ArgumentException("Please specify CertificateFilePath or CertificateFileContent");
            }

            Config.ObjectId = ObjectId;
            Config.ApplicationId = ApplicationId;
            Config.AADTenantId = AadTenantId;
            Config.CertificatePassword = CertificatePassword;

            WriteObject(Config);
        }
    }
}
