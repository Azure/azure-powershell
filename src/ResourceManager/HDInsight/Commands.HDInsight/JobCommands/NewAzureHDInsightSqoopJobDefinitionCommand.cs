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

using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.New,
        Constants.JobDefinitions.AzureHDInsightSqoopJobDefinition),
    OutputType(
        typeof(AzureHDInsightSqoopJobDefinition))]
    public class NewAzureHDInsightSqoopJobDefinitionCommand : HDInsightCmdletBase
    {
        private AzureHDInsightSqoopJobDefinition job;

        #region Input Parameter Definitions

        [Parameter(HelpMessage = "The hive arguments for the jobDetails.")]
        public string[] Arguments { get; set; }

        [Parameter(HelpMessage = "The files for the jobDetails.")]
        public string[] Files { get; set; }

        [Parameter(HelpMessage = "The output location to use for the job.")]
        public string StatusFolder
        {
            get { return job.StatusFolder; }
            set { job.StatusFolder = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "The command to run in the sqoop job.")]
        public string Command
        {
            get { return job.Command; }
            set { job.Command = value; }
        }

        [Parameter(HelpMessage = "The query file to run in the jobDetails.")]
        public string File
        {
            get { return job.File; }
            set { job.File = value; }
        }

        #endregion

        public NewAzureHDInsightSqoopJobDefinitionCommand()
        {
            Arguments = new string[] { };
            Files = new string[] { };
            job = new AzureHDInsightSqoopJobDefinition();
        }

        public override void ExecuteCmdlet()
        {
            foreach (var arg in Arguments)
            {
                job.Arguments.Add(arg);
            }

            foreach (var file in Files)
            {
                job.Files.Add(file);
            }

            WriteObject(job);
        }
    }
}
