// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Interop.cs" company="Microsoft Corporation.">
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
    public struct SCRUBBING_STATS
    {
        public UInt32 FileDataAccessFailures;
        public UInt32 FilesAutoRecovered;
        public UInt32 FilesRecovered;
        public UInt32 FilesFailedToRecover;
        public UInt32 ErrorFilesCreated;
        public UInt32 FilesNeedingPromotion;
        public UInt32 FilesPromoted;
    }
}
