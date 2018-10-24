using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public sealed class COMReleaseHandle : SafeHandle
    {
        public COMReleaseHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid
        {
            get
            {
                return this.handle == IntPtr.Zero;
            }
        }

        protected override bool ReleaseHandle()
        {
            int newRefCount = Marshal.Release(this.handle);
            Debug.Write($"RefCount: {newRefCount}");
            return true;
        }

        public void AttachHandle(IntPtr assignedHandle)
        {
            this.SetHandle(assignedHandle);
        }
    }
}
