// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Extensions;

    /// <summary>The template for adding updateable properties.</summary>
    public partial class StorageDiscoveryWorkspaceUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdate,
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal
    {

        /// <summary>The description of the storage discovery workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string Description { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal)Property).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal)Property).Description = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdate Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspaceUpdateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspacePropertiesUpdate()); set { {_property = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdate _property;

        /// <summary>The resource-specific properties for this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdate Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.StorageDiscoveryWorkspacePropertiesUpdate()); set => this._property = value; }

        /// <summary>The scopes of the storage discovery workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> Scope { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal)Property).Scope; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal)Property).Scope = value ?? null /* arrayOf */; }

        /// <summary>The storage discovery sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public string Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal)Property).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal)Property).Sku = value ?? null; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.Tags()); set => this._tag = value; }

        /// <summary>The view level storage discovery data estate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PropertyOrigin.Inlined)]
        public System.Collections.Generic.List<string> WorkspaceRoot { get => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal)Property).WorkspaceRoot; set => ((Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdateInternal)Property).WorkspaceRoot = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="StorageDiscoveryWorkspaceUpdate" /> instance.</summary>
        public StorageDiscoveryWorkspaceUpdate()
        {

        }
    }
    /// The template for adding updateable properties.
    public partial interface IStorageDiscoveryWorkspaceUpdate :
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.IJsonSerializable
    {
        /// <summary>The description of the storage discovery workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The description of the storage discovery workspace",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>The scopes of the storage discovery workspace.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The scopes of the storage discovery workspace.",
        SerializedName = @"scopes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope) })]
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> Scope { get; set; }
        /// <summary>The storage discovery sku</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The storage discovery sku",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Standard", "Free")]
        string Sku { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITags) })]
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITags Tag { get; set; }
        /// <summary>The view level storage discovery data estate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The view level storage discovery data estate",
        SerializedName = @"workspaceRoots",
        PossibleTypes = new [] { typeof(string) })]
        System.Collections.Generic.List<string> WorkspaceRoot { get; set; }

    }
    /// The template for adding updateable properties.
    internal partial interface IStorageDiscoveryWorkspaceUpdateInternal

    {
        /// <summary>The description of the storage discovery workspace</summary>
        string Description { get; set; }
        /// <summary>The resource-specific properties for this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryWorkspacePropertiesUpdate Property { get; set; }
        /// <summary>The scopes of the storage discovery workspace.</summary>
        System.Collections.Generic.List<Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.IStorageDiscoveryScope> Scope { get; set; }
        /// <summary>The storage discovery sku</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.PSArgumentCompleterAttribute("Standard", "Free")]
        string Sku { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StorageDiscovery.Models.ITags Tag { get; set; }
        /// <summary>The view level storage discovery data estate</summary>
        System.Collections.Generic.List<string> WorkspaceRoot { get; set; }

    }
}