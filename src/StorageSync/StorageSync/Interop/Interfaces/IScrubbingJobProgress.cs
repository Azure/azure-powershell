// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScrubbingJobProgress.cs" company="Microsoft Corporation.">
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
    [Guid("03057D98-C8F3-4B70-B1CF-5768DF69EE16"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IScrubbingJobProgress
    {

        void ReceiveProgressNotification(
            uint code,
            uint value
            );

    }
}
