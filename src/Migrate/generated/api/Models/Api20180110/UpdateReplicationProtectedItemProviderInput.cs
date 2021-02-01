namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Update replication protected item provider specific input.</summary>
    public partial class UpdateReplicationProtectedItemProviderInput :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInput,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IUpdateReplicationProtectedItemProviderInputInternal
    {

        /// <summary>Backing field for <see cref="InstanceType" /> property.</summary>
        private string _instanceType;

        /// <summary>The class type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string InstanceType { get => this._instanceType; set => this._instanceType = value; }

        /// <summary>
        /// Creates an new <see cref="UpdateReplicationProtectedItemProviderInput" /> instance.
        /// </summary>
        public UpdateReplicationProtectedItemProviderInput()
        {

        }
    }
    /// Update replication protected item provider specific input.
    public partial interface IUpdateReplicationProtectedItemProviderInput :
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
    /// Update replication protected item provider specific input.
    internal partial interface IUpdateReplicationProtectedItemProviderInputInternal

    {
        /// <summary>The class type.</summary>
        string InstanceType { get; set; }

    }
}