
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

namespace Microsoft.Azure.Commands.ServiceBus.Models
{
    public class PSSQLFilterAttributes
    {
        /// <summary>
        /// Initializes a new instance of the SqlFilter class.
        /// </summary>
        public PSSQLFilterAttributes()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SqlFilter class.
        /// </summary>
        /// <param name="sqlExpression">The SQL expression. e.g.
        /// MyProperty='ABC'</param>
        /// <param name="compatibilityLevel">This property is reserved for
        /// future use. An integer value showing the compatibility level,
        /// currently hard-coded to 20.</param>
        /// <param name="requiresPreprocessing">Value that indicates whether
        /// the rule action requires preprocessing.</param>
        public PSSQLFilterAttributes(string sqlExpression = default(string), int? compatibilityLevel = default(int?), bool? requiresPreprocessing = default(bool?))
        {
            SqlExpression = sqlExpression;
            CompatibilityLevel = compatibilityLevel;
            RequiresPreprocessing = requiresPreprocessing;
        }

        public PSSQLFilterAttributes(Management.ServiceBus.Models.SqlFilter sqlFilter)
        {
            if (sqlFilter != null)
            {
                SqlExpression = sqlFilter.SqlExpression;
                CompatibilityLevel = sqlFilter.CompatibilityLevel;
                RequiresPreprocessing = sqlFilter.RequiresPreprocessing;
            }
        }

        /// <summary>
        /// Gets or sets the SQL expression. e.g. MyProperty='ABC'
        /// </summary>
        public string SqlExpression { get; set; }

        /// <summary>
        /// Gets this property is reserved for future use. An integer value
        /// showing the compatibility level, currently hard-coded to 20.
        /// </summary>
        public int? CompatibilityLevel { get; private set; }

        /// <summary>
        /// Gets or sets value that indicates whether the rule action requires
        /// preprocessing.
        /// </summary>
        public bool? RequiresPreprocessing { get; set; }

    }
}
