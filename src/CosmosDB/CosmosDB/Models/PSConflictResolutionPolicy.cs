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

using Microsoft.Azure.Management.CosmosDB.Models;
using System;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{

    public class PSConflictResolutionPolicy
    {
        public PSConflictResolutionPolicy()
        {
        }

        public PSConflictResolutionPolicy(ConflictResolutionPolicy conflictResolutionPolicy)
        {
            if (conflictResolutionPolicy == null)
            {
                return;
            }

            Mode = conflictResolutionPolicy.Mode;
            ConflictResolutionPath = conflictResolutionPolicy.ConflictResolutionPath;
            ConflictResolutionProcedure = conflictResolutionPolicy.ConflictResolutionProcedure;
        }

        //
        // Summary:
        //     Gets or sets indicates the conflict resolution mode. Possible values include:
        //     'LastWriterWins', 'Custom'
        public string Mode { get; set; }
        //
        // Summary:
        //     Gets or sets the conflict resolution path in the case of LastWriterWins mode.
        public string ConflictResolutionPath { get; set; }
        //
        // Summary:
        //     Gets or sets the procedure to resolve conflicts in the case of custom mode.
        public string ConflictResolutionProcedure { get; set; }

        public static ConflictResolutionPolicy ToSDKModel(PSConflictResolutionPolicy pSConflictResolutionPolicy)
        {
            if (pSConflictResolutionPolicy == null)
            {
                return null;
            }

            ConflictResolutionPolicy conflictResolutionPolicy = new ConflictResolutionPolicy
            {
                Mode = pSConflictResolutionPolicy.Mode
            };

            if (pSConflictResolutionPolicy.Mode.Equals(ConflictResolutionMode.LastWriterWins, StringComparison.OrdinalIgnoreCase))
            {
                conflictResolutionPolicy.ConflictResolutionPath = pSConflictResolutionPolicy.ConflictResolutionPath;
            }
            else if (pSConflictResolutionPolicy.Mode.Equals(ConflictResolutionMode.Custom, StringComparison.OrdinalIgnoreCase))
            {
                conflictResolutionPolicy.ConflictResolutionProcedure = pSConflictResolutionPolicy.ConflictResolutionProcedure;
            }

            return conflictResolutionPolicy;
        }
    }
}