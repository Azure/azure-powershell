/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    internal class PropertyTransformation
    {
        internal PropertyTransformation(string name, Func<object, object> transformer)
        {
            Name        = name        ?? throw new ArgumentNullException(nameof(name));
            Transformer = transformer ?? throw new ArgumentNullException(nameof(transformer));
        }

        internal string Name { get; }

        internal Func<object, object> Transformer { get; }
    }
}