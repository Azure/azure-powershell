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
    internal class NewAzureHDInsightPigJobDefinitionCommand
        : AzureHDInsightNewJobDefinitionCommand<AzureHDInsightPigJobDefinition>, INewAzureHDInsightPigJobDefinitionCommand
    {
        private readonly PigJobCreateParameters pigJobDefinition = new PigJobCreateParameters();
        private Hashtable defines = new Hashtable();
        private string[] resources = new string[] { };

        public string[] Arguments { get; set; }

        public override Hashtable Defines
        {
            get { return this.defines; }
            set { this.defines = value; }
        }

        public string File
        {
            get { return this.pigJobDefinition.File; }
            set { this.pigJobDefinition.File = value; }
        }

        public override string[] Files
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

        public string Query
        {
            get { return this.pigJobDefinition.Query; }
            set { this.pigJobDefinition.Query = value; }
        }

        public override string StatusFolder
        {
            get { return this.pigJobDefinition.StatusFolder; }
            set { this.pigJobDefinition.StatusFolder = value; }
        }

        public override Task EndProcessing()
        {
            if (this.Query.IsNotNullOrEmpty() && this.File.IsNotNullOrEmpty())
            {
                throw new ArgumentException("Only Query or File can be specified, not both.");
            }

            var pigJob = new AzureHDInsightPigJobDefinition();
            pigJob.Query = this.Query;
            pigJob.File = this.File;
            pigJob.StatusFolder = this.StatusFolder;

            if (this.Arguments.IsNotNull())
            {
                pigJob.Arguments.AddRange(this.Arguments);
            }

            if (this.Files.IsNotNull())
            {
                pigJob.Files.AddRange(this.Files);
            }

            this.Output.Add(pigJob);
            return TaskEx.FromResult(0);
        }
    }
}
