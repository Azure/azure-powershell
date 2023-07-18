### Example 1: Get a build service resource of the enterprise spring cloud
```powershell
Get-AzSpringBuildService -ResourceGroupName Springrg -ServiceName sspring-portal01
```

```output
Name    ResourceGroupName ProvisioningState KPackVersion ResourceRequestCpu ResourceRequestMemory
----    ----------------- ----------------- ------------ ------------------ ---------------------
default Springrg     Succeeded         0.5.2        2                  4Gi
```

Get a build service resource of the enterprise spring cloud.

### Example 2: Get a build service resource of the enterprise spring cloud by id
```powershell
Get-AzSpringBuildService -InputObject "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/Springrg/providers/Microsoft.AppPlatform/Spring/sspring-portal01/buildServices/default"
```

```output
Name    ResourceGroupName ProvisioningState KPackVersion ResourceRequestCpu ResourceRequestMemory
----    ----------------- ----------------- ------------ ------------------ ---------------------
default Springrg     Succeeded         0.5.2        2                  4Gi
```

Get a build service resource of the enterprise spring cloud.