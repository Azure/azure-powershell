namespace Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Extensions;

    /// <summary>Specifications of the Dimension of metrics.</summary>
    public partial class Dimension :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IDimension,
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Models.Api20200820Preview.IDimensionInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Localized friendly display name of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="InternalName" /> property.</summary>
        private string _internalName;

        /// <summary>Name of the dimension as it appears in MDM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string InternalName { get => this._internalName; set => this._internalName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The public facing name of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ToBeExportedForShoebox" /> property.</summary>
        private bool? _toBeExportedForShoebox;

        /// <summary>
        /// A Boolean flag indicating whether this dimension should be included for the shoebox export scenario.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Origin(Microsoft.Azure.PowerShell.Cmdlets.Communication.PropertyOrigin.Owned)]
        public bool? ToBeExportedForShoebox { get => this._toBeExportedForShoebox; set => this._toBeExportedForShoebox = value; }

        /// <summary>Creates an new <see cref="Dimension" /> instance.</summary>
        public Dimension()
        {

        }
    }
    /// Specifications of the Dimension of metrics.
    public partial interface IDimension :
        Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.IJsonSerializable
    {
        /// <summary>Localized friendly display name of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly display name of the dimension.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Name of the dimension as it appears in MDM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the dimension as it appears in MDM.",
        SerializedName = @"internalName",
        PossibleTypes = new [] { typeof(string) })]
        string InternalName { get; set; }
        /// <summary>The public facing name of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The public facing name of the dimension.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// A Boolean flag indicating whether this dimension should be included for the shoebox export scenario.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Communication.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A Boolean flag indicating whether this dimension should be included for the shoebox export scenario.",
        SerializedName = @"toBeExportedForShoebox",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ToBeExportedForShoebox { get; set; }

    }
    /// Specifications of the Dimension of metrics.
    internal partial interface IDimensionInternal

    {
        /// <summary>Localized friendly display name of the dimension.</summary>
        string DisplayName { get; set; }
        /// <summary>Name of the dimension as it appears in MDM.</summary>
        string InternalName { get; set; }
        /// <summary>The public facing name of the dimension.</summary>
        string Name { get; set; }
        /// <summary>
        /// A Boolean flag indicating whether this dimension should be included for the shoebox export scenario.
        /// </summary>
        bool? ToBeExportedForShoebox { get; set; }

    }
}