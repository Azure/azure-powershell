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
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.ElasticJobs.Model;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzureRmSqlElasticJobTarget Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlElasticJobTarget",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultSqlDatabaseSet),
        OutputType(typeof(JobTarget))]
    public class RemoveAzureSqlElasticJobTarget : AzureSqlElasticJobTargetCmdletBase<AzureSqlElasticJobTargetGroupModel>
    {
        /// <summary>
        /// Execution starts here
        /// </summary>
        public override void ExecuteCmdlet()
        {
            InitializeInputObjectProperties(this.TargetGroupObject);
            InitializeResourceIdProperties(this.TargetGroupResourceId);
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Updates list of existing targets during remove target scenario
        /// There is 1 scenario where we will need to send an update to server
        /// 1. If target was in list and we removed it.
        /// If this scenarios occurs, we return true and send update to server.
        /// Otherwise, we return empty response to indicate that no changes were made.
        /// </summary>
        /// <returns>True if an update to server is required after updating list of existing targets</returns>
        protected override bool UpdateExistingTargets()
        {
            int? index = FindTarget();
            bool targetExists = index.HasValue;
            bool needsUpdate = false;

            if (targetExists)
            {
                // Update current target type's membership type to existing membership type
                this.Target.MembershipType = this.ExistingTargets[index.Value].MembershipType;

                // Target existed and we want to remove this target
                this.ExistingTargets.RemoveAt(index.Value);
                needsUpdate = true;
            }

            return needsUpdate;
        }
    }
}