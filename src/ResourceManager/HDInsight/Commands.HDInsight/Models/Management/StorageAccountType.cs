using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    /// <summary>
    /// Enum specifically used for Runtime Script Actions
    /// Crud time script actions use ClusterNodeType
    /// </summary>
    public enum StorageType
    {
        /// <summary>
        /// Windows Azure Blob Storage
        /// </summary>
        AzureStorage,

        /// <summary>
        /// Azure Data Lake Store
        /// </summary>
        AzureDataLakeStore,
    }
}