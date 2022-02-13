/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    public sealed class JsonObjectConverter : JsonConverter<JsonObject>
    {
        internal override JsonNode ToJson(JsonObject value) => value;

        internal override JsonObject FromJson(JsonNode node) => (JsonObject)node;
    }
}