### Example 1: Get an overview of The Central service Instance(s)
```powershell
 Get-AzWorkloadsSapCentralInstance -ResourceGroupName DemoRGVIS -SapVirtualInstanceName DRT
```

```output
Name ResourceGroupName Health  EnqueueServerPropertyHostname ProvisioningState Status  Location
---- ----------------- ------  ----------------------------- ----------------- ------  --------
cs0  DemoRGVIS         Healthy drtvm                         Succeeded         Running eastus2euap
```

This command will help you get an overview, including health and status of the Central service instance in a Virtual instance for SAP solutions


### Example 2:  Get an overview of The Central service Instance(s)
```powershell
Get-AzWorkloadsSapCentralInstance -InputObject /subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/DemoRGVIS/providers/Microsoft.Workloads/sapVirtualInstances/DRT/centralInstances/cs0
```

```output
Name ResourceGroupName Health  EnqueueServerPropertyHostname ProvisioningState Status  Location
---- ----------------- ------  ----------------------------- ----------------- ------  --------
cs0  DemoRGVIS         Healthy drtvm                         Succeeded         Running eastus2euap
```

This command will help you get an overview, including health and status of a Central service instance in the Virtual instance for SAP solutions by using the Azure resource ID of the Central service instance