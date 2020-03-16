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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    /// <summary>
    /// Specifies the different sampling mode of distributed tracing.
    /// </summary>
    public enum PSDistributedTracingSamplingMode
    {
        /// <summary>
        /// Indicates that a distributed tracing is disabled
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// Indicates that a distributed tracing is enabled
        /// </summary>
        Enabled = 1
    }
}
