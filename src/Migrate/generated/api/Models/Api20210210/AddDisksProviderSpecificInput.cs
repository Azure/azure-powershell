namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Add Disks provider specific input.</summary>
    public partial class AddDisksProviderSpecificInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IAddDisksProviderSpecificInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20210210.IAddDisksProviderSpecificInputInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>Creates an new <see cref="AddDisksProviderSpecificInput" /> instance.</summary>
        public AddDisksProviderSpecificInput()
        {

        }
    }
    /// Add Disks provider specific input.
    public partial interface IAddDisksProviderSpecificInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The class type.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get; set; }

    }
    /// Add Disks provider specific input.
    internal partial interface IAddDisksProviderSpecificInputInternal

    {
        /// <summary>The class type.</summary>
        string InstanceType { get; set; }

    }
}