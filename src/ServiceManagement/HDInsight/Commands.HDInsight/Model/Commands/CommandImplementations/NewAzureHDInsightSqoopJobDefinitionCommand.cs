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
using System.Threading.Tasks;
using Microsoft.Hadoop.Client;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class NewAzureHDInsightSqoopJobDefinitionCommand
        : AzureHDInsightNewJobDefinitionCommand<AzureHDInsightSqoopJobDefinition>, INewAzureHDInsightSqoopJobDefinitionCommand
    {
        private readonly SqoopJobCreateParameters sqoopJobDefinition = new SqoopJobCreateParameters();
        private string[] resources = new string[] { };

        public string Command
        {
            get { return this.sqoopJobDefinition.Command; }
            set { this.sqoopJobDefinition.Command = value; }
        }

        public override Hashtable Defines { get; set; }

        public string File
        {
            get { return this.sqoopJobDefinition.File; }
            set { this.sqoopJobDefinition.File = value; }
        }

        public override string[] Files
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

        public override string StatusFolder
        {
            get { return this.sqoopJobDefinition.StatusFolder; }
            set { this.sqoopJobDefinition.StatusFolder = value; }
        }

        public override Task EndProcessing()
        {
            if (this.Command.IsNotNullOrEmpty() && this.File.IsNotNullOrEmpty())
            {
                throw new ArgumentException("Only Query or File can be specified, not both.");
            }

            var sqoopJob = new AzureHDInsightSqoopJobDefinition();
            sqoopJob.Command = this.Command;
            sqoopJob.File = this.File;
            sqoopJob.StatusFolder = this.StatusFolder;

            if (sqoopJob.Command.IsNullOrEmpty())
            {
                sqoopJob.File.ArgumentNotNullOrEmpty("File");
            }

            if (this.Files.IsNotNull())
            {
                sqoopJob.Files.AddRange(this.Files);
            }

            this.Output.Add(sqoopJob);
            return TaskEx.FromResult(0);
        }
    }
}
