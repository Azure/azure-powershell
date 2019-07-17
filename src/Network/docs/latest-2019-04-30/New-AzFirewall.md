---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azfirewall
schema: 2.0.0
---

# New-AzFirewall

## SYNOPSIS
Creates or updates the specified Azure Firewall.

## SYNTAX

### Create (Default)
```
New-AzFirewall -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IAzureFirewall>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzFirewall -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-ApplicationRuleCollection <IAzureFirewallApplicationRuleCollection[]>]
 [-IPConfiguration <IAzureFirewallIPConfiguration[]>] [-Id <String>] [-Location <String>]
 [-NatRuleCollection <IAzureFirewallNatRuleCollection[]>]
 [-NetworkRuleCollection <IAzureFirewallNetworkRuleCollection[]>] [-Tag <Hashtable>]
 [-ThreatIntelMode <AzureFirewallThreatIntelMode>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzFirewall -InputObject <INetworkIdentity>
 [-ApplicationRuleCollection <IAzureFirewallApplicationRuleCollection[]>]
 [-IPConfiguration <IAzureFirewallIPConfiguration[]>] [-Id <String>] [-Location <String>]
 [-NatRuleCollection <IAzureFirewallNatRuleCollection[]>]
 [-NetworkRuleCollection <IAzureFirewallNetworkRuleCollection[]>] [-Tag <Hashtable>]
 [-ThreatIntelMode <AzureFirewallThreatIntelMode>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzFirewall -InputObject <INetworkIdentity> [-Parameter <IAzureFirewall>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the specified Azure Firewall.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -ApplicationRuleCollection
Collection of application rule collections used by Azure Firewall.
To construct, see NOTES section for APPLICATIONRULECOLLECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallApplicationRuleCollection[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IPConfiguration
IP configuration of the Azure Firewall resource.
To construct, see NOTES section for IPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallIPConfiguration[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the Azure Firewall.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: AzureFirewallName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NatRuleCollection
Collection of NAT rule collections used by Azure Firewall.
To construct, see NOTES section for NATRULECOLLECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNatRuleCollection[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkRuleCollection
Collection of network rule collections used by Azure Firewall.
To construct, see NOTES section for NETWORKRULECOLLECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewallNetworkRuleCollection[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Azure Firewall resource
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewall
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases: VirtualNetworkName, PublicIpName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ThreatIntelMode
The operation mode for Threat Intelligence.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.AzureFirewallThreatIntelMode
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewall

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAzureFirewall

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### APPLICATIONRULECOLLECTION <IAzureFirewallApplicationRuleCollection[]>: Collection of application rule collections used by Azure Firewall.
  - `[Id <String>]`: Resource ID.
  - `[ActionType <AzureFirewallRcActionType?>]`: The type of action.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Priority <Int32?>]`: Priority of the application rule collection resource.
  - `[Rule <IAzureFirewallApplicationRule[]>]`: Collection of rules used by a application rule collection.
    - `[Description <String>]`: Description of the rule.
    - `[FqdnTag <String[]>]`: List of FQDN Tags for this rule.
    - `[Name <String>]`: Name of the application rule.
    - `[Protocol <IAzureFirewallApplicationRuleProtocol[]>]`: Array of ApplicationRuleProtocols.
      - `[Port <Int32?>]`: Port number for the protocol, cannot be greater than 64000. This field is optional.
      - `[ProtocolType <AzureFirewallApplicationRuleProtocolType?>]`: Protocol type
    - `[SourceAddress <String[]>]`: List of source IP addresses for this rule.
    - `[TargetFqdn <String[]>]`: List of FQDNs for this rule.

#### IPCONFIGURATION <IAzureFirewallIPConfiguration[]>: IP configuration of the Azure Firewall resource.
  - `[Id <String>]`: Resource ID.
  - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[PublicIPAddressId <String>]`: Resource ID.
  - `[SubnetId <String>]`: Resource ID.

#### NATRULECOLLECTION <IAzureFirewallNatRuleCollection[]>: Collection of NAT rule collections used by Azure Firewall.
  - `[Id <String>]`: Resource ID.
  - `[ActionType <AzureFirewallNatRcActionType?>]`: The type of action.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Priority <Int32?>]`: Priority of the NAT rule collection resource.
  - `[Rule <IAzureFirewallNatRule[]>]`: Collection of rules used by a NAT rule collection.
    - `[Description <String>]`: Description of the rule.
    - `[DestinationAddress <String[]>]`: List of destination IP addresses for this rule. Supports IP ranges, prefixes, and service tags.
    - `[DestinationPort <String[]>]`: List of destination ports.
    - `[Name <String>]`: Name of the NAT rule.
    - `[Protocol <AzureFirewallNetworkRuleProtocol[]>]`: Array of AzureFirewallNetworkRuleProtocols applicable to this NAT rule.
    - `[SourceAddress <String[]>]`: List of source IP addresses for this rule.
    - `[TranslatedAddress <String>]`: The translated address for this NAT rule.
    - `[TranslatedPort <String>]`: The translated port for this NAT rule.

