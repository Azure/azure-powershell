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
using System.Runtime.InteropServices;

namespace Commands.StorageSync.Interop.Interfaces
{
    /// <summary>
    /// Interface INetworkLimitConfigurationEntryEnumeration
    /// </summary>
    [ComImport]
    [Guid("B72C2D6B-1A05-4B96-9012-91B06C793BCC"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INetworkLimitConfigurationEntryEnumeration
    {
        /// <summary>
        /// Gets the next value.
        /// </summary>
        /// <returns>INetworkLimitConfigEntry.</returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        INetworkLimitConfigEntry GetNextValue();
    }
}
