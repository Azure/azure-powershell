// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>
    /// The compute properties of the cluster. This includes the virtual-cores/memory and scaling options applied to servers in
    /// the cluster.
    /// </summary>
    public partial class ComputeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputeProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IComputePropertiesInternal
    {

        /// <summary>Backing field for <see cref="Tier" /> property.</summary>
        private string _tier;

        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string Tier { get => this._tier; set => this._tier = value; }

        /// <summary>Creates an new <see cref="ComputeProperties" /> instance.</summary>
        public ComputeProperties()
        {

        }
    }
    /// The compute properties of the cluster. This includes the virtual-cores/memory and scaling options applied to servers in
    /// the cluster.
    public partial interface IComputeProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30', 'M40'.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string Tier { get; set; }

    }
    /// The compute properties of the cluster. This includes the virtual-cores/memory and scaling options applied to servers in
    /// the cluster.
    internal partial interface IComputePropertiesInternal

    {
        /// <summary>
        /// The compute tier to assign to the cluster, where each tier maps to a virtual-core and memory size. Example values: 'M30',
        /// 'M40'.
        /// </summary>
        string Tier { get; set; }

    }
}