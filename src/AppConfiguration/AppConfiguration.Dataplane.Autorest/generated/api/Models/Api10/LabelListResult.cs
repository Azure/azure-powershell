namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>The result of a list request.</summary>
    public partial class LabelListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.ILabelListResult,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.ILabelListResultInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IHeaderSerializable
    {

        /// <summary>Backing field for <see cref="Item" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.ILabel[] _item;

        /// <summary>The collection value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.ILabel[] Item { get => this._item; set => this._item = value; }

        /// <summary>Backing field for <see cref="NextLink" /> property.</summary>
        private string _nextLink;

        /// <summary>The URI that can be used to request the next set of paged results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string NextLink { get => this._nextLink; set => this._nextLink = value; }

        /// <summary>Backing field for <see cref="SyncToken" /> property.</summary>
        private string _syncToken;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string SyncToken { get => this._syncToken; set => this._syncToken = value; }

        /// <summary>Creates an new <see cref="LabelListResult" /> instance.</summary>
        public LabelListResult()
        {

        }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("Sync-Token", out var __syncTokenHeader))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.ILabelListResultInternal)this).SyncToken = System.Linq.Enumerable.FirstOrDefault(__syncTokenHeader) is string __headerSyncTokenHeader ? __headerSyncTokenHeader : (string)null;
            }
        }
    }
    /// The result of a list request.
    public partial interface ILabelListResult :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>The collection value.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The collection value.",
        SerializedName = @"items",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.ILabel) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.ILabel[] Item { get; set; }
        /// <summary>The URI that can be used to request the next set of paged results.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI that can be used to request the next set of paged results.",
        SerializedName = @"@nextLink",
        PossibleTypes = new [] { typeof(string) })]
        string NextLink { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"Sync-Token",
        PossibleTypes = new [] { typeof(string) })]
        string SyncToken { get; set; }

    }
    /// The result of a list request.
    internal partial interface ILabelListResultInternal

    {
        /// <summary>The collection value.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.ILabel[] Item { get; set; }
        /// <summary>The URI that can be used to request the next set of paged results.</summary>
        string NextLink { get; set; }

        string SyncToken { get; set; }

    }
}