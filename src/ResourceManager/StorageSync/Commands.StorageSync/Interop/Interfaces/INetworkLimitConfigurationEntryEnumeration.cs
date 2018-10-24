using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.Interfaces
{
    [ComImport]
    [Guid("B72C2D6B-1A05-4B96-9012-91B06C793BCC"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INetworkLimitConfigurationEntryEnumeration
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        INetworkLimitConfigEntry GetNextValue();
    }
}
