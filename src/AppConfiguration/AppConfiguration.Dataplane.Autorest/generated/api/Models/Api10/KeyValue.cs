namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    public partial class KeyValue :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValue,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueInternal,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IHeaderSerializable
    {

        /// <summary>Backing field for <see cref="ContentType" /> property.</summary>
        private string _contentType;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string ContentType { get => this._contentType; set => this._contentType = value; }

        /// <summary>Backing field for <see cref="ETag" /> property.</summary>
        private string _eTag;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string ETag { get => this._eTag; set => this._eTag = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Backing field for <see cref="Key" /> property.</summary>
        private string _key;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Key { get => this._key; set => this._key = value; }

        /// <summary>Backing field for <see cref="Label" /> property.</summary>
        private string _label;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Label { get => this._label; set => this._label = value; }

        /// <summary>Backing field for <see cref="LastModified" /> property.</summary>
        private global::System.DateTime? _lastModified;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModified { get => this._lastModified; set => this._lastModified = value; }

        /// <summary>Backing field for <see cref="LastModified1" /> property.</summary>
        private string _lastModified1;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string LastModified1 { get => this._lastModified1; set => this._lastModified1 = value; }

        /// <summary>Backing field for <see cref="Locked" /> property.</summary>
        private bool? _locked;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public bool? Locked { get => this._locked; set => this._locked = value; }

        /// <summary>Backing field for <see cref="SyncToken" /> property.</summary>
        private string _syncToken;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string SyncToken { get => this._syncToken; set => this._syncToken = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueTags _tag;

        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.KeyValueTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="KeyValue" /> instance.</summary>
        public KeyValue()
        {

        }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("Sync-Token", out var __syncTokenHeader))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueInternal)this).SyncToken = System.Linq.Enumerable.FirstOrDefault(__syncTokenHeader) is string __headerSyncTokenHeader ? __headerSyncTokenHeader : (string)null;
            }
            if (headers.TryGetValues("ETag", out var __eTagHeader))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueInternal)this).ETag = System.Linq.Enumerable.FirstOrDefault(__eTagHeader) is string __headerETagHeader ? __headerETagHeader : (string)null;
            }
            if (headers.TryGetValues("Last-Modified", out var __lastModifiedHeader))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueInternal)this).LastModified1 = System.Linq.Enumerable.FirstOrDefault(__lastModifiedHeader) is string __headerLastModifiedHeader ? __headerLastModifiedHeader : (string)null;
            }
        }
    }
    public partial interface IKeyValue :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"content_type",
        PossibleTypes = new [] { typeof(string) })]
        string ContentType { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"ETag",
        PossibleTypes = new [] { typeof(string) })]
        string ETag { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"key",
        PossibleTypes = new [] { typeof(string) })]
        string Key { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string Label { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"last_modified",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModified { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"Last-Modified",
        PossibleTypes = new [] { typeof(string) })]
        string LastModified1 { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"locked",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Locked { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"Sync-Token",
        PossibleTypes = new [] { typeof(string) })]
        string SyncToken { get; set; }
        /// <summary>Dictionary of <string></summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Dictionary of <string>",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueTags Tag { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get; set; }

    }
    internal partial interface IKeyValueInternal

    {
        string ContentType { get; set; }

        string ETag { get; set; }

        string Etag { get; set; }

        string Key { get; set; }

        string Label { get; set; }

        global::System.DateTime? LastModified { get; set; }

        string LastModified1 { get; set; }

        bool? Locked { get; set; }

        string SyncToken { get; set; }
        /// <summary>Dictionary of <string></summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueTags Tag { get; set; }

        string Value { get; set; }

    }
}