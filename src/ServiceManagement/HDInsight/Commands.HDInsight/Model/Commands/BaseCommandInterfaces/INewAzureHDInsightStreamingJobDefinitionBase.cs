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
namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces
{
    internal interface INewAzureHDInsightStreamingJobDefinitionBase : INewAzureHDInsightJobWithDefinesConfigBase
    {
        /// <summary>
        ///     Gets or sets the arguments for the jobDetails.
        /// </summary>
        string[] Arguments { get; set; }

        /// <summary>
        ///     Gets or sets the command line environment for the mappers or the reducers.
        /// </summary>
        string[] CmdEnv { get; set; }

        /// <summary>
        ///     Gets or sets the Combiner.
        /// </summary>
        string Combiner { get; set; }

        /// <summary>
        ///     Gets or sets the location of the input data in Hadoop.
        /// </summary>
        string InputPath { get; set; }

        /// <summary>
        ///     Gets or sets the Mapper.
        /// </summary>
        string Mapper { get; set; }

        /// <summary>
        ///     Gets or sets the Location in which to store the output data.
        /// </summary>
        string OutputPath { get; set; }

        /// <summary>
        ///     Gets or sets the Reducer.
        /// </summary>
        string Reducer { get; set; }
    }
}
