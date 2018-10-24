using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.Interfaces
{
    [ComImport]
    [Guid("D8875569-2376-42B6-B2BA-3722F88F77F7"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INetworkLimitConfigEntry
    {
        string Id
        {
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        DayOfWeek Day
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        uint StartHour
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        uint StartMinute
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        uint EndHour
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        uint EndMinute
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }

        uint LimitKbps
        {
            [return: MarshalAs(UnmanagedType.U4)]
            get;
        }
    }

   
}
