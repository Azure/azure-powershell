namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Resync provider specific input.</summary>
    public partial class ResyncProviderSpecificInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResyncProviderSpecificInputInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>Creates an new <see cref="ResyncProviderSpecificInput" /> instance.</summary>
        public ResyncProviderSpecificInput()
        {

        }
    }
    /// Resync provider specific input.
    public partial interface IResyncProviderSpecificInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get; set; }

    }
    /// Resync provider specific input.
    internal partial interface IResyncProviderSpecificInputInternal

    {
        /// <summary>The class type.</summary>
        string InstanceType { get; set; }

    }
}