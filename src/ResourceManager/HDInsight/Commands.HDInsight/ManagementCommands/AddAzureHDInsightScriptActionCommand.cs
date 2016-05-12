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
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.Azure.Management.HDInsight.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.Add,
        Constants.CommandNames.AzureHDInsightScriptAction),
    OutputType(typeof(AzureHDInsightConfig))]
    public class AddAzureHDInsightScriptActionCommand : HDInsightCmdletBase
    {
        private AzureHDInsightScriptAction _action;
        #region Input Parameter Definitions

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster.")]
        public AzureHDInsightConfig Config { get; set; }

        [Parameter(Position = 1,
            Mandatory = true,
            HelpMessage = "The node on which to apply the action.")]
        public ClusterNodeType NodeType { get; set; }

        [Parameter(Position = 2,
            Mandatory = true,
            HelpMessage = "The URI for the action.")]
        public Uri Uri
        {
            get { return _action.Uri; }
            set { _action.Uri = value; }
        }

        [Parameter(Position = 3,
            Mandatory = true,
            HelpMessage = "The name of the action.")]
        public string Name
        {
            get { return _action.ActionName; }
            set { _action.ActionName = value; }
        }

        [Parameter(Position = 4,
            HelpMessage = "The parameters for the action.")]
        public string Parameters
        {
            get { return _action.Parameters; }
            set { _action.Parameters = value; }
        }

        #endregion

        public AddAzureHDInsightScriptActionCommand()
        {
            _action = new AzureHDInsightScriptAction();
        }

        public override void ExecuteCmdlet()
        {
            List<AzureHDInsightScriptAction> actions;

            if (Config.ScriptActions.TryGetValue(NodeType, out actions))
            {
                actions.Add(_action);
                Config.ScriptActions[NodeType] = actions;
            }
            else
            {
                Config.ScriptActions.Add(NodeType, new List<AzureHDInsightScriptAction> { _action });
            }

            WriteObject(Config);
        }
    }
}
