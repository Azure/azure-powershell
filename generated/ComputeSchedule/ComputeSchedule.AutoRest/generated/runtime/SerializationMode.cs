/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime
{
    [System.Flags]
    public enum SerializationMode
    {
        None = 0,
        IncludeHeaders = 1 << 0,
        IncludeRead = 1 << 1,
        IncludeCreate = 1 << 2,
        IncludeUpdate = 1 << 3,
        IncludeAll = IncludeHeaders | IncludeRead | IncludeCreate | IncludeUpdate,
        IncludeCreateOrUpdate = IncludeCreate | IncludeUpdate
    }
}