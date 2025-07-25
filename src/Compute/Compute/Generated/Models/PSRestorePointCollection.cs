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


using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Compute.Automation.Models
{
    class PSRestorePointCollection
    {
        public RestorePointCollectionSourceProperties Source { get; set; }
        //
        // Summary:
        //     Gets the provisioning state of the restore point collection.
        public string ProvisioningState { get; set; }
        //
        // Summary:
        //     Gets the unique id of the restore point collection.
        public string RestorePointCollectionId { get; set; }
        //
        // Summary:
        //     Gets a list containing all restore points created under this restore point collection.
        public IList<RestorePoint> RestorePoints { get; set; }
    }
}
