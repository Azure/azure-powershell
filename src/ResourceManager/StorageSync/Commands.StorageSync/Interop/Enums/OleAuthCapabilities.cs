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
    [Flags]
    public enum OleAuthCapabilities
    {
        EOACNONE = 0,
        EOACMUTUALAUTH = 0x1,
        EOACSTATICCLOAKING = 0x20,
        EOACDYNAMICCLOAKING = 0x40,
        EOACANYAUTHORITY = 0x80,
        EOACMAKEFULLSIC = 0x100,
        EOACDEFAULT = 0x800,
        EOACSECUREREFS = 0x2,
        EOACACCESSCONTROL = 0x4,
        EOACAPPID = 0x8,
        EOACDYNAMIC = 0x10,
        EOACREQUIREFULLSIC = 0x200,
        EOACAUTOIMPERSONATE = 0x400,
        EOACNOCUSTOMMARSHAL = 0x2000,
        EOACDISABLEAAA = 0x1000
    }
}
