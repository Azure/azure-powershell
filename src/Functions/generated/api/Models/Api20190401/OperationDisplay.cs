namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Display metadata associated with the operation.</summary>
    public partial class OperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IOperationDisplay,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IOperationDisplayInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>Type of operation: get, read, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; set => this._operation = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>Service provider: Microsoft Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string _resource;

        /// <summary>Resource on which the operation is performed etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Resource { get => this._resource; set => this._resource = value; }

        /// <summary>Creates an new <see cref="OperationDisplay" /> instance.</summary>
        public OperationDisplay()
        {

        }
    }
    /// Display metadata associated with the operation.
    public partial interface IOperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Type of operation: get, read, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of operation: get, read, delete, etc.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get; set; }
        /// <summary>Service provider: Microsoft Storage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service provider: Microsoft Storage.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }
        /// <summary>Resource on which the operation is performed etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource on which the operation is performed etc.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string Resource { get; set; }

    }
    /// Display metadata associated with the operation.
    internal partial interface IOperationDisplayInternal

    {
        /// <summary>Description of the operation.</summary>
        string Description { get; set; }
        /// <summary>Type of operation: get, read, delete, etc.</summary>
        string Operation { get; set; }
        /// <summary>Service provider: Microsoft Storage.</summary>
        string Provider { get; set; }
        /// <summary>Resource on which the operation is performed etc.</summary>
        string Resource { get; set; }

    }
}