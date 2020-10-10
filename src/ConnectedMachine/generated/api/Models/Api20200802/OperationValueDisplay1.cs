namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Describes the properties of a Hybrid Compute Operation Value Display.</summary>
    public partial class OperationValueDisplay1 :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal
    {

        /// <summary>Backing field for <see cref="Description" /> property.</summary>
        private string _description;

        /// <summary>The description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Description { get => this._description; }

        /// <summary>Internal Acessors for Description</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal.Description { get => this._description; set { {_description = value;} } }

        /// <summary>Internal Acessors for Operation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal.Operation { get => this._operation; set { {_operation = value;} } }

        /// <summary>Internal Acessors for Provider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal.Provider { get => this._provider; set { {_provider = value;} } }

        /// <summary>Internal Acessors for Resource</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal.Resource { get => this._resource; set { {_resource = value;} } }

        /// <summary>Backing field for <see cref="Operation" /> property.</summary>
        private string _operation;

        /// <summary>The display name of the compute operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Operation { get => this._operation; }

        /// <summary>Backing field for <see cref="Provider" /> property.</summary>
        private string _provider;

        /// <summary>The resource provider for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Provider { get => this._provider; }

        /// <summary>Backing field for <see cref="Resource" /> property.</summary>
        private string _resource;

        /// <summary>The display name of the resource the operation applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Resource { get => this._resource; }

        /// <summary>Creates an new <see cref="OperationValueDisplay1" /> instance.</summary>
        public OperationValueDisplay1()
        {

        }
    }
    /// Describes the properties of a Hybrid Compute Operation Value Display.
    public partial interface IOperationValueDisplay1 :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>The description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The description of the operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string Description { get;  }
        /// <summary>The display name of the compute operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The display name of the compute operation.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string Operation { get;  }
        /// <summary>The resource provider for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource provider for the operation.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string Provider { get;  }
        /// <summary>The display name of the resource the operation applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The display name of the resource the operation applies to.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string Resource { get;  }

    }
    /// Describes the properties of a Hybrid Compute Operation Value Display.
    internal partial interface IOperationValueDisplay1Internal

    {
        /// <summary>The description of the operation.</summary>
        string Description { get; set; }
        /// <summary>The display name of the compute operation.</summary>
        string Operation { get; set; }
        /// <summary>The resource provider for the operation.</summary>
        string Provider { get; set; }
        /// <summary>The display name of the resource the operation applies to.</summary>
        string Resource { get; set; }

    }
}