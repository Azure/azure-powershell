### Example 1:  Get an overview of the Database Instance(s)
```powershell
Get-AzWorkloadsSapDatabaseInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT
```

```output
Name ResourceGroupName ProvisioningState Location    Status  IPAddress DatabaseSid
---- ----------------- ----------------- --------    ------  --------- -----------
db0  DemoRGVIS         Succeeded         eastus2euap Running 10.0.0.6  XRT
```

This command will help you get an overview, including health and status of a Database instance in the Virtual instance for SAP solutions

### Example 2: Get an overview of the Database Instance(s)
```powershell
Get-AzWorkloadsSapDatabaseInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/DemoRGVIS/providers/Microsoft.Workloads/sapVirtualInstances/DRT/databaseInstances/db0
```

```output
Name ResourceGroupName ProvisioningState Location    Status  IPAddress DatabaseSid
---- ----------------- ----------------- --------    ------  --------- -----------
db0  DemoRGVIS         Succeeded         eastus2euap Running 10.0.0.6  XRT
```

This command will help you get an overview, including health and status of a Database instance in the Virtual instance for SAP solutions by using the Azure resource ID of the Database instance