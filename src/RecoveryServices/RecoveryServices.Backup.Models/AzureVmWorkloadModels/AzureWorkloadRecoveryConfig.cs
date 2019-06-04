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

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Recovery config of a resource.
    /// </summary>
    public class AzureWorkloadRecoveryConfig : RecoveryConfigBase
    {
        /// <summary>
        /// Target Server
        /// </summary>
        public string TargetServer { get; }

        /// <summary>
        /// Target Instance
        /// </summary>
        public string TargetInstance { get; }

        /// <summary>
        /// Restored DB Name
        /// </summary>
        public string RestoredDBName { get; set; }

        /// <summary>
        /// OverwriteWLIfpresent
        /// </summary>
        public string OverwriteWLIfpresent { get; set; }

        /// <summary>
        /// NoRecoveryMode
        /// </summary>
        public string NoRecoveryMode { get; set; }

        /// <summary>
        /// targetPhysicalPath
        /// </summary>
        public IList<SQLDataDirectoryMapping> targetPhysicalPath { get; set; }

        public string ContainerId { get; set; }

        public AzureWorkloadRecoveryConfig(string targetServer, string targetInstance, string restoreRequestType,
            RecoveryPointBase recoveryPoint, DateTime pointInTime)
            : base(restoreRequestType, recoveryPoint, pointInTime)
        {
            TargetServer = targetServer;
            TargetInstance = targetInstance;
        }
    }
}