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

### Example 2: Create a ModifyProperties automation rule action object for automation rule
```powershell
New-AzSentinelAutomationRuleActionObject -ActionType ModifyProperties -Order 1 -Severity High
```

```output
ActionConfigurationClassification        : 
ActionConfigurationClassificationComment : 
ActionConfigurationClassificationReason  : 
ActionConfigurationLabel                 : 
ActionConfigurationSeverity              : High
ActionConfigurationStatus                : 
ActionType                               : ModifyProperties
Order                                    : 1
OwnerAssignedTo                          : 
OwnerEmail                               : 
OwnerObjectId                            : 
OwnerType                                : 
OwnerUserPrincipalName                   : 
```

This command creates a ModifyProperties automation rule action object for automation rule.

