/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    public sealed class SingleConverter : JsonConverter<float>
    {
        internal override JsonNode ToJson(float value) => new JsonNumber(value.ToString());

        internal override float FromJson(JsonNode node) => (float)node;
    }
}