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

using Microsoft.Azure.Management.Sql.Models;
using System;

namespace Microsoft.Azure.Commands.Sql.Model
{
    public class IndexRecommendation : RecommendedIndexProperties
    {
        /// <summary>
        /// Copy constructor from base class
        /// </summary>
        /// <param name="other">Source object</param>
        public IndexRecommendation(RecommendedIndexProperties other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            this.Action = other.Action;
            this.Columns = other.Columns;
            this.Created = other.Created;
            this.EstimatedImpact = other.EstimatedImpact;
            this.IncludedColumns = other.IncludedColumns;
            this.IndexScript = other.IndexScript;
            this.IndexType = other.IndexType;
            this.LastModified = other.LastModified;
            this.ReportedImpact = other.ReportedImpact;
            this.Schema = other.Schema;
            this.State = other.State;
            this.Table = other.Table;
            this.Columns = other.Columns;
        }

        /// <summary>
        /// Azure SQL Database name on which this index should be created.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Name of recommended index.
        /// </summary>
        public string Name { get; set; }
    }
}
