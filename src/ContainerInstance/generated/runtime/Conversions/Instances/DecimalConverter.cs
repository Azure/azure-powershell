/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    public sealed class DecimalConverter : JsonConverter<decimal>
    {
        internal override JsonNode ToJson(decimal value) => new JsonNumber(value.ToString());

        internal override decimal FromJson(JsonNode node)
        {
            return (decimal)node;
        }
    }
}