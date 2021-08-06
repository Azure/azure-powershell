/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    public sealed class JsonArrayConverter : JsonConverter<JsonArray>
    {
        internal override JsonNode ToJson(JsonArray value) => value;

        internal override JsonArray FromJson(JsonNode node) => (JsonArray)node;
    }
}