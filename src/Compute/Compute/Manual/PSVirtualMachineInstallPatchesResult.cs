//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Compute.Models;


namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    public class PSVirtualMachineInstallPatchesResult
    {
        public string Status { get; set; }
        public string InstallationActivityId { get; set; }
        public string RebootStatus { get; set; }
        public bool? MaintenanceWindowExceeded { get; set; }
        public int? ExcludedPatchCount { get; set; }
        public int? NotSelectedPatchCount { get; set; }
        public int? PendingPatchCount { get; set; }
        public int? InstalledPatchCount { get; set; }
        public int? FailedPatchCount { get; set; }
        public IList<PatchInstallationDetail> Patches { get; set; }
        public DateTime? StartDateTime { get; set; }
        public ApiError Error { get; set; }
    }
}
