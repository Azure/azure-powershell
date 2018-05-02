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
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets.BackupRestore
{
    public class AzureWebAppSnapshot
    {
        /// <summary>
        /// The resource group of the web app
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The name of the web app
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the web app slot
        /// </summary>
        public string Slot { get; set; }

        /// <summary>
        /// The time that the snapshot was taken
        /// </summary>
        public DateTime SnapshotTime { get; set; }
    }
}
