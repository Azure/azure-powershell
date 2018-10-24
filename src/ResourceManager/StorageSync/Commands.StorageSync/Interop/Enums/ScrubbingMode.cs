// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScrubbingMode.cs" company="Microsoft Corporation.">
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

    public enum ScrubbingMode
    {
        Report = 0,
        Repair,
        Overwrite
    }
}