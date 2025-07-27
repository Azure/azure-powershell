---
external help file:
Module Name: Az.StackHCIVM
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/update-azstackhcivmsecurityrule
schema: 2.0.0
---

# Update-AzStackHCIVMSecurityRule

## SYNOPSIS
Update a security rule in the specified resource group.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStackHCIVMSecurityRule -Name <String> -NetworkSecurityGroupName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Access <String>] [-Description <String>] [-DestinationAddressPrefix <String[]>]
 [-DestinationPortRange <String[]>] [-Direction <String>] [-ExtendedLocationName <String>]
 [-ExtendedLocationType <String>] [-Priority <Int32>] [-Protocol <String>] [-SourceAddressPrefix <String[]>]
 [-SourcePortRange <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStackHCIVMSecurityRule -InputObject <IStackHcivmIdentity> [-Access <String>] [-Description <String>]
 [-DestinationAddressPrefix <String[]>] [-DestinationPortRange <String[]>] [-Direction <String>]
 [-ExtendedLocationName <String>] [-ExtendedLocationType <String>] [-Priority <Int32>] [-Protocol <String>]
 [-SourceAddressPrefix <String[]>] [-SourcePortRange <String[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityNetworkSecurityGroup
```
Update-AzStackHCIVMSecurityRule -Name <String> -NetworkSecurityGroupInputObject <IStackHcivmIdentity>
 -Resource <ISecurityRule> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityNetworkSecurityGroupExpanded
```
Update-AzStackHCIVMSecurityRule -Name <String> -NetworkSecurityGroupInputObject <IStackHcivmIdentity>
 [-Access <String>] [-Description <String>] [-DestinationAddressPrefix <String[]>]
 [-DestinationPortRange <String[]>] [-Direction <String>] [-ExtendedLocationName <String>]
 [-ExtendedLocationType <String>] [-Priority <Int32>] [-Protocol <String>] [-SourceAddressPrefix <String[]>]
 [-SourcePortRange <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a security rule in the specified resource group.

## EXAMPLES

### Example 1:  Update a Network Security Rule 
```powershell
Update-AzStackHCIVMSecurityRule -Name 'testnsgrule' -NetworkSecurityGroupName "testnsg" -ResourceGroupName 'test-rg' 
```

This command updates a specific network security group in the specified resource group.

## PARAMETERS

### -Access
The network traffic is allowed or denied.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
A description for this rule.
Restricted to 140 chars.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationAddressPrefix
The destination address prefixes.
CIDR or destination IP ranges.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationPortRange
The destination port ranges.
Integer or range between 0 and 65535.
Asterisk '*' can also be used to match all ports.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direction
The direction of the rule.
The direction specifies if rule will be evaluated on incoming or outgoing traffic.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The name of the extended location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IStackHcivmIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the security rule.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNetworkSecurityGroup, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases: SecurityRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSecurityGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IStackHcivmIdentity
Parameter Sets: UpdateViaIdentityNetworkSecurityGroup, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkSecurityGroupName
Name of the network security group

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Priority
The priority of the rule.
The value can be between 100 and 4096.
The priority number must be unique for each rule in the collection.
The lower the priority number, the higher the priority of the rule.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
Network protocol this rule applies to.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Security Rule resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.ISecurityRule
Parameter Sets: UpdateViaIdentityNetworkSecurityGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceAddressPrefix
The CIDR or source IP ranges.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourcePortRange
The source port ranges.
Integer or range between 0 and 65535.
Asterisk '*' can also be used to match all ports.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityNetworkSecurityGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.ISecurityRule

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IStackHcivmIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.ISecurityRule

## NOTES

## RELATED LINKS

