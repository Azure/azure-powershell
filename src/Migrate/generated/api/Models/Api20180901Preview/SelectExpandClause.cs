namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class SelectExpandClause :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISelectExpandClause,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISelectExpandClauseInternal
    {

        /// <summary>Backing field for <see cref="AllSelected" /> property.</summary>
        private bool? _allSelected;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public bool? AllSelected { get => this._allSelected; }

        /// <summary>Internal Acessors for AllSelected</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISelectExpandClauseInternal.AllSelected { get => this._allSelected; set { {_allSelected = value;} } }

        /// <summary>Internal Acessors for SelectedItem</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny[] Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.ISelectExpandClauseInternal.SelectedItem { get => this._selectedItem; set { {_selectedItem = value;} } }

        /// <summary>Backing field for <see cref="SelectedItem" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny[] _selectedItem;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny[] SelectedItem { get => this._selectedItem; }

        /// <summary>Creates an new <see cref="SelectExpandClause" /> instance.</summary>
        public SelectExpandClause()
        {

        }
    }
    public partial interface ISelectExpandClause :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"allSelected",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllSelected { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"selectedItems",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny) })]
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny[] SelectedItem { get;  }

    }
    internal partial interface ISelectExpandClauseInternal

    {
        bool? AllSelected { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.IAny[] SelectedItem { get; set; }

    }
}