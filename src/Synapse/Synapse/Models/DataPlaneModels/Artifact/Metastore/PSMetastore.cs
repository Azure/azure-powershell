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

using Azure.Analytics.Synapse.Artifacts.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSMetastore
    {
        public PSMetastore(MetastoreRegistrationResponse response, string workspaceName, string databaseName)
        {
            this.Status = response?.Status.ToString();
            this.WorkspaceName = workspaceName;
            this.DatabaseName = databaseName;
        }

        public PSMetastore(MetastoreUpdationResponse response, string workspaceName, string databaseName)
        {
            this.Status = response?.Status.ToString();
            this.WorkspaceName = workspaceName;
            this.DatabaseName = databaseName;
        }

        public PSMetastore(MetastoreRequestSuccessResponse response, string workspaceName, string databaseName)
        {
            this.Status = response?.Status.ToString();
            this.WorkspaceName = workspaceName;
            this.DatabaseName = databaseName;
        }

        public string Status { get; }

        public string WorkspaceName { get; set; }

        public string DatabaseName { get; set; }
    }
}
