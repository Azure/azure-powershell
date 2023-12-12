/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    public sealed class UriConverter : JsonConverter<Uri>
    {
        internal override JsonNode ToJson(Uri value) => new JsonString(value.AbsoluteUri);

        internal override Uri FromJson(JsonNode node) => (Uri)node;
    }
}