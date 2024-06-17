/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Json
{
    public sealed class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        internal override JsonNode ToJson(DateTimeOffset value) => new JsonDate(value);

        internal override DateTimeOffset FromJson(JsonNode node) => (DateTimeOffset)node;
    }
}