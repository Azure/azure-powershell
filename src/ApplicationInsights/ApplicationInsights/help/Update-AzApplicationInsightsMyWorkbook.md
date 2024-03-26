---
external help file: Az.ApplicationInsights-help.xml
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.applicationinsights/update-azapplicationinsightsmyworkbook
schema: 2.0.0
---

# Update-AzApplicationInsightsMyWorkbook

## SYNOPSIS
Updates a private workbook that has already been added.

## SYNTAX

```
Update-AzApplicationInsightsMyWorkbook -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-LinkedSourceId <String>] -WorkbookProperty <IMyWorkbook> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a private workbook that has already been added.

## EXAMPLES

### Example 1: Updates a private workbook that has already been added
```powershell
$myWorkbook = Get-AzApplicationInsightsMyWorkbook -ResourceGroupName "appinsights-hkrs2v-test" -Name "2e47417f-c136-44c0-b78f-7a4ca35fd9d1"
$myWorkbook.DisplayName = "pwsh01"
Update-AzApplicationInsightsMyWorkbook -ResourceGroupName "appinsights-hkrs2v-test" -Name "2e47417f-c136-44c0-b78f-7a4ca35fd9d1" -WorkbookProperty $myWorkbook
```

```output
ResourceGroupName       Name                                 DisplayName Location Kind Category
-----------------       ----                                 ----------- -------- ---- --------
appinsights-hkrs2v-test 2e47417f-c136-44c0-b78f-7a4ca35fd9d1 pwsh01      westus2  user workbook
```

Updates a private workbook that has already been added.

## PARAMETERS

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

### -LinkedSourceId
Azure Resource Id that will fetch all linked workbooks.

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

### -Name
The name of the Application Insights component resource.

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

### -WorkbookProperty
An Application Insights private workbook definition.
To construct, see NOTES section for WORKBOOKPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20210308.IMyWorkbook

## NOTES

## RELATED LINKS
