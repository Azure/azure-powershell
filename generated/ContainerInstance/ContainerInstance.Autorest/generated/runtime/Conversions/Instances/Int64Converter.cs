/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    public sealed class Int64Converter : JsonConverter<long>
    {
        internal override JsonNode ToJson(long value) => new JsonNumber(value);

        internal override long FromJson(JsonNode node) => (long)node;
    }
}