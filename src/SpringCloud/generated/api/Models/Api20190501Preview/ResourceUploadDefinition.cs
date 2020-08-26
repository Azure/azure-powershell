namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Resource upload definition payload</summary>
    public partial class ResourceUploadDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceUploadDefinition,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IResourceUploadDefinitionInternal
    {

        /// <summary>Backing field for <see cref="RelativePath" /> property.</summary>
        private string _relativePath;

        /// <summary>Source relative path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string RelativePath { get => this._relativePath; set => this._relativePath = value; }

        /// <summary>Backing field for <see cref="UploadUrl" /> property.</summary>
        private string _uploadUrl;

        /// <summary>Upload URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string UploadUrl { get => this._uploadUrl; set => this._uploadUrl = value; }

        /// <summary>Creates an new <see cref="ResourceUploadDefinition" /> instance.</summary>
        public ResourceUploadDefinition()
        {

        }
    }
    /// Resource upload definition payload
    public partial interface IResourceUploadDefinition :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Source relative path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Source relative path",
        SerializedName = @"relativePath",
        PossibleTypes = new [] { typeof(string) })]
        string RelativePath { get; set; }
        /// <summary>Upload URL</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Upload URL",
        SerializedName = @"uploadUrl",
        PossibleTypes = new [] { typeof(string) })]
        string UploadUrl { get; set; }

    }
    /// Resource upload definition payload
    public partial interface IResourceUploadDefinitionInternal

    {
        /// <summary>Source relative path</summary>
        string RelativePath { get; set; }
        /// <summary>Upload URL</summary>
        string UploadUrl { get; set; }

    }
}