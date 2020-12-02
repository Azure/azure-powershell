﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightDefaultStorage"), OutputType(typeof(AzureHDInsightConfig))]
    public class SetAzureHDInsightDefaultStorageCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster.")]
        public AzureHDInsightConfig Config { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            HelpMessage = "The storage account name for the storage account to be added to the new cluster.")]
        public string StorageAccountResourceId { get; set; }

        [Parameter(Position = 2,
            Mandatory = false,
            HelpMessage = "The storage account key for the storage account to be added to the new cluster.")]
        public string StorageAccountKey { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Gets or sets the type of the default storage account. Defaults to AzureStorage")]
        public StorageType? StorageAccountType { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            Config.StorageAccountType = StorageAccountType ?? Config.StorageAccountType;
            Config.StorageAccountResourceId = StorageAccountResourceId;
            Config.StorageAccountKey = StorageAccountKey;
            WriteObject(Config);
        }
    }
}
