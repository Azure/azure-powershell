namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Operation result properties</summary>
    public partial class OperationResultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api202101.IOperationResultPropertiesInternal
    {

        /// <summary>Backing field for <see cref="OperationKind" /> property.</summary>
        private string _operationKind;

        /// <summary>The kind of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string OperationKind { get => this._operationKind; set => this._operationKind = value; }

        /// <summary>Backing field for <see cref="OperationState" /> property.</summary>
        private string _operationState;

        /// <summary>The state of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string OperationState { get => this._operationState; set => this._operationState = value; }

        /// <summary>Creates an new <see cref="OperationResultProperties" /> instance.</summary>
        public OperationResultProperties()
        {

        }
    }
    /// Operation result properties
    public partial interface IOperationResultProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The kind of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The kind of the operation.",
        SerializedName = @"operationKind",
        PossibleTypes = new [] { typeof(string) })]
        string OperationKind { get; set; }
        /// <summary>The state of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The state of the operation.",
        SerializedName = @"operationState",
        PossibleTypes = new [] { typeof(string) })]
        string OperationState { get; set; }

    }
    /// Operation result properties
    internal partial interface IOperationResultPropertiesInternal

    {
        /// <summary>The kind of the operation.</summary>
        string OperationKind { get; set; }
        /// <summary>The state of the operation.</summary>
        string OperationState { get; set; }

    }
}