#### NETWORKRULECOLLECTION <IAzureFirewallNetworkRuleCollection[]>: Collection of network rule collections used by Azure Firewall.
  - `[Id <String>]`: Resource ID.
  - `[ActionType <AzureFirewallRcActionType?>]`: The type of action.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Priority <Int32?>]`: Priority of the network rule collection resource.
  - `[Rule <IAzureFirewallNetworkRule[]>]`: Collection of rules used by a network rule collection.
    - `[Description <String>]`: Description of the rule.
    - `[DestinationAddress <String[]>]`: List of destination IP addresses.
    - `[DestinationPort <String[]>]`: List of destination ports.
    - `[Name <String>]`: Name of the network rule.
    - `[Protocol <AzureFirewallNetworkRuleProtocol[]>]`: Array of AzureFirewallNetworkRuleProtocols.
    - `[SourceAddress <String[]>]`: List of source IP addresses for this rule.

#### PARAMETER <IAzureFirewall>: Azure Firewall resource
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[ApplicationRuleCollection <IAzureFirewallApplicationRuleCollection[]>]`: Collection of application rule collections used by Azure Firewall.
    - `[Id <String>]`: Resource ID.
    - `[ActionType <AzureFirewallRcActionType?>]`: The type of action.
    - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Priority <Int32?>]`: Priority of the application rule collection resource.
    - `[Rule <IAzureFirewallApplicationRule[]>]`: Collection of rules used by a application rule collection.
      - `[Description <String>]`: Description of the rule.
      - `[FqdnTag <String[]>]`: List of FQDN Tags for this rule.
      - `[Name <String>]`: Name of the application rule.
      - `[Protocol <IAzureFirewallApplicationRuleProtocol[]>]`: Array of ApplicationRuleProtocols.
        - `[Port <Int32?>]`: Port number for the protocol, cannot be greater than 64000. This field is optional.
        - `[ProtocolType <AzureFirewallApplicationRuleProtocolType?>]`: Protocol type
      - `[SourceAddress <String[]>]`: List of source IP addresses for this rule.
      - `[TargetFqdn <String[]>]`: List of FQDNs for this rule.
  - `[IPConfiguration <IAzureFirewallIPConfiguration[]>]`: IP configuration of the Azure Firewall resource.
    - `[Id <String>]`: Resource ID.
    - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PublicIPAddressId <String>]`: Resource ID.
    - `[SubnetId <String>]`: Resource ID.
  - `[NatRuleCollection <IAzureFirewallNatRuleCollection[]>]`: Collection of NAT rule collections used by Azure Firewall.
    - `[Id <String>]`: Resource ID.
    - `[ActionType <AzureFirewallNatRcActionType?>]`: The type of action.
    - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Priority <Int32?>]`: Priority of the NAT rule collection resource.
    - `[Rule <IAzureFirewallNatRule[]>]`: Collection of rules used by a NAT rule collection.
      - `[Description <String>]`: Description of the rule.
      - `[DestinationAddress <String[]>]`: List of destination IP addresses for this rule. Supports IP ranges, prefixes, and service tags.
      - `[DestinationPort <String[]>]`: List of destination ports.
      - `[Name <String>]`: Name of the NAT rule.
      - `[Protocol <AzureFirewallNetworkRuleProtocol[]>]`: Array of AzureFirewallNetworkRuleProtocols applicable to this NAT rule.
      - `[SourceAddress <String[]>]`: List of source IP addresses for this rule.
      - `[TranslatedAddress <String>]`: The translated address for this NAT rule.
      - `[TranslatedPort <String>]`: The translated port for this NAT rule.
  - `[NetworkRuleCollection <IAzureFirewallNetworkRuleCollection[]>]`: Collection of network rule collections used by Azure Firewall.
    - `[Id <String>]`: Resource ID.
    - `[ActionType <AzureFirewallRcActionType?>]`: The type of action.
    - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Priority <Int32?>]`: Priority of the network rule collection resource.
    - `[Rule <IAzureFirewallNetworkRule[]>]`: Collection of rules used by a network rule collection.
      - `[Description <String>]`: Description of the rule.
      - `[DestinationAddress <String[]>]`: List of destination IP addresses.
      - `[DestinationPort <String[]>]`: List of destination ports.
      - `[Name <String>]`: Name of the network rule.
      - `[Protocol <AzureFirewallNetworkRuleProtocol[]>]`: Array of AzureFirewallNetworkRuleProtocols.
      - `[SourceAddress <String[]>]`: List of source IP addresses for this rule.
  - `[ThreatIntelMode <AzureFirewallThreatIntelMode?>]`: The operation mode for Threat Intelligence.

## RELATED LINKS

