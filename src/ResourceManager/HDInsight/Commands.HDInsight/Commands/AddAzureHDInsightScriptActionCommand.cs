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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.Add,
        Constants.CommandNames.AzureHDInsightScriptAction),
    OutputType(typeof(AzureHDInsightConfig))]
    public class AddAzureHDInsightScriptActionCommand : HDInsightCmdletBase
    {
        private ScriptAction _action;
        #region Input Parameter Definitions

        [Parameter(Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster")]
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
            get { return this._action.Uri; }
            set { this._action.Uri = value; }
        }

        [Parameter(Position = 3,
            Mandatory = true,
            HelpMessage = "The name of the action.")]
        public string Name
        {
            get { return this._action.Name; }
            set { this._action.Name = value; }
        }

        [Parameter(Position = 4,
            Mandatory = true,
            HelpMessage = "The parameters for the action.")]
        public string Parameters
        {
            get { return this._action.Parameters; }
            set { this._action.Parameters = value; }
        }

        #endregion

        public AddAzureHDInsightScriptActionCommand()
        {
            _action = new ScriptAction();
        }
        
        public override void ExecuteCmdlet()
        {
            List<ScriptAction> actions;

            if (this.Config.ScriptActions.TryGetValue(this.NodeType, out actions))
            {
                actions.Add(this._action);
                this.Config.ScriptActions[this.NodeType] = actions;
            }
            else
            {
                this.Config.ScriptActions.Add(this.NodeType, new List<ScriptAction> {_action});
            }
        }

        private void AddConfigToConfigurations(Dictionary<string, string> userConfigs, string configKey)
        {
            //if no configs of this type provided, do nothing
            if (userConfigs == null || userConfigs.Count == 0)
            {
                return;
            }

            Dictionary<string, string> config;

            //if configs provided and key does not already exist, add the key with provided dictionary
            if (!_configurations.TryGetValue(configKey, out config))
            {
                _configurations.Add(configKey, userConfigs);
                return;
            }

            //if configs provided and key already exists, add the provided values to the dictionary for the key
            foreach (var conf in userConfigs)
            {
                config.Add(conf.Key, conf.Value);
            }
            _configurations[configKey] = config;
        }
    }
}
