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

    public enum RecallResult
    {
        RECALL_SUCCEEDED = 1,
        RECALL_FAILED = 2,
        RECALL_SKIPPED = 3
    }

}
