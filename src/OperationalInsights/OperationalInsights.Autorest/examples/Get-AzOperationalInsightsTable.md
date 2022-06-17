### Example 1: List tables for a given workspace name
```powershell
Get-AzOperationalInsightsTable -ResourceGroupName {RG-Name} -WorkspaceName {WS-Name}


Name                                         Id                                                                                                                                                                                                      RetentionInDays
----                                         --                                                                                                                                                                                                      ---------------
DatabricksTables                             /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/DatabricksTables                                          30
BlockchainProxyLog                           /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/BlockchainProxyLog                                        30
BlockchainApplicationLog                     /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/BlockchainApplicationLog                                  30
AADDomainServicesAccountLogon                /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/AADDomainServicesAccountLogon                             30
AADDomainServicesAccountManagement           /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/AADDomainServicesAccountManagement                        30

```

Get all tables for a given workspace name

### Example 2: Get a table by name
```powershell
Get-AzOperationalInsightsTable -ResourceGroupName {RG-Name} -WorkspaceName {WS-Name} -TableName {Table-Name}

Name  Id                                                                                                                                                               RetentionInDays
----  --                                                                                                                                                               ---------------
{Table-Name} /subscriptions/{SUB-id}/resourcegroups/{RG-Name}/providers/Microsoft.OperationalInsights/workspaces/{WS-Name}/tables/{Table-Name}              90
```

Get a specific table by name for a given workspace