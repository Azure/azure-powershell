namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Settings for Resource Forest</summary>
    public partial class ResourceForestSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IResourceForestSettingsInternal
    {

        /// <summary>Backing field for <see cref="ResourceForest" /> property.</summary>
        private string _resourceForest;

        /// <summary>Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string ResourceForest { get => this._resourceForest; set => this._resourceForest = value; }

        /// <summary>Backing field for <see cref="Setting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] _setting;

        /// <summary>List of settings for Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] Setting { get => this._setting; set => this._setting = value; }

        /// <summary>Creates an new <see cref="ResourceForestSettings" /> instance.</summary>
        public ResourceForestSettings()
        {

        }
    }
    /// Settings for Resource Forest
    public partial interface IResourceForestSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Forest",
        SerializedName = @"resourceForest",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceForest { get; set; }
        /// <summary>List of settings for Resource Forest</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of settings for Resource Forest",
        SerializedName = @"settings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] Setting { get; set; }

    }
    /// Settings for Resource Forest
    internal partial interface IResourceForestSettingsInternal

    {
        /// <summary>Resource Forest</summary>
        string ResourceForest { get; set; }
        /// <summary>List of settings for Resource Forest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[] Setting { get; set; }

    }
}