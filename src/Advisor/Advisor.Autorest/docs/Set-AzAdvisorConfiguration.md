---
external help file:
Module Name: Az.Advisor
online version: https://learn.microsoft.com/powershell/module/az.advisor/Set-AzAdvisorConfiguration
schema: 2.0.0
---

# Set-AzAdvisorConfiguration

## SYNOPSIS
Updates or creates the Azure Advisor Configuration.

## SYNTAX

### CreateByLCT (Default)
```
Set-AzAdvisorConfiguration [-SubscriptionId <String>] [-Exclude] [-LowCpuThreshold <CpuThreshold>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateByInputObject
```
Set-AzAdvisorConfiguration -InputObject <IAdvisorIdentity> [-Exclude] [-LowCpuThreshold <CpuThreshold>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateByRG
```
Set-AzAdvisorConfiguration -ResourceGroupName <String> [-SubscriptionId <String>] [-Exclude]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates or creates the Azure Advisor Configuration.

## EXAMPLES

### Example 1: Set advisor configuration by subscription id
```powershell
Set-AzAdvisorConfiguration -Exclude -LowCpuThreshold 20
```

```output
Name    Exclude LowCpuThreshold
----    ------- ---------------
default True    20
```

Set advisor configuration by subscription id

### Example 2:  Set advisor configuration by resource group name
```powershell
Set-AzAdvisorConfiguration -Exclude
```

```output
Name    Exclude LowCpuThreshold
----    ------- ---------------
default True
```

Set advisor configuration by resource group name

## PARAMETERS

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

### -Exclude
Exclude the resource from Advisor evaluations.
Valid values: False (default) or True.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity
Parameter Sets: CreateByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LowCpuThreshold
Minimum percentage threshold for Advisor low CPU utilization evaluation.
Valid only for subscriptions.
Valid values: 5 (default), 10, 15 or 20.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Advisor.Support.CpuThreshold
Parameter Sets: CreateByInputObject, CreateByLCT
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Azure resource group.

```yaml
Type: System.String
Parameter Sets: CreateByRG
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: CreateByLCT, CreateByRG
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

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.IAdvisorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Advisor.Models.Api202001.IConfigData

## NOTES

## RELATED LINKS

