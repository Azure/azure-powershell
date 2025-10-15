// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Utils;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSTaskSchedulingPolicy
    {
        internal TaskSchedulingPolicy toMgmtTaskSchedulingPolicy()
        {
            TaskSchedulingPolicy mgmtTaskSchedulingPolicy = new TaskSchedulingPolicy();
            mgmtTaskSchedulingPolicy.NodeFillType = Utils.Utils.toMgmtComputeNodeFillType(this.ComputeNodeFillType);
            return mgmtTaskSchedulingPolicy;
        }

        internal PSTaskSchedulingPolicy fromMgmtTaskSchedulingPolicy(TaskSchedulingPolicy mgmtTaskSchedulingPolicy)
        {
            if (mgmtTaskSchedulingPolicy == null)
            {
                return null;
            }
            PSTaskSchedulingPolicy psTaskSchedulingPolicy = new PSTaskSchedulingPolicy(Utils.Utils.fromMgmtComputeNodeFillType(mgmtTaskSchedulingPolicy.NodeFillType));
            return psTaskSchedulingPolicy;
        }
    }
}
