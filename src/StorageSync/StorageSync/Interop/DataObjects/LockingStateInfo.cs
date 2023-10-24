// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LockingStateInfo.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.DataObjects
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LockingStateInfo
    {
        [MarshalAs(UnmanagedType.BStr)]
        public string NameRecord_ObjectFid;
        [MarshalAs(UnmanagedType.BStr)]
        public string NameRecord_ParentFid;
        [MarshalAs(UnmanagedType.BStr)]
        public string NameRecord_ObjectLid;
        [MarshalAs(UnmanagedType.BStr)]
        public string NameRecord_ParentLid;
        public UInt32 NameRecord_Flags;
        public UInt32 NameRecord_AckNeeded;
        [MarshalAs(UnmanagedType.BStr)]
        public string NameRecord_ObjectName;
        public UInt32 NameRecord_DlmAction;
        [MarshalAs(UnmanagedType.BStr)]
        public string LockIdRecord_ObjectFid;
        [MarshalAs(UnmanagedType.BStr)]
        public string LockIdRecord_ParentFid;
        [MarshalAs(UnmanagedType.BStr)]
        public string LockIdRecord_ObjectLid;
        [MarshalAs(UnmanagedType.BStr)]
        public string LockIdRecord_ParentLid;
        public UInt32 LockIdRecord_Flags;
        public UInt64 LockIdRecord_USN;
        public UInt64 LockIdRecord_AckUSN;
        public UInt32 LockIdRecord_AckNeeded;
        [MarshalAs(UnmanagedType.BStr)]
        public string LockIdRecord_LastHandleOpenTimeUtc;
        [MarshalAs(UnmanagedType.BStr)]
        public string LockIdRecord_LastHandleOpenTimeLocal;
        public UInt32 LockIdRecord_StreamCount;
        public UInt64 LockIdRecord_ShareAccess;
        public UInt32 LockIdRecord_DlmAction;
        public UInt32 CacheObject_DlmCachedAccess;
        public UInt32 CacheObject_DlmCachedShareAccess;
        public UInt32 CacheObject_ShareAccessOpenCount;
        public UInt32 CacheObject_ShareAccessReaders;
        public UInt32 CacheObject_ShareAccessWriters;
        public UInt32 CacheObject_ShareAccessDeleters;
        public UInt32 CacheObject_ShareAccessSharedRead;
        public UInt32 CacheObject_ShareAccessSharedWrite;
        public UInt32 CacheObject_ShareAccessSharedDelete;
        public UInt32 CacheObject_StreamSize;
        public UInt32 CacheObject_PendingStreamSize;
        [MarshalAs(UnmanagedType.BStr)]
        public string CacheObject_PendingAckTimeUtc;
        [MarshalAs(UnmanagedType.BStr)]
        public string CacheObject_PendingAckTimeLocal;
    }
}