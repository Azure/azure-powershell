---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.dll-Help.xml
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/get-azsentinelalertruleaction
schema: 2.0.0
---

# Get-AzSentinelAlertRuleAction

## SYNOPSIS
Gets an Automated Response (Alert Rule Action) for an Analytics Rule, like an Azure Logic Apps Playbook.<br/>
Azure Sentinel Automation Rules will be supported in the future.

*Note: This requires a parameter value of "AlertRuleId"*

## SYNTAX

### AlertRuleId (Default)
```
Get-AzSentinelAlertRuleAction -ResourceGroupName <String> -WorkspaceName <String> -AlertRuleId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ActionId
```
Get-AzSentinelAlertRuleAction -ResourceGroupName <String> -WorkspaceName <String> -AlertRuleId <String>
 -ActionId <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSentinelAlertRuleAction** cmdlet gets an Automated Response (Alert Rule Action) from the specified workspace.
If you specify the *ActionId* and *AlertRuleId* parameters, a single **AlertRuleAction** object is returned.<br/>
If you do not specify the *ActionId* parameter, an array containing all of the Actions for the specificed Alert Rule in the specified workspace are returned.
You can use the **Action** object to update the Action, for example you can change the the **Action** for an Alert Rule.

## EXAMPLES

### Example 1
```powershell
$AlertRuleActions = Get-AzSentinelAlertRuleAction -ResourceGroupName "MyResourceGroup" -WorkspaceName "MyWorkspaceName" -AlertRuleId "29d2523f-84ce-42d3-b5f1-9e63c85aaed1"
```

This example gets all of the **Actions** for the specified Alert Rule in the specified workspace, and then stores it in the $AlertRuleActions variable.<br/><br/>

*Note: the field **LogicAppResourceID** contains the full Azure Resource Manager (ARM) ID, which contains the name of the Azure Logic Apps Playbook.*

### Example 2
```powershell
$AlertRuleAction = Get-AzSentinelAlertRuleAction -ResourceGroupName "MyResourceGroup" -WorkspaceName "MyWorkspaceName" -AlertRuleId "MyAlertRuleId" -ActionId "MyActionId"
```

This example gets an **AlertRuleAction** for the specified Alert Rule in the specified workspace, and then stores it in the $AlertRuleAction variable.

## PARAMETERS

### -ActionId
Action Id.

```yaml
Type: System.String
Parameter Sets: ActionId
Aliases:

Required: True
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### Microsoft.Azure.Commands.SecurityInsights.Models.Actions.PSSentinelActionResponse
## NOTES

## RELATED LINKS
