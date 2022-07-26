### Example 1: Test Linker
```powershell
Test-AzServiceLinkerForContainerApp -ContainerApp servicelinker-app -ResourceGroupName servicelinker-test-group -Name postgresql_connection | fl
```

```output
AuthType              : 
IsConnectionAvailable : True
LinkerName            : postgresql_connection
ReportEndTimeUtc      : 5/6/2022 8:32:26 AM
ReportStartTimeUtc    : 5/6/2022 8:32:24 AM
ResourceId            : /subscriptions/d82d7763-8e12-4f39-a7b6-496a983ec2f4/resourceGroups/servicelinke 
                        r-test-group/providers/Microsoft.App/containerApps/servicelinker-app/providers/Mi 
                        crosoft.ServiceLinker/linkers/postgresql_connection
SourceId              :
Status                : Succeeded
TargetId              : /subscriptions/937bc588-a144-4083-8612-5f9ffbbddb14/resourceGroups/servicelinke 
                        r-test-group/providers/Microsoft.Storage/storageAccounts/servicelinkersto 
                        rage/tableServices/default
ValidationDetail      : {The target existence is validated, The target service firewall is validated,   
                        The configured values is validated}
```

Test Linker
