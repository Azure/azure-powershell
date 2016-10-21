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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.Add,
        Constants.CommandNames.AzureHDInsightComponentVersion),
    OutputType(typeof(AzureHDInsightConfig))]
    public class AddAzureHDInsightComponentVersionCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster.")]
        public AzureHDInsightConfig Config { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            HelpMessage = "The component name whose version should be specified for the new cluster.")]
        public string ComponentName { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The version of a specific service in the new cluster.")]
        public string ComponentVersion { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            Config.ComponentVersion.Add(ComponentName, ComponentVersion);
            WriteObject(Config);
        }
    }
}
