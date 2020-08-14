namespace Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Extensions;

    /// <summary>Describes the properties of a run output</summary>
    public partial class RunOutputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IRunOutputProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IRunOutputPropertiesInternal
    {

        /// <summary>Backing field for <see cref="ArtifactId" /> property.</summary>
        private string _artifactId;

        /// <summary>The resource id of the artifact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string ArtifactId { get => this._artifactId; set => this._artifactId = value; }

        /// <summary>Backing field for <see cref="ArtifactUri" /> property.</summary>
        private string _artifactUri;

        /// <summary>The location URI of the artifact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public string ArtifactUri { get => this._artifactUri; set => this._artifactUri = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IRunOutputPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Origin(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Creates an new <see cref="RunOutputProperties" /> instance.</summary>
        public RunOutputProperties()
        {

        }
    }
    /// Describes the properties of a run output
    public partial interface IRunOutputProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.IJsonSerializable
    {
        /// <summary>The resource id of the artifact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource id of the artifact.",
        SerializedName = @"artifactId",
        PossibleTypes = new [] { typeof(string) })]
        string ArtifactId { get; set; }
        /// <summary>The location URI of the artifact.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The location URI of the artifact.",
        SerializedName = @"artifactUri",
        PossibleTypes = new [] { typeof(string) })]
        string ArtifactUri { get; set; }
        /// <summary>Provisioning state of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the resource",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? ProvisioningState { get;  }

    }
    /// Describes the properties of a run output
    public partial interface IRunOutputPropertiesInternal

    {
        /// <summary>The resource id of the artifact.</summary>
        string ArtifactId { get; set; }
        /// <summary>The location URI of the artifact.</summary>
        string ArtifactUri { get; set; }
        /// <summary>Provisioning state of the resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningState? ProvisioningState { get; set; }

    }
}