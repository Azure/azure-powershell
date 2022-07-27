---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.dll-Help.xml
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/get-azsentinelalertrule
schema: 2.0.0
---

# Get-AzSentinelAlertRule

## SYNOPSIS
Gets a specific or all Analytic Rules (Alert Rule).

## SYNTAX

### WorkspaceScope (Default)
```
Get-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AlertRuleId
```
Get-AzSentinelAlertRule -ResourceGroupName <String> -WorkspaceName <String> -AlertRuleId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceId
```
Get-AzSentinelAlertRule -ResourceId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSentinelAlertRule** cmdlet gets one or more Analytic Rules (Alert Rules) from the specified workspace.
If you specify the *AlertRuleId* parameter, a single AlertRule object is returned.
If you do not specify the *AlertRuleId* parameter, an array containing all of the Alert Rules in the specified workspace is returned.
You can use the AlertRule object to update the AlertRule. For example you can enable or disable the AlertRule. <br/>

*Note: An AlertRuleId can be any string, as long as it is unique in your workspace and can be found in the Azure Sentinel Analytics view under the rule details pane on your right in the field "Id"*

## EXAMPLES

### Example 1
```powershell
$AlertRules = Get-AzSentinelAlertRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName"
```

This example gets all  the AlertRules in the specified workspace, and then stores it in the $AlertRules variable.

### Example 2
```powershell
$AlertRule = Get-AzSentinelAlertRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -AlertRuleId "myAlertRuleId"
```

This example gets an AlertRule in the specified workspace, and then stores it in the $AlertRule variable.<br/>
*Please note that **AlertRuleId** is in this format: 168d330b-219b-4191-a5b1-742c211adb05*

### Example 3
```powershell
Get-AzSentinelAlertRule -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName | Where-Object {$_.DisplayName -like "*Azure Security Center*"}
```

This example gets an AlertRule with a displayname which contains "Azure Security Center"

## PARAMETERS

### -AlertRuleId
Alert Rule Id.

```yaml
Type: System.String
Parameter Sets: AlertRuleId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: WorkspaceScope, AlertRuleId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource Id.

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WorkspaceName
Workspace Name.

```yaml
Type: System.String
Parameter Sets: WorkspaceScope, AlertRuleId
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

### System.String
## OUTPUTS

### Microsoft.Azure.Commands.SecurityInsights.Models.AlertRules.PSSentinelAlertRule
## NOTES

## RELATED LINKS
