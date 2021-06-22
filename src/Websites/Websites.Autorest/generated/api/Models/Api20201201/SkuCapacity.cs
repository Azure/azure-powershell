namespace Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Extensions;

    /// <summary>Description of the App Service plan scale options.</summary>
    public partial class SkuCapacity :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuCapacity,
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Models.Api20201201.ISkuCapacityInternal
    {

        /// <summary>Backing field for <see cref="Default" /> property.</summary>
        private int? _default;

        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public int? Default { get => this._default; set => this._default = value; }

        /// <summary>Backing field for <see cref="ElasticMaximum" /> property.</summary>
        private int? _elasticMaximum;

        /// <summary>Maximum number of Elastic workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public int? ElasticMaximum { get => this._elasticMaximum; set => this._elasticMaximum = value; }

        /// <summary>Backing field for <see cref="Maximum" /> property.</summary>
        private int? _maximum;

        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public int? Maximum { get => this._maximum; set => this._maximum = value; }

        /// <summary>Backing field for <see cref="Minimum" /> property.</summary>
        private int? _minimum;

        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public int? Minimum { get => this._minimum; set => this._minimum = value; }

        /// <summary>Backing field for <see cref="ScaleType" /> property.</summary>
        private string _scaleType;

        /// <summary>Available scale configurations for an App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Origin(Microsoft.Azure.PowerShell.Cmdlets.Websites.PropertyOrigin.Owned)]
        public string ScaleType { get => this._scaleType; set => this._scaleType = value; }

        /// <summary>Creates an new <see cref="SkuCapacity" /> instance.</summary>
        public SkuCapacity()
        {

        }
    }
    /// Description of the App Service plan scale options.
    public partial interface ISkuCapacity :
        Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.IJsonSerializable
    {
        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Default number of workers for this App Service plan SKU.",
        SerializedName = @"default",
        PossibleTypes = new [] { typeof(int) })]
        int? Default { get; set; }
        /// <summary>Maximum number of Elastic workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of Elastic workers for this App Service plan SKU.",
        SerializedName = @"elasticMaximum",
        PossibleTypes = new [] { typeof(int) })]
        int? ElasticMaximum { get; set; }
        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum number of workers for this App Service plan SKU.",
        SerializedName = @"maximum",
        PossibleTypes = new [] { typeof(int) })]
        int? Maximum { get; set; }
        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum number of workers for this App Service plan SKU.",
        SerializedName = @"minimum",
        PossibleTypes = new [] { typeof(int) })]
        int? Minimum { get; set; }
        /// <summary>Available scale configurations for an App Service plan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Websites.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Available scale configurations for an App Service plan.",
        SerializedName = @"scaleType",
        PossibleTypes = new [] { typeof(string) })]
        string ScaleType { get; set; }

    }
    /// Description of the App Service plan scale options.
    internal partial interface ISkuCapacityInternal

    {
        /// <summary>Default number of workers for this App Service plan SKU.</summary>
        int? Default { get; set; }
        /// <summary>Maximum number of Elastic workers for this App Service plan SKU.</summary>
        int? ElasticMaximum { get; set; }
        /// <summary>Maximum number of workers for this App Service plan SKU.</summary>
        int? Maximum { get; set; }
        /// <summary>Minimum number of workers for this App Service plan SKU.</summary>
        int? Minimum { get; set; }
        /// <summary>Available scale configurations for an App Service plan.</summary>
        string ScaleType { get; set; }

    }
}