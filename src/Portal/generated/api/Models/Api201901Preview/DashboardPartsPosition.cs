namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Extensions;

    /// <summary>The dashboard's part position.</summary>
    public partial class DashboardPartsPosition :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPosition,
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionInternal
    {

        /// <summary>Backing field for <see cref="ColSpan" /> property.</summary>
        private int _colSpan;

        /// <summary>The dashboard's part column span.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Origin(Microsoft.Azure.PowerShell.Cmdlets.Portal.PropertyOrigin.Owned)]
        public int ColSpan { get => this._colSpan; set => this._colSpan = value; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionMetadata _metadata;

        /// <summary>The dashboard part's metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Origin(Microsoft.Azure.PowerShell.Cmdlets.Portal.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionMetadata Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.DashboardPartsPositionMetadata()); set => this._metadata = value; }

        /// <summary>Backing field for <see cref="RowSpan" /> property.</summary>
        private int _rowSpan;

        /// <summary>The dashboard's part row span.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Origin(Microsoft.Azure.PowerShell.Cmdlets.Portal.PropertyOrigin.Owned)]
        public int RowSpan { get => this._rowSpan; set => this._rowSpan = value; }

        /// <summary>Backing field for <see cref="X" /> property.</summary>
        private int _x;

        /// <summary>The dashboard's part x coordinate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Origin(Microsoft.Azure.PowerShell.Cmdlets.Portal.PropertyOrigin.Owned)]
        public int X { get => this._x; set => this._x = value; }

        /// <summary>Backing field for <see cref="Y" /> property.</summary>
        private int _y;

        /// <summary>The dashboard's part y coordinate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Origin(Microsoft.Azure.PowerShell.Cmdlets.Portal.PropertyOrigin.Owned)]
        public int Y { get => this._y; set => this._y = value; }

        /// <summary>Creates an new <see cref="DashboardPartsPosition" /> instance.</summary>
        public DashboardPartsPosition()
        {

        }
    }
    /// The dashboard's part position.
    public partial interface IDashboardPartsPosition :
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.IJsonSerializable
    {
        /// <summary>The dashboard's part column span.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The dashboard's part column span.",
        SerializedName = @"colSpan",
        PossibleTypes = new [] { typeof(int) })]
        int ColSpan { get; set; }
        /// <summary>The dashboard part's metadata.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The dashboard part's metadata.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionMetadata Metadata { get; set; }
        /// <summary>The dashboard's part row span.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The dashboard's part row span.",
        SerializedName = @"rowSpan",
        PossibleTypes = new [] { typeof(int) })]
        int RowSpan { get; set; }
        /// <summary>The dashboard's part x coordinate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The dashboard's part x coordinate.",
        SerializedName = @"x",
        PossibleTypes = new [] { typeof(int) })]
        int X { get; set; }
        /// <summary>The dashboard's part y coordinate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The dashboard's part y coordinate.",
        SerializedName = @"y",
        PossibleTypes = new [] { typeof(int) })]
        int Y { get; set; }

    }
    /// The dashboard's part position.
    internal partial interface IDashboardPartsPositionInternal

    {
        /// <summary>The dashboard's part column span.</summary>
        int ColSpan { get; set; }
        /// <summary>The dashboard part's metadata.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.Api201901Preview.IDashboardPartsPositionMetadata Metadata { get; set; }
        /// <summary>The dashboard's part row span.</summary>
        int RowSpan { get; set; }
        /// <summary>The dashboard's part x coordinate.</summary>
        int X { get; set; }
        /// <summary>The dashboard's part y coordinate.</summary>
        int Y { get; set; }

    }
}