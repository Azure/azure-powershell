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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions
{
    /// <summary>
    /// Options for joining a computer to a domain
    /// </summary>
    [Flags]
    public enum JoinOptions : uint
    {
        /// <summary>
        /// Joins the computer to a domain. If this value is not specified, joins the computer to a workgroup.
        /// </summary>
        JoinDomain = 0x1,

        /// <summary>
        /// Create account on the domain
        /// </summary>
        AccountCreate = 0x2,

        /// <summary>
        /// Join operation is part of an upgrade
        /// </summary>
        Win9XUpgrade = 0x10,

        /// <summary>
        /// Perform an unsecure join
        /// </summary>
        UnsecuredJoin = 0x40,

        /// <summary>
        /// Indicate that the password passed to the join operation is the local machine account password, not a user password.
        /// It's valid only for unsecure join
        /// </summary>
        PasswordPass = 0x80,

        /// <summary>
        /// Writing SPN and DNSHostName attributes on the computer object should be deferred until the rename operation that
        /// follows the join operation
        /// </summary>
        DeferSPNSet = 0x100,

        /// <summary>
        /// Join the target machine with a new name queried from the registry. This options is used if the rename has been called prior
        /// to rebooting the machine
        /// </summary>
        JoinWithNewName = 0x400,

        /// <summary>
        /// Use a readonly domain controller
        /// </summary>
        JoinReadOnly = 0x800,

        /// <summary>
        /// Invoke during insatll
        /// </summary>
        InstallInvoke = 0x40000
    }
}
