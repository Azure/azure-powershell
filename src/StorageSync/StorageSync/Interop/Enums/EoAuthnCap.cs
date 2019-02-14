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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.Enums
{
    /// <summary>
    /// Enum EoAuthnCap
    /// </summary>
    [Flags]
    public enum EoAuthnCap
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0x00,
        /// <summary>
        /// The mutual authentication
        /// </summary>
        MutualAuth = 0x01,
        /// <summary>
        /// The static cloaking
        /// </summary>
        StaticCloaking = 0x20,
        /// <summary>
        /// The dynamic cloaking
        /// </summary>
        DynamicCloaking = 0x40,
        /// <summary>
        /// Any authority
        /// </summary>
        AnyAuthority = 0x80,
        /// <summary>
        /// The make full sic
        /// </summary>
        MakeFullSIC = 0x100,
        /// <summary>
        /// The default
        /// </summary>
        Default = 0x800,
        /// <summary>
        /// The secure refs
        /// </summary>
        SecureRefs = 0x02,
        /// <summary>
        /// The access control
        /// </summary>
        AccessControl = 0x04,
        /// <summary>
        /// The application identifier
        /// </summary>
        AppID = 0x08,
        /// <summary>
        /// The dynamic
        /// </summary>
        Dynamic = 0x10,
        /// <summary>
        /// The require full sic
        /// </summary>
        RequireFullSIC = 0x200,
        /// <summary>
        /// The automatic impersonate
        /// </summary>
        AutoImpersonate = 0x400,
        /// <summary>
        /// The no custom marshal
        /// </summary>
        NoCustomMarshal = 0x2000,
        /// <summary>
        /// The disable aaa
        /// </summary>
        DisableAAA = 0x1000
    }
}
