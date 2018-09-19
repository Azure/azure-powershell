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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.TSql
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly)]
    public class RecordMockDataResultsAttribute : Attribute
    {
        private readonly string outputPath;
        private readonly bool isolatedQueries;

        /// <summary>
        /// Creates the RecordMockDataResultsAttribute.
        /// </summary>
        /// <param name="outputPath">The output directory where the captured results will be saved.</param>
        public RecordMockDataResultsAttribute(string outputPath)
            : this(outputPath, false)
        {
        }

        /// <summary>
        /// Creates the RecordMockDataResultsAttribute.
        /// </summary>
        /// <param name="outputPath">The output directory where the captured results will be saved.</param>
        /// <param name="serverName">Name/address of the server.</param>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password</param>
        /// <param name="databaseName">Initial database name.</param>
        /// <param name="isolatedQueries">Specifies whether the query capture should be in isolated mode. 
        /// That is shared query results will not be accessible.</param>
        public RecordMockDataResultsAttribute(string outputPath, bool isolatedQueries)
        {
            this.outputPath = outputPath;
            this.isolatedQueries = isolatedQueries;
        }

        /// <summary>
        /// The output path for the query results
        /// </summary>
        public string OutputPath
        {
            get { return this.outputPath; }
        }

        /// <summary>
        /// Gets whether or not the query capture should be in isolated mode. 
        /// That is shared query results will not be accessible.
        /// </summary>
        public bool IsolatedQueries
        {
            get { return this.isolatedQueries; }
        }
    }
}
