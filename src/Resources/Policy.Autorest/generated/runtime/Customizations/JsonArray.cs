/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Sample.API.Runtime.Json
{
    public partial class JsonArray
    {
        internal override object ToValue() =>  Count == 0 ? new object[0] : System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(this, each => each.ToValue()));
    }


}