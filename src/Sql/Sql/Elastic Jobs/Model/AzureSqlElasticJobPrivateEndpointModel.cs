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

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Model
{
    /// <summary>
    /// Represents the core properties of a job private endpoint
    /// </summary>
    public class AzureSqlElasticJobPrivateEndpointModel : AzureSqlElasticJobsBaseModel
    {
        /// <summary>
        /// Gets or sets the job private endpoint name
        /// </summary>
        public string PrivateEndpointName { get; set; }

        /// <summary>
        /// Gets or sets the target server azure resource id
        /// </summary>
        public string TargetServerAzureResourceId { get; set; }

        /// <summary>
        /// Gets or sets the job private endpoint id
        /// </summary>
        public string PrivateEndpointId { get; set; }
    }
}
