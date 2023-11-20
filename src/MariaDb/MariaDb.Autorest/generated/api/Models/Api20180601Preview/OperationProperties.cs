namespace Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.Extensions;

    /// <summary>Additional descriptions for the operation.</summary>
    public partial class OperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IOperationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IOperationPropertiesInternal
    {

        /// <summary>Creates an new <see cref="OperationProperties" /> instance.</summary>
        public OperationProperties()
        {

        }
    }
    /// Additional descriptions for the operation.
    public partial interface IOperationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.IAssociativeArray<global::System.Object>
    {

    }
    /// Additional descriptions for the operation.
    internal partial interface IOperationPropertiesInternal

    {

    }
}