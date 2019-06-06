---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-aznetworksecurityrule
schema: 2.0.0
---

# Set-AzNetworkSecurityRule

## SYNOPSIS
Creates or updates a security rule in the specified network security group.

## SYNTAX

### Update1 (Default)
```
Set-AzNetworkSecurityRule -NetworkSecurityGroupName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Name <String>] [-SecurityRuleParameter <ISecurityRule>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Set-AzNetworkSecurityRule -InputObject <INetworkIdentity> -Access <SecurityRuleAccess>
 -Direction <SecurityRuleDirection> -Protocol <SecurityRuleProtocol> [-Name <String>] [-Description <String>]
 [-DestinationAddressPrefix <String>] [-DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]
 [-DestinationPortRange <String>] [-Etag <String>] [-Id <String>] [-Priority <Int32>]
 [-PropertiesDestinationAddressPrefixes <String[]>] [-PropertiesDestinationPortRanges <String[]>]
 [-PropertiesSourceAddressPrefixes <String[]>] [-PropertiesSourcePortRanges <String[]>]
 [-ProvisioningState <String>] [-SourceAddressPrefix <String>]
 [-SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>] [-SourcePortRange <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzNetworkSecurityRule -NetworkSecurityGroupName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -SecurityRuleName <String> -Access <SecurityRuleAccess>
 -Direction <SecurityRuleDirection> -Protocol <SecurityRuleProtocol> [-Name <String>] [-Description <String>]
 [-DestinationAddressPrefix <String>] [-DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]
 [-DestinationPortRange <String>] [-Etag <String>] [-Id <String>] [-Priority <Int32>]
 [-PropertiesDestinationAddressPrefixes <String[]>] [-PropertiesDestinationPortRanges <String[]>]
 [-PropertiesSourceAddressPrefixes <String[]>] [-PropertiesSourcePortRanges <String[]>]
 [-ProvisioningState <String>] [-SourceAddressPrefix <String>]
 [-SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>] [-SourcePortRange <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity1
```
Set-AzNetworkSecurityRule -InputObject <INetworkIdentity> [-SecurityRuleParameter <ISecurityRule>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a security rule in the specified network security group.

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

### -Access
The network traffic is allowed or denied.
Possible values are: 'Allow' and 'Deny'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleAccess
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: True
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

### -Description
A description for this rule.
Restricted to 140 chars.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationAddressPrefix
The destination address prefix.
CIDR or destination IP range.
Asterisk '*' can also be used to match all source IPs.
Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationApplicationSecurityGroup
The application security group specified as destination.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup[]
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DestinationPortRange
The destination port or range.
Integer or range between 0 and 65535.
Asterisk '*' can also be used to match all ports.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Direction
The direction of the rule.
The direction specifies if rule will be evaluated on incoming or outgoing traffic.
Possible values are: 'Inbound' and 'Outbound'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleDirection
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
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
Parameter Sets: UpdateViaIdentityExpanded1, UpdateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkSecurityGroupName
The name of the network security group.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Priority
The priority of the rule.
The value can be between 100 and 4096.
The priority number must be unique for each rule in the collection.
The lower the priority number, the higher the priority of the rule.

```yaml
Type: System.Int32
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesDestinationAddressPrefixes
The destination address prefixes.
CIDR or destination IP ranges.

```yaml
Type: System.String[]
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesDestinationPortRanges
The destination port ranges.

```yaml
Type: System.String[]
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesSourceAddressPrefixes
The CIDR or source IP ranges.

```yaml
Type: System.String[]
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesSourcePortRanges
The source port ranges.

```yaml
Type: System.String[]
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Protocol
Network protocol this rule applies to.
Possible values are 'Tcp', 'Udp', and '*'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.SecurityRuleProtocol
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
The provisioning state of the public IP resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SecurityRuleName
The name of the security rule.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SecurityRuleParameter
Network security rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule
Parameter Sets: Update1, UpdateViaIdentity1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -SourceAddressPrefix
The CIDR or source IP range.
Asterisk '*' can also be used to match all source IPs.
Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
If this is an ingress rule, specifies where network traffic originates from.


```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SourceApplicationSecurityGroup
The application security group specified as source.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup[]
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SourcePortRange
The source port or range.
Integer or range between 0 and 65535.
Asterisk '*' can also be used to match all ports.

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded1, UpdateExpanded1
Aliases:

Required: False
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
Parameter Sets: Update1, UpdateExpanded1
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule

## ALIASES

## RELATED LINKS

