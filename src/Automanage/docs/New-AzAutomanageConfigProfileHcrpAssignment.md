---
external help file:
Module Name: Az.Automanage
online version: https://learn.microsoft.com/powershell/module/az.automanage/new-azautomanageconfigprofilehcrpassignment
schema: 2.0.0
---

# New-AzAutomanageConfigProfileHcrpAssignment

## SYNOPSIS
Creates an association between a ARC machine and Automanage configuration profile

## SYNTAX

```
New-AzAutomanageConfigProfileHcrpAssignment -MachineName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ConfigurationProfile <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates an association between a ARC machine and Automanage configuration profile

## EXAMPLES

### Example 1: Creates an association between a ARC machine and Automanage configuration profile
```powershell
New-AzAutomanageConfigProfileHcrpAssignment -ResourceGroupName automangerg -MachineName aglinuxmachines -ConfigurationProfile "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction"
```

```output
Name    ResourceGroupName ManagedBy Status  TargetId
----    ----------------- --------- ------  --------
default automangerg                 Unknown /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/automangerg/providers/Microsoft.HybridCompute/machines/aglinuxmachines
```

This command creates an association between a ARC machine and Automanage configuration profile.

## PARAMETERS

### -ConfigurationProfile
The Automanage configurationProfile ARM Resource URI.

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
```

### -MachineName
The name of the Arc machine.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Automanage.Models.Api20220504.IConfigurationProfileAssignment

## NOTES

ALIASES

## RELATED LINKS

