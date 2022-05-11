### Example 1: Test Linker
```powershell
Test-AzServiceLinkerForSpringCloud -ServiceName servicelinker-springcloud -AppName appconfiguration -DeploymentName "default" -ResourceGroupName servicelinker-test-group -Name postgresql_connection  | fl
```

```output
AuthType              : 
IsConnectionAvailable : True
LinkerName            : storagetable_404e8
ReportEndTimeUtc      : 5/6/2022 8:32:26 AM
ReportStartTimeUtc    : 5/6/2022 8:32:24 AM
ResourceId            : /subscriptions/d82d7763-8e12-4f39-a7b6-496a983ec2f4/resourceGroups/servicelinke 
                        r-test-group/providers/Microsoft.AppPlatform/Spring/servicelinker-springcloud/apps/appconfiguration/deployments/default/providers/Mi 
                        crosoft.ServiceLinker/linkers/storagetable_404e8
SourceId              :
Status                : Succeeded
TargetId              : /subscriptions/937bc588-a144-4083-8612-5f9ffbbddb14/resourceGroups/servicelinke 
                        r-test-linux-group/providers/Microsoft.Storage/storageAccounts/servicelinkersto 
                        rage/tableServices/default
ValidationDetail      : {The target existence is validated, The target service firewall is validated,   
                        The configured values is validated}
```

Test Linker
