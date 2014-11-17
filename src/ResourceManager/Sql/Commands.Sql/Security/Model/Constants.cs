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

namespace Microsoft.Azure.Commands.Sql.Security.Model
{
    public class Constants
    {        
        // Event types
        public const string Access = "DataAccess";
        public const string Schema = "SchemaChanges";
        public const string Data = "DataChanges";
        public const string Security = "SecurityExceptions";
        public const string RevokePermissions = "RevokePermissions";
        public const string All = "All";
        public const string None = "None";

        // request headers names
        public const string ClientSessionIdHeaderName = "x-ms-client-session-id";
        public const string ClientRequestIdHeaderName = "x-ms-client-request-id";
        
        //id to locate a server's security policy
        public const string ServerPolicyId = "c3d905bb-e460-48bb-884d-75fac8f63e11";

        // types of storage keys
       public enum StorageKeyTypes {Primary, Secondary}; 
    }
}
