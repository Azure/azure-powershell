
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecallOutput.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related 
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Commands.StorageSync.Interop.DataObjects
{
    using Enums;
    using System;
    using System.Runtime.InteropServices;


    [StructLayout(LayoutKind.Sequential)]
    public struct RecallOutput
    {
        public RecallResult Result;
        public UInt64 SpaceClaimedInBytes;
    }
}
