/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json
{
    public sealed class DateTimeConverter : JsonConverter<DateTime>
    {
        internal override JsonNode ToJson(DateTime value)
        {
            return new JsonDate(value);
        }

        internal override DateTime FromJson(JsonNode node) => (DateTime)node;
    }
}