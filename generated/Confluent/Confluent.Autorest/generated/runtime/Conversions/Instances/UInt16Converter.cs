/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.confluent.Runtime.Json
{
    public sealed class UInt16Converter : JsonConverter<ushort>
    {
        internal override JsonNode ToJson(ushort value) => new JsonNumber(value);

        internal override ushort FromJson(JsonNode node) => (ushort)node;
    }
}