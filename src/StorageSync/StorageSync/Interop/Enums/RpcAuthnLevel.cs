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

namespace Commands.StorageSync.Interop.Enums
{
    /// <summary>
    /// Enum RpcAuthnLevel
    /// </summary>
    public enum RpcAuthnLevel
    {
        /// <summary>
        /// The default
        /// </summary>
        Default = 0,
        /// <summary>
        /// The none
        /// </summary>
        None = 1,
        /// <summary>
        /// The connect
        /// </summary>
        Connect = 2,
        /// <summary>
        /// The call
        /// </summary>
        Call = 3,
        /// <summary>
        /// The PKT
        /// </summary>
        Pkt = 4,
        /// <summary>
        /// The PKT integrity
        /// </summary>
        PktIntegrity = 5,
        /// <summary>
        /// The PKT privacy
        /// </summary>
        PktPrivacy = 6
    }
}
