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

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Model
{
    /// <summary>
    /// Represents the core properties of a target group
    /// </summary>
    public class AzureSqlElasticJobTargetModel : AzureSqlElasticJobsBaseModel
    {
        /// <summary>
        /// Gets or sets the target group name
        /// </summary>
        public string TargetGroupName { get; set; }

        /// <summary>
        /// Gets or sets the membership type
        /// </summary>
        public JobTargetGroupMembershipType? MembershipType { get; set; }

        /// <summary>
        /// Gets or sets the target type
        /// </summary>
        public string TargetType { get; set; }

        /// <summary>
        /// Gets or sets the target server name
        /// </summary>
        public string TargetServerName { get; set; }

        /// <summary>
        /// Gets or sets the target database name
        /// </summary>
        public string TargetDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the target elastic pool name
        /// </summary>
        public string TargetElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the target shard map name
        /// </summary>
        public string TargetShardMapName { get; set; }

        /// <summary>
        /// Gets or sets the refresh credential name
        /// </summary>
        public string RefreshCredentialName { get; set; }
    }
}