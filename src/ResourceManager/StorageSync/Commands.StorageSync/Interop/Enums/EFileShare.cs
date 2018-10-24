// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecallResult.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related 
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Commands.StorageSync.Interop.Enums
{
    using System;
    using System.Runtime.InteropServices;

    [Flags]
    public enum EFileShare : uint
    {
        None = 0x00000000,
        Read = 0x00000001,
        Write = 0x00000002,
        Delete = 0x00000004,
    }

}
