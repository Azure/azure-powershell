namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Migration Properties</summary>
    public partial class MigrationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal
    {

        /// <summary>Internal Acessors for MigrationProgress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal.MigrationProgress { get => (this._migrationProgress = this._migrationProgress ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProgress()); set { {_migrationProgress = value;} } }

        /// <summary>Internal Acessors for OldSubnetId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal.OldSubnetId { get => this._oldSubnetId; set { {_oldSubnetId = value;} } }

        /// <summary>Internal Acessors for OldVnetSiteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationPropertiesInternal.OldVnetSiteId { get => this._oldVnetSiteId; set { {_oldVnetSiteId = value;} } }

        /// <summary>Backing field for <see cref="MigrationProgress" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress _migrationProgress;

        /// <summary>Migration Progress</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress MigrationProgress { get => (this._migrationProgress = this._migrationProgress ?? new Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.MigrationProgress()); }

        /// <summary>Completion Percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public double? MigrationProgressCompletionPercentage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgressInternal)MigrationProgress).CompletionPercentage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgressInternal)MigrationProgress).CompletionPercentage = value ?? default(double); }

        /// <summary>Progress Message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Inlined)]
        public string MigrationProgressMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgressInternal)MigrationProgress).ProgressMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgressInternal)MigrationProgress).ProgressMessage = value ?? null; }

        /// <summary>Backing field for <see cref="OldSubnetId" /> property.</summary>
        private string _oldSubnetId;

        /// <summary>Old Subnet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string OldSubnetId { get => this._oldSubnetId; }

        /// <summary>Backing field for <see cref="OldVnetSiteId" /> property.</summary>
        private string _oldVnetSiteId;

        /// <summary>Old Vnet Site Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string OldVnetSiteId { get => this._oldVnetSiteId; }

        /// <summary>Creates an new <see cref="MigrationProperties" /> instance.</summary>
        public MigrationProperties()
        {

        }
    }
    /// Migration Properties
    public partial interface IMigrationProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>Completion Percentage</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Completion Percentage",
        SerializedName = @"completionPercentage",
        PossibleTypes = new [] { typeof(double) })]
        double? MigrationProgressCompletionPercentage { get; set; }
        /// <summary>Progress Message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Progress Message",
        SerializedName = @"progressMessage",
        PossibleTypes = new [] { typeof(string) })]
        string MigrationProgressMessage { get; set; }
        /// <summary>Old Subnet Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Old Subnet Id",
        SerializedName = @"oldSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string OldSubnetId { get;  }
        /// <summary>Old Vnet Site Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Old Vnet Site Id",
        SerializedName = @"oldVnetSiteId",
        PossibleTypes = new [] { typeof(string) })]
        string OldVnetSiteId { get;  }

    }
    /// Migration Properties
    internal partial interface IMigrationPropertiesInternal

    {
        /// <summary>Migration Progress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IMigrationProgress MigrationProgress { get; set; }
        /// <summary>Completion Percentage</summary>
        double? MigrationProgressCompletionPercentage { get; set; }
        /// <summary>Progress Message</summary>
        string MigrationProgressMessage { get; set; }
        /// <summary>Old Subnet Id</summary>
        string OldSubnetId { get; set; }
        /// <summary>Old Vnet Site Id</summary>
        string OldVnetSiteId { get; set; }

    }
}