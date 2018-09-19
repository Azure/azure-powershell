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

using System.Management.Automation;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces
{
    internal interface IAddAzureHDInsightMetastoreBase
    {
        /// <summary>
        ///     Gets or sets the AzureHDInsightConfig.
        /// </summary>
        AzureHDInsightConfig Config { get; set; }

        /// <summary>
        ///     Gets or sets the Azure SQL Server user credentials.
        /// </summary>
        PSCredential Credential { get; set; }

        /// <summary>
        ///     Gets or sets the Azure SQL Server database name.
        /// </summary>
        string DatabaseName { get; set; }

        /// <summary>
        ///     Gets or sets the type of metastore represented by this object.
        /// </summary>
        AzureHDInsightMetastoreType MetastoreType { get; set; }

        /// <summary>
        ///     Gets or sets the Azure SQL Server for the metastore.
        /// </summary>
        string SqlAzureServerName { get; set; }
    }
}
