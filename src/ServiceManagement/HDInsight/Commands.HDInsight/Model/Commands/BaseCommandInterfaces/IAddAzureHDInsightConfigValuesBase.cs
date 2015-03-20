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
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces
{
    /// <summary>
    ///     Represents a command to set custom configuration values for Hadoop services.
    /// </summary>
    internal interface IAddAzureHDInsightConfigValuesBase
    {
        /// <summary>
        ///     Gets or sets the AzureHDInsightConfig.
        /// </summary>
        AzureHDInsightConfig Config { get; set; }

        /// <summary>
        ///     Gets or sets a collection of configuration properties to customize the Core Hadoop service.
        /// </summary>
        Hashtable Core { get; set; }

        /// <summary>
        ///     Gets or sets a collection of configuration properties to customize the Yarn Hadoop service.
        /// </summary>
        Hashtable Yarn { get; set; }

        /// <summary>
        ///     Gets or sets a collection of configuration properties to customize the Hdfs Hadoop service.
        /// </summary>
        Hashtable Hdfs { get; set; }

        /// <summary>
        ///     Gets or sets a collection of configuration properties to customize the Hive Hadoop service.
        /// </summary>
        AzureHDInsightHiveConfiguration Hive { get; set; }

        /// <summary>
        ///     Gets or sets a collection of configuration properties to customize the MapReduce Hadoop service.
        /// </summary>
        AzureHDInsightMapReduceConfiguration MapReduce { get; set; }

        /// <summary>
        ///     Gets or sets a collection of configuration properties to customize the Oozie Hadoop service.
        /// </summary>
        AzureHDInsightOozieConfiguration Oozie { get; set; }

        /// <summary>
        ///     Gets or sets a collection of configuration properties to customize the Storm service.
        /// </summary>
        Hashtable Storm { get; set; }

        /// <summary>
        ///     Gets or sets a collection of configuration properties to customize the Spark service.
        /// </summary>
        Hashtable Spark { get; set; }

        /// <summary>
        ///     Gets or sets a collection of configuration properties to customize the HBase service.
        /// </summary>
        AzureHDInsightHBaseConfiguration HBase { get; set; }
    }
}
