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
namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    using CommandInterfaces;
    using DataObjects;
    using GetAzureHDInsightClusters;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using System;
    using System.Management.Automation;
    using System.Threading.Tasks;

    internal class AddAzureHDInsightScriptActionCommand : AzureHDInsightCommand<AzureHDInsightConfig>, IAddAzureHDInsightScriptActionCommand
    {
        private readonly AzureHDInsightScriptAction scriptAction = new AzureHDInsightScriptAction();

        public AddAzureHDInsightScriptActionCommand()
        {
            this.Config = new AzureHDInsightConfig();
        }

        public AzureHDInsightConfig Config { get; set; }

        public string Name
        {
            get { return this.scriptAction.Name; }
            set { this.scriptAction.Name = value; }
        }

        public ClusterNodeType[] ClusterRoleCollection
        {
            get { return this.scriptAction.ClusterRoleCollection; }
            set { this.scriptAction.ClusterRoleCollection = value; }
        }

        public Uri Uri
        {
            get { return this.scriptAction.Uri; }
            set { this.scriptAction.Uri = value; }
        }

        public string Parameters
        {
            get { return this.scriptAction.Parameters; }
            set { this.scriptAction.Parameters = value; }
        }

        public override Task EndProcessing()
        {
            this.Config.ConfigActions.Add(this.scriptAction);
            this.Output.Add(this.Config);
            return TaskEx.FromResult(0);
        }
    }
}
