---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/Az.SecurityInsights/new-azsentinelautomationrulerunplaybookactionobject
schema: 2.0.0
---

# New-AzSentinelAutomationRuleRunPlaybookActionObject

## SYNOPSIS
Create an in-memory object for AutomationRuleRunPlaybookAction.

## SYNTAX

```
New-AzSentinelAutomationRuleRunPlaybookActionObject -Order <Int32>
 [-ActionConfigurationLogicAppResourceId <String>] [-ActionConfigurationTenantId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AutomationRuleRunPlaybookAction.

## EXAMPLES

### Example 1: Create a RunPlaybook automation rule action object for automation rule
```powershell
New-AzSentinelAutomationRuleActionObject -ActionType RunPlaybook -Order 1 -LogicAppResourceId $LogicAppResource.Id -TenantId (Get-AzContext).Tenant.Id
```

```output
ActionConfigurationLogicAppResourceId                                                                                           ActionConfigurationTenantId          ActionType  Order
-------------------------------------                                                                                           ---------------------------          ----------  -----
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/AlertLogicApp 72f988bf-86f1-41af-91ab-2d7cd011db47 RunPlaybook     1
```

This command creates a automation rule action object for automation rule.

## PARAMETERS

### -ActionConfigurationLogicAppResourceId
The resource id of the playbook resource.

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

### -ActionConfigurationTenantId
The tenant id of the playbook resource.

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

### -Order


```yaml
Type: System.Int32
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.AutomationRuleRunPlaybookAction

## NOTES

## RELATED LINKS

