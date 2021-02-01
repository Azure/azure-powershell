namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Protection profile custom data details.</summary>
    public partial class PolicyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>The FriendlyName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Internal Acessors for ProviderSpecificDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyPropertiesInternal.ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.PolicyProviderSpecificDetails()); set { {_providerSpecificDetail = value;} } }

        /// <summary>Internal Acessors for ProviderSpecificDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyPropertiesInternal.ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal)ProviderSpecificDetail).InstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal)ProviderSpecificDetail).InstanceType = value; }

        /// <summary>Backing field for <see cref="ProviderSpecificDetail" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails _providerSpecificDetail;

        /// <summary>The ReplicationChannelSetting.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails ProviderSpecificDetail { get => (this._providerSpecificDetail = this._providerSpecificDetail ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.PolicyProviderSpecificDetails()); set => this._providerSpecificDetail = value; }

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProviderSpecificDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetailsInternal)ProviderSpecificDetail).InstanceType; }

        /// <summary>Creates an new <see cref="PolicyProperties" /> instance.</summary>
        public PolicyProperties()
        {

        }
    }
    /// Protection profile custom data details.
    public partial interface IPolicyProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The FriendlyName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The FriendlyName.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the class type. Overridden in derived classes.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string ProviderSpecificDetailInstanceType { get;  }

    }
    /// Protection profile custom data details.
    internal partial interface IPolicyPropertiesInternal

    {
        /// <summary>The FriendlyName.</summary>
        string FriendlyName { get; set; }
        /// <summary>The ReplicationChannelSetting.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IPolicyProviderSpecificDetails ProviderSpecificDetail { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        string ProviderSpecificDetailInstanceType { get; set; }

    }
}