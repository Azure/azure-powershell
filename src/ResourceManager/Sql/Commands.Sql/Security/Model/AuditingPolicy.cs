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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Security.Model
{
    public class AuditingPolicy
    {
       
        public AuditingPolicy()
        {
            ConnectionStrings = new ConnectionStrings();
        }

        public string ResourceGroupName { get; set; }
        
        public string ServerName { get; set; }
        
        public string DatabaseName { get; set; }
        
        public string StorageAccountName { get; set; }
        
        public string[] EventType { get; set; }
        
        public bool IsEnabled { get; set; }
        
        public bool UseServerDefault { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string AdoNetConnectionString { get; set; }

        public string OdbcConnectionString { get; set; }

        public string PhpConnectionString { get; set; }

        public string JdbcConnectionString { get; set; }
    }
}
