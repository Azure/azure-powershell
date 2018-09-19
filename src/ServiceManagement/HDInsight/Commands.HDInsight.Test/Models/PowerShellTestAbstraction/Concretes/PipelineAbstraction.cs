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

using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Concretes
{
    public class PipelineAbstraction : RunspaceAbstraction, IPipeline
    {
        internal PipelineAbstraction(Pipeline pipeline, Runspace runspace) : base(runspace)
        {
            this.Pipeline = pipeline;
        }

        protected Pipeline Pipeline { get; private set; }

        public ICommand AddCommand(string commandName)
        {
            var command = new Command(commandName);
            this.Pipeline.Commands.Add(command);
            return Help.SafeCreate(() => new CommandAbstraction(command, this.Pipeline, this.Runspace));
        }

        public IPipelineResult Invoke()
        {
            Collection<PSObject> results = this.Pipeline.Invoke();
            return Help.SafeCreate(() => new PipelineResultsAbstraction(results, this.Runspace));
        }
    }
}
