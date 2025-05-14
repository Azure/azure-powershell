/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    public sealed class Int32Converter : JsonConverter<int>
    {
        internal override JsonNode ToJson(int value) => new JsonNumber(value);

        internal override int FromJson(JsonNode node) => (int)node;
    }
}