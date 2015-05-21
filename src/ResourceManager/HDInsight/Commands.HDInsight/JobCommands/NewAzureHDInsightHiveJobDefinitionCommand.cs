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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(
        VerbsCommon.New,
        Constants.JobCommandNames.AzureHDInsightHiveJobDefinition),
    OutputType(
        typeof(AzureHDInsightHiveJobDefinition))]
    public class NewAzureHDInsightHiveJobDefinitionCommand : HDInsightCmdletBase
    {
        private AzureHDInsightHiveJobDefinition job;

        #region Input Parameter Definitions
        
        [Parameter(HelpMessage = "The hive arguments for the jobDetails.")]
        public ICollection<string> Arguments
        {
            get { return this.job.Arguments; }
            set { this.job.Arguments = value; }
        }

        [Parameter(HelpMessage = "The parameters for the jobDetails.")]
        public IDictionary<string, string> Defines
        {
            get { return this.job.Defines; }
            set { this.job.Defines = value; }
        }

        [Parameter(HelpMessage = "The query file to run in the jobDetails.")]
        public string File
        {
            get { return this.job.File; }
            set { this.job.File = value; }
        }

        [Parameter(HelpMessage = "The files for the jobDetails.")]
        public ICollection<string> Files
        {
            get { return this.job.Files; }
            set { this.job.Files = value; }
        }

        [Parameter(HelpMessage = "The name of the jobDetails.")]
        public string JobName
        {
            get { return this.job.JobName; }
            set { this.job.JobName = value; }
        }

        [Parameter(HelpMessage = "The query to run in the jobDetails.")]
        public string Query
        {
            get { return this.job.Query; }
            set { this.job.Query = value; }
        }
        
        [Parameter(HelpMessage = "Run the query as a file.")]
        public SwitchParameter RunAsFileJob
        {
            get { return this.job.RunAsFileJob; }
            set { this.job.RunAsFileJob = value; }
        }

        [Parameter(HelpMessage = "The output location to use for the job.")]
        public string StatusFolder
        {
            get { return this.job.StatusFolder; }
            set { this.job.StatusFolder = value; }
        }

        #endregion

        public NewAzureHDInsightHiveJobDefinitionCommand()
        {
            job = new AzureHDInsightHiveJobDefinition();
        }

        public override void ExecuteCmdlet()
        {
            WriteObject(job);
        }
    }
}
