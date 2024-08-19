### Example 1: Get an overview of The App Server Instance(s) 
```powershell
Get-AzWorkloadsSapApplicationInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 DemoRGVIS         Healthy Succeeded         Running drtvm    eastus2euap
```

This command will help you get an overview, including health and status of all the App Server instances in the Virtual instance for SAP solutions 

### Example 2: Get an overview of The App Server Instance
```powershell
Get-AzWorkloadsSapApplicationInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT -Name app0
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 DemoRGVIS         Healthy Succeeded         Running drtvm    eastus2euap
```

This command will help you get an overview, including health and status of a specific App Server instance in the Virtual instance for SAP solutions

### Example 3: Get an overview of The App Server Instance

```powershell
Get-AzWorkloadsSapApplicationInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/DemoRGVIS/providers/Microsoft.Workloads/sapVirtualInstances/DRT/applicationInstances/app0
```

```output
Name ResourceGroupName Health  ProvisioningState Status  Hostname Location
---- ----------------- ------  ----------------- ------  -------- --------
app0 DemoRGVIS         Healthy Succeeded         Running drtvm    eastus2euap
```

This command will help you get an overview, including health and status of a specific App Server instance in the Virtual instance for SAP solutions by using the Azure resource ID of the App server instance

