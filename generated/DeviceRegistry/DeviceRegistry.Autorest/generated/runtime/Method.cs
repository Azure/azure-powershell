/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime
{
    internal static class Method
    {
        internal static System.Net.Http.HttpMethod Get = System.Net.Http.HttpMethod.Get;
        internal static System.Net.Http.HttpMethod Put = System.Net.Http.HttpMethod.Put;
        internal static System.Net.Http.HttpMethod Head = System.Net.Http.HttpMethod.Head;
        internal static System.Net.Http.HttpMethod Post = System.Net.Http.HttpMethod.Post;
        internal static System.Net.Http.HttpMethod Delete = System.Net.Http.HttpMethod.Delete;
        internal static System.Net.Http.HttpMethod Options = System.Net.Http.HttpMethod.Options;
        internal static System.Net.Http.HttpMethod Trace = System.Net.Http.HttpMethod.Trace;
        internal static System.Net.Http.HttpMethod Patch = new System.Net.Http.HttpMethod("PATCH");
    }
}