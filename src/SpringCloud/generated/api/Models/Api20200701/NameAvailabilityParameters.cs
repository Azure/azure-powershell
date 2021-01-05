namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Name availability parameters payload</summary>
    public partial class NameAvailabilityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INameAvailabilityParameters,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.INameAvailabilityParametersInternal
    {

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name to be checked</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Type of the resource to check name availability</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="NameAvailabilityParameters" /> instance.</summary>
        public NameAvailabilityParameters()
        {

        }
    }
    /// Name availability parameters payload
    public partial interface INameAvailabilityParameters :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Name to be checked</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Name to be checked",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Type of the resource to check name availability</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Type of the resource to check name availability",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Name availability parameters payload
    public partial interface INameAvailabilityParametersInternal

    {
        /// <summary>Name to be checked</summary>
        string Name { get; set; }
        /// <summary>Type of the resource to check name availability</summary>
        string Type { get; set; }

    }
}