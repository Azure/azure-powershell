using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.DataObjects
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
         uint dwLowDateTime;
        uint dwHighDateTime;
    };
}
