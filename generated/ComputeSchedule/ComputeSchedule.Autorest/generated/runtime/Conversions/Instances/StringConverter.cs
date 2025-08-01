/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json
{
    public sealed class StringConverter : JsonConverter<string>
    {
        internal override JsonNode ToJson(string value) => new JsonString(value);

        internal override string FromJson(JsonNode node) => node.ToString();
    }
}