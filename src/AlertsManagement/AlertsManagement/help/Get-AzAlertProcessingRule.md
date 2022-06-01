---
external help file: Microsoft.Azure.PowerShell.Cmdlets.AlertsManagement.dll-Help.xml
Module Name: Az.AlertsManagement
online version: https://docs.microsoft.com/powershell/module/az.alertsmanagement/get-azactionrule
schema: 2.0.0
---

# Get-AzAlertProcessingRule

## SYNOPSIS
Get AlertProcessing Rules Information

## SYNTAX

### ListAlertProcessingRules (Default)
```
Get-AzAlertProcessingRule [-Name <String>] [-ResourceGroupName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceId
```
Get-AzActionRule -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ListAlertProcessingRulesByResourceGroupName
```
Get-AzAlertProcessingRule -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AlertProcessingRuleByName
```
Get-AzAlertProcessingRule -Name <String> -ResourceGroupName <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
**Get-AzAlertProcessingRule** cmdlet gets alert processing rules configured.

## EXAMPLES

### Example 1
```powershell
Get-AzAlertProcessingRule
```

List all alert processing rules configured in subscription.

### Example 2
```powershell
Get-AzAlertProcessingRule -ResourceGroupName "test-rg"
```

List all alert processing rules configured in resource group test-rg.

### Example 3
```powershell
Get-AzAlertProcessingRule -ResourceGroupName "test-rg" -Name "Test-AlertProcessing-Rule" | Format-List
```

Get the alert processing rule with name Test-AlertProcessing-Rule in test-rg resource group.

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


### -Name
Name of alert processing rule.

```yaml
Type: System.String
Parameter Sets: ListAlertProcessingRules
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: AlertProcessingRuleByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name in which alert processing rule resides.

```yaml
Type: System.String
Parameter Sets: ListAlertProcessingRules, ListAlertProcessingRulesByResourceGroupName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: AlertProcessingRuleByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```


### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.AlertsManagement.OutputModels.PSAlertProcessingRule

## NOTES

## RELATED LINKS
