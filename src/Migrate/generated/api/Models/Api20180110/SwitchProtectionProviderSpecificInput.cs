namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Provider specific switch protection input.</summary>
    public partial class SwitchProtectionProviderSpecificInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ISwitchProtectionProviderSpecificInputInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>Creates an new <see cref="SwitchProtectionProviderSpecificInput" /> instance.</summary>
        public SwitchProtectionProviderSpecificInput()
        {

        }
    }
    /// Provider specific switch protection input.
    public partial interface ISwitchProtectionProviderSpecificInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the Instance type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the Instance type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get; set; }

    }
    /// Provider specific switch protection input.
    internal partial interface ISwitchProtectionProviderSpecificInputInternal

    {
        /// <summary>Gets the Instance type.</summary>
        string InstanceType { get; set; }

    }
}