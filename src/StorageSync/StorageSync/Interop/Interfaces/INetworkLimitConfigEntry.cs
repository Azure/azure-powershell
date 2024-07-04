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
    /// Interface INetworkLimitConfigEntry
    /// </summary>
    [ComImport]
    [Guid("D8875569-2376-42B6-B2BA-3722F88F77F7"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INetworkLimitConfigEntry
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        string Id
        {
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary>
        /// Gets the day.
        /// </summary>
        /// <value>The day.</value>
        DayOfWeek Day
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        /// <summary>
        /// Gets the start hour.
        /// </summary>
        /// <value>The start hour.</value>
        uint StartHour
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        /// <summary>
        /// Gets the start minute.
        /// </summary>
        /// <value>The start minute.</value>
        uint StartMinute
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        /// <summary>
        /// Gets the end hour.
        /// </summary>
        /// <value>The end hour.</value>
        uint EndHour
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        /// <summary>
        /// Gets the end minute.
        /// </summary>
        /// <value>The end minute.</value>
        uint EndMinute
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        /// <summary>
        /// Gets the limit KBPS.
        /// </summary>
        /// <value>The limit KBPS.</value>
        uint LimitKbps
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }
    }

   
}
