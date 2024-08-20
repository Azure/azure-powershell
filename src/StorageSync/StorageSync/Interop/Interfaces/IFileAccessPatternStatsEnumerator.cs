using Commands.StorageSync.Interop.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.Interfaces
{
    [ComImport]
    [Guid("CAA2700B-5AC3-4295-A0EE-F80EA1F05A60"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileAccessPatternStatsEnumerator
    {
        FileAccessPatternStats GetNextValue();

        bool HasNext();
    }
}
