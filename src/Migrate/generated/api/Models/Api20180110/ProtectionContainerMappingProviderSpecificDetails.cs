namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Container mapping provider specific details.</summary>
    public partial class ProtectionContainerMappingProviderSpecificDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; }

        /// <summary>Internal Acessors for InstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectionContainerMappingProviderSpecificDetailsInternal.InstanceType { get => this._instanceType; set { {_instanceType = value;} } }

        /// <summary>
        /// Creates an new <see cref="ProtectionContainerMappingProviderSpecificDetails" /> instance.
        /// </summary>
        public ProtectionContainerMappingProviderSpecificDetails()
        {

        }
    }
    /// Container mapping provider specific details.
    public partial interface IProtectionContainerMappingProviderSpecificDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the class type. Overridden in derived classes.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceType { get;  }

    }
    /// Container mapping provider specific details.
    internal partial interface IProtectionContainerMappingProviderSpecificDetailsInternal

    {
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        string InstanceType { get; set; }

    }
}