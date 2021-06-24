/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime
{
    [System.Flags]
    public enum SerializationMode
    {
        None = 0,
        IncludeHeaders = 1 << 0,
        IncludeReadOnly = 1 << 1,

        IncludeAll = IncludeHeaders | IncludeReadOnly
    }
}