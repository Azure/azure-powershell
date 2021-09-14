namespace Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Extensions;

    /// <summary>Managed cluster Access Profile.</summary>
    public partial class ManagedClusterAccessProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAccessProfile,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAccessProfileInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.Resource();

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Id; }

        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inlined)]
        public byte[] KubeConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAccessProfileInternal)Property).KubeConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAccessProfileInternal)Property).KubeConfig = value ?? null /* byte array */; }

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Location = value ; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAccessProfile Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IManagedClusterAccessProfileInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AccessProfile()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAccessProfile _property;

        /// <summary>AccessProfile of a managed cluster.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAccessProfile Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.AccessProfile()); set => this._property = value; }

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Tag = value ?? null /* model class */; }

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Origin(Microsoft.Azure.PowerShell.Cmdlets.Aks.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ManagedClusterAccessProfile" /> instance.</summary>
        public ManagedClusterAccessProfile()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Managed cluster Access Profile.
    public partial interface IManagedClusterAccessProfile :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResource
    {
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Aks.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Base64-encoded Kubernetes configuration file.",
        SerializedName = @"kubeConfig",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] KubeConfig { get; set; }

    }
    /// Managed cluster Access Profile.
    internal partial interface IManagedClusterAccessProfileInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IResourceInternal
    {
        /// <summary>Base64-encoded Kubernetes configuration file.</summary>
        byte[] KubeConfig { get; set; }
        /// <summary>AccessProfile of a managed cluster.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.Api20200901.IAccessProfile Property { get; set; }

    }
}