/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    internal sealed class XNull : JsonNode
    {
        internal static readonly XNull Instance = new XNull();

        private XNull() { }

        internal override JsonType Type => JsonType.Null;
    }
}