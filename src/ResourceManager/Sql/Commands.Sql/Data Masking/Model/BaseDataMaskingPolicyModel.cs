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

namespace Microsoft.Azure.Commands.Sql.DataMasking.Model
{
    /// <summary>
    /// The possible states in which a data masking policy may be in
    /// </summary>
    public enum DataMaskingStateType { Uninitialized, Enabled, Disabled };

    /// <summary>
    /// The base class that defines the core properties of a data masking policy
    /// </summary>
    public abstract class BaseDataMaskingPolicyModel
    {
        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        ///  Gets or sets the state of the policy
        /// </summary>
        public DataMaskingStateType DataMaskingState { get; set; }

        /// <summary>
        /// Gets or sets the list of the privilege logins
        /// </summary>
        public string PrivilegedUsers { get; set; }
    }
}
