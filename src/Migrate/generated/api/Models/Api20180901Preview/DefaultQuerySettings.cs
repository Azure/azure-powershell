namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class DefaultQuerySettings :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDefaultQuerySettings,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IDefaultQuerySettingsInternal
    {

        /// <summary>Backing field for <see cref="EnableCount" /> property.</summary>
        private bool? _enableCount;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? EnableCount { get => this._enableCount; set => this._enableCount = value; }

        /// <summary>Backing field for <see cref="EnableExpand" /> property.</summary>
        private bool? _enableExpand;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? EnableExpand { get => this._enableExpand; set => this._enableExpand = value; }

        /// <summary>Backing field for <see cref="EnableFilter" /> property.</summary>
        private bool? _enableFilter;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? EnableFilter { get => this._enableFilter; set => this._enableFilter = value; }

        /// <summary>Backing field for <see cref="EnableOrderBy" /> property.</summary>
        private bool? _enableOrderBy;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? EnableOrderBy { get => this._enableOrderBy; set => this._enableOrderBy = value; }

        /// <summary>Backing field for <see cref="EnableSelect" /> property.</summary>
        private bool? _enableSelect;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? EnableSelect { get => this._enableSelect; set => this._enableSelect = value; }

        /// <summary>Backing field for <see cref="MaxTop" /> property.</summary>
        private int? _maxTop;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public int? MaxTop { get => this._maxTop; set => this._maxTop = value; }

        /// <summary>Creates an new <see cref="DefaultQuerySettings" /> instance.</summary>
        public DefaultQuerySettings()
        {

        }
    }
    public partial interface IDefaultQuerySettings :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableCount",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableCount { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableExpand",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableExpand { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableFilter",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableFilter { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableOrderBy",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableOrderBy { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"enableSelect",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableSelect { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"maxTop",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxTop { get; set; }

    }
    internal partial interface IDefaultQuerySettingsInternal

    {
        bool? EnableCount { get; set; }

        bool? EnableExpand { get; set; }

        bool? EnableFilter { get; set; }

        bool? EnableOrderBy { get; set; }

        bool? EnableSelect { get; set; }

        int? MaxTop { get; set; }

    }
}