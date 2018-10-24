// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GarbageCollectionMode.cs" company="Microsoft Corporation.">
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

    public enum GarbageCollectionMode : UInt32
    {
        Shallow = 0,
        Full
    }
}