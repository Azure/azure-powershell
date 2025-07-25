/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Json
{
    internal partial class JsonBoolean
    {
        internal static JsonBoolean Create(bool? value) => value is bool b ? new JsonBoolean(b) : null;
        internal bool ToBoolean() => Value;

        internal override object ToValue() => Value;
    }


}