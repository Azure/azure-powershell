namespace Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Extensions;

    /// <summary>Describes the properties of a Compute Operation value.</summary>
    public partial class OperationValue :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValue,
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay _display;

        /// <summary>Display properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.OperationValueDisplay()); set => this._display = value; }

        /// <summary>The description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Description; }

        /// <summary>The display name of the compute operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Operation; }

        /// <summary>The resource provider for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Provider; }

        /// <summary>The display name of the resource the operation applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Resource; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.OperationValueDisplay()); set { {_display = value;} } }

        /// <summary>Internal Acessors for DisplayDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal.DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Description = value; }

        /// <summary>Internal Acessors for DisplayOperation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal.DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Operation = value; }

        /// <summary>Internal Acessors for DisplayProvider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal.DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Provider = value; }

        /// <summary>Internal Acessors for DisplayResource</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal.DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay1Internal)Display).Resource = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Origin</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueInternal.Origin { get => this._origin; set { {_origin = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the compute operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>The origin of the compute operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Origin(Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; }

        /// <summary>Creates an new <see cref="OperationValue" /> instance.</summary>
        public OperationValue()
        {

        }
    }
    /// Describes the properties of a Compute Operation value.
    public partial interface IOperationValue :
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.IJsonSerializable
    {
        /// <summary>The description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The description of the operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get;  }
        /// <summary>The display name of the compute operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The display name of the compute operation.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get;  }
        /// <summary>The resource provider for the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource provider for the operation.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get;  }
        /// <summary>The display name of the resource the operation applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The display name of the resource the operation applies to.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get;  }
        /// <summary>The name of the compute operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the compute operation.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The origin of the compute operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The origin of the compute operation.",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get;  }

    }
    /// Describes the properties of a Compute Operation value.
    internal partial interface IOperationValueInternal

    {
        /// <summary>Display properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20200802.IOperationValueDisplay Display { get; set; }
        /// <summary>The description of the operation.</summary>
        string DisplayDescription { get; set; }
        /// <summary>The display name of the compute operation.</summary>
        string DisplayOperation { get; set; }
        /// <summary>The resource provider for the operation.</summary>
        string DisplayProvider { get; set; }
        /// <summary>The display name of the resource the operation applies to.</summary>
        string DisplayResource { get; set; }
        /// <summary>The name of the compute operation.</summary>
        string Name { get; set; }
        /// <summary>The origin of the compute operation.</summary>
        string Origin { get; set; }

    }
}