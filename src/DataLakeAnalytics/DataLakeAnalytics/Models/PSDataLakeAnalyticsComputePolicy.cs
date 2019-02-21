﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Models
{
    /// <summary>
    ///    A wrapper for ADLA compute policies and used for CRUD
    /// </summary>
    public class PSDataLakeAnalyticsComputePolicy : ComputePolicy
    {
        public PSDataLakeAnalyticsComputePolicy(ComputePolicy basePolicy) :
            base(basePolicy.Id,
                basePolicy.Name,
                basePolicy.Type,
                basePolicy.ObjectId,
                basePolicy.ObjectType,
                basePolicy.MaxDegreeOfParallelismPerJob,
                basePolicy.MinPriorityPerJob)
                
        { }
    }
}