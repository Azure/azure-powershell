namespace Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Extensions;

    /// <summary>The definition for data in the export.</summary>
    public partial class ExportDataset :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDataset,
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetInternal
    {

        /// <summary>Backing field for <see cref="Configuration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration _configuration;

        /// <summary>The export dataset configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration Configuration { get => (this._configuration = this._configuration ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfiguration()); set => this._configuration = value; }

        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Inlined)]
        public string[] ConfigurationColumn { get => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfigurationInternal)Configuration).Column; set => ((Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfigurationInternal)Configuration).Column = value ?? null /* arrayOf */; }

        /// <summary>Backing field for <see cref="Granularity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? _granularity;

        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Origin(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? Granularity { get => this._granularity; set => this._granularity = value; }

        /// <summary>Internal Acessors for Configuration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetInternal.Configuration { get => (this._configuration = this._configuration ?? new Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.ExportDatasetConfiguration()); set { {_configuration = value;} } }

        /// <summary>Creates an new <see cref="ExportDataset" /> instance.</summary>
        public ExportDataset()
        {

        }
    }
    /// The definition for data in the export.
    public partial interface IExportDataset :
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Array of column names to be included in the export. If not provided then the export will include all available columns. The available columns can vary by customer channel (see examples).",
        SerializedName = @"columns",
        PossibleTypes = new [] { typeof(string) })]
        string[] ConfigurationColumn { get; set; }
        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The granularity of rows in the export. Currently only 'Daily' is supported.",
        SerializedName = @"granularity",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? Granularity { get; set; }

    }
    /// The definition for data in the export.
    public partial interface IExportDatasetInternal

    {
        /// <summary>The export dataset configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Models.Api20200601.IExportDatasetConfiguration Configuration { get; set; }
        /// <summary>
        /// Array of column names to be included in the export. If not provided then the export will include all available columns.
        /// The available columns can vary by customer channel (see examples).
        /// </summary>
        string[] ConfigurationColumn { get; set; }
        /// <summary>The granularity of rows in the export. Currently only 'Daily' is supported.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CostManagement.Support.GranularityType? Granularity { get; set; }

    }
}