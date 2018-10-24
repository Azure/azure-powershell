using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
