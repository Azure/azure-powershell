// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Extensions;

    /// <summary>Terms and conditions</summary>
    public partial class TermsAndConditions :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditions,
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Models.ITermsAndConditionsInternal
    {

        /// <summary>Backing field for <see cref="LegalTermsType" /> property.</summary>
        private string _legalTermsType;

        /// <summary>The type of legal terms</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string LegalTermsType { get => this._legalTermsType; set => this._legalTermsType = value; }

        /// <summary>Backing field for <see cref="LegalTermsUri" /> property.</summary>
        private string _legalTermsUri;

        /// <summary>The legal terms and conditions uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string LegalTermsUri { get => this._legalTermsUri; set => this._legalTermsUri = value; }

        /// <summary>Backing field for <see cref="PrivacyPolicyUri" /> property.</summary>
        private string _privacyPolicyUri;

        /// <summary>The privacy policy uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Origin(Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.PropertyOrigin.Owned)]
        public string PrivacyPolicyUri { get => this._privacyPolicyUri; set => this._privacyPolicyUri = value; }

        /// <summary>Creates an new <see cref="TermsAndConditions" /> instance.</summary>
        public TermsAndConditions()
        {

        }
    }
    /// Terms and conditions
    public partial interface ITermsAndConditions :
        Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.IJsonSerializable
    {
        /// <summary>The type of legal terms</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The type of legal terms",
        SerializedName = @"legalTermsType",
        PossibleTypes = new [] { typeof(string) })]
        string LegalTermsType { get; set; }
        /// <summary>The legal terms and conditions uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The legal terms and conditions uri",
        SerializedName = @"legalTermsUri",
        PossibleTypes = new [] { typeof(string) })]
        string LegalTermsUri { get; set; }
        /// <summary>The privacy policy uri</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeMarketplace.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The privacy policy uri",
        SerializedName = @"privacyPolicyUri",
        PossibleTypes = new [] { typeof(string) })]
        string PrivacyPolicyUri { get; set; }

    }
    /// Terms and conditions
    internal partial interface ITermsAndConditionsInternal

    {
        /// <summary>The type of legal terms</summary>
        string LegalTermsType { get; set; }
        /// <summary>The legal terms and conditions uri</summary>
        string LegalTermsUri { get; set; }
        /// <summary>The privacy policy uri</summary>
        string PrivacyPolicyUri { get; set; }

    }
}