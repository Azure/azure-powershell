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

namespace Commands.StorageSync.Interop.Enums
{
    /// <summary>
    /// Enum OleAuthCapabilities
    /// </summary>
    [Flags]
    public enum OleAuthCapabilities
    {
        /// <summary>
        /// The eoacnone
        /// </summary>
        EOACNONE = 0,
        /// <summary>
        /// The eoacmutualauth
        /// </summary>
        EOACMUTUALAUTH = 0x1,
        /// <summary>
        /// The eoacstaticcloaking
        /// </summary>
        EOACSTATICCLOAKING = 0x20,
        /// <summary>
        /// The eoacdynamiccloaking
        /// </summary>
        EOACDYNAMICCLOAKING = 0x40,
        /// <summary>
        /// The eoacanyauthority
        /// </summary>
        EOACANYAUTHORITY = 0x80,
        /// <summary>
        /// The eoacmakefullsic
        /// </summary>
        EOACMAKEFULLSIC = 0x100,
        /// <summary>
        /// The eoacdefault
        /// </summary>
        EOACDEFAULT = 0x800,
        /// <summary>
        /// The eoacsecurerefs
        /// </summary>
        EOACSECUREREFS = 0x2,
        /// <summary>
        /// The eoacaccesscontrol
        /// </summary>
        EOACACCESSCONTROL = 0x4,
        /// <summary>
        /// The eoacappid
        /// </summary>
        EOACAPPID = 0x8,
        /// <summary>
        /// The eoacdynamic
        /// </summary>
        EOACDYNAMIC = 0x10,
        /// <summary>
        /// The eoacrequirefullsic
        /// </summary>
        EOACREQUIREFULLSIC = 0x200,
        /// <summary>
        /// The eoacautoimpersonate
        /// </summary>
        EOACAUTOIMPERSONATE = 0x400,
        /// <summary>
        /// The eoacnocustommarshal
        /// </summary>
        EOACNOCUSTOMMARSHAL = 0x2000,
        /// <summary>
        /// The eoacdisableaaa
        /// </summary>
        EOACDISABLEAAA = 0x1000
    }
}
