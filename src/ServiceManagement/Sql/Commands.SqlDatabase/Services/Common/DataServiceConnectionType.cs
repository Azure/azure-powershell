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
using System.Globalization;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Common
{
    /// <summary>
    /// The connection identification data which locates a unique data tier.
    /// </summary>
    public class DataServiceConnectionType
    {
        private const string ConnectionUriPattern = "'";
        private const string ConnectionUriReplacement = "''";

        /// <summary>
        /// The connection type.
        /// </summary>
        private readonly string connectionType;

        /// <summary>
        /// The connection parameters for this connection type.
        /// </summary>
        private readonly string[] connectionParameters;

        /// <summary>
        /// Lazily constructed relative entity <see cref="Uri"/>.
        /// </summary>
        private Uri relativeEntityUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataServiceConnectionType"/> class given a
        /// connection type and its location parameter values.
        /// </summary>
        /// <param name="connectionType">The connection type.</param>
        /// <param name="connectionParameters">The connection parameters for this connection type.</param>
        public DataServiceConnectionType(string connectionType, params string[] connectionParameters)
        {
            this.connectionType = connectionType;
            this.connectionParameters = connectionParameters;
        }

        /// <summary>
        /// Gets the connection type.
        /// </summary>
        public string ConnectionType
        {
            get { return this.connectionType; }
        }

        /// <summary>
        /// Gets the connection parameters.
        /// </summary>
        public IEnumerable<string> ConnectionParameters
        {
            get
            {
                foreach (string parameter in this.connectionParameters)
                {
                    yield return parameter;
                }
            }
        }

        /// <summary>
        /// Gets the relative entity <see cref="Uri"/> for this Connection Type.
        /// ex. Entity('key1','key2')
        /// </summary>
        public Uri RelativeEntityUri
        {
            get
            {
                if (this.relativeEntityUri == null)
                {
                    StringBuilder uriBuilder = new StringBuilder(EscapeConnectionString(this.ConnectionType));

                    // It is the caller's responsibility to not pass empty strings in the parameter
                    // enumeration to avoid having "()" at all when no parameters are considered present
                    if (this.ConnectionParameters.Count() > 0)
                    {
                        uriBuilder.Append("(");
                        string[] parameterList = this.ConnectionParameters.Select(s =>
                            string.Format(CultureInfo.InvariantCulture, "'{0}'", EscapeConnectionString(s))).ToArray();
                        uriBuilder.Append(string.Join(",", parameterList));
                        uriBuilder.Append(")");
                    }

                    this.relativeEntityUri = new Uri(uriBuilder.ToString(), UriKind.Relative);
                }

                return this.relativeEntityUri;
            }
        }

        /// <summary>
        /// Escape the connection string.
        /// </summary>
        /// <param name="unescapedString">String to escape.</param>
        /// <returns>The escaped connection string.</returns>
        private static string EscapeConnectionString(string unescapedString)
        {
            return unescapedString.Replace(ConnectionUriPattern, ConnectionUriReplacement);
        }
    }
}
