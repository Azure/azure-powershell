### Example 1: Add tags for an existing Central services instance resource
```powershell
Update-AzWorkloadsSapCentralInstance  -Name cs0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0 -Tag @{ Test = "PS"; k2 = "v2"}
```

```output
Name ResourceGroupName Health  EnqueueServerPropertyHostname ProvisioningState Status  Location
---- ----------------- ------  ----------------------------- ----------------- ------  --------
cs0  db0-vis-rg        Healthy db0vm                         Succeeded         Running centraluseuap
```

This cmdlet adds new tag name, value pairs to the existing Central services instance resource cs0. VIS name and Resource group name are the other input parameters.

### Example 2: Add tags for an existing Central services instance resource
```powershell
Update-AzWorkloadsSapCentralInstance  -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0/centralInstances/cs0 -Tag @{ Test = "PS"; k2 = "v2"}
```

```output
Name ResourceGroupName Health  EnqueueServerPropertyHostname ProvisioningState Status  Location
---- ----------------- ------  ----------------------------- ----------------- ------  --------
cs0  db0-vis-rg        Healthy db0vm                         Succeeded         Running centraluseuap
```

This cmdlet adds new tag name, value pairs to the existing Central services instance resource cs0. Here Central services instance Azure resource ID is used as the input parameter.

