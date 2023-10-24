// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SyncScenario.cs" company="Microsoft Corporation.">
//   All rights reserved.
// </copyright>
// <summary>
//   COM related 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Commands.StorageSync.Interop.Enums
{
    public enum SyncScenario : uint
    {
        Default = 0,
        RegularSync = 1,
        VssUpload = 2,
    }
}