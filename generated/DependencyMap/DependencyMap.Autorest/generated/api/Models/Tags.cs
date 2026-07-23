// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.Extensions;

    /// <summary>Resource tags.</summary>
    public partial class Tags :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ITags,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Models.ITagsInternal
    {

        /// <summary>Creates an new <see cref="Tags" /> instance.</summary>
        public Tags()
        {

        }
    }
    /// Resource tags.
    public partial interface ITags :
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DependencyMap.Runtime.IAssociativeArray<string>
    {

    }
    /// Resource tags.
    internal partial interface ITagsInternal

    {

    }
}