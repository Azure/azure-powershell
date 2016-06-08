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
using Microsoft.WindowsAzure.Commands.Common;
using System.Collections;
using System.Management.Automation;

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

        [Parameter(HelpMessage = "The arguments for the jobDetails.")]
        public string[] Arguments { get; set; }

        [Parameter(HelpMessage = "List of files to be copied to the cluster.")]
        public string[] Files { get; set; }

        [Parameter(HelpMessage = "The output location to use for the job.")]
        public string StatusFolder
        {
            get { return job.StatusFolder; }
            set { job.StatusFolder = value; }
        }

        [Parameter(Mandatory = true, HelpMessage = "The class name to use for the jobDetails.")]
        public string ClassName
        {
            get { return job.ClassName; }
            set { job.ClassName = value; }
        }

        [Parameter(HelpMessage = "The parameters for the jobDetails.")]
        public Hashtable Defines { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The jar file to use for the jobDetails.")]
        public string JarFile
        {
            get { return job.JarFile; }
            set { job.JarFile = value; }
        }

        [Parameter(HelpMessage = "The name of the jobDetails.")]
        public string JobName
        {
            get { return job.JobName; }
            set { job.JobName = value; }
        }

        [Parameter(HelpMessage = "The lib jars for the jobDetails.")]
        public string[] LibJars { get; set; }

        #endregion

        public NewAzureHDInsightMapReduceJobDefinitionCommand()
        {
            Arguments = new string[] { };
            Files = new string[] { };
            Defines = new Hashtable();
            LibJars = new string[] { };
            job = new AzureHDInsightMapReduceJobDefinition();
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

            var defineDic = Defines.ToDictionary(false);
            foreach (var define in defineDic)
            {
                job.Defines.Add(define.Key, define.Value.ToString());
            }

            foreach (var libjar in LibJars)
            {
                job.LibJars.Add(libjar);
            }

            WriteObject(job);
        }
    }
}
