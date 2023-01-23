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

using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDtc.Model
{
    /// <summary>
    /// Represents core properties of Managed Instance DTC
    /// </summary>
    public class AzureSqlManagedInstanceDtcModel
    {
        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance.
        /// </summary>
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the resource ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets whether or not the DTC is enabled.
        /// </summary>
        public bool? DtcEnabled { get; set; }

        /// <summary>
        /// Gets or sets the DTC host name DNS suffix.
        /// </summary>
        public string DtcHostNameDnsSuffix { get; set; }

        /// <summary>
        /// Gets or sets the DTC host name.
        /// </summary>
        public string DtcHostName { get; set; }

        /// <summary>
        /// Gets or sets the external DNS suffix search list.
        /// </summary>
        public List<string> ExternalDnsSuffixSearchList { get; set; }

        /// <summary>
        /// Gets or sets the DTC security settings.
        /// </summary>
        public ManagedInstanceDtcSecuritySettings SecuritySettings { get; set; }
    }
}
