namespace Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712
{
    using static Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Extensions;

    /// <summary>The operations supported by Bot Service Management.</summary>
    public partial class OperationEntity :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntity,
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntityInternal
    {

        /// <summary>Backing field for <see cref="Display" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfo _display;

        /// <summary>The operation supported by Bot Service Management.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfo Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.OperationDisplayInfo()); set => this._display = value; }

        /// <summary>The description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DisplayDescription { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfoInternal)Display).Description; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfoInternal)Display).Description = value ?? null; }

        /// <summary>The action that users can perform, based on their permission level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DisplayOperation { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfoInternal)Display).Operation; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfoInternal)Display).Operation = value ?? null; }

        /// <summary>Service provider: Microsoft Bot Service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DisplayProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfoInternal)Display).Provider; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfoInternal)Display).Provider = value ?? null; }

        /// <summary>Resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Inlined)]
        public string DisplayResource { get => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfoInternal)Display).Resource; set => ((Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfoInternal)Display).Resource = value ?? null; }

        /// <summary>Internal Acessors for Display</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfo Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationEntityInternal.Display { get => (this._display = this._display ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.OperationDisplayInfo()); set { {_display = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Operation name: {provider}/{resource}/{operation}.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Origin" /> property.</summary>
        private string _origin;

        /// <summary>The origin of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public string Origin { get => this._origin; set => this._origin = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IAny _property;

        /// <summary>Additional properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Origin(Microsoft.Azure.PowerShell.Cmdlets.BotService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IAny Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Any()); set => this._property = value; }

        /// <summary>Creates an new <see cref="OperationEntity" /> instance.</summary>
        public OperationEntity()
        {

        }
    }
    /// The operations supported by Bot Service Management.
    public partial interface IOperationEntity :
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.IJsonSerializable
    {
        /// <summary>The description of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The description of the operation.",
        SerializedName = @"description",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayDescription { get; set; }
        /// <summary>The action that users can perform, based on their permission level.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The action that users can perform, based on their permission level.",
        SerializedName = @"operation",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayOperation { get; set; }
        /// <summary>Service provider: Microsoft Bot Service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Service provider: Microsoft Bot Service.",
        SerializedName = @"provider",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayProvider { get; set; }
        /// <summary>Resource on which the operation is performed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource on which the operation is performed.",
        SerializedName = @"resource",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayResource { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Operation name: {provider}/{resource}/{operation}.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The origin of the operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The origin of the operation.",
        SerializedName = @"origin",
        PossibleTypes = new [] { typeof(string) })]
        string Origin { get; set; }
        /// <summary>Additional properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.BotService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Additional properties.",
        SerializedName = @"properties",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IAny Property { get; set; }

    }
    /// The operations supported by Bot Service Management.
    internal partial interface IOperationEntityInternal

    {
        /// <summary>The operation supported by Bot Service Management.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.Api20180712.IOperationDisplayInfo Display { get; set; }
        /// <summary>The description of the operation.</summary>
        string DisplayDescription { get; set; }
        /// <summary>The action that users can perform, based on their permission level.</summary>
        string DisplayOperation { get; set; }
        /// <summary>Service provider: Microsoft Bot Service.</summary>
        string DisplayProvider { get; set; }
        /// <summary>Resource on which the operation is performed.</summary>
        string DisplayResource { get; set; }
        /// <summary>Operation name: {provider}/{resource}/{operation}.</summary>
        string Name { get; set; }
        /// <summary>The origin of the operation.</summary>
        string Origin { get; set; }
        /// <summary>Additional properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.BotService.Models.IAny Property { get; set; }

    }
}