### Example 1: Add tags for an existing Database instance resource
```powershell
Update-AzWorkloadsSapDatabaseInstance  -Name db0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0 -Tag @{ Test = "PS"; k2 = "v2"}
```

```output
Name ResourceGroupName ProvisioningState Location      Status  IPAddress  DatabaseSid
---- ----------------- ----------------- --------      ------  ---------  -----------
db0  db0-vis-rg        Succeeded         centraluseuap Running 172.31.5.4 MB0
```

This cmdlet adds new tag name, value pairs to the existing Database instance resource db0. VIS name and Resource group name are the other input parameters.

### Example 2: Add tags for an existing Database instance resource
```powershell
Update-AzWorkloadsSapDatabaseInstance  -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0/databaseInstances/db0 -Tag @{ Test = "PS"; k2 = "v2"}
```

```output
Name ResourceGroupName ProvisioningState Location      Status  IPAddress  DatabaseSid
---- ----------------- ----------------- --------      ------  ---------  -----------
db0  db0-vis-rg        Succeeded         centraluseuap Running 172.31.5.4 MB0
```

This cmdlet adds new tag name, value pairs to the existing Database instance resource db0. Here Database instance Azure resource ID is used as the input parameter.

