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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.New,
        Constants.JobDefinitions.AzureHDInsightMapReduceJobDefinition),
    OutputType(
        typeof(AzureHDInsightMapReduceJobDefinition))]
    public class NewAzureHDInsightMapReduceJobDefinitionCommand : HDInsightCmdletBase
    {
        private AzureHDInsightMapReduceJobDefinition job;

        #region Input Parameter Definitions

        [Parameter(HelpMessage = "The hive arguments for the jobDetails.")]
        public string[] Arguments { get; set; }

        [Parameter(HelpMessage = "The files for the jobDetails.")]
        public string[] Files { get; set; }

        [Parameter(HelpMessage = "The output location to use for the job.")]
        public string StatusFolder
        {
            get { return this.job.StatusFolder; }
            set { this.job.StatusFolder = value; }
        }

        [Parameter(Mandatory = true, HelpMessage = "The class name to use for the jobDetails.")]
        public string ClassName
        {
            get { return this.job.ClassName; }
            set { this.job.ClassName = value; }
        }

        [Parameter(HelpMessage = "The parameters for the jobDetails.")]
        public Hashtable Defines { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The jar file to use for the jobDetails.")]
        public string JarFile
        {
            get { return this.job.JarFile; }
            set { this.job.JarFile = value; }
        }

        [Parameter(HelpMessage = "The name of the jobDetails.")]
        public string JobName
        {
            get { return this.job.JobName; }
            set { this.job.JobName = value; }
        }

        [Parameter(HelpMessage = "The lib jars for the jobDetails.")]
        public string[] LibJars { get; set; }

        #endregion

        public NewAzureHDInsightMapReduceJobDefinitionCommand()
        {
            this.Arguments = new string[] { };
            this.Files = new string[] { };
            this.Defines = new Hashtable();
            this.LibJars = new string[] { };
            job = new AzureHDInsightMapReduceJobDefinition();
        }

        public override void ExecuteCmdlet()
        {
            foreach (var arg in this.Arguments)
            {
                this.job.Arguments.Add(arg);
            }

            foreach (var file in this.Files)
            {
                this.job.Files.Add(file);
            }

            foreach (KeyValuePair<string, string> define in this.Defines)
            {
                this.job.Defines.Add(define.Key, define.Value);
            }

            foreach (var libjar in this.LibJars)
            {
                this.job.LibJars.Add(libjar);
            }

            WriteObject(job);
        }
    }
}
