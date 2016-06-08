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

namespace Microsoft.AzureStack.Commands
{
    /// <summary>
    /// Common constants for all PowerShell modules
    /// </summary>
    public static class CommonPSConst
    {
        /// <summary>
        /// Parameter set names
        /// </summary>
        public static class ParameterSet
        {
            /// <summary>
            /// Parameter set for property base parameters.
            /// </summary>
            public const string ByProperty = "ByProperty";

            /// <summary>
            /// Parameter set for full object base parameters.
            /// </summary>
            public const string ByObject = "ByObject";
        }
    }
}
