// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Extensions;

    /// <summary>The properties of a mongo cluster firewall rule.</summary>
    public partial class FirewallRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IFirewallRuleProperties,
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IFirewallRulePropertiesInternal
    {

        /// <summary>Backing field for <see cref="EndIPAddress" /> property.</summary>
        private string _endIPAddress;

        /// <summary>The end IP address of the mongo cluster firewall rule. Must be IPv4 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string EndIPAddress { get => this._endIPAddress; set => this._endIPAddress = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IFirewallRulePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state of the firewall rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="StartIPAddress" /> property.</summary>
        private string _startIPAddress;

        /// <summary>The start IP address of the mongo cluster firewall rule. Must be IPv4 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Origin(Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PropertyOrigin.Owned)]
        public string StartIPAddress { get => this._startIPAddress; set => this._startIPAddress = value; }

        /// <summary>Creates an new <see cref="FirewallRuleProperties" /> instance.</summary>
        public FirewallRuleProperties()
        {

        }
    }
    /// The properties of a mongo cluster firewall rule.
    public partial interface IFirewallRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.IJsonSerializable
    {
        /// <summary>The end IP address of the mongo cluster firewall rule. Must be IPv4 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The end IP address of the mongo cluster firewall rule. Must be IPv4 format.",
        SerializedName = @"endIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string EndIPAddress { get; set; }
        /// <summary>The provisioning state of the firewall rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The provisioning state of the firewall rule.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "InProgress", "Updating", "Dropping")]
        string ProvisioningState { get;  }
        /// <summary>The start IP address of the mongo cluster firewall rule. Must be IPv4 format.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"The start IP address of the mongo cluster firewall rule. Must be IPv4 format.",
        SerializedName = @"startIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string StartIPAddress { get; set; }

    }
    /// The properties of a mongo cluster firewall rule.
    internal partial interface IFirewallRulePropertiesInternal

    {
        /// <summary>The end IP address of the mongo cluster firewall rule. Must be IPv4 format.</summary>
        string EndIPAddress { get; set; }
        /// <summary>The provisioning state of the firewall rule.</summary>
        [global::Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("Succeeded", "Failed", "Canceled", "InProgress", "Updating", "Dropping")]
        string ProvisioningState { get; set; }
        /// <summary>The start IP address of the mongo cluster firewall rule. Must be IPv4 format.</summary>
        string StartIPAddress { get; set; }

    }
}