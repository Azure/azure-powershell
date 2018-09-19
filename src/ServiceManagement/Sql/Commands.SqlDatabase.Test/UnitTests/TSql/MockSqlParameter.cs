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
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.UnitTests.TSql
{
    internal class MockSqlParameter : DbParameter
    {
        /// <summary>
        /// Gets or sets the parameter type
        /// </summary>
        public override DbType DbType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the parameter direction (input, output, ...)
        /// </summary>
        public override ParameterDirection Direction
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the value is nullable
        /// </summary>
        public override bool IsNullable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the parameter name
        /// </summary>
        public override string ParameterName
        {
            get;
            set;
        }

        /// <summary>
        /// Resets the parameter type (no-op)
        /// </summary>
        public override void ResetDbType()
        {
        }

        /// <summary>
        /// Gets or sets the size of the parameter
        /// </summary>
        public override int Size
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the source column
        /// </summary>
        public override string SourceColumn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the source column null mapping
        /// </summary>
        public override bool SourceColumnNullMapping
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the source version
        /// </summary>
        public override DataRowVersion SourceVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of the parameter
        /// </summary>
        public override object Value
        {
            get;
            set;
        }
    }
}
