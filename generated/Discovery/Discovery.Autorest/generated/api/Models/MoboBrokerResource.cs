// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>
    /// Managed-On-Behalf-Of broker resource. This resource is created by the Resource Provider to manage some resources on behalf
    /// of the user.
    /// </summary>
    public partial class MoboBrokerResource :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResource,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IMoboBrokerResourceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource identifier of a Managed-On-Behalf-Of broker resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Creates an new <see cref="MoboBrokerResource" /> instance.</summary>
        public MoboBrokerResource()
        {

        }
    }
    /// Managed-On-Behalf-Of broker resource. This resource is created by the Resource Provider to manage some resources on behalf
    /// of the user.
    public partial interface IMoboBrokerResource :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>Resource identifier of a Managed-On-Behalf-Of broker resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource identifier of a Managed-On-Behalf-Of broker resource",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }

    }
    /// Managed-On-Behalf-Of broker resource. This resource is created by the Resource Provider to manage some resources on behalf
    /// of the user.
    internal partial interface IMoboBrokerResourceInternal

    {
        /// <summary>Resource identifier of a Managed-On-Behalf-Of broker resource</summary>
        string Id { get; set; }

    }
}