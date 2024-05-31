/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    public sealed class Int16Converter : JsonConverter<short>
    {
        internal override JsonNode ToJson(short value) => new JsonNumber(value);

        internal override short FromJson(JsonNode node) => (short)node;
    }
}