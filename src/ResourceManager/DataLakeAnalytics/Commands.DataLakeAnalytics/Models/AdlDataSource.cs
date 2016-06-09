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

using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Rest.Azure;
using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    /// <summary>
    ///    A wrapper for all ADLA supported data sources.
    ///    This object is returned from a GET
    /// </summary>
    public class AdlDataSource
    {
        /// <summary>
        /// Gets the type of the data source
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public DataLakeAnalyticsEnums.DataSourceType Type { get; private set; }
        
        /// <summary>
        /// Gets the name of the data source
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; private set; }
        
        /// <summary>
        /// Gets a value indicating whether this data source is the default.
        /// </summary>
        /// <value>
        /// <c>true</c> if this data source is the default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdlDataSource"/> class.
        /// </summary>
        /// <param name="dataSourceInfo">The data source information.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        public AdlDataSource(DataLakeStoreAccountInfo dataSourceInfo, bool isDefault = false)
        {
            Name = dataSourceInfo.Name;
            Type = DataLakeAnalyticsEnums.DataSourceType.DataLakeStore;
            IsDefault = isDefault;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdlDataSource"/> class.
        /// </summary>
        /// <param name="dataSourceInfo">The data source information.</param>
        public AdlDataSource(StorageAccountInfo dataSourceInfo)
        {
            Name = dataSourceInfo.Name;
            Type = DataLakeAnalyticsEnums.DataSourceType.Blob;

            // always false because there is no concept of a default blob storage container for ADL.
            IsDefault = false;
        }
    }
}