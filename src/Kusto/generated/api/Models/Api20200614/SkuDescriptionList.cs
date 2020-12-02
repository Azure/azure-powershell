namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>The list of the EngagementFabric SKU descriptions</summary>
    public partial class SkuDescriptionList :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuDescriptionList,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuDescriptionListInternal
    {

        /// <summary>Internal Acessors for Value</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuDescription[] Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuDescriptionListInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuDescription[] _value;

        /// <summary>SKU descriptions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuDescription[] Value { get => this._value; }

        /// <summary>Creates an new <see cref="SkuDescriptionList" /> instance.</summary>
        public SkuDescriptionList()
        {

        }
    }
    /// The list of the EngagementFabric SKU descriptions
    public partial interface ISkuDescriptionList :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>SKU descriptions</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"SKU descriptions",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuDescription) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuDescription[] Value { get;  }

    }
    /// The list of the EngagementFabric SKU descriptions
    internal partial interface ISkuDescriptionListInternal

    {
        /// <summary>SKU descriptions</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.ISkuDescription[] Value { get; set; }

    }
}