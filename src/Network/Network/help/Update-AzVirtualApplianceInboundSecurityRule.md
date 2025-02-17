---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/update-azvirtualapplianceinboundsecurityrule
schema: 2.0.0
---

# Update-AzVirtualApplianceInboundSecurityRule

## SYNOPSIS
Update the Inbound Security Rule of a Network Virtual Appliance Resource

## SYNTAX

### ResourceNameParameterSet (Default)
```
Update-AzVirtualApplianceInboundSecurityRule -ResourceGroupName <String> -VirtualApplianceName <String>
 -Name <String> [-RuleType <String>]
 -Rule <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSInboundSecurityRulesProperty]>
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceObjectParameterSet
```
Update-AzVirtualApplianceInboundSecurityRule -VirtualAppliance <PSNetworkVirtualAppliance> -Name <String>
 [-RuleType <String>]
 -Rule <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSInboundSecurityRulesProperty]>
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Update-AzVirtualApplianceInboundSecurityRule -VirtualApplianceResourceId <String> -Name <String>
 [-RuleType <String>]
 -Rule <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSInboundSecurityRulesProperty]>
 [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Update-AzVirtualApplianceInboundSecurityRule command updates/creates the Inbound Security Rule of a Network Virtual Appliance. The Inbound Security Rule creates an NSG rule on the NVA and a LB rule on the SLB attached to NVA if the rule type is defined as: Permanent

## EXAMPLES

### Example 1
```powershell
Update-AzVirtualApplianceInboundSecurityRule -ResourceGroupName InboundRuleRg -VirtualApplianceName nva1 -Name ruleCollection1 -RuleType Permanent -Rule $inbound
```

The above command creates or updates the Inbound Security rule with the given Rule collection name: ruleCollection1 on the NVA: nva1 with rule type permanent having rules as defined in the rules property. The Inbound Security Rule will created an NSG rule & a SLB LB rule.

### Example 2
```powershell
Update-AzVirtualApplianceInboundSecurityRule -ResourceGroupName InboundRuleRg -VirtualApplianceName nva1 -Name ruleCollection2 -RuleType AutoExpire -Rule $inbound
```

The above command creates or updates the Inbound Security rule with the given Rule collection name: ruleCollection2 on the NVA: nva1 with rule type Auto Expire having rules as defined in the rules property. The Inbound Security Rule will created only an NSG rule.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, InboundSecurityRuleCollectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
Individual rule of the Inbound Security

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSInboundSecurityRulesProperty]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleType
The Inbound Security Rule Type: AutoExpire or Permanent

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualAppliance
The parent Network Virtual Appliance object for this connection.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualAppliance
Parameter Sets: ResourceObjectParameterSet
Aliases: ParentNva, NetworkVirtualAppliance

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualApplianceName
The parent Network Virtual Appliance name.

```yaml
Type: System.String
Parameter Sets: ResourceNameParameterSet
Aliases: ParentNvaName, NetworkVirtualApplianceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualApplianceResourceId
The resource id of the parent Network Virtual Appliance for this connection.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases: ParentNvaId, NetworkVirtualApplianceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualAppliance

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSInboundSecurityRule

## NOTES

## RELATED LINKS
