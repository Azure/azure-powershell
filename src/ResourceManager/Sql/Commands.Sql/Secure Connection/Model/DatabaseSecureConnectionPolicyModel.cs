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

namespace Microsoft.Azure.Commands.Sql.SecureConnection.Model
{
    /// <summary>
    /// A class representing a database's secure connection policy
    /// </summary>
    public class DatabaseSecureConnectionPolicyModel : BaseSecureConnectionPolicyModel
    {
        /// <summary>
        /// The internal ConnectionString field
        /// </summary>
        private ConnectionStrings m_ConnectionStrings;

        /// <summary>
        /// Gets or sets the database name
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Lazy set of the connection string object
        /// </summary>
        public ConnectionStrings ConnectionStrings
        {
            get
            {
                if (m_ConnectionStrings == null)
                {
                    if (ProxyDnsName != null && ProxyPort != null && ServerName != null && DatabaseName != null)
                    {
                        m_ConnectionStrings = new ConnectionStrings(ProxyDnsName, ProxyPort, ServerName, DatabaseName);
                    }
                }
                return m_ConnectionStrings;
            }
        }
    }
}