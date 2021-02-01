/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime
{
    public interface IHeaderSerializable
    {
        void ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers);
    }
}