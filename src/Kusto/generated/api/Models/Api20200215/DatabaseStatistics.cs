namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>A class that contains database statistics information.</summary>
    public partial class DatabaseStatistics :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabaseStatistics,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200215.IDatabaseStatisticsInternal
    {

        /// <summary>Backing field for <see cref="Size" /> property.</summary>
        private float? _size;

        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public float? Size { get => this._size; set => this._size = value; }

        /// <summary>Creates an new <see cref="DatabaseStatistics" /> instance.</summary>
        public DatabaseStatistics()
        {

        }
    }
    /// A class that contains database statistics information.
    public partial interface IDatabaseStatistics :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The database size - the total size of compressed data and index in bytes.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(float) })]
        float? Size { get; set; }

    }
    /// A class that contains database statistics information.
    internal partial interface IDatabaseStatisticsInternal

    {
        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        float? Size { get; set; }

    }
}