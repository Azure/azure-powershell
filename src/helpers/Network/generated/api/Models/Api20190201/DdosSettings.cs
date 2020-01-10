namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Contains the DDoS protection settings of the public IP.</summary>
    public partial class DdosSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosSettings,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosSettingsInternal
    {

        /// <summary>Backing field for <see cref="DdosCustomPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _ddosCustomPolicy;

        /// <summary>The DDoS custom policy associated with the public IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource DdosCustomPolicy { get => (this._ddosCustomPolicy = this._ddosCustomPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._ddosCustomPolicy = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DdosCustomPolicyId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)DdosCustomPolicy).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)DdosCustomPolicy).Id = value; }

        /// <summary>Internal Acessors for DdosCustomPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDdosSettingsInternal.DdosCustomPolicy { get => (this._ddosCustomPolicy = this._ddosCustomPolicy ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_ddosCustomPolicy = value;} } }

        /// <summary>Backing field for <see cref="ProtectionCoverage" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage? _protectionCoverage;

        /// <summary>
        /// The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage? ProtectionCoverage { get => this._protectionCoverage; set => this._protectionCoverage = value; }

        /// <summary>Creates an new <see cref="DdosSettings" /> instance.</summary>
        public DdosSettings()
        {

        }
    }
    /// Contains the DDoS protection settings of the public IP.
    public partial interface IDdosSettings :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DdosCustomPolicyId { get; set; }
        /// <summary>
        /// The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.",
        SerializedName = @"protectionCoverage",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage? ProtectionCoverage { get; set; }

    }
    /// Contains the DDoS protection settings of the public IP.
    internal partial interface IDdosSettingsInternal

    {
        /// <summary>The DDoS custom policy associated with the public IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource DdosCustomPolicy { get; set; }
        /// <summary>Resource ID.</summary>
        string DdosCustomPolicyId { get; set; }
        /// <summary>
        /// The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.DdosSettingsProtectionCoverage? ProtectionCoverage { get; set; }

    }
}