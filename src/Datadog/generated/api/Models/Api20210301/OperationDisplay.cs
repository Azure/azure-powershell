namespace Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Extensions;

    /// <summary>The object that represents the operation.</summary>
    public partial class OperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplay,
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20210301.IOperationDisplayInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Description of the operation, e.g., 'Write monitors'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Description { get => this._description; set => this._description = value; }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; set => this._operation = value; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>Service provider, i.e., Microsoft.Datadog.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; set => this._provider = value; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string _resource;

        /// <summary>Type on which the operation is performed, e.g., 'monitors'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Origin(Microsoft.Azure.PowerShell.Cmdlets.Datadog.PropertyOrigin.Owned)]
        public string Resource { get => this._resource; set => this._resource = value; }

        /// <summary>Creates an new <see cref="OperationDisplay" /> instance.</summary>
        public OperationDisplay()
        {

        }
    }
    /// The object that represents the operation.
    public partial interface IOperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.IJsonSerializable
    {
        /// <summary>Description of the operation, e.g., 'Write monitors'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Description of the operation, e.g., 'Write monitors'.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get; set; }
        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation type, e.g., read, write, delete, etc.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get; set; }
        /// <summary>Service provider, i.e., Microsoft.Datadog.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service provider, i.e., Microsoft.Datadog.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get; set; }
        /// <summary>Type on which the operation is performed, e.g., 'monitors'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Datadog.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type on which the operation is performed, e.g., 'monitors'.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string Resource { get; set; }

    }
    /// The object that represents the operation.
    internal partial interface IOperationDisplayInternal

    {
        /// <summary>Description of the operation, e.g., 'Write monitors'.</summary>
        string Description { get; set; }
        /// <summary>Operation type, e.g., read, write, delete, etc.</summary>
        string Operation { get; set; }
        /// <summary>Service provider, i.e., Microsoft.Datadog.</summary>
        string Provider { get; set; }
        /// <summary>Type on which the operation is performed, e.g., 'monitors'.</summary>
        string Resource { get; set; }

    }
}