namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Volume details.</summary>
    public partial class DiskVolumeDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskVolumeDetails,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IDiskVolumeDetailsInternal
    {

        /// <summary>Backing field for <see cref="Label" /> property.</summary>
        private string _label;

        /// <summary>The volume label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Label { get => this._label; set => this._label = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The volume name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="DiskVolumeDetails" /> instance.</summary>
        public DiskVolumeDetails()
        {

        }
    }
    /// Volume details.
    public partial interface IDiskVolumeDetails :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>The volume label.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The volume label.",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string Label { get; set; }
        /// <summary>The volume name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The volume name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Volume details.
    internal partial interface IDiskVolumeDetailsInternal

    {
        /// <summary>The volume label.</summary>
        string Label { get; set; }
        /// <summary>The volume name.</summary>
        string Name { get; set; }

    }
}