---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Monitor.dll-Help.xml
Module Name: Az.Monitor
online version: https://docs.microsoft.com/powershell/module/az.monitor/remove-azdatacollectionrule
schema: 2.0.0
---

# Remove-AzDataCollectionRule

## SYNOPSIS
Delete a data collection rule.

## SYNTAX

### ByName (Default)
```
Remove-AzDataCollectionRule -ResourceGroupName <String> -RuleName <String> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
Remove-AzDataCollectionRule -InputObject <PSDataCollectionRuleResource> [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
Remove-AzDataCollectionRule -RuleId <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzDataCollectionRule** cmdlet delete a data collection rule.

Data Collection Rules (DCR) define data coming into Azure Monitor and specify where that data should be sent or stored. Here is the complete [DCR overview article](https://learn.microsoft.com/azure/azure-monitor/essentials/data-collection-rule-overview).

## EXAMPLES

### Example 1: Delete data collection rule with name and resource group parameters
```powershell
Remove-AzDataCollectionRule -ResourceGroupName "testgroup" -RuleName "testDcr"
```

Delete data collection rule with name and resource group parameters

### Example 2: Delete data collection rule with name and resource group return bool
```powershell
Remove-AzDataCollectionRule -ResourceGroupName "testgroup" -RuleName "testDcr" -PassThru
```

```output
True
```

Delete data collection rule with name and resource group return bool

### Example 3: Delete data collection rule from InputObject
```powershell
Get-AzDataCollectionRule -ResourceGroupName "testdcr" -RuleName "dcrFromPipe95" | Remove-AzDataCollectionRule
```

Delete data collection rule from InputObject

### Example 4: Delete data collection rule from resource id
```powershell
Remove-AzDataCollectionRule -RuleId "/subscriptions/{subId}/resourceGroups/testdcr/providers/Microsoft.Insights/dataCollectionRules/{dcrName}"
```

Delete data collection rule from resource id

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -InputObject
The data collection rule resource from the pipe

```yaml
Type: Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Return true upon successful removal.

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

### -ResourceGroupName
The resource group name

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RuleId
The resource identifier.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RuleName
The resource name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: Name

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
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Insights.OutputClasses.PSDataCollectionRuleResource

## NOTES

## RELATED LINKS

[Set-AzDataCollectionRule](./Set-AzDataCollectionRule.md)
[Get-AzDataCollectionRule](./Get-AzDataCollectionRule.md)
[New-AzDataCollectionRule](./New-AzDataCollectionRule.md)
[Update-AzDataCollectionRule](./Update-AzDataCollectionRule.md)