namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    public partial class ODataRawQueryOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataRawQueryOptions,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataRawQueryOptionsInternal
    {

        /// <summary>Backing field for <see cref="Filter" /> property.</summary>
        private string _filter;

        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        public string Filter { get => this._filter; }

        /// <summary>Internal Acessors for Filter</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180901Preview.IODataRawQueryOptionsInternal.Filter { get => this._filter; set { {_filter = value;} } }

        /// <summary>Creates an new <see cref="ODataRawQueryOptions" /> instance.</summary>
        public ODataRawQueryOptions()
        {

        }
    }
    public partial interface IODataRawQueryOptions :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"filter",
        PossibleTypes = new [] { typeof(string) })]
        string Filter { get;  }

    }
    internal partial interface IODataRawQueryOptionsInternal

    {
        string Filter { get; set; }

    }
}