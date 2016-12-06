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

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure Sql specific backup policy class.
    /// </summary>
    public class AzureSqlPolicy : PolicyBase
    {
        /// <summary>
        /// Object defining the retention behavior of this policy.
        /// </summary>
        public RetentionPolicyBase RetentionPolicy { get; set; }

        public override void Validate()
        {
            base.Validate();
            RetentionPolicy.Validate();
        }
    }
}
