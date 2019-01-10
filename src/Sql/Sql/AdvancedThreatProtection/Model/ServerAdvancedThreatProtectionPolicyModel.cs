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

using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model
{
    /// <summary>
    /// A class representing a server Advanced Threat Protection policy
    /// </summary>
    public class ServerAdvancedThreatProtectionPolicyModel
    {
        /// <summary>
        /// Gets or sets the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets a value to indicate whether Advanced Threat Protection is enabled
        /// </summary>
        [Ps1Xml(Label = "Enabled", Target = ViewControl.Table)]
        public bool IsEnabled { get; set; }
    }
}
