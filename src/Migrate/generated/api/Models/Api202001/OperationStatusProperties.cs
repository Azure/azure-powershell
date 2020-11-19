namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Class for operation result properties.</summary>
    public partial class OperationStatusProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IOperationStatusPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Result" /> property.</summary>
        private string _result;

        /// <summary>Result or output of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Result { get => this._result; set => this._result = value; }

        /// <summary>Creates an new <see cref="OperationStatusProperties" /> instance.</summary>
        public OperationStatusProperties()
        {

        }
    }
    /// Class for operation result properties.
    public partial interface IOperationStatusProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        /// <summary>Result or output of the workflow.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Result or output of the workflow.",
        SerializedName = @"result",
        PossibleTypes = new [] { typeof(string) })]
        string Result { get; set; }

    }
    /// Class for operation result properties.
    internal partial interface IOperationStatusPropertiesInternal

    {
        /// <summary>Result or output of the workflow.</summary>
        string Result { get; set; }

    }
}