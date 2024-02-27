---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/Add-AzSecurityAdaptiveNetworkHardening
schema: 2.0.0
---

# Add-AzSecurityAdaptiveNetworkHardening

## SYNOPSIS
Enforces the given rules on the NSG(s) listed in the request

## SYNTAX

```
Add-AzSecurityAdaptiveNetworkHardening -AdaptiveNetworkHardeningResourceName <String>
 -ResourceGroupName <String> -ResourceName <String> -ResourceNamespace <String> -ResourceType <String>
 -SubscriptionId <String> -Rule <PSSecurityAdaptiveNetworkHardeningsRule[]>
 -NetworkSecurityGroup <System.Collections.Generic.List`1[System.String]> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Adaptive Network Hardenings are automatically calculated by Azure Security Center, use this cmdlet to enforces the given rules on the NSG(s) listed in the request.

## EXAMPLES

### Example 1
```powershell
$anh = Get-AzSecurityAdaptiveNetworkHardening -AdaptiveNetworkHardeningResourceName default -ResourceGroupName myService1 -ResourceName myResource1 -ResourceNamespace Microsoft.Compute -ResourceType virtualMachines | Select-Object -First 1
Add-AzSecurityAdaptiveNetworkHardening -AdaptiveNetworkHardeningResourceName default -ResourceGroupName myService1 -ResourceName myResource1 -ResourceNamespace Microsoft.Compute -ResourceType virtualMachines -SubscriptionId 3eeab341-f466-499c-a8be-85427e154baf7612f869 -Rule $anh.Properties.Rules -NetworkSecurityGroup $anh.Properties.EffectiveNetworkSecurityGroups[0].NetworkSecurityGroups
```

```output
True
```

Enforces the given rules on the NSG(s) listed in the request

## PARAMETERS

### -AdaptiveNetworkHardeningResourceName
The name of the Adaptive Network Hardening resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -NetworkSecurityGroup
The Azure resource IDs of the effective network security groups

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return a value indicating success or failure

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
Resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceNamespace
The Namespace of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The type of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
Rule to enforce

```yaml
Type: Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveNetworkHardening.PSSecurityAdaptiveNetworkHardeningsRule[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

### Microsoft.Azure.Commands.SecurityCenter.Models.AdaptiveNetworkHardenings.PSSecurityAdaptiveNetworkHardeningsRule

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
