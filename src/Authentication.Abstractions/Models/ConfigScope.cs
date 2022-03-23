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

namespace Microsoft.Azure.PowerShell.Common.Config
{
    /// <summary>
    /// Scope for the config.
    /// </summary>
    public enum ConfigScope
    {
        /// <summary>
        /// Config will be persitent on the disk, available for all the PowerShell sessions initiated by the current user.
        /// </summary>
        CurrentUser,

        /// <summary>
        /// Config is effective in current PowerShell process.
        /// </summary>
        Process,

        /// <summary>
        /// Config is never set.
        /// </summary>
        /// <remarks>This option is not available when updating or clearing a config.</remarks>
        Default
    }
}
