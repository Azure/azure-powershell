### Example 1: Add tags for an existing app server instance resource
```powershell
Update-AzWorkloadsSapApplicationInstance  -Name app0 -ResourceGroupName db0-vis-rg -SapVirtualInstanceName DB0 -Tag @{ Test = "PS"; k2 = "v2"}
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 db0-vis-rg        Healthy Succeeded         Running db0vm    centraluseuap
```

This cmdlet adds new tag name, value pairs to the existing app server instance resource app0. VIS name and Resource group name are the other input parameters. 

### Example 2: Add tags for an existing app server instance resource
```powershell
Update-AzWorkloadsSapApplicationInstance  -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/db0-vis-rg/providers/Microsoft.Workloads/sapVirtualInstances/DB0/applicationInstances/app0 -Tag @{ Test = "PS"; k2 = "v2"}
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 db0-vis-rg        Healthy Succeeded         Running db0vm    centraluseuap
```

This cmdlet adds new tag name, value pairs to the existing app server instance resource app0. Here app instance Azure resource ID is used as the input parameter.

