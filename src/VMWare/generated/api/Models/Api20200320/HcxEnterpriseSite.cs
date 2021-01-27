namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>An HCX Enterprise Site resource</summary>
    public partial class HcxEnterpriseSite :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSite,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.Resource();

        /// <summary>The activation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public string ActivationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSitePropertiesInternal)Property).ActivationKey; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Id; }

        /// <summary>Internal Acessors for ActivationKey</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal.ActivationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSitePropertiesInternal)Property).ActivationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSitePropertiesInternal)Property).ActivationKey = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteProperties Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.HcxEnterpriseSiteProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.HcxEnterpriseSiteStatus? Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSitePropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSitePropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteProperties _property;

        /// <summary>The properties of an HCX Enterprise Site resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.HcxEnterpriseSiteProperties()); }

        /// <summary>The status of the HCX Enterprise Site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.HcxEnterpriseSiteStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSitePropertiesInternal)Property).Status; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="HcxEnterpriseSite" /> instance.</summary>
        public HcxEnterpriseSite()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// An HCX Enterprise Site resource
    public partial interface IHcxEnterpriseSite :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResource
    {
        /// <summary>The activation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The activation key",
        SerializedName = @"activationKey",
        PossibleTypes = new [] { typeof(string) })]
        string ActivationKey { get;  }
        /// <summary>The status of the HCX Enterprise Site</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the HCX Enterprise Site",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.HcxEnterpriseSiteStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.HcxEnterpriseSiteStatus? Status { get;  }

    }
    /// An HCX Enterprise Site resource
    internal partial interface IHcxEnterpriseSiteInternal :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IResourceInternal
    {
        /// <summary>The activation key</summary>
        string ActivationKey { get; set; }
        /// <summary>The properties of an HCX Enterprise Site resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.IHcxEnterpriseSiteProperties Property { get; set; }
        /// <summary>The status of the HCX Enterprise Site</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Support.HcxEnterpriseSiteStatus? Status { get; set; }

    }
}