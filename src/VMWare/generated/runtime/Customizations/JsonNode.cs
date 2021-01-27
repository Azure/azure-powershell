/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    using System;
    using System.Collections.Generic;

    public partial class JsonNode
    {
        /// <summary>
        /// Returns the content of this node as the underlying value.
        /// Will default to the string representation if not overridden in child classes.
        /// </summary>
        /// <returns>an object with the underlying value of the node.</returns>
        internal virtual object ToValue() {
            return this.ToString();
        }
    }
}