namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>
    /// Dimension of map account, for example API Category, Api Name, Result Type, and Response Code.
    /// </summary>
    public partial class Dimension :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IDimension,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IDimensionInternal
    {

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Display name of dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="InternalMetricName" /> property.</summary>
        private string _internalMetricName;

        /// <summary>Internal metric name of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string InternalMetricName { get => this._internalMetricName; set => this._internalMetricName = value; }

        /// <summary>Backing field for <see cref="InternalName" /> property.</summary>
        private string _internalName;

        /// <summary>Internal name of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string InternalName { get => this._internalName; set => this._internalName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Display name of dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="SourceMdmNamespace" /> property.</summary>
        private string _sourceMdmNamespace;

        /// <summary>Source Mdm Namespace of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public string SourceMdmNamespace { get => this._sourceMdmNamespace; set => this._sourceMdmNamespace = value; }

        /// <summary>Backing field for <see cref="ToBeExportedToShoebox" /> property.</summary>
        private bool? _toBeExportedToShoebox;

        /// <summary>Flag to indicate exporting to Azure Monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public bool? ToBeExportedToShoebox { get => this._toBeExportedToShoebox; set => this._toBeExportedToShoebox = value; }

        /// <summary>Creates an new <see cref="Dimension" /> instance.</summary>
        public Dimension()
        {

        }
    }
    /// Dimension of map account, for example API Category, Api Name, Result Type, and Response Code.
    public partial interface IDimension :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable
    {
        /// <summary>Display name of dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Display name of dimension.",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Internal metric name of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Internal metric name of the dimension.",
        SerializedName = @"internalMetricName",
        PossibleTypes = new [] { typeof(string) })]
        string InternalMetricName { get; set; }
        /// <summary>Internal name of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Internal name of the dimension.",
        SerializedName = @"internalName",
        PossibleTypes = new [] { typeof(string) })]
        string InternalName { get; set; }
        /// <summary>Display name of dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Display name of dimension.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Source Mdm Namespace of the dimension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source Mdm Namespace of the dimension.",
        SerializedName = @"sourceMdmNamespace",
        PossibleTypes = new [] { typeof(string) })]
        string SourceMdmNamespace { get; set; }
        /// <summary>Flag to indicate exporting to Azure Monitor.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag to indicate exporting to Azure Monitor.",
        SerializedName = @"toBeExportedToShoebox",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ToBeExportedToShoebox { get; set; }

    }
    /// Dimension of map account, for example API Category, Api Name, Result Type, and Response Code.
    internal partial interface IDimensionInternal

    {
        /// <summary>Display name of dimension.</summary>
        string DisplayName { get; set; }
        /// <summary>Internal metric name of the dimension.</summary>
        string InternalMetricName { get; set; }
        /// <summary>Internal name of the dimension.</summary>
        string InternalName { get; set; }
        /// <summary>Display name of dimension.</summary>
        string Name { get; set; }
        /// <summary>Source Mdm Namespace of the dimension.</summary>
        string SourceMdmNamespace { get; set; }
        /// <summary>Flag to indicate exporting to Azure Monitor.</summary>
        bool? ToBeExportedToShoebox { get; set; }

    }
}