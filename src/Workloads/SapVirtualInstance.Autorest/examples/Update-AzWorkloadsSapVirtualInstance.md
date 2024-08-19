### Example 1: Add tags for an existing VIS resource
```powershell
Update-AzWorkloadsSapVirtualInstance  -Name DB0 -ResourceGroupName db0-vis-rg -Tag @{ Test = "PS"; k2 = "v2"}
```

```output
Name ResourceGroupName Health  Environment ProvisioningState SapProduct State                Status  Location
---- ----------------- ------  ----------- ----------------- ---------- -----                ------  --------
DB0  db0-vis-rg        Healthy NonProd     Succeeded         S4HANA     RegistrationComplete Running centraluseuap
```

This cmdlet adds new tag name, value pairs to the existing VIS resource DB0. VIS name and Resource group name are the other input parameters. 

### Example 2: Add tags for an existing VIS resource
```powershell
Update-AzWorkloadsSapVirtualInstance  -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0 -Tag @{ Test = "PS"; k2 = "v2"}
```

```output
Name ResourceGroupName Health  Environment ProvisioningState SapProduct State                Status  Location
---- ----------------- ------  ----------- ----------------- ---------- -----                ------  --------
DB0  db0-vis-rg        Healthy NonProd     Succeeded         S4HANA     RegistrationComplete Running centraluseuap
```

This cmdlet adds new tag name, value pairs to the existing VIS resource DB0. Here VIS Azure resource ID is used as the input parameter.

