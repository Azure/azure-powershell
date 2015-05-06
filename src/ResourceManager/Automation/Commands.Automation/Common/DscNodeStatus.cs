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

namespace Microsoft.Azure.Commands.Automation.Common
{
    /// <summary>
    /// DscNodeStatus enum represents the all the available states of the node while applying nodeconfiguration
    /// </summary>
    public enum DscNodeStatus
    {
        /// <summary>
        /// Indicates Compliant status.
        /// </summary>
        Compliant = 1,

        /// <summary>
        /// Indicates Not Compliant status.
        /// </summary>
        NotCompliant,

        /// <summary>
        /// Indicates Failed status.
        /// </summary>
        Failed,

        /// <summary>
        /// Indicates Pending status.
        /// </summary>
        Pending,

        /// <summary>
        /// Indicates received status.
        /// </summary>
        Received,

        /// <summary>
        /// Indicates Unresponsive status
        /// </summary>
        Unresponsive
    }
}
