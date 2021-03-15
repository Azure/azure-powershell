namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Forest Trust Setting</summary>
    public partial class ForestTrust :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrustInternal
    {

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Friendly Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; set => this._friendlyName = value; }

        /// <summary>Backing field for <see cref="RemoteDnsIP" /> property.</summary>
        private string _remoteDnsIP;

        /// <summary>Remote Dns ips</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string RemoteDnsIP { get => this._remoteDnsIP; set => this._remoteDnsIP = value; }

        /// <summary>Backing field for <see cref="TrustDirection" /> property.</summary>
        private string _trustDirection;

        /// <summary>Trust Direction</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string TrustDirection { get => this._trustDirection; set => this._trustDirection = value; }

        /// <summary>Backing field for <see cref="TrustPassword" /> property.</summary>
        private string _trustPassword;

        /// <summary>Trust Password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string TrustPassword { get => this._trustPassword; set => this._trustPassword = value; }

        /// <summary>Backing field for <see cref="TrustedDomainFqdn" /> property.</summary>
        private string _trustedDomainFqdn;

        /// <summary>Trusted Domain FQDN</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string TrustedDomainFqdn { get => this._trustedDomainFqdn; set => this._trustedDomainFqdn = value; }

        /// <summary>Creates an new <see cref="ForestTrust" /> instance.</summary>
        public ForestTrust()
        {

        }
    }
    /// Forest Trust Setting
    public partial interface IForestTrust :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>Friendly Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Friendly Name",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>Remote Dns ips</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Remote Dns ips",
        SerializedName = @"remoteDnsIps",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteDnsIP { get; set; }
        /// <summary>Trust Direction</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Trust Direction",
        SerializedName = @"trustDirection",
        PossibleTypes = new [] { typeof(string) })]
        string TrustDirection { get; set; }
        /// <summary>Trust Password</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Trust Password",
        SerializedName = @"trustPassword",
        PossibleTypes = new [] { typeof(string) })]
        string TrustPassword { get; set; }
        /// <summary>Trusted Domain FQDN</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Trusted Domain FQDN",
        SerializedName = @"trustedDomainFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string TrustedDomainFqdn { get; set; }

    }
    /// Forest Trust Setting
    internal partial interface IForestTrustInternal

    {
        /// <summary>Friendly Name</summary>
        string FriendlyName { get; set; }
        /// <summary>Remote Dns ips</summary>
        string RemoteDnsIP { get; set; }
        /// <summary>Trust Direction</summary>
        string TrustDirection { get; set; }
        /// <summary>Trust Password</summary>
        string TrustPassword { get; set; }
        /// <summary>Trusted Domain FQDN</summary>
        string TrustedDomainFqdn { get; set; }

    }
}