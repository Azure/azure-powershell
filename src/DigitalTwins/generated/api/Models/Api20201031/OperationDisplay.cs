namespace Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Extensions;

    /// <summary>The object that represents the operation.</summary>
    public partial class OperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperationDisplay,
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperationDisplayInternal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>Friendly description for the operation,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperationDisplayInternal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for Operation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperationDisplayInternal.Operation { get => this._operation; set { {_operation = value;} } }

        /// <summary>Internal Acessors for Provider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperationDisplayInternal.Provider { get => this._provider; set { {_provider = value;} } }

        /// <summary>Internal Acessors for Resource</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20201031.IOperationDisplayInternal.Resource { get => this._resource; set { {_resource = value;} } }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>Name of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>Service provider: Microsoft DigitalTwins</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string _resource;

        /// <summary>Resource Type: DigitalTwinsInstances</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Origin(Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.PropertyOrigin.Owned)]
        public string Resource { get => this._resource; }

        /// <summary>Creates an new <see cref="OperationDisplay" /> instance.</summary>
        public OperationDisplay()
        {

        }
    }
    /// The object that represents the operation.
    public partial interface IOperationDisplay :
        Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.IJsonSerializable
    {
        /// <summary>Friendly description for the operation,</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Friendly description for the operation,",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>Name of the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the operation",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get;  }
        /// <summary>Service provider: Microsoft DigitalTwins</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Service provider: Microsoft DigitalTwins",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get;  }
        /// <summary>Resource Type: DigitalTwinsInstances</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Type: DigitalTwinsInstances",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string Resource { get;  }

    }
    /// The object that represents the operation.
    internal partial interface IOperationDisplayInternal

    {
        /// <summary>Friendly description for the operation,</summary>
        string Description { get; set; }
        /// <summary>Name of the operation</summary>
        string Operation { get; set; }
        /// <summary>Service provider: Microsoft DigitalTwins</summary>
        string Provider { get; set; }
        /// <summary>Resource Type: DigitalTwinsInstances</summary>
        string Resource { get; set; }

    }
}