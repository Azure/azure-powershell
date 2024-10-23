// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SyncDirection.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.Enums
{
    public enum SyncDirection: uint
    {
        None = 0,
        Upload,
        Download,
    }
}