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

using Microsoft.Azure.Commands.Sql.Elastic_Jobs.Model;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ElasticJobs.Model
{
    public class AzureSqlElasticJobStepModel : AzureSqlElasticJobBaseModel
    {
        /// <summary>
        /// The job step's step name
        /// </summary>
        public string StepName { get; set; }

        /// <summary>
        /// The job step's target group name
        /// </summary>
        public string TargetGroupName { get; set; }

        /// <summary>
        /// The job step's credential name
        /// </summary>
        public string CredentialName { get; set; }

        /// <summary>
        /// The job step's output details
        /// </summary>
        public AzureSqlElasticJobStepOutputModel Output { get; set; }

        /// <summary>
        /// The initial retry interval seconds
        /// </summary>
        public int? InitialRetryIntervalSeconds { get; set; }

        /// <summary>
        /// The maximum retry interval seconds
        /// </summary>
        public int? MaximumRetryIntervalSeconds { get; set; }

        /// <summary>
        /// The retry attempts
        /// </summary>
        public int? RetryAttempts { get; set; }

        /// <summary>
        /// The retry interval back off multiplier
        /// </summary>
        public double? RetryIntervalBackoffMultiplier { get; set; }

        /// <summary>
        /// The timeout seconds
        /// </summary>
        public int? TimeoutSeconds { get; set; }

        /// <summary>
        /// The job step's step id
        /// </summary>
        public int? StepId;

        /// <summary>
        /// The job step command text
        /// </summary>
        public string CommandText { get; set; }
    }
}