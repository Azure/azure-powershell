// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Extensions;

    /// <summary>Dictionary of identity properties for the Supercomputer.</summary>
    public partial class SupercomputerIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentities,
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal
    {

        /// <summary>Backing field for <see cref="ClusterIdentity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity _clusterIdentity;

        /// <summary>Cluster identity ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity ClusterIdentity { get => (this._clusterIdentity = this._clusterIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Identity()); set => this._clusterIdentity = value; }

        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ClusterIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)ClusterIdentity).ClientId; }

        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ClusterIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)ClusterIdentity).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)ClusterIdentity).Id = value ?? null; }

        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string ClusterIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)ClusterIdentity).PrincipalId; }

        /// <summary>Backing field for <see cref="KubeletIdentity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity _kubeletIdentity;

        /// <summary>
        /// Kubelet identity ID used by the supercomputer.
        /// This identity is used by the supercomputer at node level to access Azure resources.
        /// This identity must have ManagedIdentityOperator role on the clusterIdentity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity KubeletIdentity { get => (this._kubeletIdentity = this._kubeletIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Identity()); set => this._kubeletIdentity = value; }

        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KubeletIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)KubeletIdentity).ClientId; }

        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KubeletIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)KubeletIdentity).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)KubeletIdentity).Id = value ?? null; }

        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Inlined)]
        public string KubeletIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)KubeletIdentity).PrincipalId; }

        /// <summary>Internal Acessors for ClusterIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal.ClusterIdentity { get => (this._clusterIdentity = this._clusterIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Identity()); set { {_clusterIdentity = value;} } }

        /// <summary>Internal Acessors for ClusterIdentityClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal.ClusterIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)ClusterIdentity).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)ClusterIdentity).ClientId = value ?? null; }

        /// <summary>Internal Acessors for ClusterIdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal.ClusterIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)ClusterIdentity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)ClusterIdentity).PrincipalId = value ?? null; }

        /// <summary>Internal Acessors for KubeletIdentity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal.KubeletIdentity { get => (this._kubeletIdentity = this._kubeletIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.Identity()); set { {_kubeletIdentity = value;} } }

        /// <summary>Internal Acessors for KubeletIdentityClientId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal.KubeletIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)KubeletIdentity).ClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)KubeletIdentity).ClientId = value ?? null; }

        /// <summary>Internal Acessors for KubeletIdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesInternal.KubeletIdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)KubeletIdentity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentityInternal)KubeletIdentity).PrincipalId = value ?? null; }

        /// <summary>Backing field for <see cref="WorkloadIdentity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities _workloadIdentity;

        /// <summary>
        /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
        /// be the resource ID of the identity resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Origin(Microsoft.Azure.PowerShell.Cmdlets.Discovery.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities WorkloadIdentity { get => (this._workloadIdentity = this._workloadIdentity ?? new Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.SupercomputerIdentitiesWorkloadIdentities()); set => this._workloadIdentity = value; }

        /// <summary>Creates an new <see cref="SupercomputerIdentities" /> instance.</summary>
        public SupercomputerIdentities()
        {

        }
    }
    /// Dictionary of identity properties for the Supercomputer.
    public partial interface ISupercomputerIdentities :
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.IJsonSerializable
    {
        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The client ID of the assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterIdentityClientId { get;  }
        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The resource ID of the user assigned identity.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The principal ID of the assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string ClusterIdentityPrincipalId { get;  }
        /// <summary>The client ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The client ID of the assigned identity.",
        SerializedName = @"clientId",
        PossibleTypes = new [] { typeof(string) })]
        string KubeletIdentityClientId { get;  }
        /// <summary>The resource ID of the user assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = false,
        Description = @"The resource ID of the user assigned identity.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string KubeletIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The principal ID of the assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string KubeletIdentityPrincipalId { get;  }
        /// <summary>
        /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
        /// be the resource ID of the identity resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Discovery.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must be the resource ID of the identity resource.",
        SerializedName = @"workloadIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities WorkloadIdentity { get; set; }

    }
    /// Dictionary of identity properties for the Supercomputer.
    internal partial interface ISupercomputerIdentitiesInternal

    {
        /// <summary>Cluster identity ID.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity ClusterIdentity { get; set; }
        /// <summary>The client ID of the assigned identity.</summary>
        string ClusterIdentityClientId { get; set; }
        /// <summary>The resource ID of the user assigned identity.</summary>
        string ClusterIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        string ClusterIdentityPrincipalId { get; set; }
        /// <summary>
        /// Kubelet identity ID used by the supercomputer.
        /// This identity is used by the supercomputer at node level to access Azure resources.
        /// This identity must have ManagedIdentityOperator role on the clusterIdentity.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IIdentity KubeletIdentity { get; set; }
        /// <summary>The client ID of the assigned identity.</summary>
        string KubeletIdentityClientId { get; set; }
        /// <summary>The resource ID of the user assigned identity.</summary>
        string KubeletIdentityId { get; set; }
        /// <summary>The principal ID of the assigned identity.</summary>
        string KubeletIdentityPrincipalId { get; set; }
        /// <summary>
        /// User assigned identity IDs to be used by workloads as federated credentials running on supercomputer. The key value must
        /// be the resource ID of the identity resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.ISupercomputerIdentitiesWorkloadIdentities WorkloadIdentity { get; set; }

    }
}