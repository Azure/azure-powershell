/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json
{
    internal interface IJsonConverter
    {
        JsonNode ToJson(object value);

        object FromJson(JsonNode node);
    }
}