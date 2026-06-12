// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
namespace Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Extensions;

    /// <summary>Properties of a firewall rule.</summary>
    public partial class FirewallRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFirewallRuleProperties,
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.IFirewallRulePropertiesInternal
    {

        /// <summary>Backing field for <see cref="EndIPAddress" /> property.</summary>
        private string _endIPAddress;

        /// <summary>
        /// IP address defining the end of the range of addresses of a firewall rule. Must be expressed in IPv4 format.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string EndIPAddress { get => this._endIPAddress; set => this._endIPAddress = value; }

        /// <summary>Backing field for <see cref="StartIPAddress" /> property.</summary>
        private string _startIPAddress;

        /// <summary>
        /// IP address defining the start of the range of addresses of a firewall rule. Must be expressed in IPv4 format.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Origin(Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.PropertyOrigin.Owned)]
        public string StartIPAddress { get => this._startIPAddress; set => this._startIPAddress = value; }

        /// <summary>Creates an new <see cref="FirewallRuleProperties" /> instance.</summary>
        public FirewallRuleProperties()
        {

        }
    }
    /// Properties of a firewall rule.
    public partial interface IFirewallRuleProperties :
        Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.IJsonSerializable
    {
        /// <summary>
        /// IP address defining the end of the range of addresses of a firewall rule. Must be expressed in IPv4 format.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"IP address defining the end of the range of addresses of a firewall rule. Must be expressed in IPv4 format.",
        SerializedName = @"endIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string EndIPAddress { get; set; }
        /// <summary>
        /// IP address defining the start of the range of addresses of a firewall rule. Must be expressed in IPv4 format.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Read = true,
        Create = true,
        Update = true,
        Description = @"IP address defining the start of the range of addresses of a firewall rule. Must be expressed in IPv4 format.",
        SerializedName = @"startIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string StartIPAddress { get; set; }

    }
    /// Properties of a firewall rule.
    internal partial interface IFirewallRulePropertiesInternal

    {
        /// <summary>
        /// IP address defining the end of the range of addresses of a firewall rule. Must be expressed in IPv4 format.
        /// </summary>
        string EndIPAddress { get; set; }
        /// <summary>
        /// IP address defining the start of the range of addresses of a firewall rule. Must be expressed in IPv4 format.
        /// </summary>
        string StartIPAddress { get; set; }

    }
}