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
    using System.Management.Automation;

    internal interface INewAzureHDInsightHiveJobDefinitionBase : INewAzureHDInsightJobWithDefinesConfigBase
    {
        /// <summary>
        ///     Gets or sets the Arguments for the jobDetails.
        /// </summary>
        string[] Arguments { get; set; }

        /// <summary>
        ///     Gets or sets the query file to use for a hive job.
        /// </summary>
        string File { get; set; }

        /// <summary>
        ///     Gets or sets the Query to use for the jobDetails.
        /// </summary>
        string Query { get; set; }

        ///<summary>
        ///    Gets or sets RunAsFileJob.
        ///</summary>
        SwitchParameter RunAsFileJob { get; set; }
    }
}
