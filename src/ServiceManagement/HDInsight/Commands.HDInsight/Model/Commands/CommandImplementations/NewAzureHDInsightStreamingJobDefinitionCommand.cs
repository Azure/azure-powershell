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
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations
{
    internal class NewAzureHDInsightStreamingJobDefinitionCommand
        : AzureHDInsightNewJobDefinitionCommand<AzureHDInsightStreamingMapReduceJobDefinition>, INewAzureHDInsightStreamingJobDefinitionCommand
    {
        /// <inheritdoc />
        public string[] Arguments { get; set; }

        /// <inheritdoc />
        public string[] CmdEnv { get; set; }

        /// <inheritdoc />
        public string Combiner { get; set; }

        /// <inheritdoc />
        public override Hashtable Defines { get; set; }

        /// <inheritdoc />
        public override string[] Files { get; set; }

        /// <inheritdoc />
        public string InputPath { get; set; }

        /// <inheritdoc />
        public string JobName { get; set; }

        /// <inheritdoc />
        public string Mapper { get; set; }

        /// <inheritdoc />
        public string OutputPath { get; set; }

        /// <inheritdoc />
        public string Reducer { get; set; }

        /// <inheritdoc />
        public override string StatusFolder { get; set; }

        public override Task EndProcessing()
        {
            this.InputPath.ArgumentNotNullOrEmpty("Input");
            this.OutputPath.ArgumentNotNullOrEmpty("Output");
            this.Mapper.ArgumentNotNullOrEmpty("Mapper");

            var streamingMapReduceJob = new AzureHDInsightStreamingMapReduceJobDefinition();
            streamingMapReduceJob.JobName = this.JobName;
            streamingMapReduceJob.Input = this.InputPath;
            streamingMapReduceJob.Output = this.OutputPath;
            streamingMapReduceJob.Mapper = this.Mapper;
            streamingMapReduceJob.Reducer = this.Reducer;
            streamingMapReduceJob.Combiner = this.Combiner;
            streamingMapReduceJob.StatusFolder = this.StatusFolder;

            if (this.Defines.IsNotNull())
            {
                streamingMapReduceJob.Defines.AddRange(this.Defines.ToKeyValuePairs());
            }

            if (this.CmdEnv.IsNotNull())
            {
                streamingMapReduceJob.CommandEnvironment.AddRange(this.CmdEnv);
            }

            if (this.Arguments.IsNotNull())
            {
                streamingMapReduceJob.Arguments.AddRange(this.Arguments);
            }

            if (this.Files.IsNotNull())
            {
                streamingMapReduceJob.Files.AddRange(this.Files);
            }

            this.Output.Add(streamingMapReduceJob);
            return TaskEx.FromResult(0);
        }
    }
}
