namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Storage object properties.</summary>
    public partial class StorageClassificationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IStorageClassificationPropertiesInternal
    {

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Friendly name of the Storage classification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Creates an new <see cref="StorageClassificationProperties" /> instance.</summary>
        public StorageClassificationProperties()
        {

        }
    }
    /// Storage object properties.
    public partial interface IStorageClassificationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Friendly name of the Storage classification.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly name of the Storage classification.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }

    }
    /// Storage object properties.
    internal partial interface IStorageClassificationPropertiesInternal

    {
        /// <summary>Friendly name of the Storage classification.</summary>
        string FriendlyName { get; set; }

    }
}