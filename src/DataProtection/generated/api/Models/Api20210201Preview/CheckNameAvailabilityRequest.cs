namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>CheckNameAvailability Request</summary>
    public partial class CheckNameAvailabilityRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICheckNameAvailabilityRequest,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.ICheckNameAvailabilityRequestInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name for which availability needs to be checked</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Describes the Resource type: Microsoft.DataProtection/BackupVaults</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="CheckNameAvailabilityRequest" /> instance.</summary>
        public CheckNameAvailabilityRequest()
        {

        }
    }
    /// CheckNameAvailability Request
    public partial interface ICheckNameAvailabilityRequest :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable
    {
        /// <summary>Resource name for which availability needs to be checked</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource name for which availability needs to be checked",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Describes the Resource type: Microsoft.DataProtection/BackupVaults</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes the Resource type: Microsoft.DataProtection/BackupVaults",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// CheckNameAvailability Request
    internal partial interface ICheckNameAvailabilityRequestInternal

    {
        /// <summary>Resource name for which availability needs to be checked</summary>
        string Name { get; set; }
        /// <summary>Describes the Resource type: Microsoft.DataProtection/BackupVaults</summary>
        string Type { get; set; }

    }
}