namespace Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Extensions;

    /// <summary>A REST API operation</summary>
    public partial class Operation :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperation,
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplay _display;

        /// <summary>Contains the localized display information for this operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplay Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.OperationDisplay()); }

        /// <summary>Localized friendly description for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Description; }

        /// <summary>Localized friendly name for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Operation; }

        /// <summary>Localized friendly form of the resource provider name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Provider; }

        /// <summary>Localized friendly form of the resource type related to this operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Resource; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplay Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.OperationDisplay()); set { {_display = value;} } }

        /// <summary>Internal Acessors for DisplayDescription</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationInternal.DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Description = value; }

        /// <summary>Internal Acessors for DisplayOperation</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationInternal.DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Operation = value; }

        /// <summary>Internal Acessors for DisplayProvider</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationInternal.DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Provider = value; }

        /// <summary>Internal Acessors for DisplayResource</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationInternal.DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplayInternal)Display).Resource = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the operation being performed on this object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMWare.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Creates an new <see cref="Operation" /> instance.</summary>
        public Operation()
        {

        }
    }
    /// A REST API operation
    public partial interface IOperation :
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.IJsonSerializable
    {
        /// <summary>Localized friendly description for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Localized friendly description for the operation",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get;  }
        /// <summary>Localized friendly name for the operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Localized friendly name for the operation",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get;  }
        /// <summary>Localized friendly form of the resource provider name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Localized friendly form of the resource provider name",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get;  }
        /// <summary>Localized friendly form of the resource type related to this operation</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Localized friendly form of the resource type related to this operation",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get;  }
        /// <summary>Name of the operation being performed on this object</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMWare.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the operation being performed on this object",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }

    }
    /// A REST API operation
    internal partial interface IOperationInternal

    {
        /// <summary>Contains the localized display information for this operation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.VMWare.Models.Api20200320.IOperationDisplay Display { get; set; }
        /// <summary>Localized friendly description for the operation</summary>
        string DisplayDescription { get; set; }
        /// <summary>Localized friendly name for the operation</summary>
        string DisplayOperation { get; set; }
        /// <summary>Localized friendly form of the resource provider name</summary>
        string DisplayProvider { get; set; }
        /// <summary>Localized friendly form of the resource type related to this operation</summary>
        string DisplayResource { get; set; }
        /// <summary>Name of the operation being performed on this object</summary>
        string Name { get; set; }

    }
}