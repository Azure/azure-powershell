// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStableVersionDeepGcProgress.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related 
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace Commands.StorageSync.Interop.Interfaces
{
    using DataObjects;
    using Enums;
    using System;
    using System.Runtime.InteropServices;

    [ComVisible(true)]
    [Guid("737EADF1-B170-D548-76F2-80F4638F3787"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStableVersionDeepGcProgress
    {
        void ReceiveProgressNotification(
            uint code,
            uint value
            );

    }
}
