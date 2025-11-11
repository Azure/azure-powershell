/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json
{
    public sealed class UInt32Converter : JsonConverter<uint>
    {
        internal override JsonNode ToJson(uint value) => new JsonNumber(value);

        internal override uint FromJson(JsonNode node) => (uint)node;
    }
}