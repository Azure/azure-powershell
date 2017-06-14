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
        Constants.JobDefinitions.AzureHDInsightHiveJobDefinition),
    OutputType(
        typeof(AzureHDInsightHiveJobDefinition))]
    public class NewAzureHDInsightHiveJobDefinitionCommand : HDInsightCmdletBase
    {
        private AzureHDInsightHiveJobDefinition job;

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

        [Parameter(HelpMessage = "The parameters for the jobDetails.")]
        public Hashtable Defines { get; set; }

        [Parameter(HelpMessage = "The query file to run in the jobDetails.")]
        public string File
        {
            get { return job.File; }
            set { job.File = value; }
        }

        [Parameter(HelpMessage = "The name of the jobDetails.")]
        public string JobName
        {
            get { return job.JobName; }
            set { job.JobName = value; }
        }

        [Parameter(HelpMessage = "The query to run in the jobDetails.")]
        public string Query
        {
            get { return job.Query; }
            set { job.Query = value; }
        }

        [Parameter(HelpMessage = "Run the query as a file.")]
        public SwitchParameter RunAsFileJob
        {
            get { return job.RunAsFileJob; }
            set { job.RunAsFileJob = value; }
        }

        #endregion

        public NewAzureHDInsightHiveJobDefinitionCommand()
        {
            Arguments = new string[] { };
            Files = new string[] { };
            Defines = new Hashtable();
            job = new AzureHDInsightHiveJobDefinition();
        }

        public override void ExecuteCmdlet()
        {
            var hivejob = GetHiveJob();

            WriteObject(hivejob);
        }

        public AzureHDInsightHiveJobDefinition GetHiveJob()
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
            return job;
        }
    }
}
