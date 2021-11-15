---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.dll-Help.xml
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/new-azsentinelalertruleaction
schema: 2.0.0
---

# New-AzSentinelAlertRuleAction

## SYNOPSIS
Add an Automated Response to an Analytic Rule.

## SYNTAX

```
New-AzSentinelAlertRuleAction -ResourceGroupName <String> -WorkspaceName <String> -AlertRuleId <String>
 [-ActionId <String>] -LogicAppResourceId <String> -TriggerUri <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzSentinelAlertRuleAction** cmdlet creates an Automated Response for an Alert Rule in the specified workspace.
You must provide the Logic App ResourceId and Trigger Uri which can be found using the [Azure Logic Apps PowerShell module](https://docs.microsoft.com/en-us/powershell/module/az.logicapp/get-azlogicapp?view=azps-5.6.0).
You can use the *Confirm* parameter and $ConfirmPreference Windows PowerShell variable to control whether the cmdlet prompts you for confirmation.

## EXAMPLES

### Example 1
```powershell
$LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "MyResourceGroup" -Name "Reset-AADPassword"
$LogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName "MyResourceGroup" -Name "Reset-AADPassword" -TriggerName "When_a_response_to_an_Azure_Sentinel_alert_is_triggered"
$AlertRuleAction = New-AzSentinelAlertRuleAction -ResourceGroupName "MyResourceGroup" -WorkspaceName "MyWorkspaceName" -AlertRuleId "MyAlertRuleId" -LogicAppResourceId ($LogicAppResourceId.Id) -TriggerUri ($LogicAppTriggerUri.Value)
```

This example creates an AlertRuleAction for the specified Alert Rule using properties of the Logic App, and then stores it in the $AlertRuleAction variable.<br/>
Then we use the New-AzSentinelAlertRuleAction cmdlet to add the Logic App as an action to a specifc AlertRule.

### Example 2
```powershell
$SentinelConnection = @{
    ResourceGroupName = "myResourceGroupName"
    WorkspaceName = "mySentinelWorkspaceName"
}

$LogicAppConnection = @{
    ResourceGroupName = "myLogicAppResourceGroupName"
    Name = "Reset-AADPassword"
}

$LogicAppResourceId = Get-AzLogicApp @LogicAppConnection
$LogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl @LogicAppConnection -TriggerName "When_a_response_to_an_Azure_Sentinel_alert_is_triggered"
$AnalyticsRule = Get-AzSentinelAlertRule @SentinelConnection | Where-Object {$PSItem.DisplayName -eq "Mimikatz Detected"}
$AlertRuleAction = New-AzSentinelAlertRuleAction @SentinelConnection -AlertRuleId $AnalyticsRule.Name -LogicAppResourceId ($LogicAppResourceId.Id) -TriggerUri ($LogicAppTriggerUri.Value)
```

This example uses 2 connection objects to connect with Azure Sentinel and to get a specific Logic App. <br/>
Then a specific Analytics Rule, based on the display name, is retrieved and being used in the final **New-AzSentinelAlertRuleAction** cmdlet to add the Logic App to the Analytics Rule.

## PARAMETERS

### -ActionId
Action Id.

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

### -AlertRuleId
Alert Rule Id.

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

### -LogicAppResourceId
Action Logic App Resource Id.

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

### -TriggerUri
Action Logic App Trigger Uri.

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

### -WorkspaceName
Workspace Name.

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

### None
## OUTPUTS

### Microsoft.Azure.Commands.SecurityInsights.Models.Actions.PSSentinelActionResponse
## NOTES

## RELATED LINKS
