namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Specifications of the Log for Azure Monitoring</summary>
    public partial class LogSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ILogSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ILogSpecificationInternal
    {

        /// <summary>Backing field for <see cref="BlobDuration" /> property.</summary>
        private string _blobDuration;

        /// <summary>Blob duration of the log</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string BlobDuration { get => this._blobDuration; set => this._blobDuration = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        /// <summary>Localized friendly display name of the log</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Name of the log</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="LogSpecification" /> instance.</summary>
        public LogSpecification()
        {

        }
    }
    /// Specifications of the Log for Azure Monitoring
    public partial interface ILogSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>Blob duration of the log</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Blob duration of the log",
        SerializedName = @"blobDuration",
        PossibleTypes = new [] { typeof(string) })]
        string BlobDuration { get; set; }
        /// <summary>Localized friendly display name of the log</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Localized friendly display name of the log",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }
        /// <summary>Name of the log</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the log",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Specifications of the Log for Azure Monitoring
    public partial interface ILogSpecificationInternal

    {
        /// <summary>Blob duration of the log</summary>
        string BlobDuration { get; set; }
        /// <summary>Localized friendly display name of the log</summary>
        string DisplayName { get; set; }
        /// <summary>Name of the log</summary>
        string Name { get; set; }

    }
}