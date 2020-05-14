namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Log Definition of a single resource metric.</summary>
    public partial class LogSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecification,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ILogSpecificationInternal
    {

        /// <summary>Backing field for <see cref="BlobDuration" /> property.</summary>
        private string _blobDuration;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string BlobDuration { get => this._blobDuration; set => this._blobDuration = value; }

        /// <summary>Backing field for <see cref="DisplayName" /> property.</summary>
        private string _displayName;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DisplayName { get => this._displayName; set => this._displayName = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Creates an new <see cref="LogSpecification" /> instance.</summary>
        public LogSpecification()
        {

        }
    }
    /// Log Definition of a single resource metric.
    public partial interface ILogSpecification :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"blobDuration",
        PossibleTypes = new [] { typeof(string) })]
        string BlobDuration { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"displayName",
        PossibleTypes = new [] { typeof(string) })]
        string DisplayName { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }

    }
    /// Log Definition of a single resource metric.
    internal partial interface ILogSpecificationInternal

    {
        string BlobDuration { get; set; }

        string DisplayName { get; set; }

        string Name { get; set; }

    }
}