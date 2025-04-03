/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json
{
    public sealed class DoubleConverter : JsonConverter<double>
    {
        internal override JsonNode ToJson(double value) => new JsonNumber(value);

        internal override double FromJson(JsonNode node) => (double)node;
    }
}