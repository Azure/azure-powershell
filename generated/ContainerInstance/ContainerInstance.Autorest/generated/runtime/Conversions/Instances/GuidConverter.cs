/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    public sealed class GuidConverter : JsonConverter<Guid>
    {
        internal override JsonNode ToJson(Guid value) => new JsonString(value.ToString());

        internal override Guid FromJson(JsonNode node) => (Guid)node;
    }
}